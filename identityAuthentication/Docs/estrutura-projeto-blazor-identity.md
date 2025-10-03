# Estrutura do Projeto: identityAuthentication

Projeto Blazor Web App criado no Visual Studio 2022 com autenticação via ASP.NET Identity.

---

## 📁 Raiz do Projeto (`identityAuthentication/`)
Contém os arquivos principais e a configuração do app.

```
identityAuthentication/
│
├── Program.cs
├── identityAuthentication.csproj
├── appsettings.json
├── appsettings.Development.json
├── Properties/                                 // Metadados do projeto
│   ├── launchSettings.json                     // Configuração de execução local (URLs, perfis, etc)
│   ├── serviceDependencies.json                // Dependências externas (banco, storage, etc)
│   └── serviceDependencies.local.json          // Versão local das dependências
│
├── wwwroot/                                    // Arquivos estáticos (servidos diretamente ao navegador)
│   ├── favicon.png                             // Ícone do site
│   ├── app.css                                 // Estilos principais do app
│   ├── images/
│   │   ├── BebopLogo.png
│   │   └── Logo.png
│   └── lib/                                    // Bibliotecas JS/CSS
│       ├── fontawesome/                        // Framework fontawesome para UI e icones
│       │   └── dfontawesome-free-7.0.1-webist/
│       │       ├── css/                        // Estilos prontos do fontawesome
│       │       └── js/                         // Scripts JS do fontawesome
│       │
│       └── bootstrap/                          // Framework Bootstrap para UI responsiva
│           └── dist/
│               ├── css/                        // Estilos prontos do Bootstrap
│               └── js/                         // Scripts JS do Bootstrap
│
├── Components/                                 // Componentes Blazor reutilizáveis (.razor)
│   ├── _Imports.razor                          // Importações de namespaces comuns
│   ├── App.razor                               // Componente raiz da aplicação Blazor
│   ├── Routes.razor                            // Define as rotas e componentes do app
│   ├── Account/                                // Telas e lógicas de autenticação
│   │   ├── IdentityComponentsEndpointRouteBuilderExtensions.cs // Extensões de roteamento do Identity
│   │   ├── IdentityNoOpEmailSender.cs          // Implementação de envio de email (fake para dev)
│   │   ├── IdentityRedirectManager.cs          // Controla redirecionamentos pós-login/logout
│   │   ├── IdentityRevalidatingAuthenticationStateProvider.cs // Revalida sessão autenticada periodicamente
│   │   ├── IdentityUserAccessor.cs             // Acesso ao usuário autenticado atual
│   │   ├── Pages/                              // Páginas completas (login, registro, reset de senha, etc)
│   │   │   ├── Manage/                         // Gerenciamento de conta logada (senha, 2FA, dados, etc)
│   │   │   │   ├── _Imports.razor
│   │   │   │   ├── ChangePassword.razor        // Alterar senha
│   │   │   │   ├── DeletePersonalData.razor
│   │   │   │   ├── Disable2fa.razor
│   │   │   │   ├── Email.razor
│   │   │   │   ├── EnableAuthenticator.razor   // Habilitar autenticação de 2 fatores
│   │   │   │   ├── ExternalLogins.razor        // Gerenciar logins externos (Google, Microsoft, etc)
│   │   │   │   ├── GenerateRecoveryCodes.razor
│   │   │   │   ├── Index.razor
│   │   │   │   ├── PersonalData.razor          // Exportar ou excluir dados pessoais
│   │   │   │   ├── ResetAuthenticator.razor
│   │   │   │   ├── SetPassword.razor
│   │   │   │   └── TwoFactorAuthentication.razor
│   │   │   ├── _Imports.razor
│   │   │   ├── AccessDenied.razor              // Página de acesso negado
│   │   │   ├── ConfirmEmail.razor              // Confirmação de email
│   │   │   ├── ConfirmEmailChange.razor
│   │   │   ├── ExternalLogin.razor
│   │   │   ├── ForgotPassword.razor            // Recuperação de senha
│   │   │   ├── ForgotPasswordConfirmation.razor
│   │   │   ├── InvalidPasswordReset.razor
│   │   │   ├── InvalidUser.razor
│   │   │   ├── Lockout.razor                   // Tela de bloqueio temporário
│   │   │   ├── Login.razor                     // Tela de login do usuário
│   │   │   ├── LoginWith2fa.razor
│   │   │   ├── LoginWithRecoveryCode.razor
│   │   │   ├── Register.razor                  // Tela de cadastro de usuário
│   │   │   ├── RegisterConfirmation.razor
│   │   │   ├── ResendEmailConfirmation.razor
│   │   │   ├── ResetPassword.razor
│   │   │   └── ResetPasswordConfirmation.razor
│   │   └── Shared/                             // Componentes usados em várias telas de conta
│   │       ├── ExternalLoginPicker.razorz
│   │       ├── ManageLayout.razor              // Layout padrão da área de gerenciamento
│   │       ├── ManageNavMenu.razor             // Menu lateral de navegação da conta
│   │       ├── RedirectToLogin.razor           // Redireciona usuários não logados
│   │       ├── ShowRecoveryCodes.razor
│   │       └── StatusMessage.razor             // Exibe mensagens de sucesso/erro
│   │
│   ├── Layout/                                 // Layouts e navegação geral da aplicação
│   │   ├── MainLayout.razor                    // Layout principal da aplicação
│   │   ├── MainLayout.razor.css                // Estilo específico do layout principal
│   │   ├── NavMenu.razor                       // Menu de navegação lateral/topo
│   │   └── NavMenu.razor.css                   // CSS do menu de navegação
│   │
│   └── Pages/                                  // Páginas de navegação geral 
│       ├── Auth.razor                          // Tela de autenticação personalizada
│       ├── CadastroEmpresa.razor
│       ├── CadastroEmpresa.razor.css
│       ├── CadastroSetor.razor
│       ├── CadastroSetor.razor.css
│       ├── Categorias.razor
│       ├── Categorias.razor.css
│       ├── Colaboradores.razor
│       ├── Colaboradores.razor.css
│       ├── Debug.razor
│       ├── Error.razor                          // Página de erro genérico│       
│       ├── Faqs.razor
│       ├── Faqs.razor.css
│       ├── Home.razor
│       ├── Home.razor.css
│       ├── NovoChamado.razor
│       ├── NovoChamado.razor.css
│       ├── Painel.razor
│       ├── Painel.razor.css
│       ├── Prioridades.razor
│       ├── Prioridades.razor.css
│       ├── RolesPage.razor
│       ├── RolesPage.razor.css
│       ├── Status.razor
│       ├── Status.razor.css
│       ├── TicketDetalhes.razor
│       ├── TicketDetalhes.razor.css
│       ├── Tickets.razor       
│       └── Tickets.razor.css
│
│
├── Data/                                       // Acesso a dados e modelos do Entity Framework
│   ├── ApplicationDbContext.cs                 // Contexto do EF Core (controla acesso ao banco)
│   ├── ApplicationUser.cs                      // Modelo de usuário (extensão de IdentityUser)
│   ├── Categoria.cs
│   ├── Chamado.cs
│   ├── ChamadoHistorico.cs
│   ├── Empresa.cs
│   ├── FAQ.cs
│   ├── Prioridade.cs
│   ├── Setor.cs
│   └── StatusChamado.cs
│
├── appsettings.json                            // Configuração principal do app (connection strings, etc)
├── appsettings.Development.json                // Configuração específica do ambiente de desenvolvimento
└── Program.cs                                  // Ponto de entrada principal (configura serviços e rotas)
```

