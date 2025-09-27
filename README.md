# 📒 CallFlow - Sistema de Chamados - Em Desenvolvimento

**CallFlow** é um projeto pessoal desenvolvido em **ASP.NET Core**, inspirado no VerdanaDesk.  
Ele permite gerenciar chamados e usuários de forma simples, controlando permissões, grupos e status de chamados.

---

## ✨ Visão Geral

CallFlow permite que você:

- Crie, atualize, visualize e exclua chamados
- Gerencie usuários com permissões de **Admin** ou **Usuário**
- Adicione ou remova grupos de usuários
- Controle a visualização de chamados de acordo com os grupos do usuário
- Simule um sistema de chamados sem a necessidade de banco de dados (armazenamento em memória)

---

## 📁 Tecnologias Utilizadas

| Tecnologia       | Função                                           |
|-----------------|--------------------------------------------------|
| C#               | Linguagem principal do projeto                  |
| ASP.NET Core     | Framework para criação de APIs REST             |
| Visual Studio    | IDE recomendada para desenvolvimento           |
| Entity Framework Core          | Persistência e manipulação de dados no banco       |
| DTOs          | Transferência segura de dados entre frontend/backend       |
| AdminAuth          | Segurança básica de endpoints administrativos       |
| Scalar          | Simplifica endpoints e documentação de APIs       |

---

## 📂 Estrutura do Projeto

```plaintext
**CallFlow/**
├── **Controllers/**
│   ├── ChamadoController.cs
│   └── UsuariosController.cs
├── **Data/**
│   └── AppDbContext.cs
├── **DTOs/** (Data Transfer Objects)
│   ├── AdminAuth - Cópia.cs
│   ├── AdminAuth.cs
│   ├── AdminUserRequest.cs
│   └── CreateUserRequest.cs
├── **Migrations/**
├── **Models/**
│   ├── Chamados.cs
│   └── Usuario.cs
├── **Properties/**
└── **Arquivos na Raiz:**
    ├── .gitignore
    ├── appsettings.Development.json
    ├── appsettings.json
    ├── CallFlow.csproj (Arquivo de projeto C#)
    ├── CallFlow.http (Arquivo para testar endpoints HTTP)
    ├── Program.cs (Ponto de entrada da aplicação)
    ├── README.md
    └── CallFlow.sln (Arquivo de solução do Visual Studio)
```
---
## 🔗 Endpoints da API

# Endpoints da API

## Chamados

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/chamado?usuarioId=1` | Lista chamados visíveis para um usuário |
| GET | `/api/chamado/{id}` | Consulta um chamado específico pelo ID |
| POST | `/api/chamado` | Cria um novo chamado |
| PUT | `/api/chamado/{id}` | Atualiza um chamado existente |
| DELETE | `/api/chamado/{id}` | Deleta um chamado |

## Usuários

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/usuario?adminId={id}&senha={senha}` | Lista todos os usuários. Requer autenticação de administrador. |
| GET | `/api/usuario/{id}?adminId={id}&senha={senha}` | Consulta um usuário específico pelo ID. Requer autenticação de administrador. |
| GET | `	/api/usuario/email/{email}?adminId={id}&senha={senha}` | Consulta um usuário específico pelo Email. Requer autenticação de administrador.) |
| POST | `/api/usuario?adminId=2` | Cria um novo usuário. Requer as credenciais do administrador (adminAuth) no corpo da requisição. |
| PUT | `/api/usuario/{id}?adminId=2` | Atualiza um usuário existente (admin) |
| PUT | `/api/usuario/email?email={email}&adminId=2` | Atualiza um usuário existente pelo ID. Requer as credenciais do administrador (AdminAuth) e os novos dados no corpo. |

