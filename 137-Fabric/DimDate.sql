CREATE TABLE [dbo].[dimDate]( [DateKey] [int] NOT NULL,
 [Date] [date] NOT NULL,
 [Day] [tinyint] NOT NULL,
 [DaySuffix] [char](2) NOT NULL,
 [Weekday] [tinyint] NOT NULL,
 [WeekDayName] [varchar](10) NOT NULL,
 [WeekDayName_Short] [char](3) NOT NULL,
 [WeekDayName_FirstLetter] [char](1) NOT NULL,
 [DOWInMonth] [tinyint] NOT NULL,
 [DayOfYear] [smallint] NOT NULL,
 [WeekOfMonth] [tinyint] NOT NULL,
 [WeekOfYear] [tinyint] NOT NULL,
 [Month] [tinyint] NOT NULL,
 [MonthName] [varchar](10) NOT NULL,
 [MonthName_Short] [char](3) NOT NULL,
 [MonthName_FirstLetter] [char](1) NOT NULL,
 [Quarter] [tinyint] NOT NULL,
 [QuarterName] [varchar](6) NOT NULL,
 [Year] [int] NOT NULL,
 [YearMonth] [char](6) NOT NULL,
 [MMYYYY] [char](6) NOT NULL,
 [MonthYear] [char](7) NOT NULL,
 [IsWeekend] [bit] NOT NULL,
 [IsHoliday] [bit] NOT NULL,
 [HolidayName] [varchar](20) NULL,
 [SpecialDays] [varchar](20) NULL,
 [FinancialYear] [int] NULL,
 [FinancialQuater] [int] NULL,
 [FinancialMonth] [int] NULL,
 [FirstDateofYear] [date] NULL,
 [LastDateofYear] [date] NULL,
 [FirstDateofQuater] [date] NULL,
 [LastDateofQuater] [date] NULL,
 [FirstDateofMonth] [date] NULL,
 [LastDateofMonth] [date] NULL,
 [FirstDateofWeek] [date] NULL,
 [LastDateofWeek] [date] NULL,
 [CurrentYear] [smallint] NULL,
 [CurrentQuater] [smallint] NULL,
 [CurrentMonth] [smallint] NULL,
 [CurrentWeek] [smallint] NULL,
 [CurrentDay] [smallint] NULL,
 PRIMARY KEY CLUSTERED  ( [DateKey] ASC )WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY] ) 
 ON [PRIMARY] 
 GO 