---

## 🧩 Esquema de Banco de Dados: Sistema de Chamados com ASP.NET Identity

Documentação do esquema de banco de dados (PostgreSQL/Supabase) para a aplicação Blazor Web App identityAuthentication.

Este modelo combina as tabelas padrão do ASP.NET Identity (para autenticação e autorização) com as tabelas personalizadas do Sistema de Chamados (Suporte Técnico).

---

## 📘 Visão Geral

O esquema é dividido em duas partes principais:
- Tabelas de Identidade (Padrão): Gerenciadas pelo ASP.NET Identity para login, roles e segurança.
- Tabelas da Aplicação (Chamados): Tabelas personalizadas para gerenciar Empresas, Setores, Chamados, FAQs, etc.

---

### 🧱 1. Tabelas do ASP.NET Identity (Padrão)

Contém as tabelas internas de autenticação e autorização do ASP.NET Identity.

```bash
| Tabela             | Finalidade principal                                       |
| ------------------ | ---------------------------------------------------------- |
| `AspNetUsers`      | Armazena informações de usuários (customizada).            |
| `AspNetRoles`      | Armazena papéis (grupos de permissão).                     |
| `AspNetUserRoles`  | Faz a relação entre usuários e papéis.                     |
| `AspNetUserClaims` | Guarda declarações personalizadas de usuários.             |
| `AspNetRoleClaims` | Declarações associadas aos papéis.                         |
| `AspNetUserLogins` | Armazena logins externos (Google, Microsoft, etc.).        |
| `AspNetUserTokens` | Tokens persistentes (lembrar login, reset de senha, etc.). |
```

