import pytesseract
from PIL import Image
import os
from os import walk

def get_files(my_path):
    file_list = []
    for (dirpath, dirnames, filenames) in walk(my_path):
        file_list.extend( filenames )
        break
    return file_list


def scan_all(dir_name, out_file):
    pytesseract.pytesseract.tesseract_cmd = 'C:/Program Files/Tesseract-OCR/tesseract.exe'

    file_list = get_files(dir_name)

    out_str = ""

    for file_name in file_list:
        print(f"processing file {file_name}")
        # Open the image file
        image = Image.open( os.path.join(dir_name, file_name))
        # Perform OCR using PyTesseract
        text = pytesseract.image_to_string(image)

        out_str = out_str + "*************************************\n"
        out_str = out_str + file_name + "\n"
        out_str = out_str + "*************************************\n"
        out_str = out_str + text 
        out_str = out_str + "\n"

    # Print the extracted text
    # print(text)
        
    text_file = open(out_file, "w")
    text_file.write(out_str)
    text_file.close()        