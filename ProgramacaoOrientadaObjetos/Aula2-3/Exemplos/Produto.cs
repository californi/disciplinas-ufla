using System;

namespace Exemplos
{
    /// <summary>
    /// Classe que representa um produto
    /// </summary>
    public class Produto
    {
        // Atributos privados
        private string codigo;
        private string nome;
        private double preco;
        private int estoque;
        private string categoria;

        /// <summary>
        /// Construtor da classe Produto
        /// </summary>
        /// <param name="codigo">Código único do produto</param>
        /// <param name="nome">Nome do produto</param>
        /// <param name="preco">Preço do produto</param>
        /// <param name="categoria">Categoria do produto</param>
        /// <param name="estoque">Quantidade em estoque</param>
        public Produto(string codigo, string nome, double preco, string categoria, int estoque = 0)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.preco = Math.Max(0.0, preco); // Preço não pode ser negativo
            this.categoria = categoria;
            this.estoque = Math.Max(0, estoque); // Estoque não pode ser negativo
        }

        // Properties para acesso controlado aos atributos
        public string Codigo 
        { 
            get { return codigo; } 
        }

        public string Nome 
        { 
            get { return nome; } 
            set 
            { 
                if (!string.IsNullOrWhiteSpace(value))
                    nome = value;
                else
                    Console.WriteLine("Erro: Nome do produto não pode ser vazio!");
            } 
        }

        public double Preco 
        { 
            get { return preco; } 
            set 
            { 
                if (value >= 0)
                    preco = value;
                else
                    Console.WriteLine("Erro: Preço não pode ser negativo!");
            } 
        }

        public int Estoque 
        { 
            get { return estoque; } 
            set 
            { 
                if (value >= 0)
                    estoque = value;
                else
                    Console.WriteLine("Erro: Estoque não pode ser negativo!");
            } 
        }

        public string Categoria 
        { 
            get { return categoria; } 
            set 
            { 
                if (!string.IsNullOrWhiteSpace(value))
                    categoria = value;
                else
                    Console.WriteLine("Erro: Categoria não pode ser vazia!");
            } 
        }

        /// <summary>
        /// Calcula o preço com desconto
        /// </summary>
        /// <param name="percentualDesconto">Percentual de desconto (0-100)</param>
        /// <returns>Preço com desconto aplicado</returns>
        public double CalcularDesconto(double percentualDesconto)
        {
            if (percentualDesconto < 0 || percentualDesconto > 100)
            {
                Console.WriteLine("Erro: Percentual de desconto deve estar entre 0 e 100!");
                return preco;
            }

            double desconto = preco * (percentualDesconto / 100.0);
            double precoComDesconto = preco - desconto;
            
            Console.WriteLine($"Desconto de {percentualDesconto}% aplicado!");
            Console.WriteLine($"Preço original: R$ {preco:F2}");
            Console.WriteLine($"Valor do desconto: R$ {desconto:F2}");
            Console.WriteLine($"Preço final: R$ {precoComDesconto:F2}");
            
            return precoComDesconto;
        }

        /// <summary>
        /// Atualiza a quantidade em estoque
        /// </summary>
        /// <param name="quantidade">Quantidade a ser adicionada (pode ser negativa para remoção)</param>
        /// <returns>True se a atualização foi bem-sucedida</returns>
        public bool AtualizarEstoque(int quantidade)
        {
            int novoEstoque = estoque + quantidade;
            
            if (novoEstoque < 0)
            {
                Console.WriteLine("Erro: Estoque insuficiente para esta operação!");
                Console.WriteLine($"Estoque atual: {estoque}");
                Console.WriteLine($"Tentativa de remoção: {Math.Abs(quantidade)}");
                return false;
            }

            estoque = novoEstoque;
            
            if (quantidade > 0)
                Console.WriteLine($"Estoque atualizado! Adicionados {quantidade} itens.");
            else if (quantidade < 0)
                Console.WriteLine($"Estoque atualizado! Removidos {Math.Abs(quantidade)} itens.");
            
            Console.WriteLine($"Novo estoque: {estoque} unidades");
            return true;
        }

