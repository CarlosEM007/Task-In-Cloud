# ☁️ Task-In Cloud
## 🧩 Aplicando DDD em uma API Simples

Com o início da minha pós-graduação, decidi desenvolver uma API em ASP.NET para aplicar na prática conceitos de:

- Domain Driven Design (DDD)
- Clean Architecture
-Organização de APIs escaláveis

E nada mais direto do que começar com um clássico:
#### 👉 um sistema de gerenciamento de tarefas (Todo List).

<hr>

## 🏗️ Arquitetura

O foco principal deste projeto não foi a complexidade do domínio, mas sim a estrutura arquitetural.
A API foi estruturada seguindo princípios de Clean Architecture, separando responsabilidades em 5 camadas.

### 🌐 API Layer

Responsável pela comunicação externa.

Funções principais:

- Receber requisições HTTP
- Encaminhar dados para a camada Application
- Retornar respostas ao cliente

👉 Atua apenas como ponto de entrada/saída.

### ⚙️ Application Layer

Camada responsável pelo fluxo da aplicação.

Aqui ocorre:

- Orquestração dos casos de uso
- Tratamento inicial dos dados
- Comunicação entre Domain e Infrastructure

Fluxo:

Controller → Application → Domain → Infrastructure

### 🧠 Domain Layer

O núcleo do sistema.

Características:

- Não possui dependência de outras camadas
- Contém regras de negócio
- Entidades e validações do domínio

Essa camada representa o verdadeiro coração da aplicação.

### 🗄️ Infrastructure Layer

Responsável pelo acesso a recursos externos.

Funções:

- Comunicação com banco de dados
- Implementação de repositórios
- Operações de CRUD

### 🔧 Shared Layer

Camada compartilhada entre módulos.

Inclui:

- Classes utilitárias
- Enums
- Métodos genéricos reutilizáveis

⚠️ A Domain não depende da Shared para manter o isolamento do domínio.

<hr>

## 📚 Aprendizados

O maior aprendizado deste projeto foi compreender como organizar e aplicar uma arquitetura em um cenário real, mesmo sendo uma API simples.

Principais evoluções:

Estruturação em camadas
Separação de responsabilidades
Organização de dependências
Aplicação prática de DDD
Melhor entendimento do fluxo de uma API
⚠️ Pontos de melhoria

Alguns pontos ainda pretendo evoluir:

Melhor utilização do Domain Model
Aprofundar regras de negócio em projetos mais complexos
Refinar separação entre Application e Domain
Adicionar testes automatizados

Como o projeto é um Todo List, o domínio possui poucas regras — o que limita a exploração completa do DDD.

☁️ Próximos Passos
 - Deploy na Azure
 - Implementar autenticação
 - Adicionar testes unitários

<hr>
   
## 🚀 Objetivo do Projeto
Este projeto representa um passo importante na minha evolução como desenvolvedor backend, focando menos na funcionalidade e mais na qualidade arquitetural.
