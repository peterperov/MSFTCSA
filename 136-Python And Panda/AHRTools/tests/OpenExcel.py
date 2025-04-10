# import pandas lib as pd
import pandas as pd
import re
import csv



fileName = "W:/Azure/Reporting/AHR-Report-C2025-04-10-134916.xlsx"

df = pd.read_excel(fileName, sheet_name = 1)

df.to_csv(fileName + ".1.csv")
