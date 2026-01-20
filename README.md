# Gym API

Este projeto foi desenvolvido no início dos meus estudos em .NET e arquitetura de APIs. Ele tem como objetivo servir de base para aprendizado de conceitos como camadas de negócio, repositórios, validações, autenticação e boas práticas de desenvolvimento.

## Sobre o Projeto

O Gym API é uma API RESTful para gerenciamento de usuários de uma academia, implementando autenticação, operações CRUD, validações e separação de responsabilidades em múltiplas camadas:

- **Business**: Lógica de negócio, validações e serviços
- **Entities**: Entidades do domínio
- **Infra.Storage**: Persistência de dados (Dapper e Entity Framework)
- **Presentation**: Camada de API (Controllers, Middlewares, Configurações)

O projeto utiliza .NET, Entity Framework, Dapper, AutoMapper e FluentValidation.

## Aviso

> Este projeto foi feito no início dos meus estudos, então pode conter decisões e padrões que hoje eu faria diferente. Serve como registro da minha evolução e aprendizado.

---

# Como Executar

1. **Pré-requisitos:**
   - [.NET 8 SDK](https://dotnet.microsoft.com/download)
   - SQL Server (ou ajuste a connection string para seu banco)

2. **Clone o repositório:**

   ```bash
   git clone <url-do-repositorio>
   ```

3. **Configure o banco de dados:**
   - Ajuste a connection string em `Presentation/appsettings.Development.json` conforme seu ambiente.

4. **Rode as migrations (se necessário):**
   - O projeto já possui mapeamentos, mas você pode rodar migrations se desejar customizar o banco.

5. **Execute a API:**

   ```bash
   dotnet run --project Presentation/Api.csproj
   ```

6. **Acesse a documentação Swagger:**
   - Acesse `http://localhost:5000/swagger` (ou porta configurada) para testar os endpoints.

---

# Testes

Para rodar os testes automatizados:

```bash
dotnet test Test/Test.csproj
```

---

# Contribuição

Fique à vontade para sugerir melhorias. Toda sugestão é bem-vinda, especialmente para quem está começando!

---

---

> Projeto criado para fins de estudo e evolução profissional.
