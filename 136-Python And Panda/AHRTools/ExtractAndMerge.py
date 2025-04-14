# import pandas lib as pd
import pandas as pd
import re
import csv
import os
from datetime import datetime

from ExtractExcelTranspose import  TransposeExcel

def ExcelToCSV(fileName):
    df1 = pd.read_excel(fileName, sheet_name = 0)
    df1.to_csv(fileName + ".1.csv.dmp", index=False)

    df2 = pd.read_excel(fileName, sheet_name = 1)
    df2.to_csv(fileName + ".2.csv.dmp", index=False)


search = r'\d{4}-\d{2}'  

print( "Hello world")

folder = "W:/Azure/Reporting/"

prevdates = os.path.join(folder, 'AHR-202406-202503.csv')

# Excel file name here:
excelfile = os.path.join(folder, "")
sourcefilename = excelfile + ".2.csv.dmp"

# extract xsl to csv
ExcelToCSV(excelfile)

# merge with prev dates

# Load the first CSV file
df1 = pd.read_csv(sourcefilename, usecols=lambda x: x not in ["", "Unnamed: 0"] )

#remove the last column
df1.drop(df1.columns[-1], axis=1, inplace=True)

# Load the second CSV file
file2 = os.path.join(folder, 'AHR-Report-C2025-04-13-115457.xlsx.2.csv')
df2 = pd.read_csv(file2, usecols=lambda x: x not in ["", "Unnamed: 0"] )

# Merge the two DataFrames based on a common key
# Replace 'key_column' with the name of the column to merge on
# merged_df = pd.merge(df1, df2, on='CompositeKey', how='outer')

merged_df = pd.merge(df1, df2, on=["SummarySegment","Segment","SubSegment","ATU","SalesTerritory","TopParent","TPID","ServiceLevel1","ServiceLevel2","ServiceLevel3","ServiceLevel4","ServiceLevel5","ServiceInfluencer"], how='outer')

# Save the merged DataFrame to a new CSV file
# file_name = "AHR-202406-202504.{date:%Y%m%d-%H%M}.csv".format(date = datetime.now())
output_file =  excelfile + ".new.csv"
merged_df.to_csv(output_file, index=False)

print(f"Merged file saved as {output_file}")


# save 

