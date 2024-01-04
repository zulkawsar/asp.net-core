```
Docker MSSQL SERVER
$SA_PASSWORD = "Pass@word#123";

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Pass@word#123" -p 1433:1433 -v mssqlvolume:/var/otp/mssql -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest

```
