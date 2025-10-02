@echo off
REM Script de setup para o Minicurso REST API (Windows)
REM Executa todos os passos automaticamente

echo 🚀 Iniciando setup do Minicurso REST API...
echo ================================================

REM Verificar pré-requisitos
echo 📋 Verificando pré-requisitos...

REM Python
python --version >nul 2>&1
if %errorlevel% neq 0 (
    echo ❌ Python não encontrado. Instale Python 3.9+
    pause
    exit /b 1
) else (
    echo ✅ Python encontrado
)

REM Docker
docker --version >nul 2>&1
if %errorlevel% neq 0 (
    echo ❌ Docker não encontrado. Instale Docker Desktop
    pause
    exit /b 1
) else (
    echo ✅ Docker encontrado
)

REM Docker Compose
docker-compose --version >nul 2>&1
if %errorlevel% neq 0 (
    echo ❌ Docker Compose não encontrado. Instale Docker Compose
    pause
    exit /b 1
) else (
    echo ✅ Docker Compose encontrado
)

REM kubectl (opcional)
kubectl version --client >nul 2>&1
if %errorlevel% neq 0 (
    echo ⚠️  kubectl não encontrado. Kubernetes será pulado
) else (
    echo ✅ kubectl encontrado
)

echo.
echo 🔧 Configurando ambiente...

REM Criar ambiente virtual
echo 📦 Criando ambiente virtual...
python -m venv venv
call venv\Scripts\activate.bat
echo ✅ Ambiente virtual criado e ativado

REM Instalar dependências
echo 📥 Instalando dependências Python...
pip install -r requirements.txt
echo ✅ Dependências instaladas

REM Testar API localmente
echo 🧪 Testando API localmente...
start /b python main.py
timeout /t 5 /nobreak >nul

REM Testar health check
curl -s http://localhost:8000/health >nul 2>&1
if %errorlevel% neq 0 (
    echo ❌ API local não está funcionando
    taskkill /f /im python.exe >nul 2>&1
    pause
    exit /b 1
) else (
    echo ✅ API local funcionando
)

REM Parar API local
taskkill /f /im python.exe >nul 2>&1
timeout /t 2 /nobreak >nul

REM Build Docker
echo 🐳 Fazendo build da imagem Docker...
docker build -t user-api:latest .
if %errorlevel% neq 0 (
    echo ❌ Erro no build Docker
    pause
    exit /b 1
) else (
    echo ✅ Imagem Docker criada
)

REM Testar container Docker
echo 🧪 Testando container Docker...
docker run -d -p 8000:8000 --name user-api-test user-api:latest
timeout /t 5 /nobreak >nul

curl -s http://localhost:8000/health >nul 2>&1
if %errorlevel% neq 0 (
    echo ❌ Container Docker não está funcionando
    docker stop user-api-test >nul 2>&1
    docker rm user-api-test >nul 2>&1
    pause
    exit /b 1
) else (
    echo ✅ Container Docker funcionando
)

REM Limpar container de teste
docker stop user-api-test >nul 2>&1
docker rm user-api-test >nul 2>&1

REM Docker Compose
echo 🏗️  Testando Docker Compose...
docker-compose up -d
timeout /t 10 /nobreak >nul

curl -s http://localhost:8000/health >nul 2>&1
if %errorlevel% neq 0 (
    echo ❌ Docker Compose não está funcionando
    docker-compose down >nul 2>&1
    pause
    exit /b 1
) else (
    echo ✅ Docker Compose funcionando
)

REM Parar Docker Compose
docker-compose down

REM Kubernetes (se disponível)
kubectl version --client >nul 2>&1
if %errorlevel% equ 0 (
    echo ☸️  Testando Kubernetes...
    
    kubectl cluster-info >nul 2>&1
    if %errorlevel% equ 0 (
        kubectl apply -f k8s-deployment.yaml
        timeout /t 30 /nobreak >nul
        
        kubectl get pods -n minicurso-api | findstr "Running" >nul 2>&1
        if %errorlevel% equ 0 (
            echo ✅ Kubernetes funcionando
        ) else (
            echo ⚠️  Kubernetes configurado mas pods não estão rodando
        )
        
        kubectl delete -f k8s-deployment.yaml >nul 2>&1
    ) else (
        echo ⚠️  Nenhum cluster Kubernetes disponível
    )
)

echo.
echo 🎉 Setup concluído com sucesso!
echo ================================================
echo.
echo 📚 Próximos passos:
echo 1. Execute: python main.py (para API local)
echo 2. Execute: docker-compose up -d (para microservices)
echo 3. Execute: python test_api.py (para testes)
echo 4. Acesse: http://localhost:8000/docs (documentação)
echo.
echo 📖 Consulte o Guia-Passo-a-Passo.md para mais detalhes
echo ⚡ Consulte o Comandos-Rapidos.md para comandos úteis
echo.
echo ✅ Minicurso pronto para uso!
echo.
pause
