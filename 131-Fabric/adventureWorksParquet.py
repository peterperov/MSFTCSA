
import pandas


# Read the Excel file
df = pandas.read_excel('data\AdventureWorksSales.xlsx')

# Write the Parquet file
df.to_parquet('data\\AdventureWorksSales.parquet')


# openpyxl
# python -m pip install openpyxl