
# Below are the quick examples.
# import pandas lib as pd
import pandas as pd
import re
import csv
import numpy as np

technologies = ({
    'Courses':["Spark","Hadoop","pandas","Java","Pyspark"],
    'Fee' :[20000,25000,30000,22000,26000],
    'Duration':['30days','40days','35days','60days','50days'],
    'Discount':[1000,2500,1500,1200,3000]
               })

df = pd.DataFrame(technologies)

print("# Example 1: Use getitem ([]) to iterate over columns")
for column in df:
    print(df[column])
    
print("# Example 2: Use getitem ([]) to iterate over columns in pandas DataFrame")
for column in df:
    print(df[column].values)
    
print("# Example 3: Iterate over columns using DataFrame.iteritems()")
# for (colname,colval) in df.iteritems():
#     print(colname, colval.values)
    
print("# Example 4: Use iteritems()")
# for name, values in df.iteritems():
#    print('{name}: {value}'.format(name=name, value=values[1])) 
   
print("# Example 5: Iterate over columns in pandas DataFrame using enumerate()")
for (index, colname) in enumerate(df):
    print(index, df[colname].values)
    
print("# Example 6: Using enumerate()")
for (index, column) in enumerate(df):
    print (index, df[column])
    
print("# Example 7: Using enumerate() & Numpy.asarray()")
for (index, column) in enumerate(df):
    print (index, np.asarray(df[column]))
    
print("# Example 8: Use DataFrame.columns()")
for column in df.columns[1:]:
    print(df[column])
    
print("# Example 9: Iterate over all the columns in reversed order")
for column in df.columns[::-1]:
    print(df[column])
    
print("# Example 10: Get the indices of all columns")
for indix, column in enumerate(df.columns):
    print(indix, column)
    
print("# Example 11: Use DataFrame.transpose().iterrows()")
for (column_name, column) in df.transpose().iterrows():
    print (column_name)
    print (column) 