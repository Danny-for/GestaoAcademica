# 🎓 Gestão Acadêmica

Aplicação web para gerenciamento de alunos, desenvolvida com **ASP.NET Core Web API**, **SQL Server** e **Angular**. O projeto permite realizar operações CRUD (Create, Read, Update e Delete), possibilitando cadastrar, consultar, editar e excluir alunos.

## 🚀 Tecnologias utilizadas

### Back-end
- C#
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger

### Front-end
- Angular 19
- TypeScript
- HTML5
- CSS3

## 📁 Estrutura do projeto

```text
GestaoAcademica/
├── GestaoAcademica.Api/
│   ├── Controllers/
│   │   └── AlunosController.cs
│   ├── Data/
│   │   └── AppDbContext.cs
│   ├── Models/
│   │   └── Aluno.cs
│   ├── Properties/
│   ├── appsettings.json
│   ├── Program.cs
│   └── GestaoAcademica.Api.csproj
│
├── gestao-academica-web/
│   └── src/
│       └── app/
│           ├── models/
│           ├── services/
│           ├── app.component.ts
│           ├── app.component.html
│           └── app.component.css
│
└── README.md
```

## ⚙️ Pré-requisitos

Antes de executar o projeto, instale:

- [.NET SDK 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js e npm](https://nodejs.org/)
- [Angular CLI](https://angular.dev/tools/cli)
- SQL Server
- [DBeaver](https://dbeaver.io/download/) (opcional, para consultar o banco de dados)

## 🗄️ Configuração do banco de dados

O projeto utiliza o SQL Server para armazenar os dados dos alunos.

### 1. Configure a conexão

Abra o arquivo `appsettings.json`, localizado na pasta `GestaoAcademica.Api`, e configure a string de conexão conforme sua instalação do SQL Server.

Exemplo para SQL Server Express com autenticação do Windows:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=GestaoAcademicaDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

**Importante:** substitua `localhost\\SQLEXPRESS` pelo nome do servidor utilizado no seu ambiente. Se estiver usando autenticação SQL Server, configure o usuário e a senha adequadamente.

### 2. Criação do banco

A aplicação utiliza o Entity Framework Core para configurar o contexto e criar o banco quando executada pela primeira vez, por meio de `EnsureCreated()`.

Se o banco já existir, confira se sua estrutura corresponde ao modelo da aplicação. O método `EnsureCreated()` não substitui o gerenciamento de alterações de estrutura feito por migrations.

## 🔧 Como executar o back-end

### 1. Acesse a pasta da API

No terminal, navegue até a pasta `GestaoAcademica.Api`:

```bash
cd GestaoAcademica.Api
```

### 2. Restaure as dependências

```bash
dotnet restore
```

### 3. Compile o projeto

```bash
dotnet build
```

### 4. Execute a API

```bash
dotnet run
```

Após iniciar, confira no terminal o endereço local informado pela aplicação.

### 5. Acesse o Swagger

Abra o navegador e acesse o endereço da API acrescentando `/swagger`.

Exemplo:

```text
http://localhost:5027/swagger
```

O endereço e a porta podem ser diferentes no seu ambiente. O Swagger permite visualizar e testar os endpoints da API.

**Observação:** se ocorrer um erro relacionado a `AddSwaggerGen`, verifique se o pacote `Swashbuckle.AspNetCore` está instalado no projeto:

```bash
dotnet add package Swashbuckle.AspNetCore
```

Depois, execute novamente `dotnet restore` e `dotnet build`.

## 🖥️ Como executar o front-end

Abra outro terminal e acesse a pasta do Angular:

```bash
cd gestao-academica-web
```

### 1. Instale as dependências

```bash
npm install
```

### 2. Inicie a aplicação

```bash
npm start
```

Se o comando não estiver configurado no `package.json`, utilize:

```bash
npx ng serve
```

### 3. Acesse a aplicação

Abra o navegador em:

```text
http://localhost:4200
```

Verifique se a URL da API configurada no serviço Angular corresponde ao endereço em que o back-end está sendo executado.

## 📌 Funcionalidades

- **Cadastrar aluno:** registra um novo aluno.
- **Listar alunos:** exibe os alunos cadastrados.
- **Consultar aluno:** permite buscar um aluno pelo identificador.
- **Editar aluno:** atualiza os dados de um cadastro.
- **Excluir aluno:** remove um aluno cadastrado.
- **Validar dados:** utiliza validações no modelo para campos obrigatórios e formato de e-mail.

## 🔗 Endpoints da API

A API disponibiliza os seguintes endpoints para gerenciamento de alunos:

| Método HTTP | Endpoint | Descrição |
|---|---|---|
| GET | `/api/Alunos` | Lista todos os alunos |
| GET | `/api/Alunos/{id}` | Busca um aluno pelo ID |
| POST | `/api/Alunos` | Cadastra um novo aluno |
| PUT | `/api/Alunos/{id}` | Atualiza um aluno |
| DELETE | `/api/Alunos/{id}` | Exclui um aluno |

### Exemplo de cadastro

Requisição `POST /api/Alunos`:

```json
{
  "nome": "Maria Silva",
  "email": "maria@email.com",
  "curso": "Análise e Desenvolvimento de Sistemas"
}
```

O corpo da requisição deve corresponder às propriedades definidas no modelo `Aluno`.

## 🧪 Testes

Os endpoints podem ser testados pelo Swagger ou por ferramentas como Postman e Insomnia.

Para validar o funcionamento, teste as operações de cadastro, listagem, consulta, atualização e exclusão de alunos.

## 🔍 Consulta dos dados no DBeaver

Para verificar os dados armazenados:

1. Abra o DBeaver.
2. Conecte-se à instância do SQL Server utilizada pela aplicação.
3. Localize o banco `GestaoAcademicaDb`.
4. Expanda a seção **Tables**.
5. Consulte a tabela correspondente aos alunos.

O nome da tabela pode variar conforme a configuração do Entity Framework Core.

## 🛠️ Solução de problemas

**Erro de conexão com o SQL Server**
- Confira o nome do servidor e da instância.
- Verifique se o serviço do SQL Server está em execução.
- Confirme o tipo de autenticação configurado.

**Erro `AddSwaggerGen`**
- Instale o pacote `Swashbuckle.AspNetCore`.
- Execute `dotnet restore` e `dotnet build`.

**Erro de CORS no Angular**
- Confirme se a API permite requisições da origem `http://localhost:4200`.
- Verifique se a política de CORS está configurada e aplicada no `Program.cs`.

**Angular não consegue acessar a API**
- Confira se o back-end está em execução.
- Verifique a URL configurada no serviço Angular.
- Confirme se a porta utilizada corresponde à informada no terminal da API.

## 🎯 Objetivo do projeto

Praticar o desenvolvimento de aplicações web com arquitetura cliente-servidor, integração entre Angular e ASP.NET Core Web API, persistência de dados com SQL Server e implementação das operações CRUD utilizando Entity Framework Core.

## 🚧 Melhorias futuras

O projeto está em desenvolvimento e receberá melhorias contínuas para aprimorar suas funcionalidades, organização e experiência de uso.

Entre as melhorias planejadas estão:

- Implementação de novas funcionalidades para a gestão acadêmica.
- Aprimoramento das validações e do tratamento de erros.
- Melhorias na interface e na experiência do usuário.
- Implementação de testes automatizados.
- Refatoração do código e aplicação de boas práticas de desenvolvimento.
- Evolução da arquitetura e da persistência de dados conforme as necessidades do projeto.