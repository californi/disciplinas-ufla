# ⚡ Comandos Rápidos - Minicurso REST API

## 🚀 Execução Rápida

### 1. Executar Localmente
```bash
cd Minicurso-RestAPI-FastAPI/Aula-Introducao/Exemplos
pip install -r requirements.txt
python main.py
```

### 2. Testar API
```bash
curl http://localhost:8000/health
python test_api.py
```

### 3. Docker Build e Run
```bash
docker build -t user-api:latest .
docker run -d -p 8000:8000 --name user-api-container user-api:latest
```

### 4. Docker Compose
```bash
docker-compose up -d
docker-compose ps
docker-compose logs -f
```

### 5. Kubernetes Deploy
```bash
kubectl apply -f k8s-deployment.yaml
kubectl get pods -n minicurso-api
kubectl port-forward service/api-gateway-service 8000:80 -n minicurso-api
```

### 6. Limpeza
```bash
docker-compose down
docker rmi user-api:latest
kubectl delete -f k8s-deployment.yaml
```

## 🔧 Troubleshooting

### Porta em uso
```bash
netstat -ano | findstr :8000  # Windows
lsof -i :8000                 # Linux/Mac
```

### Docker não inicia
```bash
docker --version
docker-compose --version
```

### Kubernetes não aplica
```bash
kubectl cluster-info
kubectl apply -f k8s-deployment.yaml --force
```

## 📊 Verificar Status

### Docker
```bash
docker ps
docker images
docker-compose ps
```

### Kubernetes
```bash
kubectl get pods -n minicurso-api
kubectl get services -n minicurso-api
kubectl get ingress -n minicurso-api
```

## 🧪 Testes

### Manual
```bash
curl http://localhost:8000/health
curl http://localhost:8000/users
curl -X POST http://localhost:8000/users -H "Content-Type: application/json" -d '{"name": "Teste", "email": "teste@email.com", "age": 25}'
```

### Automatizado
```bash
python test_api.py
```

## 📝 Logs

### Docker
```bash
docker logs user-api-container
docker-compose logs -f
```

### Kubernetes
```bash
kubectl logs -f deployment/user-api -n minicurso-api
```
