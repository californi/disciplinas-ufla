using System;

namespace Exemplos
{
    /// <summary>
    /// Classe que representa um cachorro
    /// Demonstra HERANÇA - herda de Animal
    /// </summary>
    public class Cachorro : Animal
    {
        // Atributos específicos de Cachorro
        private string raca;
        private bool estaTreinado;

        /// <summary>
        /// Construtor da classe Cachorro
        /// HERANÇA: Chama construtor da classe base Animal
        /// </summary>
        /// <param name="nome">Nome do cachorro</param>
        /// <param name="raca">Raça do cachorro</param>
        /// <param name="idade">Idade em anos</param>
        /// <param name="peso">Peso em kg</param>
        /// <param name="cor">Cor do cachorro</param>
        /// <param name="estaTreinado">Se o cachorro está treinado</param>
        public Cachorro(string nome, string raca, int idade = 0, double peso = 0.0, string cor = "Não especificada", bool estaTreinado = false)
            : base(nome, "Cachorro", idade, peso, cor) // Chama construtor da classe base
        {
            this.raca = raca;
            this.estaTreinado = estaTreinado;
        }

        // Properties específicas de Cachorro
        public string Raca 
        { 
            get { return raca; } 
            set { raca = value; } 
        }

        public bool EstaTreinado 
        { 
            get { return estaTreinado; } 
            set { estaTreinado = value; } 
        }

        /// <summary>
        /// HERANÇA: Sobrescreve o método FazerSom() da classe base
        /// Comportamento específico de cachorro
        /// </summary>
        public override void FazerSom()
        {
            Console.WriteLine($"{nome} está latindo: Au au! Au au!");
        }

        /// <summary>
        /// HERANÇA: Sobrescreve o método Mover() da classe base
        /// Comportamento específico de cachorro
        /// </summary>
        /// <param name="direcao">Direção do movimento</param>
        public override void Mover(string direcao = "para frente")
        {
            Console.WriteLine($"{nome} está correndo {direcao} alegremente!");
            Console.WriteLine($"{nome} está abanando o rabo!");
        }

        /// <summary>
        /// HERANÇA: Sobrescreve o método EhAdulto() da classe base
        /// Cachorros são adultos com 1 ano
        /// </summary>
        /// <returns>True se o cachorro for adulto</returns>
        public override bool EhAdulto()
        {
            return idade >= 1; // Cachorros amadurecem mais rápido
        }

        /// <summary>
        /// Método específico de Cachorro (não existe na classe base)
        /// HERANÇA: Adiciona funcionalidade específica
        /// </summary>
        public void Latir()
        {
            Console.WriteLine($"{nome} está latindo: Au au au!");
        }

        /// <summary>
        /// Método específico de Cachorro
        /// HERANÇA: Adiciona funcionalidade específica
        /// </summary>
        public void Buscar()
        {
            if (estaTreinado)
            {
                Console.WriteLine($"{nome} está buscando o objeto!");
            }
            else
            {
                Console.WriteLine($"{nome} ainda não sabe buscar. Precisa de treinamento!");
            }
        }

        /// <summary>
        /// Método específico de Cachorro
        /// HERANÇA: Adiciona funcionalidade específica
        /// </summary>
        public void Treinar()
        {
            if (!estaTreinado)
            {
                estaTreinado = true;
                Console.WriteLine($"{nome} foi treinado com sucesso!");
            }
            else
            {
                Console.WriteLine($"{nome} já está treinado!");
            }
        }

        /// <summary>
        /// HERANÇA: Sobrescreve o método ExibirInformacoes() da classe base
        /// Adiciona informações específicas de cachorro
        /// </summary>
        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes(); // Chama método da classe base
            Console.WriteLine($"Raça: {raca}");
            Console.WriteLine($"Treinado: {(estaTreinado ? "Sim" : "Não")}");
        }

        /// <summary>
        /// HERANÇA: Sobrescreve o método ToString() da classe base
        /// Adiciona informações específicas de cachorro
        /// </summary>
        /// <returns>String com informações do cachorro</returns>
        public override string ToString()
        {
            return $"{base.ToString()} - Raça: {raca} - Treinado: {(estaTreinado ? "Sim" : "Não")}";
        }
    }
}
