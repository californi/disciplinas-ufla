#!/bin/bash

# Script de demonstração para o Minicurso REST API
# Executa uma demonstração completa passo a passo

set -e

echo "🎬 Iniciando demonstração do Minicurso REST API..."
echo "=================================================="

# Cores para output
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
BLUE='\033[0;34m'
NC='\033[0m' # No Color

print_step() {
    echo -e "${BLUE}🔹 $1${NC}"
}

print_success() {
    echo -e "${GREEN}✅ $1${NC}"
}

print_warning() {
    echo -e "${YELLOW}⚠️  $1${NC}"
}

print_error() {
    echo -e "${RED}❌ $1${NC}"
}

# Função para aguardar input do usuário
wait_for_user() {
    echo ""
    read -p "Pressione Enter para continuar..."
    echo ""
}

# PASSO 1: API Local
print_step "PASSO 1: Executando API localmente"
echo "Iniciando API FastAPI..."
python main.py &
API_PID=$!
sleep 3

if curl -s http://localhost:8000/health > /dev/null; then
    print_success "API local funcionando!"
    echo "Acesse: http://localhost:8000/docs"
else
    print_error "API local não está funcionando"
    kill $API_PID 2>/dev/null || true
    exit 1
fi

wait_for_user

# PASSO 2: Testes da API
print_step "PASSO 2: Testando endpoints da API"
echo "Executando testes automatizados..."
python test_api.py

wait_for_user

# PASSO 3: Docker
print_step "PASSO 3: Containerizando com Docker"
echo "Parando API local..."
kill $API_PID 2>/dev/null || true
sleep 2

echo "Fazendo build da imagem Docker..."
docker build -t user-api:latest .

echo "Executando container..."
docker run -d -p 8000:8000 --name demo-container user-api:latest
sleep 3

if curl -s http://localhost:8000/health > /dev/null; then
    print_success "Container Docker funcionando!"
else
    print_error "Container Docker não está funcionando"
    docker stop demo-container 2>/dev/null || true
    docker rm demo-container 2>/dev/null || true
    exit 1
fi

wait_for_user

# PASSO 4: Docker Compose
print_step "PASSO 4: Microservices com Docker Compose"
echo "Parando container individual..."
docker stop demo-container 2>/dev/null || true
docker rm demo-container 2>/dev/null || true

echo "Iniciando microservices..."
docker-compose up -d
sleep 10

if curl -s http://localhost:8000/health > /dev/null; then
    print_success "Microservices funcionando!"
    echo "Serviços disponíveis:"
    echo "- API Gateway: http://localhost:8000"
    echo "- User API: http://localhost:8001"
    echo "- Product API: http://localhost:8002"
    echo "- Nginx: http://localhost:80"
else
    print_error "Microservices não estão funcionando"
    docker-compose down 2>/dev/null || true
    exit 1
fi

wait_for_user

# PASSO 5: Testes dos Microservices
print_step "PASSO 5: Testando microservices"
echo "Testando API Gateway..."
curl -s http://localhost:8000/health | jq . 2>/dev/null || curl -s http://localhost:8000/health

echo ""
echo "Testando User API..."
curl -s http://localhost:8001/health | jq . 2>/dev/null || curl -s http://localhost:8001/health

echo ""
echo "Testando Product API..."
curl -s http://localhost:8002/health | jq . 2>/dev/null || curl -s http://localhost:8002/health

echo ""
echo "Testando através do Nginx..."
curl -s http://localhost:80/health | jq . 2>/dev/null || curl -s http://localhost:80/health

wait_for_user

# PASSO 6: Kubernetes (se disponível)
if command -v kubectl &> /dev/null && kubectl cluster-info &> /dev/null; then
    print_step "PASSO 6: Deploy no Kubernetes"
    echo "Parando Docker Compose..."
    docker-compose down
    
    echo "Aplicando configurações Kubernetes..."
    kubectl apply -f k8s-deployment.yaml
    sleep 30
    
    echo "Verificando pods..."
    kubectl get pods -n minicurso-api
    
    echo "Fazendo port-forward..."
    kubectl port-forward service/api-gateway-service 8000:80 -n minicurso-api &
    K8S_PID=$!
    sleep 5
    
    if curl -s http://localhost:8000/health > /dev/null; then
        print_success "Kubernetes funcionando!"
    else
        print_warning "Kubernetes configurado mas não acessível"
    fi
    
    wait_for_user
    
    echo "Limpando recursos Kubernetes..."
    kill $K8S_PID 2>/dev/null || true
    kubectl delete -f k8s-deployment.yaml 2>/dev/null || true
else
    print_warning "Kubernetes não disponível - pulando passo 6"
fi

# Limpeza final
print_step "Limpando recursos..."
docker-compose down 2>/dev/null || true
docker rmi user-api:latest 2>/dev/null || true

echo ""
echo "🎉 Demonstração concluída com sucesso!"
echo "=================================================="
echo ""
echo "📚 O que você aprendeu:"
echo "✅ Como criar APIs REST com FastAPI"
echo "✅ Como containerizar aplicações com Docker"
echo "✅ Como orquestrar microservices com Docker Compose"
echo "✅ Como fazer deploy no Kubernetes"
echo ""
echo "📖 Próximos passos:"
echo "1. Consulte o Guia-Passo-a-Passo.md"
echo "2. Experimente os comandos do Comandos-Rapidos.md"
echo "3. Modifique o código e teste suas próprias APIs"
echo ""
print_success "Obrigado por participar do minicurso!"
