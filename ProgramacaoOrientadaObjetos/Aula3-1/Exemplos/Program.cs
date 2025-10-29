using System;
using ExemplosRelacoes.Associacao;
using ExemplosRelacoes.Agregacao;
using ExemplosRelacoes.Composicao;

namespace ExemplosRelacoes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║   EXEMPLOS DE RELAÇÕES ENTRE CLASSES - GCT052   ║");
            Console.WriteLine("║      Aula 3.1 - Associação, Agregação e       ║");
            Console.WriteLine("║              Composição                         ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝\n");
            
            // Executar exemplos de cada tipo de relação
            ExemploAssociacao.Executar();
            Console.WriteLine("\n" + new string('=', 60));
            
            ExemploAgregacao.Executar();
            Console.WriteLine("\n" + new string('=', 60));
            
            ExemploComposicao.Executar();
            Console.WriteLine("\n" + new string('=', 60));
            
            // Menu interativo
            Menu();
        }
        
        static void Menu()
        {
            Console.WriteLine("\n╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║              MENU INTERATIVO                  ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝\n");
            
            Console.WriteLine("Escolha um exemplo:");
            Console.WriteLine("1. Associação (Professor-Aluno)");
            Console.WriteLine("2. Agregação (Universidade-Departamento)");
            Console.WriteLine("3. Composição (ContaBancaria-Transacao)");
            Console.WriteLine("0. Sair");
            
            Console.Write("\nOpção: ");
            string opcao = Console.ReadLine();
            
            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    ExemploAssociacao.Executar();
                    Menu();
                    break;
                    
                case "2":
                    Console.Clear();
                    ExemploAgregacao.Executar();
                    Menu();
                    break;
                    
                case "3":
                    Console.Clear();
                    ExemploComposicao.Executar();
                    Menu();
                    break;
                    
                case "0":
                    Console.WriteLine("\nEncerrando programa...");
                    break;
                    
                default:
                    Console.WriteLine("Opção inválida!");
                    Menu();
                    break;
            }
        }
    }
}