        /// <summary>
        /// Verifica se o produto está disponível
        /// </summary>
        /// <param name="quantidadeDesejada">Quantidade desejada</param>
        /// <returns>True se há estoque suficiente</returns>
        public bool VerificarDisponibilidade(int quantidadeDesejada)
        {
            if (quantidadeDesejada <= 0)
            {
                Console.WriteLine("Erro: Quantidade deve ser positiva!");
                return false;
            }

            bool disponivel = estoque >= quantidadeDesejada;
            
            if (disponivel)
            {
                Console.WriteLine($"Produto disponível! Estoque: {estoque} unidades");
            }
            else
            {
                Console.WriteLine($"Produto indisponível! Estoque: {estoque} unidades");
                Console.WriteLine($"Quantidade solicitada: {quantidadeDesejada} unidades");
            }
            
            return disponivel;
        }

        /// <summary>
        /// Aplica uma promoção ao produto
        /// </summary>
        /// <param name="tipoPromocao">Tipo da promoção</param>
        /// <param name="valor">Valor da promoção</param>
        public void AplicarPromocao(string tipoPromocao, double valor)
        {
            Console.WriteLine($"Aplicando promoção: {tipoPromocao}");
            
            switch (tipoPromocao.ToLower())
            {
                case "desconto":
                    CalcularDesconto(valor);
                    break;
                case "leve 2 pague 1":
                    if (estoque >= 2)
                    {
                        Console.WriteLine("Promoção 'Leve 2 Pague 1' aplicada!");
                        Console.WriteLine("Cliente paga apenas 1 produto!");
                    }
                    else
                    {
                        Console.WriteLine("Estoque insuficiente para a promoção!");
                    }
                    break;
                case "frete grátis":
                    Console.WriteLine("Frete grátis aplicado para compras acima de R$ 100,00!");
                    break;
                default:
                    Console.WriteLine("Tipo de promoção não reconhecido!");
                    break;
            }
        }

        /// <summary>
        /// Calcula o valor total do estoque
        /// </summary>
        /// <returns>Valor total em reais</returns>
        public double CalcularValorTotalEstoque()
        {
            double valorTotal = estoque * preco;
            Console.WriteLine($"Valor total do estoque: R$ {valorTotal:F2}");
            Console.WriteLine($"({estoque} unidades × R$ {preco:F2})");
            return valorTotal;
        }

        /// <summary>
        /// Verifica se o produto está em falta
        /// </summary>
        /// <returns>True se o estoque estiver zerado</returns>
        public bool EstaEmFalta()
        {
            bool emFalta = estoque == 0;
            
            if (emFalta)
                Console.WriteLine($"Produto {nome} está em falta!");
            else
                Console.WriteLine($"Produto {nome} tem {estoque} unidades em estoque.");
            
            return emFalta;
        }

        /// <summary>
        /// Exibe informações completas do produto
        /// </summary>
        public void ExibirInformacoes()
        {
            Console.WriteLine("=== Informações do Produto ===");
            Console.WriteLine($"Código: {codigo}");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Preço: R$ {preco:F2}");
            Console.WriteLine($"Categoria: {categoria}");
            Console.WriteLine($"Estoque: {estoque} unidades");
            Console.WriteLine($"Valor total do estoque: R$ {CalcularValorTotalEstoque():F2}");
            Console.WriteLine($"Status: {(EstaEmFalta() ? "Em falta" : "Disponível")}");
        }

        /// <summary>
        /// Sobrescreve o método ToString para exibição personalizada
        /// </summary>
        /// <returns>String com informações do produto</returns>
        public override string ToString()
        {
            return $"{codigo} - {nome} - R$ {preco:F2} - {categoria} - Estoque: {estoque}";
        }
    }
}
