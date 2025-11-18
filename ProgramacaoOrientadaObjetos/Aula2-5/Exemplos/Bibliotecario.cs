using System;

namespace Exemplos
{
    /// <summary>
    /// Classe que representa um bibliotecário
    /// Demonstra ASSOCIAÇÃO com a classe Livro
    /// </summary>
    public class Bibliotecario
    {
        // Atributos privados
        private string nome;
        private string matricula;
        private string especialidade;

        /// <summary>
        /// Construtor da classe Bibliotecario
        /// </summary>
        /// <param name="nome">Nome do bibliotecário</param>
        /// <param name="matricula">Matrícula do bibliotecário</param>
        /// <param name="especialidade">Especialidade do bibliotecário</param>
        public Bibliotecario(string nome, string matricula, string especialidade)
        {
            this.nome = nome;
            this.matricula = matricula;
            this.especialidade = especialidade;
        }

        // Properties para acesso controlado aos atributos
        public string Nome 
        { 
            get { return nome; } 
            set { nome = value; } 
        }

        public string Matricula 
        { 
            get { return matricula; } 
        }

        public string Especialidade 
        { 
            get { return especialidade; } 
            set { especialidade = value; } 
        }

        /// <summary>
        /// ASSOCIAÇÃO: Método que demonstra relacionamento com Livro
        /// O bibliotecário pode processar qualquer livro, mas não possui o livro
        /// </summary>
        /// <param name="livro">Livro a ser processado</param>
        public void ProcessarLivro(Livro livro)
        {
            if (livro != null)
            {
                Console.WriteLine($"{nome} está processando o livro: {livro.Titulo}");
                Console.WriteLine($"Categoria: {livro.Categoria}");
                Console.WriteLine($"Status: {livro.Status}");
                
                // Pode alterar o status do livro temporariamente
                livro.AlterarStatus("Em processamento");
                Console.WriteLine($"Novo status: {livro.Status}");
            }
            else
            {
                Console.WriteLine("Erro: Livro não pode ser nulo!");
            }
        }

        /// <summary>
        /// ASSOCIAÇÃO: Método para catalogar livro
        /// </summary>
        /// <param name="livro">Livro a ser catalogado</param>
        public void CatalogarLivro(Livro livro)
        {
            if (livro != null)
            {
                Console.WriteLine($"{nome} está catalogando: {livro.Titulo}");
                Console.WriteLine($"Autor: {livro.Autor}");
                Console.WriteLine($"ISBN: {livro.ISBN}");
                
                // Pode alterar informações do livro
                livro.AlterarStatus("Catalogado");
                Console.WriteLine($"Livro catalogado com sucesso!");
            }
        }

        /// <summary>
        /// ASSOCIAÇÃO: Método para verificar disponibilidade de livro
        /// </summary>
        /// <param name="livro">Livro a ser verificado</param>
        /// <returns>True se o livro estiver disponível</returns>
        public bool VerificarDisponibilidade(Livro livro)
        {
            if (livro != null)
            {
                bool disponivel = livro.Status.ToLower() == "disponível";
                Console.WriteLine($"Verificação de disponibilidade para: {livro.Titulo}");
                Console.WriteLine($"Disponível: {(disponivel ? "Sim" : "Não")}");
                return disponivel;
            }
            
            Console.WriteLine("Erro: Livro não pode ser nulo!");
            return false;
        }

        /// <summary>
        /// Exibe informações do bibliotecário
        /// </summary>
        public void ExibirInformacoes()
        {
            Console.WriteLine("=== Informações do Bibliotecário ===");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Matrícula: {matricula}");
            Console.WriteLine($"Especialidade: {especialidade}");
        }

        /// <summary>
        /// Sobrescreve o método ToString para exibição personalizada
        /// </summary>
        /// <returns>String com informações do bibliotecário</returns>
        public override string ToString()
        {
            return $"{nome} - {matricula} - {especialidade}";
        }
    }
}
