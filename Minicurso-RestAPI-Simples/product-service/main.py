"""
Product Service - API REST com FastAPI
Minicurso REST API Simples
"""

from fastapi import FastAPI
from pydantic import BaseModel
from typing import List
import uvicorn

app = FastAPI(title="Product Service", version="1.0.0")

# Modelo de dados
class Product(BaseModel):
    id: int
    name: str
    price: float
    description: str

# Dados em memoria
products = [
    Product(id=1, name="Notebook Dell", price=2500.00, description="Notebook Dell Inspiron 15"),
    Product(id=2, name="Mouse Logitech", price=89.90, description="Mouse sem fio Logitech"),
    Product(id=3, name="Teclado Mecanico", price=299.90, description="Teclado mecanico RGB")
]

@app.get("/")
async def root():
    return {"message": "Product Service - Minicurso REST API"}

@app.get("/health")
async def health():
    return {"status": "healthy", "service": "product-service"}

@app.get("/products", response_model=List[Product])
async def get_products():
    return products

@app.get("/products/{product_id}", response_model=Product)
async def get_product(product_id: int):
    for product in products:
        if product.id == product_id:
            return product
    return {"error": "Product not found"}

if __name__ == "__main__":
    uvicorn.run(app, host="0.0.0.0", port=8000)
