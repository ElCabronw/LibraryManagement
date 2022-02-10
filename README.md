# LibraryManagement
WebAPI para gerenciamento de livraria.

Autor : Lucas Fuziyama

Bem vindo !

    Configurando:

Para o funcionamento da WEB Api siga os passos:

0 - Baixe o ZIP do projeto. https://github.com/ElCabronw/LibraryManagement/archive/refs/heads/master.zip


1- Verifique se o pacote do entity framework foi instalado com sucesso na sua máquina, caso contrario utilize o comando no terminal "dotnet tool install --global dotnet-ef"


2 - Abra o arquivo appsettings.json e em seguida altere a string de conexão em "DefaultConnection" para se conectar com o banco PostgreSQL.


2 - Execute o comando "dotnet ef database update" se for utilizar o terminal ou "update-database" se estiver utilizando nuget package manager, para aplicar as migrations e assim o Entity construa as tabelas no banco de dados e aplique os dados que deixei por default pra facilitar na hora de você testar ;).


3 - Execute a aplicação, irá abrir no seu navegador a página do Swagger e você ja estará apto a realizar as chamadas aos endpoints.


----------------------------------------------------------------------------------------------------------------------------------------------------------
    Executando:
[GET]
"api/v1/{controller}" -> Lista todos os '{controller}' cadastrados no sistema.


[GET]
"api/v1/{controller}/{id}" ->Obtém um objeto do tipo '{controller}'.


[POST]
"api/v1/{controller}" -> Cria um objeto do tipo '{controller}'.


[PUT]
"api/v1/{controller}" -> Atualiza um objeto do tipo '{controller}'.


[DELETE]
"api/v1/{controller}/{id}" ->Apaga um objeto do tipo '{controller}'.



    Considerações importantes:
O endpoint [POST] "api/v1/book" é necessário passar um autorId e um generoId válidos para o funcionamento, esses Ids se obtem utilizando as API's [GET] de Author e Genre.

O endpoint [GET] "api/v1/book" possui o parametro sortbyName que :
false -> ordena os livros pelo id;
true -> ordena os livros pelo nome


Ao Executar o projeto é possível ver a documentação específica de cada endpoint e de como utiliza-lo.

----------------------------------------------------------------------------------------------------------------------------------------------------------

Tecnologias:

.NET Core 6;


EntityFramework 6.0.1;


PostgreSQL


Dapper 2.0.123

Bibliotecas relevantes:

AutoMapper
SwashBuckle






