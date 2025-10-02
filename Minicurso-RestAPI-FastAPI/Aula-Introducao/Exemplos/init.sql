-- Script de inicialização do banco de dados
-- Criar banco de dados para usuários
CREATE DATABASE users;

-- Criar banco de dados para produtos
CREATE DATABASE products;

-- Conectar ao banco de usuários
\c users;

-- Criar tabela de usuários
CREATE TABLE users (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    age INTEGER,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Inserir dados de exemplo
INSERT INTO users (name, email, age) VALUES
('João Silva', 'joao@email.com', 25),
('Maria Santos', 'maria@email.com', 30),
('Pedro Oliveira', 'pedro@email.com', 28);

-- Conectar ao banco de produtos
\c products;

-- Criar tabela de produtos
CREATE TABLE products (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    description TEXT,
    price DECIMAL(10,2) NOT NULL,
    stock INTEGER DEFAULT 0,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Inserir dados de exemplo
INSERT INTO products (name, description, price, stock) VALUES
('Notebook Dell', 'Notebook Dell Inspiron 15', 2500.00, 10),
('Mouse Logitech', 'Mouse sem fio Logitech', 89.90, 50),
('Teclado Mecânico', 'Teclado mecânico RGB', 299.90, 25);
