/*


*/


declare @table varchar(250); 
declare @schema varchar(200); 
declare @sql varchar(max); 

DECLARE cTables INSENSITIVE CURSOR FOR
	SELECT s.name as schemaName, t.name as tablename 
	FROM sys.tables t
	LEFT OUTER JOIN sys.schemas s ON t.schema_id = s.schema_id

OPEN cTables

FETCH NEXT FROM cTables INTO @schema, @table
WHILE (@@fetch_status <> -1)
BEGIN
    IF (@@fetch_status <> -2)
    BEGIN
	
		set @sql = 'SELECT * FROM ' + @schema + '.' + @table; 

		print @sql; 
		
    END
    FETCH NEXT FROM cTables INTO @schema, @table
END

CLOSE cTables
DEALLOCATE cTables