---

#### 🧱 1.1 Tabela AspNetUsers

Contém os dados de perfil, autenticação e segurança de cada usuário.

##### 🔹 Função:

É a tabela central do Identity. Todos os relacionamentos (claims, roles, tokens, logins) referenciam usuários a partir de seu Id.

```
| Coluna                 | Tipo        | Descrição                                     |
| ---------------------- | ----------- | --------------------------------------------- |
| `Id`                   | `varchar`   | Identificador único do usuário (GUID). **PK** |
| `UserName`             | `varchar`   | Nome de usuário.                              |
| `NormalizedUserName`   | `varchar`   | Nome de usuário em maiúsculas (para buscas).  |
| `Email`                | `varchar`   | Endereço de e-mail do usuário.                |
| `NormalizedEmail`      | `varchar`   | E-mail normalizado (para comparação).         |
| `EmailConfirmed`       | `boolean`   | Indica se o e-mail foi confirmado.            |
| `PasswordHash`         | `text`      | Hash da senha.                                |
| `SecurityStamp`        | `text`      | Valor usado para invalidar tokens antigos.    |
| `ConcurrencyStamp`     | `text`      | Controle de concorrência.                     |
| `PhoneNumber`          | `text`      | Número de telefone (opcional).                |
| `PhoneNumberConfirmed` | `boolean`   | Indica se o telefone foi validado.            |
| `TwoFactorEnabled`     | `boolean`   | Indica se o 2FA está habilitado.              |
| `LockoutEnd`           | `timestamp` | Data de expiração do bloqueio do usuário.     |
| `LockoutEnabled`       | `boolean`   | Indica se o bloqueio de login pode ocorrer.   |
| `AccessFailedCount`    | `integer`   | Contagem de tentativas de login falhas.       |
```

##### 🔹 Customização (ApplicationUser)

A tabela foi estendida para incluir campos específicos da aplicação, correspondendo à classe ApplicationUser.cs.

Coluna	Tipo	Chave	Descrição
IdEmpresa	uuid	FK → Empresas(IdEmpresa)	Vincula o usuário a uma empresa.
IdSetor	uuid	FK → Setores(IdSetor)	Vincula o usuário a um setor.

##### 🔹 Índices:

PK: Id

FKs: IdEmpresa → Empresas(IdEmpresa), IdSetor → Setores(IdSetor)

---

#### 🧱 1.2 Tabela AspNetRoles

Guarda papéis (roles) — grupos de permissão como "Administrator", "User", "Manager".

##### 🔹 Colunas:

```
| Coluna             | Tipo      | Descrição                             |
| ------------------ | --------- | ------------------------------------- |
| `Id`               | `varchar` | Identificador único do papel. **PK**  |
| `Name`             | `varchar` | Nome do papel (ex.: `Administrator`). |
| `NormalizedName`   | `varchar` | Nome normalizado (maiúsculo).         |
| `ConcurrencyStamp` | `text`    | Controle de concorrência.             |
```

##### 🔹 Índices:

PK: Id

---

#### 🧱 1.3 Tabela AspNetUserRoles

Faz a relação N:N entre AspNetUsers e AspNetRoles.

##### 🔹 Colunas:

