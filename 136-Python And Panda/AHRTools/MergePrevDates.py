import pandas as pd
import os

folder = 'W:/Azure/Reporting/'

# Load the first CSV file
file1 = os.path.join(folder, 'AHR-Report-C2025-04-10-181611.xlsx.2.csv')
df1 = pd.read_csv(file1, usecols=lambda x: x not in ["", "Unnamed: 0"] )

print( df1 )


# Create a composite key in the first DataFrame
# df1['CompositeKey'] = df1['TPID'].astype(str) + '|' + df1['ServiceLevel1'].astype(str) + '|' + df1['ServiceLevel2'].astype(str) + '|' + df1['ServiceLevel3'].astype(str) + '|' + df1['ServiceLevel4'].astype(str) + '|' + df1['ServiceLevel5'].astype(str)


# Load the second CSV file
file2 = os.path.join(folder, 'AHR-Report-C2025-04-10-134916.xlsx.2.csv')
df2 = pd.read_csv(file2, usecols=lambda x: x not in ["", "Unnamed: 0"] )

# df2['CompositeKey'] = df2['TPID'].astype(str) + '|' + df2['ServiceLevel1'].astype(str) + '|' + df2['ServiceLevel2'].astype(str) + '|' + df2['ServiceLevel3'].astype(str) + '|' + df2['ServiceLevel4'].astype(str) + '|' + df2['ServiceLevel5'].astype(str)


# Merge the two DataFrames based on a common key
# Replace 'key_column' with the name of the column to merge on
# merged_df = pd.merge(df1, df2, on='CompositeKey', how='outer')

merged_df = pd.merge(df1, df2, on=["SummarySegment","Segment","SubSegment","ATU","SalesTerritory","TopParent","TPID","ServiceLevel1","ServiceLevel2","ServiceLevel3","ServiceLevel4","ServiceLevel5","ServiceInfluencer"], how='outer')

# Save the merged DataFrame to a new CSV file
output_file = os.path.join( folder, 'merged_output.csv')
merged_df.to_csv(output_file, index=False)

print(f"Merged file saved as {output_file}")