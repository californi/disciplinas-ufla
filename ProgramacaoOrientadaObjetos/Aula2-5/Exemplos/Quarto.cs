using System;

namespace Exemplos
{
    /// <summary>
    /// Classe que representa um quarto
    /// Demonstra COMPOSIÇÃO com a classe Casa
    /// </summary>
    public class Quarto
    {
        // Atributos privados
        private string nome;
        private double area;
        private string tipo;
        private bool temJanela;
        private bool temArmario;

        /// <summary>
        /// Construtor da classe Quarto
        /// </summary>
        /// <param name="nome">Nome do quarto</param>
        /// <param name="area">Área do quarto em m²</param>
        /// <param name="tipo">Tipo do quarto (dormitório, banheiro, cozinha, etc.)</param>
        public Quarto(string nome, double area, string tipo)
        {
            this.nome = nome;
            this.area = Math.Max(0, area); // Área não pode ser negativa
            this.tipo = tipo;
            this.temJanela = false; // Padrão: sem janela
            this.temArmario = false; // Padrão: sem armário
        }

        // Properties para acesso controlado aos atributos
        public string Nome 
        { 
            get { return nome; } 
            set { nome = value; } 
        }

        public double Area 
        { 
            get { return area; } 
            set 
            { 
                if (value >= 0)
                    area = value;
                else
                    Console.WriteLine("Erro: Área não pode ser negativa!");
            } 
        }

        public string Tipo 
        { 
            get { return tipo; } 
            set { tipo = value; } 
        }

        public bool TemJanela 
        { 
            get { return temJanela; } 
            set { temJanela = value; } 
        }

        public bool TemArmario 
        { 
            get { return temArmario; } 
            set { temArmario = value; } 
        }

        /// <summary>
        /// Simula o quarto sendo usado
        /// </summary>
        /// <param name="atividade">Atividade sendo realizada</param>
        public void UsarQuarto(string atividade)
        {
            Console.WriteLine($"Usando o quarto '{nome}' para: {atividade}");
            Console.WriteLine($"Tipo: {tipo} - Área: {area}m²");
            
            // Comportamentos específicos por tipo de quarto
            switch (tipo.ToLower())
            {
                case "dormitório":
                case "quarto":
                    Console.WriteLine("Quarto preparado para descanso.");
                    break;
                case "banheiro":
                    Console.WriteLine("Banheiro em uso.");
                    break;
                case "cozinha":
                    Console.WriteLine("Cozinha sendo utilizada para preparo de alimentos.");
                    break;
                case "sala":
                    Console.WriteLine("Sala sendo utilizada para convívio.");
                    break;
                default:
                    Console.WriteLine("Ambiente sendo utilizado.");
                    break;
            }
        }

        /// <summary>
        /// Adiciona uma janela ao quarto
        /// </summary>
        public void AdicionarJanela()
        {
            if (!temJanela)
            {
                temJanela = true;
                Console.WriteLine($"Janela adicionada ao quarto '{nome}'");
            }
            else
            {
                Console.WriteLine($"Quarto '{nome}' já possui janela!");
            }
        }

        /// <summary>
        /// Adiciona um armário ao quarto
        /// </summary>
        public void AdicionarArmario()
        {
            if (!temArmario)
            {
                temArmario = true;
                Console.WriteLine($"Armário adicionado ao quarto '{nome}'");
            }
            else
            {
                Console.WriteLine($"Quarto '{nome}' já possui armário!");
            }
        }

        /// <summary>
        /// Calcula a capacidade do quarto baseada na área
        /// </summary>
        /// <returns>Número máximo de pessoas</returns>
        public int CalcularCapacidade()
        {
            int capacidade = 0;
            
            switch (tipo.ToLower())
            {
                case "dormitório":
                case "quarto":
                    capacidade = (int)(area / 8); // 8m² por pessoa
                    break;
                case "banheiro":
                    capacidade = (int)(area / 4); // 4m² por pessoa
                    break;
                case "cozinha":
                    capacidade = (int)(area / 6); // 6m² por pessoa
                    break;
                case "sala":
                    capacidade = (int)(area / 5); // 5m² por pessoa
                    break;
                default:
                    capacidade = (int)(area / 7); // 7m² por pessoa (padrão)
                    break;
            }
            
            // Capacidade mínima de 1 pessoa
            return Math.Max(1, capacidade);
        }

        /// <summary>
        /// Verifica se o quarto é adequado para dormir
        /// </summary>
        /// <returns>True se for adequado para dormir</returns>
        public bool EhAdequadoParaDormir()
        {
            return tipo.ToLower() == "dormitório" || tipo.ToLower() == "quarto";
        }

        /// <summary>
        /// Verifica se o quarto é adequado para cozinhar
        /// </summary>
        /// <returns>True se for adequado para cozinhar</returns>
        public bool EhAdequadoParaCozinhar()
        {
            return tipo.ToLower() == "cozinha";
        }

        /// <summary>
        /// Calcula o conforto do quarto baseado em suas características
        /// </summary>
        /// <returns>Nível de conforto (1-5)</returns>
        public int CalcularConforto()
        {
            int conforto = 1; // Base
            
            // Bonificação por área
            if (area >= 20) conforto += 2;
            else if (area >= 10) conforto += 1;
            
            // Bonificação por janela
            if (temJanela) conforto += 1;
            
            // Bonificação por armário
            if (temArmario) conforto += 1;
            
            // Limita entre 1 e 5
            return Math.Min(5, Math.Max(1, conforto));
        }

        /// <summary>
        /// Exibe informações completas do quarto
        /// </summary>
        public void ExibirInformacoes()
        {
            Console.WriteLine("=== Informações do Quarto ===");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Tipo: {tipo}");
            Console.WriteLine($"Área: {area}m²");
            Console.WriteLine($"Tem Janela: {(temJanela ? "Sim" : "Não")}");
            Console.WriteLine($"Tem Armário: {(temArmario ? "Sim" : "Não")}");
            Console.WriteLine($"Capacidade: {CalcularCapacidade()} pessoas");
            Console.WriteLine($"Adequado para Dormir: {(EhAdequadoParaDormir() ? "Sim" : "Não")}");
            Console.WriteLine($"Adequado para Cozinhar: {(EhAdequadoParaCozinhar() ? "Sim" : "Não")}");
            Console.WriteLine($"Nível de Conforto: {CalcularConforto()}/5");
        }

        /// <summary>
        /// Sobrescreve o método ToString para exibição personalizada
        /// </summary>
        /// <returns>String com informações do quarto</returns>
        public override string ToString()
        {
            return $"{nome} - {tipo} - {area}m² - Conforto: {CalcularConforto()}/5";
        }
    }
}
