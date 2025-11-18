using System;
using System.Collections.Generic;

namespace Exemplos
{
    /// <summary>
    /// Classe que representa uma universidade
    /// Demonstra AGREGAÇÃO com a classe Professor
    /// </summary>
    public class Universidade
    {
        // Atributos privados
        private string nome;
        private string endereco;
        private string cidade;
        private int anoFundacao;
        
        // AGREGAÇÃO: Lista de professores (professores podem existir sem universidade)
        private List<Professor> professores;

        /// <summary>
        /// Construtor da classe Universidade
        /// </summary>
        /// <param name="nome">Nome da universidade</param>
        /// <param name="endereco">Endereço da universidade</param>
        /// <param name="cidade">Cidade da universidade</param>
        /// <param name="anoFundacao">Ano de fundação</param>
        public Universidade(string nome, string endereco, string cidade, int anoFundacao)
        {
            this.nome = nome;
            this.endereco = endereco;
            this.cidade = cidade;
            this.anoFundacao = anoFundacao;
            this.professores = new List<Professor>(); // Inicializa lista vazia
        }

        // Properties para acesso controlado aos atributos
        public string Nome 
        { 
            get { return nome; } 
            set { nome = value; } 
        }

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

        public int AnoFundacao 
        { 
            get { return anoFundacao; } 
        }

        /// <summary>
        /// AGREGAÇÃO: Adiciona um professor à universidade
        /// O professor pode existir independentemente da universidade
        /// </summary>
        /// <param name="professor">Professor a ser adicionado</param>
        public void AdicionarProfessor(Professor professor)
        {
            if (professor != null)
            {
                if (!professores.Contains(professor))
                {
                    professores.Add(professor);
                    Console.WriteLine($"Professor {professor.Nome} adicionado à universidade {nome}");
                }
                else
                {
                    Console.WriteLine($"Professor {professor.Nome} já está na universidade!");
                }
            }
            else
            {
                Console.WriteLine("Erro: Professor não pode ser nulo!");
            }
        }

        /// <summary>
        /// AGREGAÇÃO: Remove um professor da universidade
        /// O professor continua existindo após ser removido
        /// </summary>
        /// <param name="professor">Professor a ser removido</param>
        public void RemoverProfessor(Professor professor)
        {
            if (professor != null)
            {
                if (professores.Contains(professor))
                {
                    professores.Remove(professor);
                    Console.WriteLine($"Professor {professor.Nome} removido da universidade {nome}");
                }
                else
                {
                    Console.WriteLine($"Professor {professor.Nome} não está na universidade!");
                }
            }
            else
            {
                Console.WriteLine("Erro: Professor não pode ser nulo!");
            }
        }

        /// <summary>
        /// AGREGAÇÃO: Busca professor por nome
        /// </summary>
        /// <param name="nomeProfessor">Nome do professor</param>
        /// <returns>Professor encontrado ou null</returns>
        public Professor BuscarProfessor(string nomeProfessor)
        {
            foreach (Professor professor in professores)
            {
                if (professor.Nome.ToLower() == nomeProfessor.ToLower())
                {
                    return professor;
                }
            }
            return null;
        }

        /// <summary>
        /// AGREGAÇÃO: Lista todos os professores da universidade
        /// </summary>
        public void ListarProfessores()
        {
            Console.WriteLine($"=== Professores da Universidade {nome} ===");
            
            if (professores.Count == 0)
            {
                Console.WriteLine("Nenhum professor cadastrado.");
            }
            else
            {
                foreach (Professor professor in professores)
                {
                    Console.WriteLine($"- {professor.Nome} - {professor.Disciplina} - {professor.Titulacao}");
                }
            }
            
            Console.WriteLine($"Total de professores: {professores.Count}");
        }

        /// <summary>
        /// AGREGAÇÃO: Conta professores por disciplina
        /// </summary>
        /// <param name="disciplina">Disciplina a ser contada</param>
        /// <returns>Número de professores da disciplina</returns>
        public int ContarProfessoresPorDisciplina(string disciplina)
        {
            int count = 0;
            foreach (Professor professor in professores)
            {
                if (professor.Disciplina.ToLower() == disciplina.ToLower())
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// AGREGAÇÃO: Calcula a média salarial dos professores
        /// </summary>
        /// <returns>Média salarial</returns>
        public double CalcularMediaSalarial()
        {
            if (professores.Count == 0)
            {
                Console.WriteLine("Nenhum professor para calcular média salarial.");
                return 0;
            }

            double somaSalarios = 0;
            foreach (Professor professor in professores)
            {
                somaSalarios += professor.Salario;
            }

            double media = somaSalarios / professores.Count;
            Console.WriteLine($"Média salarial dos professores: R$ {media:F2}");
            return media;
        }

        /// <summary>
        /// Calcula a idade da universidade
        /// </summary>
        /// <returns>Idade da universidade em anos</returns>
        public int CalcularIdade()
        {
            int anoAtual = DateTime.Now.Year;
            return anoAtual - anoFundacao;
        }

        /// <summary>
        /// Exibe informações completas da universidade
        /// </summary>
        public void ExibirInformacoes()
        {
            Console.WriteLine("=== Informações da Universidade ===");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Endereço: {endereco}");
            Console.WriteLine($"Cidade: {cidade}");
            Console.WriteLine($"Ano de Fundação: {anoFundacao}");
            Console.WriteLine($"Idade: {CalcularIdade()} anos");
            Console.WriteLine($"Número de Professores: {professores.Count}");
            
            if (professores.Count > 0)
            {
                CalcularMediaSalarial();
            }
        }

        /// <summary>
        /// Sobrescreve o método ToString para exibição personalizada
        /// </summary>
        /// <returns>String com informações da universidade</returns>
        public override string ToString()
        {
            return $"{nome} - {cidade} - {anoFundacao} - {professores.Count} professores";
        }
    }
}
