import base64
import time
import tkinter as tk
from tkinter import simpledialog
import requests
import mysql.connector

def get_limite():
    root = tk.Tk()
    root.withdraw()
    limite = simpledialog.askinteger("Filmes", "Quantos filmes deseja inserir?(1-100)", minvalue=1, maxvalue=100)
    root.destroy()
    return limite

def get_apiKey():
    root = tk.Tk()
    root.withdraw()
    api_key = simpledialog.askstring("Chave da API", "Informe a chave da API")
    root.destroy()
    return api_key

api_key = get_apiKey()
limite = get_limite()
page = 1
quantidade_inserida = 0

url = f'https://api.themoviedb.org/3/movie/popular?api_key={api_key}&language=pt-br&page=1'
response = requests.get(url)
movies = response.json().get('results', [])

db = mysql.connector.connect(
    host="localhost",
    user="root",
    password="12345",
    database="desafio-ubots"
)

cursor = db.cursor()

cursor.execute("""
    CREATE TABLE IF NOT EXISTS Filmes (
        id INT PRIMARY KEY,
        titulo VARCHAR(255),
        data_lancamento DATE,
        sinopse TEXT,
        duracao INT,
        categorias VARCHAR(255),
        capa LONGBLOB
    )
""")

def pegar_poster_filme(caminho_poster):
    if caminho_poster:
        image_url = f'https://image.tmdb.org/t/p/original{caminho_poster}'
        image_response = requests.get(image_url)
        if image_response.status_code == 200:
            return base64.b64encode(image_response.content)
    return None

while quantidade_inserida < limite:
    url = f'https://api.themoviedb.org/3/movie/popular?api_key={api_key}&language=pt-br&page={page}'
    response = requests.get(url)
    
    if response.status_code != 200:
        print(f"Falha em resgatar dados da página {page}: {response.status_code}")
        break

    movies = response.json().get('results', [])

    if not movies: 
        print("No more movies available to fetch.")
        break

    for movie in movies:
        if quantidade_inserida >= limite:
            break

        movie_details_url = f'https://api.themoviedb.org/3/movie/{movie["id"]}?api_key={api_key}&language=pt-br'
        movie_details_response = requests.get(movie_details_url)

        if movie_details_response.status_code == 429:
            print("Taxa limite excedida, esperando 10 segundos...")
            time.sleep(10)
            movie_details_response = requests.get(movie_details_url)

        movie_details_response = movie_details_response.json()

        id = movie['id']
        titulo = movie['title']
        data_lancamento = movie['release_date']
        sinopse = movie['overview']
        duracao = movie_details_response.get('runtime', None)
        categorias = ', '.join([genre['name'] for genre in movie_details_response.get('genres', [])])
        capa = pegar_poster_filme(movie['poster_path'])

        cursor.execute("""
            INSERT INTO Filmes (id, titulo, data_lancamento, sinopse, duracao, categorias, capa) 
            VALUES (%s, %s, %s, %s, %s, %s, %s)
        """, (id, titulo, data_lancamento, sinopse, duracao, categorias, capa))

        quantidade_inserida += 1
        print(f"Filme {titulo} inserido com sucesso. Total inseridos: {quantidade_inserida}")

    page += 1

db.commit()
cursor.close()
db.close()