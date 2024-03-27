import os
from os import walk


def get_files(my_path):
    file_list = []
    for (dirpath, dirnames, filenames) in walk(mypath):
        file_list.extend(filenames)
        break

    return file_list



number = 1
print("{:03d}".format(number))

mypath = "W:/Exams/TextOCR/0001/"

file_list = get_files(mypath)

print (file_list)

for f in file_list:
    print( os.path.join(mypath, f))