```
| Coluna   | Tipo      | Chave                         |
| -------- | --------- | ----------------------------- |
| `UserId` | `varchar` | **PK / FK → AspNetUsers(Id)** |
| `RoleId` | `varchar` | **PK / FK → AspNetRoles(Id)** |
```

##### 🔹 Índices:

PK composta: (UserId, RoleId)

---

#### 🧱 1.4 Tabela AspNetUserClaims

Armazena claims personalizadas (declarações extras) associadas a um usuário individual.

##### 🔹 Colunas:

```
| Coluna       | Tipo      | Chave                    | Descrição                          |
| ------------ | --------- | ------------------------ | ---------------------------------- |
| `Id`         | `serial`  | **PK**                   | Identificador da claim.            |
| `UserId`     | `varchar` | **FK → AspNetUsers(Id)** | Usuário dono da claim.             |
| `ClaimType`  | `text`    |                          | Tipo da claim (ex.: `department`). |
| `ClaimValue` | `text`    |                          | Valor da claim.                    |
```

---

#### 🧱 1.5 Tabela AspNetRoleClaims

Guarda claims ligadas a papéis (roles), herdadas por todos os usuários daquele papel.

##### 🔹 Colunas:

```
| Coluna       | Tipo      | Chave                    | Descrição               |
| ------------ | --------- | ------------------------ | ----------------------- |
| `Id`         | `serial`  | **PK**                   | Identificador da claim. |
| `RoleId`     | `varchar` | **FK → AspNetRoles(Id)** | Papel associado.        |
| `ClaimType`  | `text`    |                          | Tipo da claim.          |
| `ClaimValue` | `text`    |                          | Valor da claim.         |
```

---

#### 🧱 1.6 Tabela AspNetUserLogins

Registra os logins de provedores externos (Google, Microsoft, etc.) vinculados a usuários.

##### 🔹 Colunas:

```
| Coluna                | Tipo      | Chave                    | Descrição                          |
| --------------------- | --------- | ------------------------ | ---------------------------------- |
| `LoginProvider`       | `varchar` | **PK**                   | Nome do provedor (ex.: Google).    |
| `ProviderKey`         | `varchar` | **PK**                   | ID do usuário no provedor externo. |
| `ProviderDisplayName` | `text`    |                          | Nome descritivo do provedor.       |
| `UserId`              | `varchar` | **FK → AspNetUsers(Id)** | Usuário vinculado.                 |
```

---

#### 🧱 1.7 Tabela AspNetUserTokens

Armazena tokens persistentes (autenticação, redefinição de senha, 2FA, etc.).

##### 🔹 Colunas:

```
| Coluna          | Tipo      | Chave                         | Descrição                            |
| --------------- | --------- | ----------------------------- | ------------------------------------ |
| `UserId`        | `varchar` | **PK / FK → AspNetUsers(Id)** | Usuário associado.                   |
| `LoginProvider` | `varchar` | **PK**                        | Origem do token.                     |
| `Name`          | `varchar` | **PK**                        | Tipo de token (ex.: `RefreshToken`). |
| `Value`         | `text`    |                               | Valor do token.                      |
```

---

### 🧱 2. Tabelas da Aplicação (Sistema de Chamados)

Tabelas personalizadas que representam a lógica de negócio do sistema de suporte técnico.

---

#### 🧱 2.1 Tabela Empresas

```
| Coluna        | Tipo        | Descrição                              |
| ------------- | ----------- | -------------------------------------- |
| `IdEmpresa`   | `uuid`      | Identificador único da empresa. **PK** |
| `NomeEmpresa` | `varchar`   | Nome da empresa.                       |
| `Ativo`       | `boolean`   | Indica se o cadastro está ativo.       |
| `DataCriacao` | `timestamp` | Data de registro.                      |
```

---

#### 🧱 2.2 Tabela Setores

```
| Coluna        | Tipo        | Chave                        | Descrição                        |
| ------------- | ----------- | ---------------------------- | -------------------------------- |
| `IdSetor`     | `uuid`      | **PK**                       | Identificador único do setor.    |
| `NomeSetor`   | `varchar`   |                              | Nome do setor.                   |
| `IdEmpresa`   | `uuid`      | **FK → Empresas(IdEmpresa)** | Empresa à qual o setor pertence. |
| `Ativo`       | `boolean`   |                              | Indica se está ativo.            |
| `DataCriacao` | `timestamp` |                              | Data de registro.                |
```

