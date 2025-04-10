# import pandas lib as pd
import pandas as pd
import re
import csv
import os


def ExcelToCSV(fileName):
    df1 = pd.read_excel(fileName, sheet_name = 0)
    df1.to_csv(fileName + ".1.csv.dmp", index=False)

    df2 = pd.read_excel(fileName, sheet_name = 1)
    df2.to_csv(fileName + ".2.csv.dmp", index=False)



def AllExcels(folder): 

    for file in os.listdir(folder):
        filename = os.fsdecode(file)
        if filename.endswith(".xlsx"):
            f = os.path.join(folder, filename)
            print(f)
            ExcelToCSV(f)
            continue    



print( "Hello world")

folder = "C:/Users/peterperov/OneDrive - Microsoft/Desktop/AHR Reports/"
folder = "W:/01/"
folder = "W:/Azure/Reporting/01/"

fileName = "AHR-Report-C2025-04-10-181611.xlsx"

AllExcels( folder )
