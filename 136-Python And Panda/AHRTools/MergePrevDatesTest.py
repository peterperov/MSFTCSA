import pandas as pd
import os

folder = 'W:/Azure/Reporting/'

# Load the first CSV file
file1 = os.path.join(folder, 'AHR-Report-C2025-04-10-181611.xlsx.2.csv')
df1 = pd.read_csv(file1, usecols=lambda x: x not in ["", "Unnamed: 0"] )

print( df1 )


# Create a composite key in the first DataFrame
df1['CompositeKey'] = df1['TPID'].astype(str) + '|' + df1['ServiceLevel1'].astype(str) + '|' + df1['ServiceLevel2'].astype(str) + '|' + df1['ServiceLevel3'].astype(str) + '|' + df1['ServiceLevel4'].astype(str) + '|' + df1['ServiceLevel5'].astype(str)





df1.to_csv( os.path.join( folder, 'sample.csv'), index=False )

