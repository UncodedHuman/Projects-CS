import sqlite3  
import json  

# Connect to the SQLite database  
connection = sqlite3.connect('app.db')  
cursor = connection.cursor()  

# Fetch all data from a specific table  
cursor.execute("SELECT * FROM Credits")  
data = cursor.fetchall()  

# Get column names  
columns = [column[0] for column in cursor.description]  

# Convert to JSON-compatible format  
json_data = [dict(zip(columns, row)) for row in data]  

# Write to JSON file  
with open('output.json', 'w') as json_file:  
    json.dump(json_data, json_file, indent=4)  

# Close the connection  
connection.close()  