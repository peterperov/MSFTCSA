
import azure.cognitiveservices.speech as speechsdk
import time
import pickle
from dotenv import dotenv_values

from azure_speech import *
from utils import *


config = dotenv_values(".env")
speech_api_key = config.get("AZURE_SPEECH_API_KEY", None)
speech_region = config.get("AZURE_SPEECH_REGION", None)


print("speech_api_key: {0}".format(speech_api_key))
print("speech_region: {0}".format(speech_region))

speech_synthesis_get_available_voices()

txt = read_file("ts01.txt")
# print(txt)

# speech_synthesis_to_mp3_file(file_name = "W:/GITHUB/MSFTCSA/141-TextToSpeech/output2.mp3", text = txt)



