# Order - Api
Projeto em .NetCore 5.0.

**Sobre**

O projeto visa a criação e consulta de Consumers e Orders. 

Para CRIAR dos Customers é necessário enviar uma requisição **POST**, para o ```/v1/customer``` com o Body da seguinte forma:
```
{
  "name": "string",
  "email": "string",
}
```
Para OBTER dos Customers é necessário enviar uma requisição **GET**, para o ```/v1/customer```.

Para OBTER dos Customers é necessário enviar uma requisição **GET**, para o ```/v1/customer/{customerId}```, nesse caso será retornado os dados da customer e os dados dos orders que tiverem associado à ele.

Para CRIAR dos Orders é necessário enviar uma requisição **POST**, para o ```/v1/order/{customerId}/``` com o Body da seguinte forma:
```
{
  "price": 11.59,
}
```

# Uso 

Para deixar a aplicação mais simples, resolvi usar o InMemoryDatabase. Dessa forma basta clonar o repositório e rodá-lo como IIs Express.

Ao executar o projeto por IIs Express, abrirá a tela do Swagger, nessa tela será possível fazer todas as requisições. 

Os endpoints de Customer e User precisam de autorização para receber requisições, dessa forma basta criar seu usuário e se autenticar. Ao se autenticar pelo ```/v1/users/login```, será informado o seu token de acesso:

![image](https://user-images.githubusercontent.com/42122138/156301172-ee12ffe1-591d-4c6b-af91-219f8172b5b4.png)

Para se autenticar e fazer as requisições dos endpoints de Customer e User, basta copiar o token gerado e inserir no Authorize, que fica no canto superior da tela do Swagger, com o ```Bearer``` na frente. Dessa forma:

![image](https://user-images.githubusercontent.com/42122138/156301368-19aa0548-8f97-4457-b762-2c33ea61ead5.png)

![image](https://user-images.githubusercontent.com/42122138/156301441-d52ce64c-665b-428b-a7e1-0cb3de110134.png)

**Caso deseje**

Caso queira usar via docker-compose e migrations, basta seguir os passos abaixo:

Comente as linhas de código do InMemoryDatabase e descomente as linhas escritas para o SqlServer:

```**Startup.cs**```
![image](https://user-images.githubusercontent.com/42122138/156392106-39036735-53a1-434d-9166-87f7e2f78f80.png)

```**StoreDataContext.cs**```
![image](https://user-images.githubusercontent.com/42122138/156392655-37b26f3b-2b0a-4d12-9117-bdacb0769907.png)


Para rodar a aplicação, executar o comando ```docker-compose up -d``` dentro da pasta ```src```. Por não ter conseguido configurar o docker-compose para funcionar direitinho, é necessário rodar o IIs Express para poder testar o projeto.

Após rodar o projeto, será necessário fazer o migrations. Para isso, basta entrar no diretóprio do projeto ```Orders.Data``` e executar os comandos: ```dotnet ef migrations add "nome da migração"``` e ```dotnet ef database update```. Dessa forma teremos a base de dados pronta para receber dados.

# Author

[<img src="https://img.shields.io/badge/linkedin-%230077B5.svg?&style=for-the-badge&logo=linkedin&logoColor=white" />](https://www.linkedin.com/in/luan-freitas-a04063113/)  


