# import pandas lib as pd
import pandas as pd
import re
import csv


search = r'\d{4}-\d{2}'  

print( "Hello world")

fileName = "C:/Users/peterperov/OneDrive - Microsoft/Desktop/AHR Reports/AHR-Report-C2023-10-30-091114.xlsx"

 
# read by default 1st sheet of an excel file
# "ACRs SL5"
df = pd.read_excel(fileName, sheet_name = 2)
 
# print(dataframe1)


# Use getitem ([]) to iterate over columns
# we need to identify last 12 months
cnt = 0
format = "T{cnt:02d}"
mapping = {}
cols = []

for column in df:
    name = df[column].name
    if re.search(search, name):
        cols.append(name)
        cnt = cnt + 1
        newname = format.format(cnt = cnt)
        print (name + ' xxx ' + newname)
        # df[column].rename(format.format(cnt=cnt))
        # df.rename(columns = {df[column].name: newname})
        # mapping[name] = newname
        print( df[column].name)
    else:
        print(df[column].name)


print("************************")

# rename column headers
# df.rename(columns = mapping, inplace=True)

i = 0
i12 = cnt - 12
newDF = pd.DataFrame()
mapping = {}


print( 'i12 = {0}'.format(i12) )

# grab 12 last data columns and rename them to T01 - T12
for column in df: 
    name = df[column].name
    # copy non numerical
    if  re.search(search, name):
        print ( name + ' skipped ')
    else: 
        print(df[column].name + ' copied' )
        newDF[df[column].name] = df[column].copy()

# take top 12
i = 12
for item in sorted(cols, reverse = True):
    if i > 0:
        newName = format.format(cnt = i)
        print("col: {0} - {1} - {2}".format(newName, item, i))
        mapping[newName] = item
        newDF[newName] = df[item].copy()
        i = i - 1


# newDF.to_csv(fileName + '.debug.csv')

# save mappings
cols =  pd.DataFrame(mapping.items(), columns=['Date', 'Value'])
cols.to_csv(fileName + '.cols.csv')

#dropping duplicates for all columns
newDF.drop_duplicates(inplace=True)

# last 3 months mom
col1 = format.format(cnt = 12 - 1)
col2 = format.format(cnt = 12 - 2)
col3 = format.format(cnt = 12 - 3)
col4 = format.format(cnt = 12 - 4)
col5 = format.format(cnt = 12 - 5)

print
# df.to_csv(fileName + '.renamed.csv')

colname = "T{cnt:02d}MOM"

newDF[ colname.format(cnt = 11)] = newDF[col1] - newDF[col2]
newDF[ colname.format(cnt = 10)] = newDF[col2] - newDF[col3]
newDF[ colname.format(cnt = 9)] = newDF[col3] - newDF[col4]
newDF[ colname.format(cnt = 8)] = newDF[col4] - newDF[col5]

# df['2023-09MOM'] = df['2023-09'] - df['2023-08']
# df['2023-08MOM'] = df['2023-08'] - df['2023-07']
# df['2023-07MOM'] = df['2023-07'] - df['2023-06']

newDF.to_csv(fileName + '.new.csv')

