using System;
using System.Collections.Generic;

namespace Exemplos
{
    /// <summary>
    /// Classe principal que demonstra HERANÇA
    /// Mostra como classes derivadas herdam e estendem a classe base
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== DEMONSTRAÇÃO DE HERANÇA ===\n");
            
            // Demonstração básica de herança
            DemonstrarHerancaBasica();
            
            Console.WriteLine("\n" + new string('=', 60) + "\n");
            
            // Demonstração de polimorfismo
            DemonstrarPolimorfismo();
            
            Console.WriteLine("\n" + new string('=', 60) + "\n");
            
            // Demonstração de métodos específicos
            DemonstrarMetodosEspecificos();
            
            Console.WriteLine("\n" + new string('=', 60) + "\n");
            
            // Demonstração de sobrescrita
            DemonstrarSobrescrita();
            
            Console.WriteLine("\n=== FIM DA DEMONSTRAÇÃO ===");
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        /// <summary>
        /// Demonstra herança básica - criação de objetos das classes derivadas
        /// </summary>
        static void DemonstrarHerancaBasica()
        {
            Console.WriteLine("1. DEMONSTRAÇÃO DE HERANÇA BÁSICA");
            Console.WriteLine("   Criação de objetos das classes derivadas\n");
            
            // HERANÇA: Cachorro herda de Animal
            Cachorro cachorro = new Cachorro("Rex", "Labrador", 3, 25.0, "Dourado", true);
            Console.WriteLine("Cachorro criado:");
            cachorro.ExibirInformacoes();
            Console.WriteLine();
            
            // HERANÇA: Gato herda de Animal
            Gato gato = new Gato("Mimi", "Persa", 2, 4.5, "Branco", true);
            Console.WriteLine("Gato criado:");
            gato.ExibirInformacoes();
            Console.WriteLine();
            
            // HERANÇA: Pássaro herda de Animal
            Passaro passaro = new Passaro("Piu", "Canário", 1, 0.05, "Amarelo", true, 15.0);
            Console.WriteLine("Pássaro criado:");
            passaro.ExibirInformacoes();
            Console.WriteLine();
            
            Console.WriteLine("Observações sobre HERANÇA:");
            Console.WriteLine("- Todas as classes derivadas herdam atributos e métodos da classe base");
            Console.WriteLine("- Cada classe derivada pode ter atributos e métodos específicos");
            Console.WriteLine("- Construtores chamam o construtor da classe base com base()");
        }

        /// <summary>
        /// Demonstra polimorfismo - referências da classe base apontando para objetos derivados
        /// </summary>
        static void DemonstrarPolimorfismo()
        {
            Console.WriteLine("2. DEMONSTRAÇÃO DE POLIMORFISMO");
            Console.WriteLine("   Referências da classe base com objetos derivados\n");
            
            // POLIMORFISMO: Referência da classe base pode apontar para objetos derivados
            Animal animal1 = new Cachorro("Buddy", "Golden Retriever", 2, 30.0, "Dourado", false);
            Animal animal2 = new Gato("Luna", "Siamês", 1, 3.0, "Cinza", true);
            Animal animal3 = new Passaro("Tweety", "Canário", 1, 0.03, "Amarelo", true, 12.0);
            
            // Lista de animais (polimorfismo)
            List<Animal> animais = new List<Animal> { animal1, animal2, animal3 };
            
            Console.WriteLine("POLIMORFISMO: Tratando diferentes tipos como Animal");
            Console.WriteLine();
            
            foreach (Animal animal in animais)
            {
                Console.WriteLine($"Tipo: {animal.GetType().Name}");
                Console.WriteLine($"Nome: {animal.Nome}");
                
                // POLIMORFISMO: Chama método sobrescrito de cada classe derivada
                animal.FazerSom();
                animal.Mover("para a direita");
                
                // HERANÇA: Métodos herdados funcionam em todas as classes
                animal.Comer("ração");
                
                Console.WriteLine();
            }
            
            Console.WriteLine("Observações sobre POLIMORFISMO:");
            Console.WriteLine("- Referência da classe base pode apontar para objetos derivados");
            Console.WriteLine("- Métodos virtuais são chamados de acordo com o tipo real do objeto");
            Console.WriteLine("- Permite tratar diferentes tipos de forma uniforme");
        }

