import os
from openai import AzureOpenAI
from dotenv import dotenv_values

config = dotenv_values(".env")
deployment = config.get("AZURE_OPENAI_DEPLOYMENT_NAME", "davinci")
api_key = config.get("AZURE_OPENAI_API_KEY", None)
endpoint = config.get("AZURE_OPENAI_ENDPOINT", None)

deployment = "davinci"

print (deployment)

# from 
# https://learn.microsoft.com/en-us/azure/ai-services/openai/quickstart?tabs=command-line%2Cpython-new&pivots=programming-language-python

client = AzureOpenAI(
    api_key=os.getenv("AZURE_OPENAI_API_KEY"),  
    api_version="2023-12-01-preview",
    azure_endpoint = os.getenv("AZURE_OPENAI_ENDPOINT")
    )

print('Sending a test completion job')
start_phrase = 'Write a tagline for an ice cream shop. '
start_phrase = 'Write a gentle reminder email about message sent last friday. '

response = client.completions.create(model=deployment, 
            prompt=start_phrase, 
            max_tokens=10)

print(start_phrase + response.choices[0].text)

print(response.model_dump_json(indent=2))


