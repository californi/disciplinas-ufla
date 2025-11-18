using System;
using System.Collections.Generic;

namespace Exemplos
{
    /// <summary>
    /// Classe que representa uma casa
    /// Demonstra COMPOSIÇÃO com a classe Quarto
    /// </summary>
    public class Casa
    {
        // Atributos privados
        private string endereco;
        private string cidade;
        private int anoConstrucao;
        private double areaTotal;
        
        // COMPOSIÇÃO: Lista de quartos (quartos não podem existir sem casa)
        private List<Quarto> quartos;

        /// <summary>
        /// Construtor da classe Casa
        /// </summary>
        /// <param name="endereco">Endereço da casa</param>
        /// <param name="cidade">Cidade da casa</param>
        /// <param name="anoConstrucao">Ano de construção</param>
        /// <param name="areaTotal">Área total da casa</param>
        public Casa(string endereco, string cidade, int anoConstrucao, double areaTotal)
        {
            this.endereco = endereco;
            this.cidade = cidade;
            this.anoConstrucao = anoConstrucao;
            this.areaTotal = Math.Max(0, areaTotal); // Área não pode ser negativa
            this.quartos = new List<Quarto>(); // Inicializa lista vazia
        }

        // Properties para acesso controlado aos atributos
        public string Endereco 
        { 
            get { return endereco; } 
            set { endereco = value; } 
        }

        public string Cidade 
        { 
            get { return cidade; } 
            set { cidade = value; } 
        }

        public int AnoConstrucao 
        { 
            get { return anoConstrucao; } 
        }

        public double AreaTotal 
        { 
            get { return areaTotal; } 
            set 
            { 
                if (value >= 0)
                    areaTotal = value;
                else
                    Console.WriteLine("Erro: Área total não pode ser negativa!");
            } 
        }

        /// <summary>
        /// COMPOSIÇÃO: Adiciona um quarto à casa
        /// O quarto é criado e pertence exclusivamente a esta casa
        /// </summary>
        /// <param name="nome">Nome do quarto</param>
        /// <param name="area">Área do quarto</param>
        /// <param name="tipo">Tipo do quarto</param>
        public void AdicionarQuarto(string nome, double area, string tipo)
        {
            if (!string.IsNullOrWhiteSpace(nome) && area > 0)
            {
                // COMPOSIÇÃO: Cria o quarto dentro da casa
                Quarto novoQuarto = new Quarto(nome, area, tipo);
                quartos.Add(novoQuarto);
                
                Console.WriteLine($"Quarto '{nome}' adicionado à casa em {endereco}");
                Console.WriteLine($"Área: {area}m² - Tipo: {tipo}");
            }
            else
            {
                Console.WriteLine("Erro: Nome do quarto não pode ser vazio e área deve ser positiva!");
            }
        }

        /// <summary>
        /// COMPOSIÇÃO: Remove um quarto da casa
        /// Quando removido, o quarto deixa de existir
        /// </summary>
        /// <param name="nomeQuarto">Nome do quarto a ser removido</param>
        public void RemoverQuarto(string nomeQuarto)
        {
            Quarto quartoParaRemover = null;
            
            foreach (Quarto quarto in quartos)
            {
                if (quarto.Nome.ToLower() == nomeQuarto.ToLower())
                {
                    quartoParaRemover = quarto;
                    break;
                }
            }
            
            if (quartoParaRemover != null)
            {
                quartos.Remove(quartoParaRemover);
                Console.WriteLine($"Quarto '{nomeQuarto}' removido da casa");
                // COMPOSIÇÃO: O quarto deixa de existir quando removido da casa
            }
            else
            {
                Console.WriteLine($"Quarto '{nomeQuarto}' não encontrado na casa!");
            }
        }

