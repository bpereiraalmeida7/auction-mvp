# auction-mvp
Aplicação Web (MVP) de Leilão Online. Feito em .NET Core (API Rest) e Angular 8 (SPA).

Funcionalidades:
  - Login/Logout 
  - CRUD dos itens de leilão.

###### O Sistema:
O backend do sistema foi feito em .NET Core (API Rest), utilizando Entity Framework como ORM, fazendo mapeamento dos elementos da base de dados para os elementos da aplicação. O frontend foi contruído com Angular 8 (SPA). No login foi utilizado o JSON Web Token [(JWT)](https://jwt.io/), para proteção das requisições e rotas que necessitam de autenticação, através de token assinado com uma chave secreta da API, e configurado neste projeto para expirar após 3 horas. O banco de dados utilizado: SQL Server. Segue abaixo os guias:

* LeilaoApi - [(.NET Core)](https://github.com/bpereiraalmeida7/auction-mvp/blob/master/LeilaoApi/README.md)
* LeilaoSpa - [(Angular)](https://github.com/bpereiraalmeida7/auction-mvp/blob/master/LeilaoSpa/README.md)

