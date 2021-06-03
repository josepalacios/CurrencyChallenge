# CurrencyChallengeAPI

This project was generated with net 5

## Run

- Install lastest nugget packages of the project
- Run the project by default will display swagger so you can test the Endpoints

##DB Configuraiton

- Run the sql script in the folder infraestructure/script.sql in your local SQL SERVER enviroment
- Change appsettings.json with your local connection string

##Logs

- For logging change the path of your repository on nlog.config for both internalog 
ex: "C:\Users\Jose\source\repos\CurrencyChallenge\internallog.txt" and for server handled errors
ex: C:/Users/Jose/source/repos/CurrencyChallenge/logs/${shortdate}_logfile.txt

- There are two log files that are being created internallog and in logs folder logfile that will contain handled server errors

##APIS

- api/Currency/id  .- will get thedaily currency value by currency id ex: 1 for dollar or 2 for real
- api/Currency  .- will add a currency 

- api/CurrencyTransaction  .- will buy a currency according to the specific userID currency and purchase amount

