#115-PowerBI-Embedded

##Overview

Testbed for the PowerBI embedded report in ASP.NET MVC app. 

##Prerequsites

* Azure AD tenant
* Azure SQL DB integrated with Azure AD Tenant


## Setting up 

Add Azure AD users to the Azure SQL 


-- peterperov is an admin user 

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

