# Configurando Frontend (Angular)

###### Documentação: [Requisitos](https://angular.io/guide/setup-local#prerequisites)

Após clonar todo o projeto, e verificar os requisitos do sistema, para que rode perfeitamente, configure o frontend da seguinte forma:

1. Abra o terminal na pasta raíz do projeto no diretório LeilaoSpa, e com o Node e Angular CLI devidamente instalado, execute o comando para instalar todas as dependências do projeto: 
    > npm install
    
2. Com tudo devidamente instalado, apenas execute o comando para rodar o projeto:
    > npm start
    
O projeto irá rodar no endereço padrão: localhost:4200. Acesse nesse endereço, e utilize o projeto. No caminho src/environments/environments.ts, está configurado o endereço local onde sua API ([LeilaoApi](https://github.com/bpereiraalmeida7/auction-mvp/blob/master/LeilaoApi/README.md)) já deve está rodando, caso precise mudar, poderá faze-lo modificando o valor inputado na constante `environment.api`. Com isso, tudo pronto para o frontend se "comunicar" com o backend, e retornar os dados necessários.
