
def read_file(file_name = "ts01.txt"):
    file = open(f"ts01.txt", "r")
    content = file.read()
    # print(content)
    file.close()
    return content



print("hello world")

txt = read_file()

print(txt)



