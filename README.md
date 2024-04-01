# Locadão API

API ASP.NET para gerenciamento de aluguel de veículos, permitindo operações CRUD (Criar, Ler, Atualizar, Deletar) em entidades como Clientes, Veículos e Agências.

## Começando

Estas instruções fornecerão uma cópia do projeto em execução na sua máquina local para fins de desenvolvimento e teste.

### Pré-requisitos

- .NET 6.0 SDK ou superior
- PostgreSQL
- Visual Studio, Visual Studio Code ou editor de código de sua preferência

### Instalação

1. Clone o repositório
```cmd
git clone <url-do-repositorio>
```
2. Restaure os pacotes NuGet
```cmd
dotnet restore
```
3. Atualize a string de conexão no arquivo `appsettings.json` com suas credenciais do PostgreSQL.
4. Aplique as migrações para criar o banco de dados
```cmd
dotnet ef database update
```
5. Execute a aplicação
```cmd
dotnet run
```


## Uso

A API está documentada com Swagger, e você pode acessá-la navegando para `http://localhost:<porta>/swagger` no seu navegador após iniciar a aplicação.

### Endpoints Principais

- **Clientes**
- `GET /api/Clientes` - Lista todos os clientes
- `POST /api/Clientes` - Cria um novo cliente
- `DELETE /api/Clientes/{id}` - Remove um cliente pelo ID

- **Veículos**
- `GET /api/Veiculos` - Lista todos os veículos
- `POST /api/Veiculos` - Cria um novo veículo
- `DELETE /api/Veiculos/{id}` - Remove um veículo pelo ID

- **Agências**
- `GET /api/Agencias` - Lista todas as agências
- `POST /api/Agencias` - Cria uma nova agência
- `DELETE /api/Agencias/{id}` - Remove uma agência pelo ID

- **Aluguel**
-  `GET /api/Alugueis` - Lista todos os Alugueis
-  `POST /api/Alugueis` - Cria um novo Aluguel
- `DELETE /api/ALUgueis/{id}` - Remove um Aluguel pelo ID

- **Reservas** 
- `GET /api/Reservas` - Lista todas as reservas
- `GET /api/Reservas/{id}` - Consulta detalhes de uma reserva específica
- `POST /api/Reservas` - Cria uma nova reserva
