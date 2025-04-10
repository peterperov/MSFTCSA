import pandas as pd

# Load the first CSV file
file1 = 'file1.csv'
df1 = pd.read_csv(file1)

# Create a composite key in the first DataFrame
df1['key_column'] = df1['ServiceLevel1'].astype(str) + '_' + df1['ServiceLevel2'].astype(str)

# Load the second CSV file
file2 = 'file2.csv'
df2 = pd.read_csv(file2)

# Merge the two DataFrames based on a common key
# Replace 'key_column' with the name of the column to merge on
merged_df = pd.merge(df1, df2, on='key_column', how='inner')

# Save the merged DataFrame to a new CSV file
output_file = 'merged_output.csv'
merged_df.to_csv(output_file, index=False)

print(f"Merged file saved as {output_file}")