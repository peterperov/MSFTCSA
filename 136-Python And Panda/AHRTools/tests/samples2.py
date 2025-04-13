# import pandas lib as pd
import pandas as pd
import re
import csv


technologies = ({
    'Courses':["Spark","Hadoop","pandas","Java","Pyspark"],
    'Fee' :[20000,25000,30000,22000,26000],
    'Duration':['30days','40days','35days','60days','50days'],
    'Discount':[1000,2500,1500,1200,3000]
               })
df = pd.DataFrame(technologies)
print("Create DataFrame:\n", df)

lst = []
# df = pd.DataFrame(technologies)
new_row = {'Courses':'Hyperion', 
           'Fee':24000, 
           'Duration':'55days', 
           'Discount':1800}
lst.append(new_row)

# df2 = df.append(new_row, ignore_index=True)
df2 = pd.DataFrame(lst)
print("After adding a new row to DataFrame:\n", df2)
