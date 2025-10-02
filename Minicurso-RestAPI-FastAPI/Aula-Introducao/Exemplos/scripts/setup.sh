#!/bin/bash

# Script de setup para o Minicurso REST API
# Executa todos os passos automaticamente

set -e  # Parar em caso de erro

echo "🚀 Iniciando setup do Minicurso REST API..."
echo "================================================"

# Cores para output
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
NC='\033[0m' # No Color

# Função para print colorido
print_status() {
    echo -e "${GREEN}✅ $1${NC}"
}

print_warning() {
    echo -e "${YELLOW}⚠️  $1${NC}"
}

print_error() {
    echo -e "${RED}❌ $1${NC}"
}

# Verificar pré-requisitos
echo "📋 Verificando pré-requisitos..."

# Python
if command -v python3 &> /dev/null; then
    print_status "Python3 encontrado: $(python3 --version)"
else
    print_error "Python3 não encontrado. Instale Python 3.9+"
    exit 1
fi

# Docker
if command -v docker &> /dev/null; then
    print_status "Docker encontrado: $(docker --version)"
else
    print_error "Docker não encontrado. Instale Docker Desktop"
    exit 1
fi

# Docker Compose
if command -v docker-compose &> /dev/null; then
    print_status "Docker Compose encontrado: $(docker-compose --version)"
else
    print_error "Docker Compose não encontrado. Instale Docker Compose"
    exit 1
fi

# kubectl (opcional)
if command -v kubectl &> /dev/null; then
    print_status "kubectl encontrado: $(kubectl version --client --short 2>/dev/null || echo 'instalado')"
else
    print_warning "kubectl não encontrado. Kubernetes será pulado"
fi

echo ""
echo "🔧 Configurando ambiente..."

# Criar ambiente virtual
echo "📦 Criando ambiente virtual..."
python3 -m venv venv
source venv/bin/activate
print_status "Ambiente virtual criado e ativado"

# Instalar dependências
echo "📥 Instalando dependências Python..."
pip install -r requirements.txt
print_status "Dependências instaladas"

# Testar API localmente
echo "🧪 Testando API localmente..."
python main.py &
API_PID=$!
sleep 5

# Testar health check
if curl -s http://localhost:8000/health > /dev/null; then
    print_status "API local funcionando"
else
    print_error "API local não está funcionando"
    kill $API_PID 2>/dev/null || true
    exit 1
fi

# Parar API local
kill $API_PID 2>/dev/null || true
sleep 2

# Build Docker
echo "🐳 Fazendo build da imagem Docker..."
docker build -t user-api:latest .
print_status "Imagem Docker criada"

# Testar container Docker
echo "🧪 Testando container Docker..."
docker run -d -p 8000:8000 --name user-api-test user-api:latest
sleep 5

if curl -s http://localhost:8000/health > /dev/null; then
    print_status "Container Docker funcionando"
else
    print_error "Container Docker não está funcionando"
    docker stop user-api-test 2>/dev/null || true
    docker rm user-api-test 2>/dev/null || true
    exit 1
fi

# Limpar container de teste
docker stop user-api-test 2>/dev/null || true
docker rm user-api-test 2>/dev/null || true

# Docker Compose
echo "🏗️  Testando Docker Compose..."
docker-compose up -d
sleep 10

if curl -s http://localhost:8000/health > /dev/null; then
    print_status "Docker Compose funcionando"
else
    print_error "Docker Compose não está funcionando"
    docker-compose down 2>/dev/null || true
    exit 1
fi

# Parar Docker Compose
docker-compose down

# Kubernetes (se disponível)
if command -v kubectl &> /dev/null; then
    echo "☸️  Testando Kubernetes..."
    
    # Verificar se há cluster disponível
    if kubectl cluster-info &> /dev/null; then
        kubectl apply -f k8s-deployment.yaml
        sleep 30
        
        # Verificar se pods estão rodando
        if kubectl get pods -n minicurso-api | grep -q "Running"; then
            print_status "Kubernetes funcionando"
        else
            print_warning "Kubernetes configurado mas pods não estão rodando"
        fi
        
        # Limpar recursos Kubernetes
        kubectl delete -f k8s-deployment.yaml 2>/dev/null || true
    else
        print_warning "Nenhum cluster Kubernetes disponível"
    fi
fi

echo ""
echo "🎉 Setup concluído com sucesso!"
echo "================================================"
echo ""
echo "📚 Próximos passos:"
echo "1. Execute: python main.py (para API local)"
echo "2. Execute: docker-compose up -d (para microservices)"
echo "3. Execute: python test_api.py (para testes)"
echo "4. Acesse: http://localhost:8000/docs (documentação)"
echo ""
echo "📖 Consulte o Guia-Passo-a-Passo.md para mais detalhes"
echo "⚡ Consulte o Comandos-Rapidos.md para comandos úteis"
echo ""
print_status "Minicurso pronto para uso!"
