using System;

namespace ExemplosPOO
{
    public class CalculadoraViagem
    {
        // Sobrecarga de métodos de cálculo de preço
        public decimal CalcularPreco(decimal precoBase)
        {
            return precoBase;
        }
        
        public decimal CalcularPreco(decimal precoBase, decimal taxa)
        {
            return precoBase + taxa;
        }
        
        public decimal CalcularPreco(decimal precoBase, decimal taxa, decimal desconto)
        {
            decimal precoComTaxa = precoBase + taxa;
            return precoComTaxa - desconto;
        }
        
        public decimal CalcularPreco(decimal[] precos)
        {
            decimal total = 0;
            foreach (decimal preco in precos)
                total += preco;
            return total;
        }
        
        // Sobrecarga de métodos de desconto
        public decimal AplicarDesconto(decimal preco, decimal percentual)
        {
            return preco * (1 - percentual / 100);
        }
        
        public decimal AplicarDesconto(decimal preco, string tipoCliente)
        {
            switch (tipoCliente.ToLower())
            {
                case "vip":
                    return preco * 0.85m; // 15% de desconto
                case "premium":
                    return preco * 0.90m; // 10% de desconto
                case "regular":
                    return preco * 0.95m; // 5% de desconto
                default:
                    return preco;
            }
        }
        
        // Sobrecarga de métodos de validação
        public bool ValidarDestino(string destino)
        {
            return !string.IsNullOrEmpty(destino) && destino.Length > 2;
        }
        
        public bool ValidarDestino(string destino, string[] destinosValidos)
        {
            if (!ValidarDestino(destino))
                return false;
                
            foreach (string dest in destinosValidos)
            {
                if (destino.Equals(dest, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
    }
    
    // Classe para demonstrar uso da sobrecarga
    public class ExemploSobrecarga
    {
        public static void DemonstrarSobrecarga()
        {
            CalculadoraViagem calc = new CalculadoraViagem();
            
            // Uso da sobrecarga de cálculo de preço
            decimal preco1 = calc.CalcularPreco(1000.0m);                    // decimal CalcularPreco(decimal)
            decimal preco2 = calc.CalcularPreco(1000.0m, 100.0m);           // decimal CalcularPreco(decimal, decimal)
            decimal preco3 = calc.CalcularPreco(1000.0m, 100.0m, 50.0m);    // decimal CalcularPreco(decimal, decimal, decimal)
            
            decimal[] precos = { 500.0m, 300.0m, 200.0m };
            decimal preco4 = calc.CalcularPreco(precos);                    // decimal CalcularPreco(decimal[])
            
            // Uso da sobrecarga de desconto
            decimal desconto1 = calc.AplicarDesconto(1000.0m, 10.0m);       // decimal AplicarDesconto(decimal, decimal)
            decimal desconto2 = calc.AplicarDesconto(1000.0m, "VIP");       // decimal AplicarDesconto(decimal, string)
            
            // Uso da sobrecarga de validação
            bool valido1 = calc.ValidarDestino("Paris");                    // bool ValidarDestino(string)
            string[] destinos = { "Paris", "Londres", "Roma" };
            bool valido2 = calc.ValidarDestino("Paris", destinos);          // bool ValidarDestino(string, string[])
            
            Console.WriteLine($"Preços calculados: {preco1}, {preco2}, {preco3}, {preco4}");
            Console.WriteLine($"Descontos aplicados: {desconto1}, {desconto2}");
            Console.WriteLine($"Validações: {valido1}, {valido2}");
        }
    }
}
