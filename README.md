# TEXO_Raspberry_Awards_API
<p align="center">API RESTful para possibilitar a leitura da lista de indicados e vencedores
da categoria Pior Filme do Golden Raspberry Awards.</p>

# Requisitos da API:
1. Obter o produtor com maior intervalo entre dois prêmios consecutivos, e o que
obteve dois prêmios mais rápido, seguindo a especificação de formato definida:
```json
{
"min": [
{
"producer": "Producer 1",
"interval": 1,
"previousWin": 2008,
"followingWin": 2009
},
{
"producer": "Producer 2",
"interval": 1,
"previousWin": 2018,
"followingWin": 2019
}
],
"max": [
{
"producer": "Producer 1",
"interval": 99,
"previousWin": 1900,
"followingWin": 1999
},
{
"producer": "Producer 2",
"interval": 99,
"previousWin": 2000,
"followingWin": 2099
}
]
}
```

# Requisitos
Para execução do projeto, é necessário instalação do .Net 5. O passo-a-passo abaixo foi feito com base no Visial Studio 2019.

# DataBase
No projeto foi utilizado um banco de dados em memória (Entity Framework Core (EF Core) como banco de dados In-Memory).

# Para executar o projeto
Nenhuma instalação externa é necessária. Ao ser iniciada, a aplicação cria o banco de dados e o popula com os dados do arquivo movielist.csv, que se encontra em TEXO_Raspberry_Awards_API\Domain\FileSeed\movielist.csv

Clone o repositório ou faça download;
Para iniciar a aplicação clique no projeto com o botão direito do mouse, selecione "Set as Startup Project" e na aba superior da IDE clique em Run.
# EndPoints
Para ver a lista de chamadas REST disponíveis, seus parametros, códigos de resposta HTTP, e tipo de retorno, inicie a aplicação e acesse: hhttps://localhost:44395/swagger/

# Testes
Para executar os testes abra a aba de testes do Visual Studio 2019 e clique Run. Isso fará com que todos os testes de integração implementados sejam executados.