        /// <summary>
        /// COMPOSIÇÃO: Busca quarto por nome
        /// </summary>
        /// <param name="nomeQuarto">Nome do quarto</param>
        /// <returns>Quarto encontrado ou null</returns>
        public Quarto BuscarQuarto(string nomeQuarto)
        {
            foreach (Quarto quarto in quartos)
            {
                if (quarto.Nome.ToLower() == nomeQuarto.ToLower())
                {
                    return quarto;
                }
            }
            return null;
        }

        /// <summary>
        /// COMPOSIÇÃO: Lista todos os quartos da casa
        /// </summary>
        public void ListarQuartos()
        {
            Console.WriteLine($"=== Quartos da Casa em {endereco} ===");
            
            if (quartos.Count == 0)
            {
                Console.WriteLine("Nenhum quarto cadastrado.");
            }
            else
            {
                foreach (Quarto quarto in quartos)
                {
                    Console.WriteLine($"- {quarto.Nome} - {quarto.Area}m² - {quarto.Tipo}");
                }
            }
            
            Console.WriteLine($"Total de quartos: {quartos.Count}");
        }

        /// <summary>
        /// COMPOSIÇÃO: Calcula a área total dos quartos
        /// </summary>
        /// <returns>Área total dos quartos</returns>
        public double CalcularAreaQuartos()
        {
            double areaQuartos = 0;
            foreach (Quarto quarto in quartos)
            {
                areaQuartos += quarto.Area;
            }
            
            Console.WriteLine($"Área total dos quartos: {areaQuartos}m²");
            return areaQuartos;
        }

        /// <summary>
        /// COMPOSIÇÃO: Calcula a área restante (área total - área dos quartos)
        /// </summary>
        /// <returns>Área restante</returns>
        public double CalcularAreaRestante()
        {
            double areaQuartos = CalcularAreaQuartos();
            double areaRestante = areaTotal - areaQuartos;
            
            Console.WriteLine($"Área restante da casa: {areaRestante}m²");
            return areaRestante;
        }

        /// <summary>
        /// COMPOSIÇÃO: Conta quartos por tipo
        /// </summary>
        /// <param name="tipo">Tipo do quarto</param>
        /// <returns>Número de quartos do tipo</returns>
        public int ContarQuartosPorTipo(string tipo)
        {
            int count = 0;
            foreach (Quarto quarto in quartos)
            {
                if (quarto.Tipo.ToLower() == tipo.ToLower())
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Calcula a idade da casa
        /// </summary>
        /// <returns>Idade da casa em anos</returns>
        public int CalcularIdade()
        {
            int anoAtual = DateTime.Now.Year;
            return anoAtual - anoConstrucao;
        }

        /// <summary>
        /// Verifica se a casa é antiga (mais de 30 anos)
        /// </summary>
        /// <returns>True se a casa for antiga</returns>
        public bool EhAntiga()
        {
            return CalcularIdade() > 30;
        }

        /// <summary>
        /// Exibe informações completas da casa
        /// </summary>
        public void ExibirInformacoes()
        {
            Console.WriteLine("=== Informações da Casa ===");
            Console.WriteLine($"Endereço: {endereco}");
            Console.WriteLine($"Cidade: {cidade}");
            Console.WriteLine($"Ano de Construção: {anoConstrucao}");
            Console.WriteLine($"Idade: {CalcularIdade()} anos");
            Console.WriteLine($"Área Total: {areaTotal}m²");
            Console.WriteLine($"Número de Quartos: {quartos.Count}");
            
            if (quartos.Count > 0)
            {
                CalcularAreaQuartos();
                CalcularAreaRestante();
            }
            
            Console.WriteLine($"Antiga: {(EhAntiga() ? "Sim" : "Não")}");
        }

        /// <summary>
        /// Sobrescreve o método ToString para exibição personalizada
        /// </summary>
        /// <returns>String com informações da casa</returns>
        public override string ToString()
        {
            return $"{endereco} - {cidade} - {anoConstrucao} - {quartos.Count} quartos";
        }
    }
}