---

#### 🧱 2.3 Tabela categorias

```
| Coluna          | Tipo        | Descrição                            |
| --------------- | ----------- | ------------------------------------ |
| `idcategoria`   | `uuid`      | Identificador único. **PK**          |
| `nomecategoria` | `varchar`   | Nome da categoria (ex.: “Hardware”). |
| `descricao`     | `text`      | Descrição opcional.                  |
| `ativo`         | `boolean`   | Indica se está ativa.                |
| `datacriacao`   | `timestamp` | Data de registro.                    |
```

---

#### 🧱 2.4 Tabela prioridades

```
| Coluna           | Tipo      | Descrição                         |
| ---------------- | --------- | --------------------------------- |
| `idprioridade`   | `uuid`    | Identificador único. **PK**       |
| `nomeprioridade` | `varchar` | Nome da prioridade (ex.: “Alta”). |
| `nivelurgencia`  | `integer` | Valor numérico para ordenação.    |
| `corhex`         | `varchar` | Cor para UI (ex.: `#FF0000`).     |
```

---

#### 🧱 2.5 Tabela statuschamados

```
| Coluna       | Tipo      | Descrição                   |
| ------------ | --------- | --------------------------- |
| `idstatus`   | `uuid`    | Identificador único. **PK** |
| `nomestatus` | `varchar` | Nome do status.             |
```

---

#### 🧱 2.6 Tabela faqs

```
| Coluna        | Tipo        | Chave                            | Descrição                   |
| ------------- | ----------- | -------------------------------- | --------------------------- |
| `idfaq`       | `uuid`      | **PK**                           | Identificador único da FAQ. |
| `pergunta`    | `text`      |                                  | Pergunta.                   |
| `resposta`    | `text`      |                                  | Resposta.                   |
| `ativo`       | `boolean`   |                                  | Indica se está visível.     |
| `datacriacao` | `timestamp` |                                  | Data de registro.           |
| `idcategoria` | `uuid`      | **FK → categorias(idcategoria)** | Categoria da FAQ.           |
```

---

#### 🧱 2.7 Tabela chamados

```
| Coluna           | Tipo        | Chave                              | Descrição                        |
| ---------------- | ----------- | ---------------------------------- | -------------------------------- |
| `IdChamado`      | `uuid`      | **PK**                             | Identificador único do chamado.  |
| `Titulo`         | `varchar`   |                                    | Título do chamado.               |
| `Descricao`      | `text`      |                                    | Descrição detalhada do problema. |
| `DataAbertura`   | `timestamp` |                                    | Data de criação do ticket.       |
| `DataFechamento` | `timestamp` |                                    | Data de conclusão (opcional).    |
| `IdSolicitante`  | `varchar`   | **FK → AspNetUsers(Id)**           | Usuário que abriu o chamado.     |
| `IdEmpresa`      | `uuid`      | **FK → Empresas(IdEmpresa)**       | Empresa do solicitante.          |
| `IdSetor`        | `uuid`      | **FK → Setores(IdSetor)**          | Setor do solicitante.            |
| `IdAtendente`    | `varchar`   | **FK → AspNetUsers(Id)**           | Técnico responsável.             |
| `IdCategoria`    | `uuid`      | **FK → categorias(idcategoria)**   | Categoria do chamado.            |
| `IdPrioridade`   | `uuid`      | **FK → prioridades(idprioridade)** | Nível de urgência.               |
| `IdStatus`       | `uuid`      | **FK → statuschamados(idstatus)**  | Status atual do chamado.         |
```

---

#### 🧱 2.8 Tabela chamadohistorico

```
| Coluna           | Tipo        | Chave                             | Descrição                         |
| ---------------- | ----------- | --------------------------------- | --------------------------------- |
| `IdHistorico`    | `uuid`      | **PK**                            | Identificador único do histórico. |
| `IdChamado`      | `uuid`      | **FK → chamados(IdChamado)**      | Chamado ao qual pertence.         |
| `IdUsuario`      | `varchar`   | **FK → AspNetUsers(Id)**          | Usuário que registrou a ação.     |
| `Comentario`     | `text`      |                                   | Texto do comentário.              |
| `DataComentario` | `timestamp` |                                   | Data da ação.                     |
| `EraStatusId`    | `uuid`      | **FK → statuschamados(idstatus)** | Status anterior.                  |
| `NovoStatusId`   | `uuid`      | **FK → statuschamados(idstatus)** | Novo status.                      |
```

---

### 🔗 3. Diagrama de Relacionamento (ERD)

erDiagram
    AspNetUsers ||--o{ AspNetUserClaims : "possui (claims)"
    AspNetUsers ||--o{ AspNetUserLogins : "possui (logins)"
    AspNetUsers ||--o{ AspNetUserRoles : "pertence (roles)"
    AspNetUsers ||--o{ AspNetUserTokens : "possui (tokens)"
    AspNetRoles ||--o{ AspNetRoleClaims : "possui (claims)"
    AspNetRoles ||--o{ AspNetUserRoles : "agrupa (usuários)"

    Empresas ||--o{ Setores : "contém"
    categorias ||--o{ faqs : "agrupa"

    Empresas ||--o{ AspNetUsers : "vincula (usuário)"
    Setores ||--o{ AspNetUsers : "vincula (usuário)"
    
    chamados }o--|| AspNetUsers : "solicitado por"
    chamados }o--|| AspNetUsers : "atendido por"
    chamados }o--|| Empresas : "pertence a"
    chamados }o--|| Setores : "pertence a"
    chamados }o--|| categorias : "classificado como"
    chamados }o--|| prioridades : "tem prioridade"
    chamados }o--|| statuschamados : "tem status"
    
    chamadohistorico }o--|| chamados : "pertence ao"
    chamadohistorico }o--|| AspNetUsers : "registrado por"
    chamadohistorico }o--|| statuschamados : "era (status)"
    chamadohistorico }o--|| statuschamados : "novo (status)"

---

### 💿 4. Contexto do Projeto C# (POCOs)

Este esquema é consumido por um projeto Blazor Web App (Identity Authentication).

```
| Classe                    | Tabela Correspondente                                      |
| ------------------------- | ---------------------------------------------------------- |
| `ApplicationUser.cs`      | `AspNetUsers`                                              |
| `Empresa.cs`              | `Empresas`                                                 |
| `Setor.cs`                | `Setores`                                                  |
| `Categoria.cs`            | `categorias`                                               |
| `Prioridade.cs`           | `prioridades`                                              |
| `StatusChamado.cs`        | `statuschamados`                                           |
| `Chamado.cs`              | `chamados`                                                 |
| `ChamadoHistorico.cs`     | `chamadohistorico`                                         |
| `FAQ.cs`                  | `faqs`                                                     |
| `ApplicationDbContext.cs` | Contexto EF Core com mapeamento de todas as classes acima. |
```

---

### 🛑 5. Regras de Desenvolvimento

* Database First (Manual): Criação e alteração de tabelas via SQL (ex: Supabase Editor).
* App Data-Only: O app Blazor não gerencia o esquema, apenas faz CRUD.
* Sem Migrations: O EF Core não utiliza migrations; foco é nas operações de dados e na camada de apresentação.

---

### • WARNING: This schema is for context only and is not meant to be run.

Table order and constraints may not be valid for execution.

```
CREATE TABLE public.AspNetRoleClaims (
  Id integer NOT NULL DEFAULT nextval('"AspNetRoleClaims_Id_seq"'::regclass),
  RoleId character varying NOT NULL,
  ClaimType text,
  ClaimValue text,
  CONSTRAINT AspNetRoleClaims_pkey PRIMARY KEY (Id),
  CONSTRAINT FK_AspNetRoleClaims_AspNetRoles_RoleId FOREIGN KEY (RoleId) REFERENCES public.AspNetRoles(Id)
);
CREATE TABLE public.AspNetRoles (
  Id character varying NOT NULL,
  Name character varying,
  NormalizedName character varying,
  ConcurrencyStamp text,
  CONSTRAINT AspNetRoles_pkey PRIMARY KEY (Id)
);
CREATE TABLE public.AspNetUserClaims (
  Id integer NOT NULL DEFAULT nextval('"AspNetUserClaims_Id_seq"'::regclass),
  UserId character varying NOT NULL,
  ClaimType text,
  ClaimValue text,
  CONSTRAINT AspNetUserClaims_pkey PRIMARY KEY (Id),
  CONSTRAINT FK_AspNetUserClaims_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES public.AspNetUsers(Id)
);
CREATE TABLE public.AspNetUserLogins (
  LoginProvider character varying NOT NULL,
  ProviderKey character varying NOT NULL,
  ProviderDisplayName text,
  UserId character varying NOT NULL,
  CONSTRAINT AspNetUserLogins_pkey PRIMARY KEY (LoginProvider, ProviderKey),
  CONSTRAINT FK_AspNetUserLogins_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES public.AspNetUsers(Id)
);
CREATE TABLE public.AspNetUserRoles (
  UserId character varying NOT NULL,
  RoleId character varying NOT NULL,
  CONSTRAINT AspNetUserRoles_pkey PRIMARY KEY (UserId, RoleId),
  CONSTRAINT FK_AspNetUserRoles_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES public.AspNetUsers(Id),
  CONSTRAINT FK_AspNetUserRoles_AspNetRoles_RoleId FOREIGN KEY (RoleId) REFERENCES public.AspNetRoles(Id)
);
CREATE TABLE public.AspNetUserTokens (
  UserId character varying NOT NULL,
  LoginProvider character varying NOT NULL,
  Name character varying NOT NULL,
  Value text,
  CONSTRAINT AspNetUserTokens_pkey PRIMARY KEY (UserId, LoginProvider, Name),
  CONSTRAINT FK_AspNetUserTokens_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES public.AspNetUsers(Id)
);
CREATE TABLE public.AspNetUsers (
  Id character varying NOT NULL,
  UserName character varying,
  NormalizedUserName character varying,
  Email character varying,
  NormalizedEmail character varying,
  EmailConfirmed boolean NOT NULL DEFAULT false,
  PasswordHash text,
  SecurityStamp text,
  ConcurrencyStamp text,
  PhoneNumber text,
  PhoneNumberConfirmed boolean NOT NULL DEFAULT false,
  TwoFactorEnabled boolean NOT NULL DEFAULT false,
  LockoutEnd timestamp with time zone,
  LockoutEnabled boolean NOT NULL DEFAULT false,
  AccessFailedCount integer NOT NULL DEFAULT 0,
  IdEmpresa uuid,
  IdSetor uuid,
  CONSTRAINT AspNetUsers_pkey PRIMARY KEY (Id),
  CONSTRAINT FK_AspNetUsers_Empresas FOREIGN KEY (IdEmpresa) REFERENCES public.Empresas(IdEmpresa),
  CONSTRAINT FK_AspNetUsers_Setores FOREIGN KEY (IdSetor) REFERENCES public.Setores(IdSetor)
);
CREATE TABLE public.Empresas (
  IdEmpresa uuid NOT NULL DEFAULT gen_random_uuid(),
  NomeEmpresa character varying NOT NULL,
  Ativo boolean DEFAULT true,
  DataCriacao timestamp with time zone DEFAULT now(),
  CONSTRAINT Empresas_pkey PRIMARY KEY (IdEmpresa)
);
CREATE TABLE public.Setores (
  IdSetor uuid NOT NULL DEFAULT gen_random_uuid(),
  NomeSetor character varying NOT NULL,
  IdEmpresa uuid NOT NULL,
  Ativo boolean DEFAULT true,
  DataCriacao timestamp with time zone DEFAULT now(),
  CONSTRAINT Setores_pkey PRIMARY KEY (IdSetor),
  CONSTRAINT FK_Setores_Empresas FOREIGN KEY (IdEmpresa) REFERENCES public.Empresas(IdEmpresa)
);
CREATE TABLE public.categorias (
  idcategoria uuid NOT NULL DEFAULT gen_random_uuid(),
  nomecategoria character varying NOT NULL UNIQUE,
  descricao text,
  ativo boolean DEFAULT true,
  datacriacao timestamp with time zone DEFAULT now(),
  CONSTRAINT categorias_pkey PRIMARY KEY (idcategoria)
);
CREATE TABLE public.chamadohistorico (
  IdHistorico uuid NOT NULL DEFAULT gen_random_uuid(),
  IdChamado uuid NOT NULL,
  IdUsuario character varying NOT NULL,
  Comentario text NOT NULL,
  DataComentario timestamp with time zone DEFAULT now(),
  EraStatusId uuid,
  NovoStatusId uuid,
  CONSTRAINT chamadohistorico_pkey PRIMARY KEY (IdHistorico),
  CONSTRAINT FK_Historico_Chamado FOREIGN KEY (IdChamado) REFERENCES public.chamados(IdChamado),
  CONSTRAINT FK_Historico_Usuario FOREIGN KEY (IdUsuario) REFERENCES public.AspNetUsers(Id),
  CONSTRAINT FK_Historico_EraStatus FOREIGN KEY (EraStatusId) REFERENCES public.statuschamados(idstatus),
  CONSTRAINT FK_Historico_NovoStatus FOREIGN KEY (NovoStatusId) REFERENCES public.statuschamados(idstatus)
);
CREATE TABLE public.chamados (
  IdChamado uuid NOT NULL DEFAULT gen_random_uuid(),
  Titulo character varying NOT NULL,
  Descricao text NOT NULL,
  DataAbertura timestamp with time zone DEFAULT now(),
  DataFechamento timestamp with time zone,
  IdSolicitante character varying NOT NULL,
  IdEmpresa uuid NOT NULL,
  IdSetor uuid,
  IdAtendente character varying,
  IdCategoria uuid NOT NULL,
  IdPrioridade uuid NOT NULL,
  IdStatus uuid NOT NULL,
  CONSTRAINT chamados_pkey PRIMARY KEY (IdChamado),
  CONSTRAINT FK_Chamados_Solicitante FOREIGN KEY (IdSolicitante) REFERENCES public.AspNetUsers(Id),
  CONSTRAINT FK_Chamados_Empresa FOREIGN KEY (IdEmpresa) REFERENCES public.Empresas(IdEmpresa),
  CONSTRAINT FK_Chamados_Setor FOREIGN KEY (IdSetor) REFERENCES public.Setores(IdSetor),
  CONSTRAINT FK_Chamados_Atendente FOREIGN KEY (IdAtendente) REFERENCES public.AspNetUsers(Id),
  CONSTRAINT FK_Chamados_Categoria FOREIGN KEY (IdCategoria) REFERENCES public.categorias(idcategoria),
  CONSTRAINT FK_Chamados_Prioridade FOREIGN KEY (IdPrioridade) REFERENCES public.prioridades(idprioridade),
  CONSTRAINT FK_Chamados_Status FOREIGN KEY (IdStatus) REFERENCES public.statuschamados(idstatus)
);
CREATE TABLE public.faqs (
  idfaq uuid NOT NULL DEFAULT gen_random_uuid(),
  pergunta text NOT NULL,
  resposta text NOT NULL,
  ativo boolean DEFAULT true,
  datacriacao timestamp with time zone DEFAULT now(),
  idcategoria uuid NOT NULL,
  embedding USER-DEFINED,
  CONSTRAINT faqs_pkey PRIMARY KEY (idfaq),
  CONSTRAINT fk_faqs_categorias FOREIGN KEY (idcategoria) REFERENCES public.categorias(idcategoria)
);
CREATE TABLE public.prioridades (
  idprioridade uuid NOT NULL DEFAULT gen_random_uuid(),
  nomeprioridade character varying NOT NULL UNIQUE,
  nivelurgencia integer NOT NULL UNIQUE,
  corhex character varying DEFAULT '#FFFFFF'::character varying,
  CONSTRAINT prioridades_pkey PRIMARY KEY (idprioridade)
);
CREATE TABLE public.statuschamados (
  idstatus uuid NOT NULL DEFAULT gen_random_uuid(),
  nomestatus character varying NOT NULL UNIQUE,
  CONSTRAINT statuschamados_pkey PRIMARY KEY (idstatus)
);
```