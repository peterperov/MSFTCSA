/*

Silly load script that selects * from every table in the database

Major source of inspiration: 

https://stackoverflow.com/questions/2875768/how-do-i-list-all-tables-in-all-databases-in-sql-server-in-a-single-result-set
*/

use master
go

declare @table varchar(250); 
declare @schema varchar(200); 
declare @database varchar(200);
declare @sql nvarchar(max); 

SET NOCOUNT ON
DECLARE @AllTables table (DbName sysname,SchemaName sysname, TableName sysname)
DECLARE
     @SearchDb nvarchar(200)
    ,@SearchSchema nvarchar(200)
    ,@SearchTable nvarchar(200)

SET @SearchDb='%'
SET @SearchSchema='%'
SET @SearchTable='%'
SET @SQL='select ''?'' as DbName, s.name as SchemaName, t.name as TableName from [?].sys.tables t inner join [?].sys.schemas s on t.schema_id=s.schema_id WHERE ''?'' LIKE '''+@SearchDb+''' AND s.name LIKE '''+@SearchSchema+''' AND t.name LIKE '''+@SearchTable+''''

INSERT INTO @AllTables (DbName, SchemaName, TableName)
    EXEC sp_msforeachdb @SQL
SET NOCOUNT OFF

DECLARE cTables INSENSITIVE CURSOR FOR
select dbName, SchemaName, TableName from @AllTables; 

OPEN cTables

FETCH NEXT FROM cTables INTO @database, @schema, @table
WHILE (@@fetch_status <> -1)
BEGIN
    IF (@@fetch_status <> -2)
    BEGIN

		SET @sql = 'SELECT * FROM ' + @database + '.' + @schema + '.' + @table; 
	
		print @sql; 

		execute sp_executesql @sql;

    END
    FETCH NEXT FROM cTables INTO  @database, @schema, @table
END

CLOSE cTables
DEALLOCATE cTables