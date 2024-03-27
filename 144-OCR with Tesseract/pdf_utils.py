from pdf2image import convert_from_path
import os


def extract_pages(file_name, out_path):
    pdf_images = convert_from_path(file_name)

    print (len(pdf_images))

    for idx in range(len(pdf_images)):
        name = "pdf_page_{:03d}.png".format(idx)
        out_file = os.path.join( out_path, name)
        pdf_images[idx].save(out_file, 'PNG')
        
    print("Successfully converted PDF to images")
