## Pré-requisitos

- Python 3.12.0
- MySQL Server(Ou um container docker)
- Chave de api do TMDB


## Passo a Passo para Rodar o Script

1. **Criar um ambiente virtual**

   Para isolar as dependências do projeto, crie um ambiente virtual utilizando o comando abaixo:

   ```bash
   python -m venv .venv/
     
2. **Ativar ambiente virtual**

   ```bash
   Linux e MacOS: source .venv/bin/activate
   Windows: source .venv\bin\activate
3. Com o ambiente virtual ativado, instale as dependências necessárias para rodar o script usando o arquivo requirements.txt:
   ```bash
   pip install -r requirements.txt

4. Rodar o script
   ```bash
   python buscar_filmes.py

