# GerenciadorLivro.API

API para gerenciar empréstimos de livros, incluindo operações com usuários e livros, utilizando Clean Architecture, o padrão de repositório e CQRS.

## Índice

- [Sobre o Projeto](#sobre-o-projeto)
- [Arquitetura](#arquitetura)
  - [Clean Architecture](#clean-architecture)
  - [Padrão Repository](#padrão-repository)
  - [CQRS](#cqrs)

- [Autenticação](#autenticação)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Instalação](#instalação)
- [Como Usar](#como-usar)
- [Rotas da API](#rotas-da-api)
  - [Emprestimos](#emprestimos)
  - [Livros](#livros)
  - [Usuarios](#usuarios)
- [Saiba Mais - Next Wave Education](#saiba-mais)
- [Contato](#contato)

## Sobre o Projeto

O GerenciadorLivro.API é uma aplicação para gerenciar empréstimos de livros, permitindo o cadastro de livros, usuários e a realização de empréstimos. Utiliza Clean Architecture para garantir manutenibilidade e testabilidade, o padrão de repositório para abstração de dados e CQRS para separação de comandos e consultas.

## Arquitetura

### Clean Architecture

A Clean Architecture, ou Arquitetura Limpa, é uma abordagem que permite criar sistemas com baixo acoplamento e alta coesão. A estrutura do projeto segue o princípio de divisão de responsabilidades em camadas:

- **Camada de Core**: Contém a lógica de negócios e entidades do domínio.
- **Camada de Application**: Inclui casos de uso e serviços que orquestram a lógica de negócios.
- **Camada de Infrastructure**: Implementa detalhes técnicos como acesso a dados, serviços externos, etc.

### Padrão Repository

O padrão de repositório é utilizado para criar uma abstração entre a camada de aplicação e a camada de dados. Ele facilita a troca de fontes de dados (ex.: de um banco de dados SQL para um NoSQL) sem alterar a lógica de negócios.

### CQRS

CQRS (Command Query Responsibility Segregation) é um padrão que separa a leitura e escrita de dados. Isso significa que comandos (operações de escrita) e consultas (operações de leitura) são tratados por modelos diferentes. Isso melhora a escalabilidade e facilita a manutenção do código.

## Autenticação

A API utiliza autenticação JWT para proteger os endpoints. Para acessar os endpoints protegidos, você precisa incluir o token JWT no cabeçalho da solicitação.

### Autenticação JWT

A autenticação é feita através do cabeçalho `Authorization` usando o esquema `Bearer`.

**Cabeçalho da solicitação:**

```http
Authorization: Bearer {seu_token_jwt}
```

No projeto GerenciadorLivro, implementamos um controlador para gerenciar operações de livros, empréstimos e usuários com autenticação e autorização adequadas. Confira:

#### 📖 Operações com Livros

1. GET /api/livros: Retorna todos os livros. 🔐 Acesso: "admin" e "comum".
2. GET /api/livros/{id}: Retorna um livro pelo ID. 🔐 Acesso: "admin" e "comum".
3. POST /api/livros: Cria um novo livro. 🔐 Acesso: "admin".
4. PUT /api/livros/{id}: Atualiza um livro. 🔐 Acesso: "admin".
5. DELETE /api/livros/{id}: Remove um livro. 🔐 Acesso: "admin".

#### 📅 Operações com Empréstimos

1. GET /api/emprestimos: Retorna todos os empréstimos. 🔐 Acesso: "admin" e "comum".
2. GET /api/emprestimos/{id}: Retorna um empréstimo pelo ID. 🔐 Acesso: "admin" e "comum".
3. POST /api/emprestimos: Cria um novo empréstimo. 🔐 Acesso: "admin" e "comum".
4. PUT /api/emprestimos/{id}: Atualiza um empréstimo. 🔐 Acesso: "admin" e "comum".
5. DELETE /api/emprestimos/{id}: Remove um empréstimo. 🔐 Acesso: "admin".

#### 👤 Operações com Usuários

1. GET /api/usuarios: Retorna todos os usuários. 🔐 Acesso: "admin".
2. GET /api/usuarios/{id}: Retorna um usuário pelo ID. 🔐 Acesso: "admin".
3. POST /api/usuarios: Cria um novo usuário. 🌐 Acesso: aberto.
4. PUT /api/usuarios/{id}: Atualiza um usuário. 🔐 Acesso: "admin".
5. DELETE /api/usuarios/{id}: Remove um usuário. 🔐 Acesso: "admin".
6. PUT /api/usuarios/login: Realiza login. 🌐 Acesso: aberto.

## Tecnologias Utilizadas

- [.NET Core](https://dotnet.microsoft.com/)
- [Entity Framework Core](https://docs.microsoft.com/ef/core/)
- [ASP.NET Core](https://docs.microsoft.com/aspnet/core/)
- [Swagger](https://swagger.io/)

## Instalação

Instruções para instalar e rodar o projeto localmente.

```bash
# Clone o repositório
git clone https://github.com/viniciusbenicio/GerenciadorLivro.git

# Navegue até o diretório do projeto
cd nome-do-projeto

# Restaure as dependências
dotnet restore

# Compile o projeto
dotnet build

# Execute a aplicação
dotnet run
```

## Como Usar

Explique como utilizar o projeto, com exemplos de código, comandos ou capturas de tela.

```bash
# Execute a aplicação
dotnet run
```

Acesse em seu navegador: `http://localhost:44380`.

## Rotas da API

### Endpoints de Autenticação

- **Login do Usuário**

  `PUT /api/usuarios/login`
  
  Request Body:
  ```json
  {
    "email": "string",
    "senha": "string"
  }
  ```

  Response:
  ```json
  {
    "token": "string"
  }
  ```

### Emprestimos

- `GET /api/Emprestimos`
  - Descrição: Retorna todos os empréstimos com possibilidade de busca.
  - Parâmetros:
    - `query` (opcional): String de busca.

- `POST /api/Emprestimos`
  - Descrição: Cria um novo empréstimo.
  - Corpo da Requisição:
    ```json
    {
      "usuarioId": 1,
      "livroId": 1,
      "prazoDias": 14
    }
    ```

- `GET /api/Emprestimos/{id}`
  - Descrição: Retorna um empréstimo pelo ID.
  - Parâmetros:
    - `id` (obrigatório): ID do empréstimo.

- `PUT /api/Emprestimos/{id}`
  - Descrição: Atualiza um empréstimo pelo ID.
  - Parâmetros:
    - `id` (obrigatório): ID do empréstimo.
  - Corpo da Requisição:
    ```json
    {
      "id": 1,
      "idLivro": 1,
      "dataEmprestimo": "2023-01-01T00:00:00"
    }
    ```

- `DELETE /api/Emprestimos/{id}`
  - Descrição: Remove um empréstimo pelo ID.
  - Parâmetros:
    - `id` (obrigatório): ID do empréstimo.

### Livros

- `GET /api/livros`
  - Descrição: Retorna todos os livros com possibilidade de busca.
  - Parâmetros:
    - `query` (opcional): String de busca.

- `POST /api/livros`
  - Descrição: Cria um novo livro.
  - Corpo da Requisição:
    ```json
    {
      "titulo": "Título do Livro",
      "autor": "Autor do Livro",
      "isbn": "1234567890",
      "anoPublicacao": 2023
    }
    ```

- `GET /api/livros/{id}`
  - Descrição: Retorna um livro pelo ID.
  - Parâmetros:
    - `id` (obrigatório): ID do livro.

- `PUT /api/livros/{id}`
  - Descrição: Atualiza um livro pelo ID.
  - Parâmetros:
    - `id` (obrigatório): ID do livro.
  - Corpo da Requisição:
    ```json
    {
      "id": 1,
      "titulo": "Título Atualizado",
      "autor": "Autor Atualizado",
      "isbn": "0987654321",
      "anoPublicacao": 2024
    }
    ```

- `DELETE /api/livros/{id}`
  - Descrição: Remove um livro pelo ID.
  - Parâmetros:
    - `id` (obrigatório): ID do livro.

### Usuarios

- `GET /api/usuarios`
  - Descrição: Retorna todos os usuários com possibilidade de busca.
  - Parâmetros:
    - `query` (opcional): String de busca.

- `POST /api/usuarios`
  - Descrição: Cria um novo usuário.
  - Corpo da Requisição:
    ```json
    {
      "nome": "Nome do Usuário",
      "email": "email@exemplo.com"
    }
    ```

- `GET /api/usuarios/{id}`
  - Descrição: Retorna um usuário pelo ID.
  - Parâmetros:
    - `id` (obrigatório): ID do usuário.

- `PUT /api/usuarios/{id}`
  - Descrição: Atualiza um usuário pelo ID.
  - Parâmetros:
    - `id` (obrigatório): ID do usuário.
  - Corpo da Requisição:
    ```json
    {
      "id": 1,
      "nome": "Nome Atualizado",
      "email": "email@atualizado.com"
    }
    ```

- `DELETE /api/usuarios/{id}`
  - Descrição: Remove um usuário pelo ID.
  - Parâmetros:
    - `id` (obrigatório): ID do usuário.

## Saiba Mais - Next Wave Education

- Com o Método .NET do Luis Felipe [@luisLinkedin](https://www.linkedin.com/in/luisdeol/), enfrentamos constantes desafios na plataforma, estimulando-nos a praticar o que aprendemos. Um desses desafios consistiu no desenvolvimento do Projeto 1: Gerenciador de Biblioteca.
- Além do desenvolvimento básico, foram propostos desafios extras para impulsionar nosso aprendizado, como:
  - Validar Dados (PLUS 1)
  - Cadastrar um Usuário (PLUS 1)
  - Registrar um Empréstimo (PLUS 1)
  - Inserir Data de Devolução (PLUS 2)
  - Realizar a Devolução de um Livro (PLUS 2) 
    - Emitir Mensagem Com Dias de Atraso (Se Estiver) ou Se Estiver em Dia (PLUS 2)


## Contato

LinkedIn - [@ViniciusBenicio](https://www.linkedin.com/in/viniciusbenicio/)
