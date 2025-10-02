# 🚀 Comandos - Minicurso REST API Simples

## 📋 Pré-requisitos

- Docker Desktop instalado e rodando
- Kubernetes habilitado no Docker Desktop
- kubectl configurado

## 🔧 Comandos de Build e Push

### 1. User Service

```bash
# Navegar para o diretório
cd user-service

# Build da imagem
docker build -t user-service:latest .

# Tag para registry local
docker tag user-service:latest localhost:5000/user-service:latest

# Push para registry local
docker push localhost:5000/user-service:latest

# Voltar ao diretório raiz
cd ..
```

### 2. Product Service

```bash
# Navegar para o diretório
cd product-service

# Build da imagem
docker build -t product-service:latest .

# Tag para registry local
docker tag product-service:latest localhost:5000/product-service:latest

# Push para registry local
docker push localhost:5000/product-service:latest

# Voltar ao diretório raiz
cd ..
```

## ☸️ Comandos Kubernetes

### 1. Aplicar Deployments e Services

```bash
# Aplicar User Service
kubectl apply -f k8s/user-deployment.yaml
kubectl apply -f k8s/user-service.yaml

# Aplicar Product Service
kubectl apply -f k8s/product-deployment.yaml
kubectl apply -f k8s/product-service.yaml
```

### 2. Verificar Status

```bash
# Ver pods
kubectl get pods

# Ver services
kubectl get services

# Ver deployments
kubectl get deployments
```

### 3. Port Forward para Testar

```bash
# User Service (terminal 1)
kubectl port-forward service/user-service 8001:80

# Product Service (terminal 2)
kubectl port-forward service/product-service 8002:80
```

### 4. Testar APIs

```bash
# User Service
curl http://localhost:8001/health
curl http://localhost:8001/users
curl http://localhost:8001/users/1

# Product Service
curl http://localhost:8002/health
curl http://localhost:8002/products
curl http://localhost:8002/products/1
```

## 🧹 Limpeza

```bash
# Remover recursos Kubernetes
kubectl delete -f k8s/

# Remover imagens Docker
docker rmi user-service:latest
docker rmi product-service:latest
docker rmi localhost:5000/user-service:latest
docker rmi localhost:5000/product-service:latest
```

## 🔍 Troubleshooting

### Verificar Logs

```bash
# Logs do User Service
kubectl logs -l app=user-service

# Logs do Product Service
kubectl logs -l app=product-service
```

### Verificar Descrição dos Pods

```bash
# Descrição dos pods
kubectl describe pods

# Descrição dos services
kubectl describe services
```

### Reiniciar Deployments

```bash
# Reiniciar User Service
kubectl rollout restart deployment/user-service

# Reiniciar Product Service
kubectl rollout restart deployment/product-service
```
