
import pytesseract
from PIL import Image

from pdf_utils import extract_pages
from ocr_utils import scan_all 


filename = "..."
folder = "W:/Exams/TextOCR/0004"

# extract_pages( filename, folder)

out_file = "W:/Exams/TextOCR/0004.txt"

scan_all(folder, out_file)



