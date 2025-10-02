"""
User Service - API REST com FastAPI
Minicurso REST API Simples
"""

from fastapi import FastAPI
from pydantic import BaseModel
from typing import List
import uvicorn

app = FastAPI(title="User Service", version="1.0.0")

# Modelo de dados
class User(BaseModel):
    id: int
    name: str
    email: str

# Dados em memoria
users = [
    User(id=1, name="Joao Silva", email="joao@email.com"),
    User(id=2, name="Maria Santos", email="maria@email.com"),
    User(id=3, name="Pedro Oliveira", email="pedro@email.com")
]

@app.get("/")
async def root():
    return {"message": "User Service - Minicurso REST API"}

@app.get("/health")
async def health():
    return {"status": "healthy", "service": "user-service"}

@app.get("/users", response_model=List[User])
async def get_users():
    return users

@app.get("/users/{user_id}", response_model=User)
async def get_user(user_id: int):
    for user in users:
        if user.id == user_id:
            return user
    return {"error": "User not found"}

if __name__ == "__main__":
    uvicorn.run(app, host="0.0.0.0", port=8000)
