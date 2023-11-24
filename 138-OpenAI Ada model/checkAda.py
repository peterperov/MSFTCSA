
import os
from openai import AzureOpenAI
from dotenv import dotenv_values

config = dotenv_values(".env")
deployment = config.get("AZURE_OPENAI_DEPLOYMENT_NAME", None)
api_key = config.get("AZURE_OPENAI_API_KEY", None)
endpoint = config.get("AZURE_OPENAI_ENDPOINT", None)


print (deployment)



client = AzureOpenAI(
  api_key = os.getenv("AZURE_OPENAI_KEY"),  
  api_version = "2023-05-15",
  azure_endpoint =os.getenv("AZURE_OPENAI_ENDPOINT") 
)

response = client.embeddings.create(
    input = "Your text string goes here",
    model= "text-embedding-ada-002"
)

print(response.model_dump_json(indent=2))