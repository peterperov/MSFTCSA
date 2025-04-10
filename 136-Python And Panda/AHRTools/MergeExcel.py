# import pandas lib as pd
import pandas as pd
# import re
# import csv

# from ExtractExcelTranspose import  TransposeExcel

fileName = "W:/WEB/TestWeb/UploadedFiles/AHR-Report-C2024-09-11-073113.xlsx"

# fileName = "W:/WEB/TestWeb/UploadedFiles/test.xlsx"

# print( fileName )

df = pd.read_excel(fileName, sheet_name = 0, engine='openpyxl')

df.to_csv(fileName + ".1.csv")

df2 = pd.read_excel(fileName, sheet_name = 1)

df2.to_csv(fileName + ".2.csv")