        /// <summary>
        /// Demonstra métodos específicos de cada classe derivada
        /// </summary>
        static void DemonstrarMetodosEspecificos()
        {
            Console.WriteLine("3. DEMONSTRAÇÃO DE MÉTODOS ESPECÍFICOS");
            Console.WriteLine("   Cada classe derivada tem métodos únicos\n");
            
            Cachorro cachorro = new Cachorro("Max", "Pastor Alemão", 4, 35.0, "Preto", true);
            Gato gato = new Gato("Whiskers", "Maine Coon", 3, 6.0, "Laranja", true);
            Passaro passaro = new Passaro("Charlie", "Papagaio", 5, 0.4, "Verde", true, 25.0);
            
            Console.WriteLine("Métodos específicos de Cachorro:");
            cachorro.Latir();
            cachorro.Buscar();
            cachorro.Treinar();
            Console.WriteLine();
            
            Console.WriteLine("Métodos específicos de Gato:");
            gato.Ronronar();
            gato.Arranhar();
            gato.SubirEmArvore();
            Console.WriteLine();
            
            Console.WriteLine("Métodos específicos de Pássaro:");
            passaro.Voar();
            passaro.ConstruirNinho();
            passaro.BotarOvo();
            Console.WriteLine();
            
            Console.WriteLine("Observações sobre MÉTODOS ESPECÍFICOS:");
            Console.WriteLine("- Cada classe derivada pode adicionar métodos próprios");
            Console.WriteLine("- Esses métodos não existem na classe base");
            Console.WriteLine("- Apenas objetos do tipo específico podem chamar esses métodos");
        }

        /// <summary>
        /// Demonstra sobrescrita de métodos - cada classe implementa de forma diferente
        /// </summary>
        static void DemonstrarSobrescrita()
        {
            Console.WriteLine("4. DEMONSTRAÇÃO DE SOBRESCRITA");
            Console.WriteLine("   Cada classe sobrescreve métodos da classe base\n");
            
            Cachorro cachorro = new Cachorro("Rocky", "Bulldog", 2, 20.0, "Branco", false);
            Gato gato = new Gato("Shadow", "Preto", 1, 3.5, "Preto", true);
            Passaro passaro = new Passaro("Sky", "Águia", 3, 2.5, "Marrom", true, 180.0);
            
            Console.WriteLine("SOBRESCRITA: Cada classe implementa FazerSom() de forma diferente");
            cachorro.FazerSom();
            gato.FazerSom();
            passaro.FazerSom();
            Console.WriteLine();
            
            Console.WriteLine("SOBRESCRITA: Cada classe implementa Mover() de forma diferente");
            cachorro.Mover("para frente");
            gato.Mover("para frente");
            passaro.Mover("para frente");
            Console.WriteLine();
            
            Console.WriteLine("SOBRESCRITA: Cada classe implementa EhAdulto() de forma diferente");
            Console.WriteLine($"Cachorro é adulto: {cachorro.EhAdulto()}");
            Console.WriteLine($"Gato é adulto: {gato.EhAdulto()}");
            Console.WriteLine($"Pássaro é adulto: {passaro.EhAdulto()}");
            Console.WriteLine();
            
            Console.WriteLine("SOBRESCRITA: Cada classe implementa ExibirInformacoes() de forma diferente");
            cachorro.ExibirInformacoes();
            Console.WriteLine();
            gato.ExibirInformacoes();
            Console.WriteLine();
            passaro.ExibirInformacoes();
            Console.WriteLine();
            
            Console.WriteLine("Observações sobre SOBRESCRITA:");
            Console.WriteLine("- Métodos marcados com 'virtual' podem ser sobrescritos");
            Console.WriteLine("- Métodos sobrescritos usam 'override'");
            Console.WriteLine("- Cada classe pode ter comportamento único");
            Console.WriteLine("- Método da base pode ser chamado com 'base.Metodo()'");
        }
    }
}
