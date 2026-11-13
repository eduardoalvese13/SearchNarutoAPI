# SearchNarutoAPI

Atividade da Lista de Exercícios 26 — UniBH, UC Usabilidade, Desenvolvimento Web, Mobile e Jogos, professor Daniel Henrique Matos de Paiva.

Aplicação simples em **Blazor WebAssembly e .NET 10** que consulta a [Dattebayo API](https://api-dattebayo.vercel.app/docs).

## Funcionalidades

- Listagem paginada e busca por nome de personagens.
- Exibição de nome, primeira imagem disponível, clã, afiliação, patente ninja e lista de jutsus.
- Mensagens de carregamento, resultado vazio, dados ausentes e falha de conexão, com opção de tentar novamente.

## Executar

Instale o [SDK do .NET 10](https://dotnet.microsoft.com/download/dotnet/10.0). Na pasta do projeto:

```bash
dotnet restore
dotnet run --urls http://localhost:5000
```

Abra o endereço informado no terminal. Digite um nome e clique em **Buscar**; uma busca vazia volta à listagem. Use **Anterior** e **Próxima** para navegar.

```bash
dotnet build
dotnet publish -c Release
```

Não exige banco de dados, chave de API ou backend próprio. O navegador precisa de acesso à internet, à API e aos servidores de imagens. A API pública pode demorar para responder ou ficar indisponível; o projeto não utiliza dados locais como substituição.

## API utilizada

Base: `https://dattebayo-api.onrender.com/`.

A aplicação consulta `characters?page=1&limit=10` e acrescenta o parâmetro `name` para buscar. Os campos apresentados são `name`, `images`, `personal.clan`, `personal.affiliation`, `jutsu` e `rank.ninjaRank`. Campos que variam entre texto, lista e objeto são formatados para leitura.

## Entrega

Repositório: https://github.com/eduardoalvese13/SearchNarutoAPI

Entregue esse link no Google Classroom, conforme o enunciado.

## Validação realizada

- Compilação e publicação em Release concluídas com .NET SDK 10.0.404.
- Teste funcional em Chromium com respostas simuladas: campos e imagem, paginação, busca, resultado vazio, falha de rede e nova tentativa.
- A integração com a API pública não pôde ser validada no ambiente de desenvolvimento porque o proxy bloqueou o domínio (HTTP 403 no túnel). Os testes simulados não comprovam disponibilidade ou CORS da API real.
