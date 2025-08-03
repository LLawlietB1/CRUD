# CRUD Model 

Este projeto CRUD foi desenvolvido com o propósito principal de aprendizado e prática dos conceitos fundamentais de manipulação de dados em aplicações. Através dele, foram exploradas as operações básicas de criação, leitura, atualização e exclusão (CRUD), além da organização do código em camadas para melhor entendimento da arquitetura.

## Objetivos do projeto
- Praticar a estruturação de um sistema organizado em camadas (Application, API, Domain).

- Implementar funcionalidades essenciais de um CRUD de forma clara e didática.

- Entender a interação entre controllers, use cases e entidades.

- Aplicar validações e tratamento de erros básicos.

- Familiarizar-se com injeção de dependências e organização do código.

## Estrutura do Projeto

- **crud.API**: Possui conexão direta com o usuário e é através dele que as principais requisições do usuário são atendidas e repassadas pelas outras partes do projeto. Ex: Quando o usuário solicita uma requisição, o API Project terá a responsabilidade de receber chamados e devolver uma resposta.

- **crud.Application**: Receberá a solicitação vinda do API Project e terá a responsabilidade de gerenciar as regras de negócio (ou Use Cases), que tem por objetivo validar, deletar e gerenciar o que pode ou não ser feito. 

- **crud.Communication**: É responsável por conter apenas as classes de resposta e requisição. Fará o papel de conversor de dados, sendo recebidas as requisições HTTP e convertido em classes, isso ocorre devido ao Model Binder do ASP.NET, facilitando a comunicação entre API e o Application Project. 

- **crud.Infrastructure**: Somente o projeto de Application tem acesso que é onde está a classe, o repositório e a conexão do banco de dados. Além de conter também as entidades que são classes espelhando o banco de dados. O crudDbContext original foi ocultado por conter dados sensíveis, mas no lugar foi gerado o crudDbContextExample que segue o mesmo modelo do DbContext original. 😉

- **crud.Exceptions**: Nele serão desenvolvidas as exceções do projeto, sendo uma forma de padronizar e centralizar a forma como os erros são tratados na aplicação. 

## Tecnologias Utilizadas

- .NET 8
- Entity Framework Core
- SQL Server
- Swashbuckle/Swagger para documentação da API
- BCrypt.Net para segurança

## Como Executar

1. Clone o repositório:
   ```sh
   git clone <https://github.com/LLawlietB1/CRUD.git>
   ```
2. Restaure os pacotes:
   ```sh
   dotnet restore
   ```
3. Execute as migrações (se necessário):
   ```sh
   dotnet ef database update --project crud.Infrastructure
   ```
4. Inicie a API:
   ```sh
   dotnet run --project crud.API
   ```
5. Opcional: 
- Caso necessário, com botão direito em crud.API (Utilizando o Visual Studio 2022)
    ```sh
        Set as Startup Project
    ```

## Documentação da API

Acesse `/swagger` após iniciar o projeto para visualizar e testar os endpoints.

## Organização dos Diretórios

- `Controllers/`: Endpoints da API.
- `UseCase/`: Casos de uso (Application).
- `Requests/Responses/`: Contratos de entrada/saída (Communication).
- `Security/`: Implementações de segurança.
- `Properties/`: Configurações do projeto.

## Contribuição

Pull requests são bem-vindos! Para grandes mudanças, abra uma issue primeiro para discutir o que deseja modificar.

## Licença

Este projeto está sob a licença MIT.

---

> Dúvidas ou sugestões? Abra uma issue!