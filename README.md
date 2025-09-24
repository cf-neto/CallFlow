# 📒 CallFlow - Sistema de Chamados Pessoal

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
| Swagger          | Testes e documentação de endpoints da API       |

---

## 📂 Estrutura do Projeto

```plaintext
CallFlow/
├── Controllers/
│   ├── ChamadoController.cs   # Gerencia chamados (CRUD)
│   └── UsuarioController.cs  # Gerencia usuários e grupos
├── Models/
│   ├── Chamado.cs             # Modelo de chamado
│   └── Usuario.cs             # Modelo de usuário e enum Papel
├── Program.cs                 # Configuração principal do ASP.NET Core
├── CallFlow.csproj            # Projeto ASP.NET Core
└── README.md                  # Documentação do projeto
```
---
## 🔗 Endpoints da API

### Chamados

| Método | Endpoint                  | Descrição                                   |
|--------|---------------------------|--------------------------------------------|
| GET    | /api/chamado?usuarioId=1  | Lista chamados visíveis para um usuário    |
| GET    | /api/chamado/{id}         | Consulta um chamado específico pelo ID     |
| POST   | /api/chamado              | Cria um novo chamado                        |
| PUT    | /api/chamado/{id}         | Atualiza um chamado existente              |
| DELETE | /api/chamado/{id}         | Deleta um chamado                           |

### Usuários

| Método | Endpoint                                           | Descrição                                  |
|--------|---------------------------------------------------|-------------------------------------------|
| GET    | /api/usuario?adminId=2                            | Lista todos os usuários (apenas admin)    |
| GET    | /api/usuario/{id}?adminId=2                      | Consulta usuário específico (admin)       |
| POST   | /api/usuario?adminId=2                            | Cria um novo usuário (admin)              |
| PUT    | /api/usuario/{id}?adminId=2                      | Atualiza um usuário existente (admin)     |
| DELETE | /api/usuario?id=3&adminId=2                      | Remove um usuário (admin)                 |
| POST   | /api/usuario/{id}/adicionar-grupo?adminId=2     | Adiciona um grupo ao usuário (admin)      |
| DELETE | /api/usuario/{id}/remover-grupo?adminId=2       | Remove um grupo do usuário (admin)        |
