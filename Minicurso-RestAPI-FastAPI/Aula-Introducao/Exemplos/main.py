"""
Demonstração prática: API REST com FastAPI
Minicurso: REST APIs, Microservices, Docker e Kubernetes
"""

from fastapi import FastAPI, HTTPException
from pydantic import BaseModel, EmailStr
from typing import List, Optional
import uvicorn
from datetime import datetime

# Inicializar FastAPI
app = FastAPI(
    title="User Management API",
    description="API para gerenciamento de usuários - Demonstração do Minicurso",
    version="1.0.0",
    docs_url="/docs",
    redoc_url="/redoc"
)

# Modelos de dados
class UserBase(BaseModel):
    name: str
    email: str
    age: Optional[int] = None

class UserCreate(UserBase):
    pass

class UserUpdate(BaseModel):
    name: Optional[str] = None
    email: Optional[str] = None
    age: Optional[int] = None

class User(UserBase):
    id: int
    created_at: datetime
    
    class Config:
        from_attributes = True

# Banco de dados em memória (para demonstração)
users_db = []
next_id = 1

# Middleware para logging
@app.middleware("http")
async def log_requests(request, call_next):
    start_time = datetime.now()
    response = await call_next(request)
    process_time = (datetime.now() - start_time).total_seconds()
    print(f"{request.method} {request.url} - {response.status_code} - {process_time:.3f}s")
    return response

# Endpoints
@app.get("/")
async def root():
    """Endpoint raiz da API"""
    return {
        "message": "Bem-vindo à User Management API!",
        "version": "1.0.0",
        "docs": "/docs",
        "endpoints": {
            "users": "/users",
            "health": "/health"
        }
    }

@app.get("/health")
async def health_check():
    """Verificação de saúde da API"""
    return {
        "status": "healthy",
        "timestamp": datetime.now(),
        "users_count": len(users_db)
    }

@app.get("/users", response_model=List[User])
async def get_users(skip: int = 0, limit: int = 100):
    """
    Listar todos os usuários com paginação
    
    - **skip**: Número de usuários para pular
    - **limit**: Número máximo de usuários para retornar
    """
    return users_db[skip:skip + limit]

@app.get("/users/{user_id}", response_model=User)
async def get_user(user_id: int):
    """
    Obter um usuário específico por ID
    
    - **user_id**: ID único do usuário
    """
    for user in users_db:
        if user["id"] == user_id:
            return user
    raise HTTPException(status_code=404, detail="Usuário não encontrado")

@app.post("/users", response_model=User)
async def create_user(user: UserCreate):
    """
    Criar um novo usuário
    
    - **name**: Nome do usuário
    - **email**: Email do usuário
    - **age**: Idade do usuário (opcional)
    """
    global next_id
    
    # Verificar se email já existe
    for existing_user in users_db:
        if existing_user["email"] == user.email:
            raise HTTPException(status_code=400, detail="Email já cadastrado")
    
    new_user = {
        "id": next_id,
        "name": user.name,
        "email": user.email,
        "age": user.age,
        "created_at": datetime.now()
    }
    
    users_db.append(new_user)
    next_id += 1
    
    return new_user

@app.put("/users/{user_id}", response_model=User)
async def update_user(user_id: int, user_update: UserUpdate):
    """
    Atualizar um usuário existente
    
    - **user_id**: ID único do usuário
    - **user_update**: Dados para atualização
    """
    for i, existing_user in enumerate(users_db):
        if existing_user["id"] == user_id:
            # Atualizar apenas campos fornecidos
            update_data = user_update.dict(exclude_unset=True)
            for field, value in update_data.items():
                existing_user[field] = value
            
            users_db[i] = existing_user
            return existing_user
    
    raise HTTPException(status_code=404, detail="Usuário não encontrado")

@app.delete("/users/{user_id}")
async def delete_user(user_id: int):
    """
    Deletar um usuário
    
    - **user_id**: ID único do usuário
    """
    for i, user in enumerate(users_db):
        if user["id"] == user_id:
            deleted_user = users_db.pop(i)
            return {
                "message": "Usuário deletado com sucesso",
                "deleted_user": deleted_user
            }
    
    raise HTTPException(status_code=404, detail="Usuário não encontrado")

@app.get("/users/search/{query}")
async def search_users(query: str):
    """
    Buscar usuários por nome ou email
    
    - **query**: Termo de busca
    """
    results = []
    query_lower = query.lower()
    
    for user in users_db:
        if (query_lower in user["name"].lower() or 
            query_lower in user["email"].lower()):
            results.append(user)
    
    return {
        "query": query,
        "results": results,
        "count": len(results)
    }

# Inicializar dados de exemplo
@app.on_event("startup")
async def startup_event():
    """Inicializar dados de exemplo quando a aplicação iniciar"""
    global next_id
    
    sample_users = [
        {"name": "João Silva", "email": "joao@email.com", "age": 25},
        {"name": "Maria Santos", "email": "maria@email.com", "age": 30},
        {"name": "Pedro Oliveira", "email": "pedro@email.com", "age": 28},
    ]
    
    for user_data in sample_users:
        new_user = {
            "id": next_id,
            "name": user_data["name"],
            "email": user_data["email"],
            "age": user_data["age"],
            "created_at": datetime.now()
        }
        users_db.append(new_user)
        next_id += 1
    
    print(f"API iniciada com {len(users_db)} usuários de exemplo")

if __name__ == "__main__":
    uvicorn.run(
        "main:app",
        host="0.0.0.0",
        port=8000,
        reload=True,
        log_level="info"
    )
