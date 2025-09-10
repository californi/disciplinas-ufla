using System;

namespace Exemplos
{
    /// <summary>
    /// Classe principal para demonstrar o uso das classes ContaBancaria, Animal e Produto
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Demonstração de Classes e Objetos ===\n");

            // Demonstração da classe ContaBancaria
            DemonstrarContaBancaria();
            
            Console.WriteLine("\n" + new string('=', 50) + "\n");
            
            // Demonstração da classe Animal
            DemonstrarAnimal();
            
            Console.WriteLine("\n" + new string('=', 50) + "\n");
            
            // Demonstração da classe Produto
            DemonstrarProduto();
            
            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        /// <summary>
        /// Demonstra o uso da classe ContaBancaria
        /// </summary>
        static void DemonstrarContaBancaria()
        {
            Console.WriteLine("=== DEMONSTRAÇÃO: Conta Bancária ===");
            
            // Criando contas bancárias
            ContaBancaria contaJoao = new ContaBancaria("12345-6", "João Silva", "Corrente", 1000.0);
            ContaBancaria contaMaria = new ContaBancaria("67890-1", "Maria Santos", "Poupança", 2500.0);
            
            Console.WriteLine("Contas criadas:");
            contaJoao.ExibirInformacoes();
            contaMaria.ExibirInformacoes();
            
            Console.WriteLine("\n--- Operações na conta do João ---");
            contaJoao.Depositar(500.0);
            contaJoao.Sacar(200.0);
            contaJoao.VerificarSaldo();
            
            Console.WriteLine("\n--- Operações na conta da Maria ---");
            contaMaria.Depositar(1000.0);
            contaMaria.Sacar(300.0);
            contaMaria.VerificarSaldo();
            
            Console.WriteLine("\n--- Transferência ---");
            contaJoao.Transferir(contaMaria, 100.0);
            
            Console.WriteLine("\n--- Saldos finais ---");
            contaJoao.VerificarSaldo();
            contaMaria.VerificarSaldo();
        }

        /// <summary>
        /// Demonstra o uso da classe Animal
        /// </summary>
        static void DemonstrarAnimal()
        {
            Console.WriteLine("=== DEMONSTRAÇÃO: Animal ===");
            
            // Criando animais
            Animal gato = new Animal("Mimi", "Gato", 3, 4.5, "Branco");
            Animal cachorro = new Animal("Rex", "Cachorro", 5, 15.0, "Marrom");
            Animal passaro = new Animal("Piu", "Pássaro", 1, 0.2, "Amarelo");
            
            Console.WriteLine("Animais criados:");
            Console.WriteLine(gato.ToString());
            Console.WriteLine(cachorro.ToString());
            Console.WriteLine(passaro.ToString());
            
            Console.WriteLine("\n--- Comportamentos do Gato ---");
            gato.FazerSom();
            gato.Comer("peixe");
            gato.Dormir(12);
            gato.Mover("silenciosamente");
            
            Console.WriteLine("\n--- Comportamentos do Cachorro ---");
            cachorro.FazerSom();
            cachorro.Comer("osso");
            cachorro.Mover("correndo");
            
            Console.WriteLine("\n--- Comportamentos do Pássaro ---");
            passaro.FazerSom();
            passaro.Mover("voando");
            passaro.Comer("sementes");
            
            Console.WriteLine("\n--- Informações detalhadas ---");
            gato.ExibirInformacoes();
            Console.WriteLine($"IMC do gato: {gato.CalcularIMC(0.3):F2}");
        }

        /// <summary>
        /// Demonstra o uso da classe Produto
        /// </summary>
        static void DemonstrarProduto()
        {
            Console.WriteLine("=== DEMONSTRAÇÃO: Produto ===");
            
            // Criando produtos
            Produto notebook = new Produto("NB001", "Dell Inspiron 15", 2500.0, "Eletrônicos", 10);
            Produto livro = new Produto("LB002", "C# Completo e Total", 89.90, "Livros", 25);
            Produto celular = new Produto("CL003", "iPhone 15", 5000.0, "Eletrônicos", 5);
            
            Console.WriteLine("Produtos criados:");
            Console.WriteLine(notebook.ToString());
            Console.WriteLine(livro.ToString());
            Console.WriteLine(celular.ToString());
            
            Console.WriteLine("\n--- Operações com o Notebook ---");
            notebook.VerificarDisponibilidade(2);
            notebook.CalcularDesconto(10.0);
            notebook.AtualizarEstoque(-1);
            notebook.ExibirInformacoes();
            
            Console.WriteLine("\n--- Operações com o Livro ---");
            livro.AplicarPromocao("desconto", 15.0);
            livro.VerificarDisponibilidade(30);
            livro.AtualizarEstoque(10);
            livro.ExibirInformacoes();
            
            Console.WriteLine("\n--- Operações com o Celular ---");
            celular.AplicarPromocao("leve 2 pague 1", 0);
            celular.CalcularValorTotalEstoque();
            celular.EstaEmFalta();
            
            Console.WriteLine("\n--- Tentativa de venda ---");
            if (celular.VerificarDisponibilidade(2))
            {
                celular.AtualizarEstoque(-2);
                Console.WriteLine("Venda realizada com sucesso!");
            }
        }
    }
}
