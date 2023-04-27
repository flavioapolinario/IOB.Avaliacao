# IOB.Avaliacao
Avaliaçãoda IOB

## 🚀 Getting started

### Visual Studio
Para executar a aplicação pelo Visual Studio, basta selecionar o projeto `IOB.WebApp`.

### Visual Studio Code
Para executar a aplicação via Visual Studio Code, será necessario executar os comandos abaixo, no diretorio `..\src\IOB.WebApp` 

```
dotnet build
dotnet run
```

## Database

Podemos criar o banco de dados da aplicação das seguintes formas:

### Via Migrations

Para criar o banco de dados via migrations, será necessario executar o comando abaixo, no diretorio: `..\IOB.Avaliacao\src\IOB.WebApp`.

```
dotnet ef database update
```

### Scripts

O script de criação do banco de dados encontra-se no diretorio: 

```
..\scripts\IOB-Database.sql
```
