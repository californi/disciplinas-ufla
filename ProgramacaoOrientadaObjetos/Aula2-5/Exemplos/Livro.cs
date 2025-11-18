using System;

namespace Exemplos
{
    /// <summary>
    /// Classe que representa um livro
    /// Demonstra ASSOCIAÇÃO com a classe Bibliotecario
    /// </summary>
    public class Livro
    {
        // Atributos privados
        private string titulo;
        private string autor;
        private string isbn;
        private string categoria;
        private string status;
        private int anoPublicacao;

        /// <summary>
        /// Construtor da classe Livro
        /// </summary>
        /// <param name="titulo">Título do livro</param>
        /// <param name="autor">Autor do livro</param>
        /// <param name="isbn">ISBN do livro</param>
        /// <param name="categoria">Categoria do livro</param>
        /// <param name="anoPublicacao">Ano de publicação</param>
        public Livro(string titulo, string autor, string isbn, string categoria, int anoPublicacao)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.isbn = isbn;
            this.categoria = categoria;
            this.anoPublicacao = anoPublicacao;
            this.status = "Disponível"; // Status inicial
        }

        // Properties para acesso controlado aos atributos
        public string Titulo 
        { 
            get { return titulo; } 
            set { titulo = value; } 
        }

        public string Autor 
        { 
            get { return autor; } 
        }

        public string ISBN 
        { 
            get { return isbn; } 
        }

        public string Categoria 
        { 
            get { return categoria; } 
            set { categoria = value; } 
        }

        public string Status 
        { 
            get { return status; } 
        }

        public int AnoPublicacao 
        { 
            get { return anoPublicacao; } 
        }

        /// <summary>
        /// Altera o status do livro
        /// </summary>
        /// <param name="novoStatus">Novo status do livro</param>
        public void AlterarStatus(string novoStatus)
        {
            if (!string.IsNullOrWhiteSpace(novoStatus))
            {
                string statusAnterior = status;
                status = novoStatus;
                Console.WriteLine($"Status alterado de '{statusAnterior}' para '{novoStatus}'");
            }
            else
            {
                Console.WriteLine("Erro: Status não pode ser vazio!");
            }
        }

        /// <summary>
        /// Verifica se o livro está disponível para empréstimo
        /// </summary>
        /// <returns>True se o livro estiver disponível</returns>
        public bool EstaDisponivel()
        {
            return status.ToLower() == "disponível";
        }

        /// <summary>
        /// Empresta o livro (altera status para "Emprestado")
        /// </summary>
        public void Emprestar()
        {
            if (EstaDisponivel())
            {
                AlterarStatus("Emprestado");
                Console.WriteLine($"Livro '{titulo}' foi emprestado com sucesso!");
            }
            else
            {
                Console.WriteLine($"Livro '{titulo}' não está disponível para empréstimo!");
                Console.WriteLine($"Status atual: {status}");
            }
        }

        /// <summary>
        /// Devolve o livro (altera status para "Disponível")
        /// </summary>
        public void Devolver()
        {
            if (status.ToLower() == "emprestado")
            {
                AlterarStatus("Disponível");
                Console.WriteLine($"Livro '{titulo}' foi devolvido com sucesso!");
            }
            else
            {
                Console.WriteLine($"Livro '{titulo}' não estava emprestado!");
                Console.WriteLine($"Status atual: {status}");
            }
        }

        /// <summary>
        /// Calcula a idade do livro
        /// </summary>
        /// <returns>Idade do livro em anos</returns>
        public int CalcularIdade()
        {
            int anoAtual = DateTime.Now.Year;
            return anoAtual - anoPublicacao;
        }

        /// <summary>
        /// Verifica se o livro é antigo (mais de 10 anos)
        /// </summary>
        /// <returns>True se o livro for antigo</returns>
        public bool EhAntigo()
        {
            return CalcularIdade() > 10;
        }

        /// <summary>
        /// Exibe informações completas do livro
        /// </summary>
        public void ExibirInformacoes()
        {
            Console.WriteLine("=== Informações do Livro ===");
            Console.WriteLine($"Título: {titulo}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"ISBN: {isbn}");
            Console.WriteLine($"Categoria: {categoria}");
            Console.WriteLine($"Ano de Publicação: {anoPublicacao}");
            Console.WriteLine($"Idade: {CalcularIdade()} anos");
            Console.WriteLine($"Status: {status}");
            Console.WriteLine($"Disponível: {(EstaDisponivel() ? "Sim" : "Não")}");
            Console.WriteLine($"Antigo: {(EhAntigo() ? "Sim" : "Não")}");
        }

        /// <summary>
        /// Sobrescreve o método ToString para exibição personalizada
        /// </summary>
        /// <returns>String com informações do livro</returns>
        public override string ToString()
        {
            return $"{titulo} - {autor} - {anoPublicacao} - {status}";
        }
    }
}
