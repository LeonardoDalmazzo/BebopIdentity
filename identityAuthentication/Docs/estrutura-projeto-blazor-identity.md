# Estrutura do Projeto: identityAuthentication

Projeto Blazor Web App criado no Visual Studio 2022 com autenticação via ASP.NET Identity.

---

## 📁 Raiz do Projeto (`identityAuthentication/`)
Contém os arquivos principais e a configuração do app.

```
identityAuthentication/
│
├── Program.cs
├── identityAuthentication.csproj.user
├── identityAuthentication.csproj
├── appsettings.json
├── appsettings.Development.json
├── Properties/                                 // Metadados do projeto
│   ├── launchSettings.json                     // Configuração de execução local (URLs, perfis, etc)
│   ├── serviceDependencies.json                // Dependências externas (banco, storage, etc)
│   ├── serviceDependencies.local.json          // Versão local das dependências
│   └── serviceDependencies.local.json.user
│
├── wwwroot/                                    // Arquivos estáticos (servidos diretamente ao navegador)
│   ├── favicon.png                             // Ícone do site
│   ├── app.css                                 // Estilos principais do app
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
│   │       ├── ManageLayout.razor              // Layout padrão da área de gerenciamento
│   │       ├── ManageNavMenu.razor             // Menu lateral de navegação da conta
│   │       ├── StatusMessage.razor             // Exibe mensagens de sucesso/erro
│   │       ├── ShowRecoveryCodes.razor
│   │       ├── ExternalLoginPicker.razor
│   │       └── RedirectToLogin.razor           // Redireciona usuários não logados
│   │
│   ├── Layout/                                 // Layouts e navegação geral da aplicação
│   │   ├── MainLayout.razor                    // Layout principal da aplicação
│   │   ├── MainLayout.razor.css                // Estilo específico do layout principal
│   │   ├── NavMenu.razor                       // Menu de navegação lateral/topo
│   │   └── NavMenu.razor.css                   // CSS do menu de navegação
│   │
│   └── Pages/                                      // Páginas de navegação geral
│       ├── Home.razor                              // Página inicial
│       ├── Counter.razor                           // Exemplo de contador (demo padrão do Blazor)
│       ├── Weather.razor                           // Exemplo de API (demo padrão)
│       ├── Auth.razor                              // Tela de autenticação personalizada
│       ├── Debug.razor
│       └── Error.razor                             // Página de erro genérico│       
│
│
├── Data/                                       // Acesso a dados e modelos do Entity Framework
│   ├── ApplicationDbContext.cs                 // Contexto do EF Core (controla acesso ao banco)
│   └── ApplicationUser.cs                      // Modelo de usuário (extensão de IdentityUser)
│
├── appsettings.json                            // Configuração principal do app (connection strings, etc)
├── appsettings.Development.json                // Configuração específica do ambiente de desenvolvimento
└── Program.cs                                  // Ponto de entrada principal (configura serviços e rotas)
```

---

## 🧭 Comentários Gerais

- **Blazor Web App com Identity**: essa estrutura mistura UI Razor + autenticação server-side via ASP.NET Identity.
- **Pasta `Components/Account`**: contém todas as páginas de login, registro, recuperação e gerenciamento de conta.
- **`Data/`**: guarda o `DbContext` e instruções para Entity Framework Core.
- **`Program.cs`**: é onde são registrados os serviços (`AddDbContext`, `AddIdentity`, etc.).
- **`wwwroot/`**: contém os assets públicos, como CSS, JS e imagens.
- **`lib/bootstrap`**: é o framework de estilo incluído automaticamente para compor o layout base.
- **`lib/fontawesome`**: é o framework para os icones do projeto.

---

### Regras de Desenvolvimento
- "Database First" (Manual): A criação e alteração de tabelas (ex: CREATE TABLE, ALTER TABLE) é feita manualmente por você, diretamente no SQL Editor do Supabase.
- App "Data-Only": A aplicação Blazor não gerencia o esquema do banco. Ela apenas realiza operações de dados (CRUD: INSERT, SELECT, UPDATE, DELETE) em tabelas que ela assume que já existem.
- Sem Migrations.

Isso simplifica bastante as coisas do lado do C#. Nosso foco será puramente na lógica de front-end (Blazor), nas classes de modelo (POCOs), e na configuração do DbContext para que ele "entenda" as tabelas que criadas manualmente no Supabase.

---

📘 **Dica:**  
Quando for migrar para um banco remoto (ex: Supabase), você só precisará alterar a `ConnectionString` em `appsettings.json` e instalar o pacote:

```bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

Depois, ajuste em `Program.cs`:
```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Supabase")));
```

---

**Autor:** *Gerado automaticamente com base na estrutura do projeto Blazor Web App (Visual Studio 2022, .NET 8, Identity habilitado).*

---

## WARNING: This schema is for context only and is not meant to be run.
### Table order and constraints may not be valid for execution.

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
  CONSTRAINT AspNetUsers_pkey PRIMARY KEY (Id)
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