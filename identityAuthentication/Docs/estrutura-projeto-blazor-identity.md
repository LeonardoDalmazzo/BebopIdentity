# Estrutura do Projeto: identityAuthentication

Projeto Blazor Web App criado no Visual Studio 2022 com autenticação via ASP.NET Identity.

---

## 📁 Raiz do Projeto (`identityAuthentication/`)
Contém os arquivos principais e a configuração do app.

```
identityAuthentication/
│
├── Connected Services/                         // Serviços conectados (ex: secrets.json, banco local)
│   ├── Secrets.json (Local)                    // Armazena segredos de desenvolvimento (connection strings)
│   └── SQL Server Express LocalDB              // Banco local usado pelo EF Identity por padrão
│
├── Dependencies/                               // Pacotes e frameworks utilizados
│   ├── Analyzers/                              // Analisadores de código e warnings de compilação
│   ├── Frameworks/                             // Frameworks ASP.NET Core e .NET utilizados
│   └── Packages/                               // Pacotes NuGet (EntityFramework, Identity, etc)
│
├── Properties/                                 // Metadados do projeto
│   ├── launchSettings.json                     // Configuração de execução local (URLs, perfis, etc)
│   ├── serviceDependencies.json                // Dependências externas (banco, storage, etc)
│   └── serviceDependencies.local.json          // Versão local das dependências
│
├── wwwroot/                                    // Arquivos estáticos (servidos diretamente ao navegador)
│   ├── favicon.png                             // Ícone do site
│   ├── app.css                                 // Estilos principais do app
│   └── lib/                                    // Bibliotecas JS/CSS
│       └── bootstrap/                          // Framework Bootstrap para UI responsiva
│           └── dist/
│               ├── css/                        // Estilos prontos do Bootstrap
│               └── js/                         // Scripts JS do Bootstrap
│
├── Components/                                 // Componentes Blazor reutilizáveis (.razor)
│   ├── Account/                                // Telas e lógicas de autenticação
│   │   ├── Pages/                              // Páginas completas (login, registro, reset de senha, etc)
│   │   │   ├── Manage/                         // Gerenciamento de conta logada (senha, 2FA, dados, etc)
│   │   │   │   ├── ChangePassword.razor        // Alterar senha
│   │   │   │   ├── EnableAuthenticator.razor   // Habilitar autenticação de 2 fatores
│   │   │   │   ├── ExternalLogins.razor        // Gerenciar logins externos (Google, Microsoft, etc)
│   │   │   │   ├── PersonalData.razor          // Exportar ou excluir dados pessoais
│   │   │   │   └── ...                         // Outras telas de gerenciamento de conta
│   │   │   ├── Login.razor                     // Tela de login do usuário
│   │   │   ├── Register.razor                  // Tela de cadastro de usuário
│   │   │   ├── ForgotPassword.razor            // Recuperação de senha
│   │   │   ├── ConfirmEmail.razor              // Confirmação de email
│   │   │   ├── Lockout.razor                   // Tela de bloqueio temporário
│   │   │   └── AccessDenied.razor              // Página de acesso negado
│   │   └── Shared/                             // Componentes usados em várias telas de conta
│   │       ├── ManageLayout.razor              // Layout padrão da área de gerenciamento
│   │       ├── ManageNavMenu.razor             // Menu lateral de navegação da conta
│   │       ├── StatusMessage.razor             // Exibe mensagens de sucesso/erro
│   │       └── RedirectToLogin.razor           // Redireciona usuários não logados
│   │
│   ├── Layout/                                 // Layouts e navegação geral da aplicação
│   │   ├── MainLayout.razor                    // Layout principal da aplicação
│   │   ├── MainLayout.razor.css                // Estilo específico do layout principal
│   │   ├── NavMenu.razor                       // Menu de navegação lateral/topo
│   │   └── NavMenu.razor.css                   // CSS do menu de navegação
│   │
│   ├── Shared/                                 // Classes auxiliares usadas pelo Identity
│   │   ├── IdentityComponentsEndpointRouteBuilderExtensions.cs // Extensões de roteamento do Identity
│   │   ├── IdentityNoOpEmailSender.cs          // Implementação de envio de email (fake para dev)
│   │   ├── IdentityRedirectManager.cs          // Controla redirecionamentos pós-login/logout
│   │   ├── IdentityRevalidatingAuthenticationStateProvider.cs // Revalida sessão autenticada periodicamente
│   │   └── IdentityUserAccessor.cs             // Acesso ao usuário autenticado atual
│
├── Pages/                                      // Páginas de navegação geral
│   ├── Home.razor                              // Página inicial
│   ├── Counter.razor                           // Exemplo de contador (demo padrão do Blazor)
│   ├── Weather.razor                           // Exemplo de API (demo padrão)
│   ├── Auth.razor                              // Tela de autenticação personalizada
│   ├── Error.razor                             // Página de erro genérico
│   ├── _Imports.razor                          // Importações de namespaces comuns
│   ├── App.razor                               // Componente raiz da aplicação Blazor
│   └── Routes.razor                            // Define as rotas e componentes do app
│
├── Data/                                       // Acesso a dados e modelos do Entity Framework
│   ├── ApplicationDbContext.cs                 // Contexto do EF Core (controla acesso ao banco)
│   ├── ApplicationUser.cs                      // Modelo de usuário (extensão de IdentityUser)
│   ├── Migrations/                             // Histórico de migrações do banco de dados
│   │   ├── 00000000000000_CreateIdentitySchema.cs // Primeira migração (cria tabelas do Identity)
│   │   ├── 00000000000000_CreateIdentitySchema.Designer.cs // Código auxiliar da migração
│   │   └── ApplicationDbContextModelSnapshot.cs // Snapshot atual do modelo do banco
│
├── appsettings.json                            // Configuração principal do app (connection strings, etc)
├── appsettings.Development.json                // Configuração específica do ambiente de desenvolvimento
└── Program.cs                                  // Ponto de entrada principal (configura serviços e rotas)
```

---

## 🧭 Comentários Gerais

- **Blazor Web App com Identity**: essa estrutura mistura UI Razor + autenticação server-side via ASP.NET Identity.
- **Pasta `Components/Account`**: contém todas as páginas de login, registro, recuperação e gerenciamento de conta.
- **`Data/`**: guarda o `DbContext` e as migrações do Entity Framework Core.
- **`Program.cs`**: é onde são registrados os serviços (`AddDbContext`, `AddIdentity`, etc.).
- **`wwwroot/`**: contém os assets públicos, como CSS, JS e imagens.
- **`lib/bootstrap`**: é o framework de estilo incluído automaticamente para compor o layout base.

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
