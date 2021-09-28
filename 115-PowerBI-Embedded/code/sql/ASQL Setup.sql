

CREATE LOGIN [joe@myaad.onmicrosoft.com] FROM EXTERNAL PROVIDER GO

CREATE USER [peterperov@chipsandfish.net] FROM EXTERNAL PROVIDER WITH DEFAULT_SCHEMA = dbo;

-- Add user to the db_datareader role
ALTER ROLE db_datareader ADD MEMBER [peterperov@chipsandfish.net];

-- additional role management might be required for admin user: 
ALTER ROLE dbmanager ADD MEMBER [peterperov@chipsandfish.net];
ALTER ROLE loginmanager ADD MEMBER [peterperov@chipsandfish.net];

-- reader@chipsandfish.net

CREATE USER [reader@chipsandfish.net] FROM EXTERNAL PROVIDER WITH DEFAULT_SCHEMA = dbo;

-- Add user to the db_datareader role
ALTER ROLE db_datareader ADD MEMBER [reader@chipsandfish.net];

-- test@chipsandfish.net

CREATE USER [test@chipsandfish.net] FROM EXTERNAL PROVIDER WITH DEFAULT_SCHEMA = dbo;

-- Add user to the db_datareader role
ALTER ROLE db_datareader ADD MEMBER [test@chipsandfish.net];

-- user@chipsandfish.net

CREATE USER [user@chipsandfish.net] FROM EXTERNAL PROVIDER WITH DEFAULT_SCHEMA = dbo;

-- Add user to the db_datareader role
ALTER ROLE db_datareader ADD MEMBER [user@chipsandfish.net];

-- powerbi@chipsandfish.net
CREATE USER [powerbi@chipsandfish.net] FROM EXTERNAL PROVIDER WITH DEFAULT_SCHEMA = dbo;

-- Add user to the db_datareader role
ALTER ROLE db_datareader ADD MEMBER [powerbi@chipsandfish.net];
