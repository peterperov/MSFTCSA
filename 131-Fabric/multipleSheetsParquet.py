import pandas as pd

for sheet_name, df in pd.read_excel(r"data\AdventureWorksSales.xlsx", index_col=0, sheet_name=None).items():
    csvFile = f'data\\aw_{sheet_name}.csv'
    df.to_csv(csvFile, index=False, encoding='utf-8')

    # single csv file per table 
    parquetFile = f'data\\{sheet_name}.parquet'

    # Read the csv file
    df = pd.read_csv(csvFile) 

    # Write the Parquet file
    df.to_parquet(parquetFile)