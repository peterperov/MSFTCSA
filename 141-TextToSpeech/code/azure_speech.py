import json
import string
import time
import threading
import wave
import utils

import azure.cognitiveservices.speech as speechsdk
from dotenv import dotenv_values

config = dotenv_values(".env")
speech_key = config.get("AZURE_SPEECH_API_KEY", None)
service_region = config.get("AZURE_SPEECH_REGION", None)


def imported():
    print("IMPORTED FUNCTION")


def speech_synthesis_to_mp3_file(text = "Hello everyone, hope you have a nice day", file_name = "outputaudio.mp3"):
    """performs speech synthesis to a mp3 file"""
    # Creates an instance of a speech config with specified subscription key and service region.
    speech_config = speechsdk.SpeechConfig(subscription=speech_key, region=service_region)
    # Sets the synthesis output format.
    # The full list of supported format can be found here:
    # https://docs.microsoft.com/azure/cognitive-services/speech-service/rest-text-to-speech#audio-outputs
    speech_config.set_speech_synthesis_output_format(speechsdk.SpeechSynthesisOutputFormat.Audio16Khz32KBitRateMonoMp3)
    # Creates a speech synthesizer using file as audio output.
    # Replace with your own audio file name.
    
    file_config = speechsdk.audio.AudioOutputConfig(filename=file_name)
    speech_synthesizer = speechsdk.SpeechSynthesizer(speech_config=speech_config, audio_config=file_config)

    # Receives a text from console input and synthesizes it to mp3 file.
    #while True:
    #    print("Enter some text that you want to synthesize, Ctrl-Z to exit")
    #    try:
    #        text = input()
    #    except EOFError:
    #        break

    result = speech_synthesizer.speak_text_async(text).get()
    # Check result
    if result.reason == speechsdk.ResultReason.SynthesizingAudioCompleted:
        print("Speech synthesized for text [{}], and the audio was saved to [{}]".format(text, file_name))
    elif result.reason == speechsdk.ResultReason.Canceled:
        cancellation_details = result.cancellation_details
        print("Speech synthesis canceled: {}".format(cancellation_details.reason))
        if cancellation_details.reason == speechsdk.CancellationReason.Error:
            print("Error details: {}".format(cancellation_details.error_details))


def speech_synthesis_get_available_voices(text = "en-US"):
    """gets the available voices list."""

    speech_config = speechsdk.SpeechConfig(subscription=speech_key, region=service_region)

    # Creates a speech synthesizer.
    speech_synthesizer = speechsdk.SpeechSynthesizer(speech_config=speech_config, audio_config=None)

#    print("Enter a locale in BCP-47 format (e.g. en-US) that you want to get the voices of, "
#          "or enter empty to get voices in all locales.")
#    try:
#        text = input()
#    except EOFError:
#        pass

    result = speech_synthesizer.get_voices_async(text).get()
    # Check result
    if result.reason == speechsdk.ResultReason.VoicesListRetrieved:
        print('Voices successfully retrieved, they are:')
        for voice in result.voices:
            print(voice.name)
    elif result.reason == speechsdk.ResultReason.Canceled:
        print("Speech synthesis canceled; error details: {}".format(result.error_details))