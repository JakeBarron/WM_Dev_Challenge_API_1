#!/bin/bash

sudo docker pull mcr.microsoft.com/mssql/server:2019-latest

sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong@Passw0rd" \
   -p 1433:1433 --name sqlserver -h sqlserverhost \
   -d mcr.microsoft.com/mssql/server:2019-latest

docker cp ./Titles.bak sqlserver:/Titles.bak