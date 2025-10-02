# 🚀 Guia Passo a Passo - Minicurso REST API

## 📋 Pré-requisitos

Antes de começar, certifique-se de ter instalado:

- ✅ Python 3.9+
- ✅ Docker Desktop
- ✅ Docker Compose
- ✅ kubectl (opcional)
- ✅ Git

## 🎯 Objetivo

Ao final deste guia, você terá:
- Uma API REST funcionando com FastAPI
- Aplicação containerizada com Docker
- Microservices orquestrados com Docker Compose
- Deploy no Kubernetes (opcional)

---

## 📁 PASSO 1: Preparar o Ambiente

### 1.1 Clonar/Download dos Arquivos

```bash
# Se usando Git
git clone https://github.com/californi/disciplinas-ufla.git
cd Minicurso-RestAPI-FastAPI/Aula-Introducao/Exemplos

# Ou baixe os arquivos manualmente e navegue até a pasta
cd Minicurso-RestAPI-FastAPI/Aula-Introducao/Exemplos
```

### 1.2 Verificar Arquivos

```bash
# Listar arquivos
ls -la

# Deve mostrar:
# - main.py
# - requirements.txt
# - Dockerfile
# - docker-compose.yml
# - k8s-deployment.yaml
# - test_api.py
# - README.md
```

---

## 🐍 PASSO 2: Executar Localmente (Python)

### 2.1 Instalar Dependências

```bash
# Criar ambiente virtual (recomendado)
python -m venv venv

# Ativar ambiente virtual
# Windows:
venv\Scripts\activate
# Linux/Mac:
source venv/bin/activate

# Instalar dependências
pip install -r requirements.txt
```

### 2.2 Executar a API

```bash
# Executar a aplicação
python main.py
```

**✅ Resultado esperado:**
```
INFO:     Started server process [12345]
INFO:     Waiting for application startup.
API iniciada com 3 usuários de exemplo
INFO:     Application startup complete.
INFO:     Uvicorn running on http://0.0.0.0:8000 (Press CTRL+C to quit)
```

### 2.3 Testar a API

```bash
# Em outro terminal, testar a API
curl http://localhost:8000/health

# Ou abrir no navegador:
# http://localhost:8000/docs
```

**✅ Resultado esperado:**
```json
{
  "status": "healthy",
  "timestamp": "2024-01-15T10:30:00",
  "users_count": 3
}
```

### 2.4 Executar Testes Automatizados

```bash
# Instalar requests se não estiver instalado
pip install requests

# Executar testes
python test_api.py
```

**✅ Resultado esperado:**
```
🚀 Iniciando testes da API...
==================================================
1. Testando Health Check...
Status: 200
Response: {'status': 'healthy', 'timestamp': '...', 'users_count': 3}
...
✅ Testes concluídos!
```

---

## 🐳 PASSO 3: Containerizar com Docker

### 3.1 Build da Imagem Docker

```bash
# Fazer build da imagem
docker build -t user-api:latest .

# Verificar se a imagem foi criada
docker images | grep user-api
```

**✅ Resultado esperado:**
```
REPOSITORY    TAG       IMAGE ID       CREATED         SIZE
user-api      latest    abc123def456   2 minutes ago   150MB
```

### 3.2 Executar Container

```bash
# Executar container
docker run -d -p 8000:8000 --name user-api-container user-api:latest

# Verificar se está rodando
docker ps
```

**✅ Resultado esperado:**
```
CONTAINER ID   IMAGE           COMMAND                  CREATED         STATUS         PORTS                    NAMES
abc123def456   user-api:latest "uvicorn main:app --…"   2 minutes ago   Up 2 minutes   0.0.0.0:8000->8000/tcp   user-api-container
```

### 3.3 Testar Container

```bash
# Testar a API no container
curl http://localhost:8000/health

# Ver logs do container
docker logs user-api-container

# Parar container
docker stop user-api-container

# Remover container
docker rm user-api-container
```

