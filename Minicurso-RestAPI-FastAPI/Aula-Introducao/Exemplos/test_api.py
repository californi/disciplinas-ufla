"""
Script de teste para a API
Demonstra como testar os endpoints da API
"""

import requests
import json
import time

# URL base da API
BASE_URL = "http://localhost:8000"

def test_api():
    """Testar todos os endpoints da API"""
    
    print("🚀 Iniciando testes da API...")
    print("=" * 50)
    
    # Teste 1: Health Check
    print("\n1. Testando Health Check...")
    try:
        response = requests.get(f"{BASE_URL}/health")
        print(f"Status: {response.status_code}")
        print(f"Response: {response.json()}")
    except Exception as e:
        print(f"Erro: {e}")
    
    # Teste 2: Listar usuários
    print("\n2. Listando usuários...")
    try:
        response = requests.get(f"{BASE_URL}/users")
        print(f"Status: {response.status_code}")
        print(f"Usuários encontrados: {len(response.json())}")
    except Exception as e:
        print(f"Erro: {e}")
    
    # Teste 3: Criar novo usuário
    print("\n3. Criando novo usuário...")
    new_user = {
        "name": "Ana Costa",
        "email": "ana@email.com",
        "age": 27
    }
    try:
        response = requests.post(f"{BASE_URL}/users", json=new_user)
        print(f"Status: {response.status_code}")
        if response.status_code == 200:
            created_user = response.json()
            print(f"Usuário criado: {created_user['name']} (ID: {created_user['id']})")
            user_id = created_user['id']
        else:
            print(f"Erro: {response.text}")
            return
    except Exception as e:
        print(f"Erro: {e}")
        return
    
    # Teste 4: Buscar usuário específico
    print(f"\n4. Buscando usuário ID {user_id}...")
    try:
        response = requests.get(f"{BASE_URL}/users/{user_id}")
        print(f"Status: {response.status_code}")
        if response.status_code == 200:
            user = response.json()
            print(f"Usuário encontrado: {user['name']}")
        else:
            print(f"Erro: {response.text}")
    except Exception as e:
        print(f"Erro: {e}")
    
    # Teste 5: Atualizar usuário
    print(f"\n5. Atualizando usuário ID {user_id}...")
    update_data = {
        "name": "Ana Costa Silva",
        "age": 28
    }
    try:
        response = requests.put(f"{BASE_URL}/users/{user_id}", json=update_data)
        print(f"Status: {response.status_code}")
        if response.status_code == 200:
            updated_user = response.json()
            print(f"Usuário atualizado: {updated_user['name']} (idade: {updated_user['age']})")
        else:
            print(f"Erro: {response.text}")
    except Exception as e:
        print(f"Erro: {e}")
    
    # Teste 6: Buscar usuários
    print("\n6. Buscando usuários por nome...")
    try:
        response = requests.get(f"{BASE_URL}/users/search/Ana")
        print(f"Status: {response.status_code}")
        if response.status_code == 200:
            search_result = response.json()
            print(f"Resultados encontrados: {search_result['count']}")
            for user in search_result['results']:
                print(f"  - {user['name']} ({user['email']})")
        else:
            print(f"Erro: {response.text}")
    except Exception as e:
        print(f"Erro: {e}")
    
    # Teste 7: Deletar usuário
    print(f"\n7. Deletando usuário ID {user_id}...")
    try:
        response = requests.delete(f"{BASE_URL}/users/{user_id}")
        print(f"Status: {response.status_code}")
        if response.status_code == 200:
            result = response.json()
            print(f"Resultado: {result['message']}")
        else:
            print(f"Erro: {response.text}")
    except Exception as e:
        print(f"Erro: {e}")
    
    # Teste 8: Verificar se usuário foi deletado
    print(f"\n8. Verificando se usuário ID {user_id} foi deletado...")
    try:
        response = requests.get(f"{BASE_URL}/users/{user_id}")
        print(f"Status: {response.status_code}")
        if response.status_code == 404:
            print("✅ Usuário foi deletado com sucesso!")
        else:
            print("❌ Usuário ainda existe")
    except Exception as e:
        print(f"Erro: {e}")
    
    print("\n" + "=" * 50)
    print("✅ Testes concluídos!")

def test_performance():
    """Teste de performance básico"""
    print("\n🏃 Testando performance...")
    
    # Teste de carga simples
    start_time = time.time()
    successful_requests = 0
    failed_requests = 0
    
    for i in range(100):
        try:
            response = requests.get(f"{BASE_URL}/health")
            if response.status_code == 200:
                successful_requests += 1
            else:
                failed_requests += 1
        except:
            failed_requests += 1
    
    end_time = time.time()
    total_time = end_time - start_time
    
    print(f"Total de requisições: 100")
    print(f"Sucessos: {successful_requests}")
    print(f"Falhas: {failed_requests}")
    print(f"Tempo total: {total_time:.2f}s")
    print(f"Requisições por segundo: {100/total_time:.2f}")

if __name__ == "__main__":
    # Aguardar a API estar pronta
    print("⏳ Aguardando API estar pronta...")
    time.sleep(2)
    
    # Executar testes
    test_api()
    test_performance()
