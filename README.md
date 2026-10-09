Desafio Técnico - C#

Esta é uma solução em Web API desenvolvida em C# / .NET 8, construída para responder aos requisitos de um desafio técnico contendo três módulos principais: Cálculo de Comissões de Vendas, Gestão e Movimentação de Estoque e Cobrança/Cálculo de Juros Diários.

O projeto adota boas práticas de desenvolvimento como Clean Code, arquitetura em camadas (Controllers, Services, DTOs), princípios SOLID e Injeção de Dependência nativa do .NET.

🛠️ Tecnologias Utilizadas
.NET 8 (ASP.NET Core Web API)
C# 12
Swagger / OpenAPI (Documentação interativa das rotas)
C# Collections In-Memory (ConcurrentDictionary para persistência em memória thread-safe)

📁 Estrutura da Solução

A arquitetura foi projetada visando manutenibilidade, testabilidade e separação clara de responsabilidades:

desafioDotnet/
├── controllers/          # Camada REST (Endpoints/Rotas HTTP)
│   ├── CobrancaController.cs
│   ├── ComissoesController.cs
│   └── EstoqueController.cs
├── dtos/                 # Contratos de Entrada e Saída (Request/Response)
│   ├── cobranca/
│   ├── comissao/
│   └── estoque/
├── enums/                # Tipos Enumerados (Ex: TipoMovimentacao)
├── models/               # Entidades de Domínio (Ex: Produto)
├── services/             # Regras de Negócio e Cálculos
│   ├── interface/        # Abstrações/Contratos das Regras de Negócio
│   │   ├── ICobrancaService.cs
│   │   ├── IComissaoService.cs
│   │   └── IEstoqueService.cs
│   ├── CobrancaService.cs
│   ├── ComissaoService.cs
│   └── EstoqueService.cs
└── Program.cs            # Injeção de Dependências e Middlewares


💻 Módulos do Sistema

1. 💰 Módulo de Comissões (ComissoesController)

Processa o payload de vendas e aplica a régua de cálculo por item vendido:

Abaixo de R$ 100,00: Isento de comissão (0%).

Entre R$ 100,00 e R$ 499,99: 1% de comissão.

A partir de R$ 500,00: 5% de comissão.

Retorno: Agrupamento por vendedor contendo o total vendido e o total de comissão gerada.

2. 📦 Módulo de Estoque (EstoqueController)

Gerencia o saldo de produtos mantidos em memória:

Suporta lançamentos de Entrada e Saída.

Cada movimentação gera um identificador único (Guid).

Realiza validações de estoque insuficiente para operações de saída.

Retorna o saldo final atualizado do produto movimentado.

3. 📄 Módulo de Cobrança (CobrancaController)

Calcula encargos financeiros sobre títulos vencidos:

Aplica uma taxa de multa/juros diários de 2,5% ao dia (0.025).

Considera a diferença em dias entre a data de vencimento e a data atual.

Retorna os dias de atraso, o valor dos juros aplicados e o valor total atualizado.

🚀 Como Executar o Projeto

Pré-requisitos

.NET 8.0 SDK instalado.

Passo a Passo

Clonar o repositório:

git clone https://github.com/seu-usuario/desafioDotnet.git
cd desafioDotnet


Restaurar as dependências e compilar:

dotnet build


Executar a aplicação:

dotnet run


Acessar a documentação no Swagger:
Abra o seu navegador e acesse:

http://localhost:5034/swagger


📬 Exemplos de Requisições (Endpoints)

1. Calcular Comissões

Endpoint: POST /api/Comissoes/calcular

Request:

{
  "vendas": [
    { "vendedor": "João Silva", "valor": 1200.50 },
    { "vendedor": "João Silva", "valor": 250.30 },
    { "vendedor": "João Silva", "valor": 80.00 },
    { "vendedor": "Maria Souza", "valor": 2100.40 }
  ]
}


Response (200 OK):

[
  {
    "vendedor": "João Silva",
    "totalVendido": 1530.80,
    "totalComissao": 62.52
  },
  {
    "vendedor": "Maria Souza",
    "totalVendido": 2100.40,
    "totalComissao": 105.02
  }
]


2. Consultar Estoque

Endpoint: GET /api/Estoque

Response (200 OK):

[
  {
    "codigoProduto": 101,
    "descricaoProduto": "Caneta Azul",
    "quantidadeEstoque": 150
  },
  {
    "codigoProduto": 102,
    "descricaoProduto": "Caderno Universitário",
    "quantidadeEstoque": 75
  }
]


3. Movimentar Estoque

Endpoint: POST /api/Estoque/movimentar

Request:

{
  "codigoProduto": 101,
  "descricaoMovimentacao": "Entrada de lote do fornecedor",
  "tipo": 1,
  "quantidade": 50
}


(Nota: tipo: 1 = Entrada, 2 = Saída)

Response (200 OK):

{
  "idMovimentacao": "a1b2c3d4-e5f6-7890-abcd-1234567890ab",
  "codigoProduto": 101,
  "descricaoProduto": "Caneta Azul",
  "descricaoMovimentacao": "Entrada de lote do fornecedor",
  "estoqueFinal": 200
}


4. Calcular Juros e Cobrança

Endpoint: POST /api/Cobranca/calcular-juros

Request:

{
  "valorOriginal": 500.00,
  "dataVencimento": "2026-10-01T00:00:00"
}


Response (200 OK):

{
  "valorOriginal": 500.00,
  "dataVencimento": "2026-10-01T00:00:00",
  "dataCalculo": "2026-10-09T00:00:00",
  "diasAtraso": 8,
  "taxaMultaDiariaPorcentagem": 2.5,
  "valorMultaJuros": 100.00,
  "valorTotalAtualizado": 600.00
}
