# PDV - MVP Nível Médio

Projeto backend em .NET 10 Web API para um sistema de Ponto de Venda (PDV), com foco em portfólio profissional.

## Objetivo

Construir um MVP de PDV demonstrando domínio em C#, ASP.NET Core, SQL Server, EF Core, API REST, JWT, Swagger/OpenAPI, logs, tratamento de erros, regras de negócio, testes automatizados e arquitetura em camadas.

## Status atual

O projeto ainda está em fase inicial. A solução já possui a separação em camadas principais, com projetos para API, Application, Core, Infrastructure, testes unitários e testes de integração.

No momento, a API ainda está próxima do template inicial e o restante do escopo será implementado gradualmente.

## Escopo planejado do MVP

- Autenticação JWT
- Usuários e perfis
- Produtos
- Categorias
- Estoque
- Caixa
- Abertura e fechamento de caixa
- Venda
- Itens da venda
- Pagamento simulado
- Cancelamento de venda
- Relatório/resumo diário
- Logs
- Swagger/OpenAPI
- Testes automatizados

## Estrutura atual

O projeto está organizado na raiz do repositório com os seguintes projetos:

- Pdv.Api: API Web do sistema.
- Pdv.Application: camada de aplicação e casos de uso.
- Pdv.Core: domínio, entidades, regras de negócio e exceções.
- Pdv.Infrastructure: infraestrutura, persistência e integrações.
- Pdv.UnitTests: testes unitários.
- Pdv.IntegrationTests: testes de integração.

## Próximos passos

A implementação deve evoluir a partir do domínio, com foco inicial em produtos, regras de negócio e testes. Depois disso, o projeto deve avançar para persistência, autenticação, operações de caixa, vendas e relatórios.
