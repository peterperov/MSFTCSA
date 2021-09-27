SELECT 'INSERT INTO [dbo].[CoffeesDrunk]([Date], [User], [Coffee]) VALUES (''' 
	  + format( [date], 'yyyy-MM-dd') + '''' 
      -- convert(nvarchar(30), [Date], 111) + '''' 
      + ',''' + [User] + '''' + 
      + ',''' + [Coffee] + ''');'
FROM  [dbo].[CoffeesDrunk]

