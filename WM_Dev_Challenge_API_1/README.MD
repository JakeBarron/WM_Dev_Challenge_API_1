# WM_Challenge_UI_api_ASP.net

An api for the WM_Dev_Challenge

## Installation and Usage
Building and running this project requires Visual Studio
```bash
dotnet start
```
## Notes
You'll need a sql-server db to run locally. If you have docker installed you can prop up the db by running this script. 
```bash
run-docker-sql-server.sh
```
This will start a local sql-server instance, you will need to connect from your flavor of db IDE and restore from Titles.bak. You can get the connection details from `appsettings.json`
Create a new empty Db via
```sql
CREATE DATABASE Titles
```
then restore this db via the Titles.bak file saved on root of the docker container.
(if for some reason you do not see this file run `docker cp ./Titles.bak sqlserver:/Titles.bak`)