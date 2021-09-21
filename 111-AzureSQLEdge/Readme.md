# Azure SQL Edge

Installing Azure SQL Edge Developer on QNAP NAS



## Links


Azure SQL Edge
https://hub.docker.com/_/microsoft-azure-sql-edge

SQL Server and Docker Compose
https://dbafromthecold.com/2020/07/17/sql-server-and-docker-compose/



## configuration

mcr.microsoft.com/azure-sql-edge:latest


## docker compose file for portainer 

version: '2'
services:
  sqlserver1:
    image: mcr.microsoft.com/azure-sql-edge:latest
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