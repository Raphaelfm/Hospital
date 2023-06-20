# Link do video no youtube
https://youtu.be/SzwnY6RyYUo

# Hospital
This project is to analyze data from hospitals in all Brazilian states

![image](https://user-images.githubusercontent.com/51061090/236844959-1f5bb422-3c66-468b-85aa-9fd7477e43ce.png)

# Setting the project dependecies

## Install .Net framework 7 by clicking in the link bellow
https://dotnet.microsoft.com/pt-br/download

## Install MariaDB or MySQL
MariaDB: https://mariadb.org/download/?t=mariadb&p=mariadb&r=11.1.0&os=windows&cpu=x86_64&pkg=msi&m=fder

MySQL: https://dev.mysql.com/downloads/installer/

## Configure the database enviroment in the project
Go to the folder AnliseHospitais and edit the file appsettings.Development.json with your database settings

## Restore the database
You may restore the database executing entity framework, in .net cli with the command: update-database

You may also restore the database executing the script in the folder Modelagem_Banco_de_Dados

## Running the application

### Visual Studio
If you are using Visual Studio, you may run the application clicking in the run button

### Visual Studio Code
If you are using Visual Studio Code, you may run the application opening the folder AnliseHospitais, starting a new Terminal, and running the command: dotnet run

### Command Prompt
If you feel confortable by using cmd, you may open the folder AnliseHospitais with cmd, and executing the command: dotnet run

## Remember to install .net sdk
https://dotnet.microsoft.com/en-us/download/dotnet/7.0


