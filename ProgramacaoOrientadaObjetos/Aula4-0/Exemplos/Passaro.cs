using System;

namespace Exemplos
{
    /// <summary>
    /// Classe que representa um pássaro
    /// Demonstra HERANÇA - herda de Animal
    /// </summary>
    public class Passaro : Animal
    {
        // Atributos específicos de Pássaro
        private string especiePassaro;
        private bool podeVoar;
        private double envergadura;

        /// <summary>
        /// Construtor da classe Passaro
        /// HERANÇA: Chama construtor da classe base Animal
        /// </summary>
        /// <param name="nome">Nome do pássaro</param>
        /// <param name="especiePassaro">Espécie específica do pássaro</param>
        /// <param name="idade">Idade em anos</param>
        /// <param name="peso">Peso em kg</param>
        /// <param name="cor">Cor do pássaro</param>
        /// <param name="podeVoar">Se o pássaro pode voar</param>
        /// <param name="envergadura">Envergadura das asas em cm</param>
        public Passaro(string nome, string especiePassaro, int idade = 0, double peso = 0.0, string cor = "Não especificada", bool podeVoar = true, double envergadura = 0.0)
            : base(nome, "Pássaro", idade, peso, cor) // Chama construtor da classe base
        {
            this.especiePassaro = especiePassaro;
            this.podeVoar = podeVoar;
            this.envergadura = Math.Max(0.0, envergadura);
        }

        // Properties específicas de Pássaro
        public string EspeciePassaro 
        { 
            get { return especiePassaro; } 
            set { especiePassaro = value; } 
        }

        public bool PodeVoar 
        { 
            get { return podeVoar; } 
            set { podeVoar = value; } 
        }

        public double Envergadura 
        { 
            get { return envergadura; } 
            set { envergadura = Math.Max(0.0, value); } 
        }

        /// <summary>
        /// HERANÇA: Sobrescreve o método FazerSom() da classe base
        /// Comportamento específico de pássaro
        /// </summary>
        public override void FazerSom()
        {
            Console.WriteLine($"{nome} está cantando: Piu piu! Piu piu!");
        }

        /// <summary>
        /// HERANÇA: Sobrescreve o método Mover() da classe base
        /// Comportamento específico de pássaro
        /// </summary>
        /// <param name="direcao">Direção do movimento</param>
        public override void Mover(string direcao = "para frente")
        {
            if (podeVoar)
            {
                Console.WriteLine($"{nome} está voando {direcao}!");
                Console.WriteLine($"{nome} está batendo as asas!");
            }
            else
            {
                Console.WriteLine($"{nome} está caminhando {direcao}.");
                Console.WriteLine($"{nome} não pode voar, então está caminhando.");
            }
        }

        /// <summary>
        /// HERANÇA: Sobrescreve o método EhAdulto() da classe base
        /// Pássaros são adultos com 1 ano
        /// </summary>
        /// <returns>True se o pássaro for adulto</returns>
        public override bool EhAdulto()
        {
            return idade >= 1; // Pássaros amadurecem rapidamente
        }

        /// <summary>
        /// Método específico de Pássaro (não existe na classe base)
        /// HERANÇA: Adiciona funcionalidade específica
        /// </summary>
        public void Voar()
        {
            if (podeVoar)
            {
                Console.WriteLine($"{nome} está voando alto no céu!");
                Console.WriteLine($"Envergadura: {envergadura} cm");
            }
            else
            {
                Console.WriteLine($"{nome} não pode voar!");
            }
        }

        /// <summary>
        /// Método específico de Pássaro
        /// HERANÇA: Adiciona funcionalidade específica
        /// </summary>
        public void ConstruirNinho()
        {
            Console.WriteLine($"{nome} está construindo um ninho!");
            Console.WriteLine($"{nome} está coletando materiais para o ninho.");
        }

        /// <summary>
        /// Método específico de Pássaro
        /// HERANÇA: Adiciona funcionalidade específica
        /// </summary>
        public void BotarOvo()
        {
            if (EhAdulto())
            {
                Console.WriteLine($"{nome} botou um ovo!");
            }
            else
            {
                Console.WriteLine($"{nome} ainda é muito jovem para botar ovos.");
            }
        }

        /// <summary>
        /// HERANÇA: Sobrescreve o método ExibirInformacoes() da classe base
        /// Adiciona informações específicas de pássaro
        /// </summary>
        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes(); // Chama método da classe base
            Console.WriteLine($"Espécie: {especiePassaro}");
            Console.WriteLine($"Pode Voar: {(podeVoar ? "Sim" : "Não")}");
            if (envergadura > 0)
            {
                Console.WriteLine($"Envergadura: {envergadura} cm");
            }
        }

        /// <summary>
        /// HERANÇA: Sobrescreve o método ToString() da classe base
        /// Adiciona informações específicas de pássaro
        /// </summary>
        /// <returns>String com informações do pássaro</returns>
        public override string ToString()
        {
            return $"{base.ToString()} - Espécie: {especiePassaro} - Pode Voar: {(podeVoar ? "Sim" : "Não")}";
        }
    }
}
