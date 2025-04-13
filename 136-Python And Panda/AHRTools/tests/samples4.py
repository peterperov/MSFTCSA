

from datetime import datetime

import pandas as pd
print(pd.__file__)

import xlrd

print(xlrd.__version__)


now = datetime.now() # current date and time

date_time = now.strftime("%m/%d/%Y, %H:%M:%S")
print("date and time:",date_time)


# 'AHR-202406-202504.csv'
str = "AHR-202406-202504.{date:%Y%m%d-%H%M}.csv".format(date = datetime.now())

print(str)
