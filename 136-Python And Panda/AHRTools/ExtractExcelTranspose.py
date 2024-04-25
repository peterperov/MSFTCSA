# import pandas lib as pd
import pandas as pd
import re
import csv


# print( "Hello world")

# fileName = "C:/Users/peterperov/OneDrive - Microsoft/Desktop/AHR Reports/AHR-Report-C2023-11-23-142316.xlsx"


def TransposeExcel(filename):

    selectedColumns = {"SummarySegment","Segment","SubSegment","ATU","SalesTerritory","TopParent","TPID","ServiceLevel1","ServiceLevel2","ServiceLevel3","ServiceLevel4","ServiceLevel5","ServiceInfluencer"}
    
    df = pd.read_excel(filename, sheet_name = 1)

    cnt = 0
    r = 0

    lst = []

    for index, row in df.iterrows():
        cnt = cnt + 1
        c = 0
        for column in df.columns:
            val = row[column]
            if column in selectedColumns:
                continue

            new_row = {}
            for sel in selectedColumns:
                new_row[sel] = row[sel]

            new_row["Month"] = column
            new_row["ACR"] = val

            lst.append(new_row)


    newDF = pd.DataFrame(lst)

    new_filename = filename + ".transposed.csv"
    newDF.to_csv(new_filename, index=False) 
    return new_filename