---

## 🏗️ PASSO 4: Microservices com Docker Compose

### 4.1 Iniciar Microservices

```bash
# Iniciar todos os serviços
docker-compose up -d

# Verificar status dos serviços
docker-compose ps
```

**✅ Resultado esperado:**
```
Name                     Command               State           Ports         
-----------------------------------------------------------------------------
exemplos_api-gateway_1   uvicorn main:app ...   Up      0.0.0.0:8000->8000/tcp
exemplos_db_1            docker-entrypoint.sh   Up      0.0.0.0:5432->5432/tcp
exemplos_nginx_1         nginx -g daemon off;   Up      0.0.0.0:80->80/tcp
exemplos_product-api_1   uvicorn main:app ...   Up      0.0.0.0:8002->8000/tcp
exemplos_redis_1         docker-entrypoint.sh   Up      0.0.0.0:6379->6379/tcp
exemplos_user-api_1      uvicorn main:app ...   Up      0.0.0.0:8001->8000/tcp
```

### 4.2 Testar Microservices

```bash
# Testar API Gateway
curl http://localhost:8000/health

# Testar User API diretamente
curl http://localhost:8001/health

# Testar Product API diretamente
curl http://localhost:8002/health

# Testar através do Nginx
curl http://localhost:80/health
```

### 4.3 Verificar Logs

```bash
# Ver logs de todos os serviços
docker-compose logs

# Ver logs de um serviço específico
docker-compose logs user-api

# Ver logs em tempo real
docker-compose logs -f api-gateway
```

### 4.4 Parar Microservices

```bash
# Parar todos os serviços
docker-compose down

# Parar e remover volumes (cuidado: apaga dados)
docker-compose down -v
```

---

## ☸️ PASSO 5: Deploy no Kubernetes (Opcional)

### 5.1 Pré-requisitos Kubernetes

```bash
# Verificar se kubectl está instalado
kubectl version --client

# Verificar cluster (se usando minikube)
minikube status

# Se não tiver minikube, instalar:
# Windows: choco install minikube
# Mac: brew install minikube
# Linux: curl -LO https://storage.googleapis.com/minikube/releases/latest/minikube-linux-amd64
```

### 5.2 Iniciar Minikube (se necessário)

```bash
# Iniciar minikube
minikube start

# Verificar status
minikube status

# Habilitar ingress
minikube addons enable ingress
```

### 5.3 Aplicar Configurações Kubernetes

```bash
# Aplicar todas as configurações
kubectl apply -f k8s-deployment.yaml

# Verificar namespace
kubectl get namespaces | grep minicurso

# Verificar pods
kubectl get pods -n minicurso-api
```

**✅ Resultado esperado:**
```
NAME                           READY   STATUS    RESTARTS   AGE
api-gateway-7d4b8c9f6-abc12    1/1     Running   0          2m
postgres-6f8e9d2a1-def34       1/1     Running   0          2m
product-api-5c7b8a9d2-ghi56    1/1     Running   0          2m
redis-4b6c8e1f3-jkl78          1/1     Running   0          2m
user-api-3a5b7c9e1-mno90       1/1     Running   0          2m
```

### 5.4 Verificar Serviços

```bash
# Verificar serviços
kubectl get services -n minicurso-api

# Verificar ingress
kubectl get ingress -n minicurso-api
```

### 5.5 Acessar a Aplicação

```bash
# Obter URL do serviço (minikube)
minikube service api-gateway-service -n minicurso-api

# Ou usar port-forward
kubectl port-forward service/api-gateway-service 8000:80 -n minicurso-api
```

### 5.6 Testar no Kubernetes

```bash
# Testar health check
curl http://localhost:8000/health

# Testar API
curl http://localhost:8000/users
```

### 5.7 Limpar Recursos Kubernetes

```bash
# Remover todos os recursos
kubectl delete -f k8s-deployment.yaml

# Verificar se foi removido
kubectl get pods -n minicurso-api
```

---

