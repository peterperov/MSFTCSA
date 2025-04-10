# import pandas lib as pd
import pandas as pd
import re
import csv

from ExtractExcelTranspose import  TransposeExcel

search = r'\d{4}-\d{2}'  

print( "Hello world")

fileName = "C:/Users/peterperov/OneDrive - Microsoft/Desktop/AHR Reports/AHR-Report-C2025-04-10-181611.xlsx"

# TransposeExcel(fileName)

# read by default 1st sheet of an excel file
# "ACRs SL5"
df1 = pd.read_excel(fileName, sheet_name = 0)

df1.to_csv(fileName + ".1.csv.dmp")

df2 = pd.read_excel(fileName, sheet_name = 1)

df2.to_csv(fileName + ".2.csv.dmp")

