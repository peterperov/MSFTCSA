import pandas

# Read the Excel file
# df = pandas.read_excel('data\AzureUsage (72).csv')

# Read the csv file
df = pandas.read_csv('data\AzureUsage (72).csv') 

# Write the Parquet file
df.to_parquet('data\\azureusage.parquet')

#  - Missing optional dependency 'pyarrow'. pyarrow is required for parquet support. Use pip or conda to install pyarrow.
# - Missing optional dependency 'fastparquet'. fastparquet is required for parquet support. Use pip or conda to install fastparquet.

# pyarrow 
# python -m pip install pyarrow