## 🧪 PASSO 6: Testes e Validação

### 6.1 Testes Manuais

```bash
# 1. Health Check
curl http://localhost:8000/health

# 2. Listar usuários
curl http://localhost:8000/users

# 3. Criar usuário
curl -X POST http://localhost:8000/users \
  -H "Content-Type: application/json" \
  -d '{"name": "Teste User", "email": "teste@email.com", "age": 25}'

# 4. Buscar usuário
curl http://localhost:8000/users/1

# 5. Atualizar usuário
curl -X PUT http://localhost:8000/users/1 \
  -H "Content-Type: application/json" \
  -d '{"name": "Teste User Atualizado", "age": 26}'

# 6. Deletar usuário
curl -X DELETE http://localhost:8000/users/1
```

### 6.2 Testes Automatizados

```bash
# Executar suite de testes
python test_api.py

# Teste de performance
python -c "
import requests
import time
start = time.time()
for i in range(100):
    requests.get('http://localhost:8000/health')
end = time.time()
print(f'100 requests em {end-start:.2f}s')
print(f'{(100/(end-start)):.2f} req/s')
"
```

---

## 🔧 PASSO 7: Troubleshooting

### 7.1 Problemas Comuns

#### Porta já em uso
```bash
# Verificar processo na porta 8000
netstat -ano | findstr :8000  # Windows
lsof -i :8000                 # Linux/Mac

# Matar processo
taskkill /PID <PID> /F        # Windows
kill -9 <PID>                 # Linux/Mac
```

#### Docker não inicia
```bash
# Verificar status do Docker
docker --version
docker-compose --version

# Reiniciar Docker Desktop
# Windows: Reiniciar Docker Desktop
# Linux: sudo systemctl restart docker
```

#### Kubernetes não aplica
```bash
# Verificar cluster
kubectl cluster-info

# Verificar contexto
kubectl config current-context

# Aplicar novamente
kubectl apply -f k8s-deployment.yaml --force
```

### 7.2 Logs e Debug

```bash
# Docker Compose logs
docker-compose logs -f

# Kubernetes logs
kubectl logs -f deployment/user-api -n minicurso-api

# Docker logs
docker logs user-api-container
```

---

## 📊 PASSO 8: Monitoramento

### 8.1 Verificar Status

```bash
# Docker Compose
docker-compose ps

# Kubernetes
kubectl get pods -n minicurso-api
kubectl get services -n minicurso-api

# Docker
docker ps
docker images
```

### 8.2 Métricas de Performance

```bash
# Teste de carga simples
ab -n 1000 -c 10 http://localhost:8000/health

# Ou usando curl
for i in {1..100}; do curl -s http://localhost:8000/health > /dev/null; done
```

---

## 🎉 PASSO 9: Conclusão

### 9.1 Limpeza Final

```bash
# Parar Docker Compose
docker-compose down

# Remover imagens Docker
docker rmi user-api:latest

# Limpar Kubernetes (se usado)
kubectl delete -f k8s-deployment.yaml

# Parar minikube (se usado)
minikube stop
```

### 9.2 Próximos Passos

1. **Estudar mais sobre:**
   - Service Mesh (Istio)
   - Message Queues (RabbitMQ, Kafka)
   - Monitoring (Prometheus, Grafana)
   - CI/CD (GitHub Actions, GitLab CI)

2. **Praticar:**
   - Criar mais endpoints
   - Adicionar autenticação
   - Implementar cache
   - Adicionar testes unitários

3. **Recursos:**
   - [FastAPI Documentation](https://fastapi.tiangolo.com/)
   - [Docker Documentation](https://docs.docker.com/)
   - [Kubernetes Documentation](https://kubernetes.io/docs/)

---

## 📞 Suporte

Se encontrar problemas:

1. Verifique os logs
2. Consulte a documentação
3. Teste cada passo individualmente
4. Verifique pré-requisitos

**Boa sorte e bom aprendizado! 🚀**
