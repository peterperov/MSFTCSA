import azure.cognitiveservices.speech as speechsdk
import time
import pickle

# https://northeurope.api.cognitive.microsoft.com/sts/v1.0/issuetoken
# 

subscription_key = ""
speech_region = "northeurope"
file_name = "audio_only.wav"
# Authenticate
speech_config = speechsdk.SpeechConfig(subscription_key, speech_region)
# Set up the file as the audio source
audio_config = speechsdk.AudioConfig(filename=file_name)
speech_recognizer = speechsdk.SpeechRecognizer(speech_config, audio_config)

# Flag to end transcription
done = False
# List of transcribed lines
results = list()

def stop_cb(evt):
    """callback that stops continuous recognition upon receiving an event `evt`"""
    print(f"CLOSING on {evt}")
    speech_recognizer.stop_continuous_recognition()
    # Let the function modify the flag defined outside this function
    global done
    done = True
    print(f"CLOSED on {evt}")


def recognised(evt):
    """Callback to process a single transcription"""
    recognised_text = evt.result.text
    # Simply append the new transcription to the running list
    results.append(recognised_text)
    print(f"Audio transcription: '{recognised_text}'")


# Define behaviour for each recognition/transcription
speech_recognizer.recognized.connect(recognised)

# Define behaviour for end of session
speech_recognizer.session_stopped.connect(stop_cb)
# And for canceled sessions
speech_recognizer.canceled.connect(stop_cb)

# Create a synchronous continuous recognition, the transcription itself if you will
speech_recognizer.start_continuous_recognition()
# Set a brief pause between API calls
while not done:
    time.sleep(0.5)

# Dump the whole transcription to a pickle file
with open("transcribed_video.pickle", "wb") as f:
    pickle.dump(results, f)
    print("Transcription dumped")