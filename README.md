# Desafio Ubots

Este projeto é para o desafio Ubots.  
Contem um script Python que utiliza a API do TMDB para buscar dados de filmes e insere-os em um banco de dados MySQL. O script permite configurar o número máximo de filmes a serem buscados e processados.  

### Pré-requisitos
---
- Docker
- .Net 8

### Container com dados para teste
---
O projeto possui um arquivo Docker Compose para facilitar a execução do projeto. 
Para executar o comando abra o terminal na pasta do docker compose e execute o comando a seguir:
```
docker-compose up -d
```

### Testando API
---
Para iniciar a api navegue até a pasta /MovieAPI/ pelo terminal e insira o comando: 
```
dotnet run --project MovieApi.RestAPI --urls "http://localhost:5000
```
- (a porta pode ser mudada de acordo com as que estiverem disponiveis)

Em seguida no navegador, digite a URL utilizada no comando acima incluindo a porta seguido de `/swagger`para acessar a api.