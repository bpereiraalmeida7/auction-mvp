# Configurando API

###### Documentação da Plataforma: [.NET](https://docs.microsoft.com/pt-br/dotnet/core/)

Após clonar todo o projeto, e verificar os requisitos do sistema, para que rode perfeitamente, você terá o sistema dividido em duas pastas (LeilaoApi e LeilaoSpa). Configure a api da seguinte forma:

1. Rode o [script SQL](https://github.com/bpereiraalmeida7/auction-mvp/blob/master/sql/SQLLeilao.sql), para criação da base de dados, o qual já acompanha insert de um usuário e um item de leilão.

2. Abra a pasta no diretório LeilaoApi, identificando a Solução do projeto (caminho: LeilaoApi\LeilaoApi.sln), abrindo a mesma no [Visual Studio](https://visualstudio.microsoft.com/pt-br/vs/).

3. Abra o arquivo `appsettings.json`, e modifique o valor "Server" da connection string, com a instância de sua preferência.
    ![run solution](https://github.com/bpereiraalmeida7/auction-mvp/blob/master/screenshots/connection.PNG)
    
4. Execute a solução, clicando no botão como na imagem abaixo:  

    ![run solution](https://github.com/bpereiraalmeida7/auction-mvp/blob/master/screenshots/runApi.PNG)

    
Obs: Ele abrirá por padrão, o navegador na página configurada em `launchSettings.json`, a página retornará 401, já que está sendo acessada sem autenticação, mas não feche. Próximo passo: Executar a [SPA](https://github.com/bpereiraalmeida7/auction-mvp/blob/master/LeilaoSpa/README.md)
