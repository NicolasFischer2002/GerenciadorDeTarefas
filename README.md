# Gerenciador de Tarefas

Sistema para gerenciamento de tarefas com API em ASP.NET Core e front-end em WPF.

---

# Tecnologias utilizadas

- .NET 8.0 / C#
- ASP.NET Core Web API
- WPF
- Entity Framework Core
- SQL Server 2025 Express
- SQL Server Management Studio

---

# Funcionalidades

- Criar tarefa
- Listar tarefas
- Buscar tarefa por Id
- Atualizar tarefa
- Excluir tarefa
- Filtrar tarefas por status:
  - Pendente
  - EmProgresso
  - Concluída

---

# Estrutura do projeto

- `Domain`
  - Entidades
  - Regras de negócio
  - Value Objects

- `Application`
  - Commands
  - Queries
  - Handlers

- `Infrastructure`
  - Persistência
  - Entity Framework Core
  - Repositórios

- `Presentation`
  - Controllers
  - Endpoints HTTP

- `FrontEnd`
  - Aplicação WPF

---

# Pré-requisitos

- .NET 8 SDK
- SQL Server Express
- SQL Server Management Studio
- Visual Studio 2022/2026 ou VS Code

---

# Instalação do SQL Server

## SQL Server Express

https://www.microsoft.com/pt-br/sql-server/sql-server-downloads

## SQL Server Management Studio

https://learn.microsoft.com/pt-br/ssms/install/install

---

# Banco de dados

O projeto utiliza SQL Server.

A configuração foi feita de forma simples para ambiente local e desenvolvimento.

Se necessário, ajuste a connection string da API antes de executar o projeto.

---

# Como executar o projeto

## 1. Executar a API

No terminal da IDE:

```bash
dotnet run --project BackEnd/Contextos/ContextoTarefa/Apresentacao
```

A API precisa estar em execução antes de abrir o WPF.

---

## 2. Executar o WPF

Abra o projeto WPF no Visual Studio e execute normalmente.

Ou via terminal:

```bash
dotnet run --project FrontEnd/UI/GerenciadorDeTarefas
```

---

# Como executar os testes

```bash
dotnet test
```

---

# Arquitetura

O projeto foi desenvolvido utilizando arquitetura em camadas:

- Domain
- Application
- Infrastructure
- Presentation

Também foram aplicados conceitos de:

- SOLID
- Clean Code
- DDD

---

# Regras de negócio implementadas

- Título obrigatório
- Título limitado a 100 caracteres
- Controle de status:
  - Pendente
  - EmProgresso
  - Concluída
- Apenas tarefas pendentes podem ser iniciadas
- Apenas tarefas em progresso podem ser concluídas
- Apenas tarefas concluídas podem ser reabertas

---

# Observações

- O front-end consome diretamente a API REST.
- As validações principais são feitas no domínio.
- O projeto foi desenvolvido para fins de estudo e avaliação técnica.

---

# Swagger

http://localhost:5277/swagger/index.html

---

# Vídeo de demonstração

https://www.youtube.com/watch?v=RESlmqsEoyQ

---

# Repositório

https://github.com/NicolasFischer2002/GerenciadorDeTarefas