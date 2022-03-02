# Order - Api
Projeto em .NetCore 5.0 para o desafio técnico da Ília Digital

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
Para rodar a aplicação, executar o comando ```docker-compose up -d``` dentro da pasta ```src```. 

# Author

[<img src="https://img.shields.io/badge/linkedin-%230077B5.svg?&style=for-the-badge&logo=linkedin&logoColor=white" />](https://www.linkedin.com/in/luan-freitas-a04063113/)


