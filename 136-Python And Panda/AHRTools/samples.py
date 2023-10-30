
# Below are the quick examples.

# Use getitem ([]) to iterate over columns
for column in df:
    print(df[column])
    
# Use getitem ([]) to iterate over columns in pandas DataFrame
for column in df:
    print(df[column].values)
    
# Iterate over columns using DataFrame.iteritems()
for (colname,colval) in df.iteritems():
    print(colname, colval.values)
    
# Use iteritems()
for name, values in df.iteritems():
   print('{name}: {value}'.format(name=name, value=values[1])) 
   
# Iterate over columns in pandas DataFrame using enumerate()
for (index, colname) in enumerate(df):
    print(index, df[colname].values)
    
# Using enumerate()
for (index, column) in enumerate(df):
    print (index, df[column])
    
# Using enumerate() & Numpy.asarray()
for (index, column) in enumerate(df):
    print (index, np.asarray(df[column]))
    
# Use DataFrame.columns()
for column in df.columns[1:]:
    print(df[column])
    
# Iterate over all the columns in reversed order    
for column in df.columns[::-1]:
    print(df[column])
    
# Get the indices of all columns
for indix, column in enumerate(df.columns):
    print(indix, column)
    
# Use DataFrame.transpose().iterrows()
for (column_name, column) in df.transpose().iterrows():
    print (column_name)



# save csv - saves weird
with open(fileName + '.cols.csv', 'w') as f:
    writer = csv.writer(f)
    writer.writerows(mapping)