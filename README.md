# Product-CRUD-app
//Powershell command: 1-docker pull mcr.microsoft.com/mssql/server:2022-latest -- > This command downloads the latest version of SQL Server 2022 image from the official Microsoft Container Registry. voici la reponse de system: 2022-latest: Pulling from mssql/server 9c44873e77b3: Pull complete 15f18156905c: Pull complete a7f551132cc7: Pull complete Digest: sha256:7c29dfbac885ad7519e219c7fe4aee0e67283e21a10e9c252d13b0fbde1866f8 Status: Downloaded newer image for mcr.microsoft.com/mssql/server:2022-latest mcr.microsoft.com/mssql/server:2022-latest

2-docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Passw0rd123!" `

-p 1433:1433 --name sqlserver ` -d mcr.microsoft.com/mssql/server:2022-latest --> What it does:

-e "ACCEPT_EULA=Y": Accepts the Microsoft license terms.

-e "SA_PASSWORD=Passw0rd123!": Sets the system administrator (SA) password.

-p 1433:1433: Maps port 1433 on the host to port 1433 on the container (SQL Server default port).

--name sqlserver: Names the container sqlserver.

-d: Runs the container in detached mode (in the background).

mcr.microsoft.com/mssql/server:2022-latest: Specifies the SQL Server image to run.

-->A long container ID is displayed (e.g., 07a4fc85ee47...), confirming the container has started.

voici la reponse de system: 07a4fc85ee47c2fb94bcebd032d0c3f54aaaad27d6725b54c9480be4a8bdd12e

3-docker ps

-->Pour voir si le container est bien demarrer

voici la reponse: CONTAINER ID IMAGE COMMAND CREATED STATUS PORTS NAMES 07a4fc85ee47 mcr.microsoft.com/mssql/server:2022-latest "/opt/mssql/bin/laun…" 53 seconds ago Up 52 seconds 0.0.0.0:1433->1433/tcp, [::]:1433->1433/tcp sqlserver PS C:\Users\GROUPE SABIL>

et voici mon App Docker:
<img width="1920" height="1033" alt="Capture d'écran 2025-08-05 172438" src="https://github.com/user-attachments/assets/72849463-efc6-4e42-bbf9-f8649b765cc3" />
