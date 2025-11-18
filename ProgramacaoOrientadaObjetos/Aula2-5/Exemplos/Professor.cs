using System;

namespace Exemplos
{
    /// <summary>
    /// Classe que representa um professor
    /// Demonstra AGREGAÇÃO com a classe Universidade
    /// </summary>
    public class Professor
    {
        // Atributos privados
        private string nome;
        private string disciplina;
        private string titulacao;
        private double salario;
        private int anosExperiencia;

        /// <summary>
        /// Construtor da classe Professor
        /// </summary>
        /// <param name="nome">Nome do professor</param>
        /// <param name="disciplina">Disciplina que leciona</param>
        /// <param name="titulacao">Titulação acadêmica</param>
        /// <param name="salario">Salário do professor</param>
        /// <param name="anosExperiencia">Anos de experiência</param>
        public Professor(string nome, string disciplina, string titulacao, double salario, int anosExperiencia = 0)
        {
            this.nome = nome;
            this.disciplina = disciplina;
            this.titulacao = titulacao;
            this.salario = Math.Max(0, salario); // Salário não pode ser negativo
            this.anosExperiencia = Math.Max(0, anosExperiencia); // Experiência não pode ser negativa
        }

        // Properties para acesso controlado aos atributos
        public string Nome 
        { 
            get { return nome; } 
            set { nome = value; } 
        }

        public string Disciplina 
        { 
            get { return disciplina; } 
            set { disciplina = value; } 
        }

        public string Titulacao 
        { 
            get { return titulacao; } 
            set { titulacao = value; } 
        }

        public double Salario 
        { 
            get { return salario; } 
            set 
            { 
                if (value >= 0)
                    salario = value;
                else
                    Console.WriteLine("Erro: Salário não pode ser negativo!");
            } 
        }

        public int AnosExperiencia 
        { 
            get { return anosExperiencia; } 
            set 
            { 
                if (value >= 0)
                    anosExperiencia = value;
                else
                    Console.WriteLine("Erro: Anos de experiência não podem ser negativos!");
            } 
        }

        /// <summary>
        /// Simula o professor ministrando uma aula
        /// </summary>
        /// <param name="tema">Tema da aula</param>
        public void MinistrarAula(string tema)
        {
            Console.WriteLine($"Professor {nome} está ministrando aula sobre: {tema}");
            Console.WriteLine($"Disciplina: {disciplina}");
            Console.WriteLine($"Experiência: {anosExperiencia} anos");
        }

        /// <summary>
        /// Simula o professor corrigindo provas
        /// </summary>
        /// <param name="quantidadeProvas">Quantidade de provas</param>
        public void CorrigirProvas(int quantidadeProvas)
        {
            Console.WriteLine($"Professor {nome} está corrigindo {quantidadeProvas} provas");
            
            if (quantidadeProvas > 50)
            {
                Console.WriteLine("Muitas provas! Professor está sobrecarregado.");
            }
            else if (quantidadeProvas > 0)
            {
                Console.WriteLine("Correção em andamento...");
            }
            else
            {
                Console.WriteLine("Nenhuma prova para corrigir.");
            }
        }

        /// <summary>
        /// Calcula o salário anual do professor
        /// </summary>
        /// <returns>Salário anual</returns>
        public double CalcularSalarioAnual()
        {
            double salarioAnual = salario * 12;
            Console.WriteLine($"Salário anual do professor {nome}: R$ {salarioAnual:F2}");
            return salarioAnual;
        }

        /// <summary>
        /// Aplica aumento salarial
        /// </summary>
        /// <param name="percentualAumento">Percentual de aumento (0-100)</param>
        public void AplicarAumentoSalarial(double percentualAumento)
        {
            if (percentualAumento > 0 && percentualAumento <= 100)
            {
                double aumento = salario * (percentualAumento / 100.0);
                double novoSalario = salario + aumento;
                
                Console.WriteLine($"Aumento de {percentualAumento}% aplicado ao professor {nome}");
                Console.WriteLine($"Salário anterior: R$ {salario:F2}");
                Console.WriteLine($"Valor do aumento: R$ {aumento:F2}");
                Console.WriteLine($"Novo salário: R$ {novoSalario:F2}");
                
                salario = novoSalario;
            }
            else
            {
                Console.WriteLine("Erro: Percentual de aumento deve estar entre 0 e 100!");
            }
        }

        /// <summary>
        /// Verifica se o professor é experiente (mais de 10 anos)
        /// </summary>
        /// <returns>True se o professor for experiente</returns>
        public bool EhExperiente()
        {
            return anosExperiencia >= 10;
        }

        /// <summary>
        /// Calcula o tempo até a aposentadoria (considerando 30 anos de contribuição)
        /// </summary>
        /// <returns>Anos restantes para aposentadoria</returns>
        public int CalcularTempoAposentadoria()
        {
            int anosRestantes = Math.Max(0, 30 - anosExperiencia);
            Console.WriteLine($"Professor {nome} tem {anosRestantes} anos para se aposentar");
            return anosRestantes;
        }

        /// <summary>
        /// Simula o professor fazendo pesquisa
        /// </summary>
        /// <param name="areaPesquisa">Área de pesquisa</param>
        public void FazerPesquisa(string areaPesquisa)
        {
            Console.WriteLine($"Professor {nome} está fazendo pesquisa em: {areaPesquisa}");
            Console.WriteLine($"Disciplina relacionada: {disciplina}");
            
            if (EhExperiente())
            {
                Console.WriteLine("Professor experiente conduzindo pesquisa avançada.");
            }
            else
            {
                Console.WriteLine("Professor em desenvolvimento de pesquisa.");
            }
        }

        /// <summary>
        /// Exibe informações completas do professor
        /// </summary>
        public void ExibirInformacoes()
        {
            Console.WriteLine("=== Informações do Professor ===");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Disciplina: {disciplina}");
            Console.WriteLine($"Titulação: {titulacao}");
            Console.WriteLine($"Salário: R$ {salario:F2}");
            Console.WriteLine($"Anos de Experiência: {anosExperiencia}");
            Console.WriteLine($"Salário Anual: R$ {CalcularSalarioAnual():F2}");
            Console.WriteLine($"Experiente: {(EhExperiente() ? "Sim" : "Não")}");
            Console.WriteLine($"Anos para Aposentadoria: {CalcularTempoAposentadoria()}");
        }

        /// <summary>
        /// Sobrescreve o método ToString para exibição personalizada
        /// </summary>
        /// <returns>String com informações do professor</returns>
        public override string ToString()
        {
            return $"{nome} - {disciplina} - {titulacao} - R$ {salario:F2}";
        }
    }
}
