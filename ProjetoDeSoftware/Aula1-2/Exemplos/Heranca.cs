using System;

namespace ExemplosPOO
{
    // Classe base (pai)
    public class Transporte
    {
        public string Companhia { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public decimal Preco { get; set; }
        
        public virtual void ExibirInformacoes()
        {
            Console.WriteLine($"Transporte: {Companhia}");
            Console.WriteLine($"Rota: {Origem} → {Destino}");
            Console.WriteLine($"Preço: R$ {Preco:F2}");
        }
        
        public virtual void CalcularTempoViagem()
        {
            Console.WriteLine("Tempo de viagem não especificado");
        }
    }

    // Classe filha - herança simples
    public class Aviao : Transporte
    {
        public string NumeroVoo { get; set; }
        public string Classe { get; set; } // Econômica, Executiva, Primeira
        
        public override void ExibirInformacoes()
        {
            Console.WriteLine($"Avião: {Companhia} - Voo {NumeroVoo}");
            Console.WriteLine($"Rota: {Origem} → {Destino}");
            Console.WriteLine($"Classe: {Classe} - Preço: R$ {Preco:F2}");
        }
        
        public override void CalcularTempoViagem()
        {
            Console.WriteLine("Tempo de voo calculado baseado na distância");
        }
        
        public void VerificarBagagem()
        {
            Console.WriteLine("Verificando bagagem de mão e despachada");
        }
    }

    // Classe filha - herança simples
    public class Onibus : Transporte
    {
        public string NumeroLinha { get; set; }
        public bool ArCondicionado { get; set; }
        
        public override void ExibirInformacoes()
        {
            Console.WriteLine($"Ônibus: {Companhia} - Linha {NumeroLinha}");
            Console.WriteLine($"Rota: {Origem} → {Destino}");
            Console.WriteLine($"Ar condicionado: {ArCondicionado} - Preço: R$ {Preco:F2}");
        }
        
        public override void CalcularTempoViagem()
        {
            Console.WriteLine("Tempo de viagem considerando paradas e trânsito");
        }
        
        public void VerificarAssentos()
        {
            Console.WriteLine("Verificando disponibilidade de assentos");
        }
    }

    // Classe filha - herança múltipla de níveis
    public class AviaoExecutivo : Aviao
    {
        public bool ServicoBordo { get; set; }
        public string TipoAssento { get; set; } // Leito, Poltrona
        
        public override void ExibirInformacoes()
        {
            Console.WriteLine($"Avião Executivo: {Companhia} - Voo {NumeroVoo}");
            Console.WriteLine($"Rota: {Origem} → {Destino}");
            Console.WriteLine($"Classe: {Classe} - Tipo: {TipoAssento}");
            Console.WriteLine($"Serviço de bordo: {ServicoBordo} - Preço: R$ {Preco:F2}");
        }
        
        public void ServirRefeicao()
        {
            if (ServicoBordo)
                Console.WriteLine("Servindo refeição executiva");
            else
                Console.WriteLine("Sem serviço de bordo");
        }
    }
}
