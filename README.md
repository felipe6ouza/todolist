# Todolist
Uma simples API de Lista de Tarefas

## Executando o Projeto

### Requisitos
- Docker Compose

### Instruções

1. **Navegue até a raiz do projeto:**

   Acesse a pasta onde está localizado o arquivo `docker-compose.yml`:

2. **Construa e inicie os containers**:

```
docker-compose up --build
```
3. **Acesse a documentação da API**:
Acesse a documentação Swagger da API em seu navegador ou faça requests por ferramentas como o Postman/Insomnia:
```
http://localhost:8080/swagger/index.html
```

## Observações:

- Dois usuários de teste foram criados via Migration do EF: um com a função de 'colaborador' e outro com a função de 'gerente'. Você pode obter as informações deles requisitando o endpoint /api/Usuario/todos.

- O container do SQL Server foi configurado para utilizar a porta 1433.

Tecnologias e Bibliotecas Utilizadas:

- .NET 8
- EF Core
- MediatR
- FluentValidation
- SQL Server

That's all, folks!
