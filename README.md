# MSFTCSA

Small projects for CSA team. 



## 101-Azure Function

Setting up a test bed for the customer enquiry about how to setup Azure Function on an Vnet with Private Endpoints. 





version: '3'
services:
  sqlserver1:
    build: 
      image: azure-sql-edge:latest
      dockerfile: dockerfile
    ports:  
      - "15789:1433"
    environment: 
      - ACCEPT_EULA=Y
      - MSSQL_PID=Developer 
      - MSSQL_SA_PASSWORD=order21
      - MSSQL_DATA_DIR=/var/opt/sqlserver/data
      - MSSQL_LOG_DIR=/var/opt/sqlserver/log
      - MSSQL_BACKUP_DIR=/var/opt/sqlserver/backup
    volumes: 
      - sqlsystem:/work/mssql/
      - sqldata:/work/sqlserver/data
      - sqllog:/work/sqlserver/log
      - sqlbackup:/work/sqlserver/backup
volumes:
  sqlsystem:
  sqldata:
  sqllog:
  sqlbackup:





version: '2'
services:
  sqlserver1:
    image: azure-sql-edge:latest
    ports:  
      - "15789:1433"
    environment: 
      - ACCEPT_EULA=Y
      - MSSQL_PID=Developer 
      - MSSQL_SA_PASSWORD=order21
      - MSSQL_DATA_DIR=/var/opt/sqlserver/data
      - MSSQL_LOG_DIR=/var/opt/sqlserver/log
      - MSSQL_BACKUP_DIR=/var/opt/sqlserver/backup
    volumes: 
      - sqlsystem:/work/mssql/
      - sqldata:/work/sqlserver/data
      - sqllog:/work/sqlserver/log
      - sqlbackup:/work/sqlserver/backup
volumes:
  sqlsystem:
  sqldata:
  sqllog:
  sqlbackup: