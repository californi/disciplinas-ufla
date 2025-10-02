@echo off
REM Script de demonstração para o Minicurso REST API (Windows)
REM Executa uma demonstração completa passo a passo

echo 🎬 Iniciando demonstração do Minicurso REST API...
echo ==================================================

REM Função para aguardar input do usuário
:wait_for_user
echo.
pause
echo.

REM PASSO 1: API Local
echo 🔹 PASSO 1: Executando API localmente
echo Iniciando API FastAPI...
start /b python main.py
timeout /t 3 /nobreak >nul

curl -s http://localhost:8000/health >nul 2>&1
if %errorlevel% neq 0 (
    echo ❌ API local não está funcionando
    taskkill /f /im python.exe >nul 2>&1
    pause
    exit /b 1
) else (
    echo ✅ API local funcionando!
    echo Acesse: http://localhost:8000/docs
)

call :wait_for_user

REM PASSO 2: Testes da API
echo 🔹 PASSO 2: Testando endpoints da API
echo Executando testes automatizados...
python test_api.py

call :wait_for_user

REM PASSO 3: Docker
echo 🔹 PASSO 3: Containerizando com Docker
echo Parando API local...
taskkill /f /im python.exe >nul 2>&1
timeout /t 2 /nobreak >nul

echo Fazendo build da imagem Docker...
docker build -t user-api:latest .
if %errorlevel% neq 0 (
    echo ❌ Erro no build Docker
    pause
    exit /b 1
)

echo Executando container...
docker run -d -p 8000:8000 --name demo-container user-api:latest
timeout /t 3 /nobreak >nul

curl -s http://localhost:8000/health >nul 2>&1
if %errorlevel% neq 0 (
    echo ❌ Container Docker não está funcionando
    docker stop demo-container >nul 2>&1
    docker rm demo-container >nul 2>&1
    pause
    exit /b 1
) else (
    echo ✅ Container Docker funcionando!
)

call :wait_for_user

REM PASSO 4: Docker Compose
echo 🔹 PASSO 4: Microservices com Docker Compose
echo Parando container individual...
docker stop demo-container >nul 2>&1
docker rm demo-container >nul 2>&1

echo Iniciando microservices...
docker-compose up -d
timeout /t 10 /nobreak >nul

curl -s http://localhost:8000/health >nul 2>&1
if %errorlevel% neq 0 (
    echo ❌ Microservices não estão funcionando
    docker-compose down >nul 2>&1
    pause
    exit /b 1
) else (
    echo ✅ Microservices funcionando!
    echo Serviços disponíveis:
    echo - API Gateway: http://localhost:8000
    echo - User API: http://localhost:8001
    echo - Product API: http://localhost:8002
    echo - Nginx: http://localhost:80
)

call :wait_for_user

REM PASSO 5: Testes dos Microservices
echo 🔹 PASSO 5: Testando microservices
echo Testando API Gateway...
curl -s http://localhost:8000/health

echo.
echo Testando User API...
curl -s http://localhost:8001/health

echo.
echo Testando Product API...
curl -s http://localhost:8002/health

echo.
echo Testando através do Nginx...
curl -s http://localhost:80/health

call :wait_for_user

REM PASSO 6: Kubernetes (se disponível)
kubectl version --client >nul 2>&1
if %errorlevel% equ 0 (
    kubectl cluster-info >nul 2>&1
    if %errorlevel% equ 0 (
        echo 🔹 PASSO 6: Deploy no Kubernetes
        echo Parando Docker Compose...
        docker-compose down
        
        echo Aplicando configurações Kubernetes...
        kubectl apply -f k8s-deployment.yaml
        timeout /t 30 /nobreak >nul
        
        echo Verificando pods...
        kubectl get pods -n minicurso-api
        
        echo Fazendo port-forward...
        start /b kubectl port-forward service/api-gateway-service 8000:80 -n minicurso-api
        timeout /t 5 /nobreak >nul
        
        curl -s http://localhost:8000/health >nul 2>&1
        if %errorlevel% equ 0 (
            echo ✅ Kubernetes funcionando!
        ) else (
            echo ⚠️  Kubernetes configurado mas não acessível
        )
        
        call :wait_for_user
        
        echo Limpando recursos Kubernetes...
        taskkill /f /im kubectl.exe >nul 2>&1
        kubectl delete -f k8s-deployment.yaml >nul 2>&1
    ) else (
        echo ⚠️  Kubernetes não disponível - pulando passo 6
    )
) else (
    echo ⚠️  Kubernetes não disponível - pulando passo 6
)

REM Limpeza final
echo 🔹 Limpando recursos...
docker-compose down >nul 2>&1
docker rmi user-api:latest >nul 2>&1

echo.
echo 🎉 Demonstração concluída com sucesso!
echo ==================================================
echo.
echo 📚 O que você aprendeu:
echo ✅ Como criar APIs REST com FastAPI
echo ✅ Como containerizar aplicações com Docker
echo ✅ Como orquestrar microservices com Docker Compose
echo ✅ Como fazer deploy no Kubernetes
echo.
echo 📖 Próximos passos:
echo 1. Consulte o Guia-Passo-a-Passo.md
echo 2. Experimente os comandos do Comandos-Rapidos.md
echo 3. Modifique o código e teste suas próprias APIs
echo.
echo ✅ Obrigado por participar do minicurso!
echo.
pause
