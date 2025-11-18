using System;

namespace Exemplos
{
    /// <summary>
    /// Classe que representa um gato
    /// Demonstra HERANÇA - herda de Animal
    /// </summary>
    public class Gato : Animal
    {
        // Atributos específicos de Gato
        private string raca;
        private bool ehDomesticado;

        /// <summary>
        /// Construtor da classe Gato
        /// HERANÇA: Chama construtor da classe base Animal
        /// </summary>
        /// <param name="nome">Nome do gato</param>
        /// <param name="raca">Raça do gato</param>
        /// <param name="idade">Idade em anos</param>
        /// <param name="peso">Peso em kg</param>
        /// <param name="cor">Cor do gato</param>
        /// <param name="ehDomesticado">Se o gato é domesticado</param>
        public Gato(string nome, string raca, int idade = 0, double peso = 0.0, string cor = "Não especificada", bool ehDomesticado = true)
            : base(nome, "Gato", idade, peso, cor) // Chama construtor da classe base
        {
            this.raca = raca;
            this.ehDomesticado = ehDomesticado;
        }

        // Properties específicas de Gato
        public string Raca 
        { 
            get { return raca; } 
            set { raca = value; } 
        }

        public bool EhDomesticado 
        { 
            get { return ehDomesticado; } 
            set { ehDomesticado = value; } 
        }

        /// <summary>
        /// HERANÇA: Sobrescreve o método FazerSom() da classe base
        /// Comportamento específico de gato
        /// </summary>
        public override void FazerSom()
        {
            Console.WriteLine($"{nome} está miando: Miau! Miau!");
        }

        /// <summary>
        /// HERANÇA: Sobrescreve o método Mover() da classe base
        /// Comportamento específico de gato
        /// </summary>
        /// <param name="direcao">Direção do movimento</param>
        public override void Mover(string direcao = "para frente")
        {
            Console.WriteLine($"{nome} está se movendo {direcao} silenciosamente.");
            Console.WriteLine($"{nome} está se movendo com elegância felina!");
        }

        /// <summary>
        /// HERANÇA: Sobrescreve o método EhAdulto() da classe base
        /// Gatos são adultos com 1 ano
        /// </summary>
        /// <returns>True se o gato for adulto</returns>
        public override bool EhAdulto()
        {
            return idade >= 1; // Gatos amadurecem rapidamente
        }

        /// <summary>
        /// Método específico de Gato (não existe na classe base)
        /// HERANÇA: Adiciona funcionalidade específica
        /// </summary>
        public void Ronronar()
        {
            Console.WriteLine($"{nome} está ronronando: Prrr... Prrr...");
            Console.WriteLine($"{nome} está feliz e relaxado!");
        }

        /// <summary>
        /// Método específico de Gato
        /// HERANÇA: Adiciona funcionalidade específica
        /// </summary>
        public void Arranhar()
        {
            Console.WriteLine($"{nome} está arranhando para afiar as unhas!");
        }

        /// <summary>
        /// Método específico de Gato
        /// HERANÇA: Adiciona funcionalidade específica
        /// </summary>
        public void SubirEmArvore()
        {
            if (ehDomesticado)
            {
                Console.WriteLine($"{nome} está tentando subir em uma árvore!");
            }
            else
            {
                Console.WriteLine($"{nome} subiu na árvore com agilidade!");
            }
        }

        /// <summary>
        /// HERANÇA: Sobrescreve o método ExibirInformacoes() da classe base
        /// Adiciona informações específicas de gato
        /// </summary>
        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes(); // Chama método da classe base
            Console.WriteLine($"Raça: {raca}");
            Console.WriteLine($"Domesticado: {(ehDomesticado ? "Sim" : "Não")}");
        }

        /// <summary>
        /// HERANÇA: Sobrescreve o método ToString() da classe base
        /// Adiciona informações específicas de gato
        /// </summary>
        /// <returns>String com informações do gato</returns>
        public override string ToString()
        {
            return $"{base.ToString()} - Raça: {raca} - Domesticado: {(ehDomesticado ? "Sim" : "Não")}";
        }
    }
}
