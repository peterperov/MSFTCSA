import csv  
import json

# Open the CSV file for reading  
with open('w:\\GITHUB\MSFTCSA\\130-OpenAIPlayground\\data\\bbc-news-data.txt', 'r') as csv_file:  
    # Create a CSV reader object  
    # csv_reader = csv.reader(csv_file)
    csv_reader = csv.reader(csv_file, delimiter='\t')
 
    # Create an empty list to store the JSON objects  
    json_list = []

    # Iterate over each row in the CSV file  
    for row in csv_reader:  
        # Create a dictionary to store the values for this row  
        row_dict = {}  
        # Iterate over each column in the row, adding the key-value pairs to the dictionary  
        for i in range(len(row)):  
            row_dict[f'field_{i+1}'] = row[i]  
        # Add the dictionary to the list  
        json_list.append(row_dict)

# Write the JSON objects to a file  
with open('w:\\GITHUB\MSFTCSA\\130-OpenAIPlayground\\data\\example.json', 'w') as json_file:  
    json.dump(json_list, json_file)



