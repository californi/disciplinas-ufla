using System;
using System.Collections.Generic;

namespace ExemplosPOO
{
    // Classe base abstrata
    public abstract class ServicoViagem
    {
        public string Nome { get; set; }
        public decimal PrecoBase { get; set; }
        
        public abstract decimal CalcularPrecoFinal();
        public abstract string ObterTipoServico();
        
        public virtual void ExibirDetalhes()
        {
            Console.WriteLine($"Serviço: {Nome} - Preço Base: R$ {PrecoBase:F2}");
        }
    }

    // Classes filhas com implementações específicas
    public class Hospedagem : ServicoViagem
    {
        public int NumeroQuartos { get; set; }
        public string TipoQuarto { get; set; } // Individual, Duplo, Suíte
        public bool CafeIncluso { get; set; }
        
        public override decimal CalcularPrecoFinal()
        {
            decimal precoFinal = PrecoBase;
            
            if (NumeroQuartos > 1)
                precoFinal += (NumeroQuartos - 1) * 100.0m;
                
            if (CafeIncluso)
                precoFinal += 50.0m;
                
            return precoFinal;
        }
        
        public override string ObterTipoServico()
        {
            return "Hospedagem";
        }
        
        public override void ExibirDetalhes()
        {
            base.ExibirDetalhes();
            Console.WriteLine($"Quartos: {NumeroQuartos} ({TipoQuarto})");
            Console.WriteLine($"Café incluso: {CafeIncluso}");
            Console.WriteLine($"Preço Final: R$ {CalcularPrecoFinal():F2}");
        }
    }

    public class Passeio : ServicoViagem
    {
        public string DestinoPasseio { get; set; }
        public int DuracaoHoras { get; set; }
        public bool GuiaIncluso { get; set; }
        
        public override decimal CalcularPrecoFinal()
        {
            decimal precoFinal = PrecoBase;
            
            if (DuracaoHoras > 4)
                precoFinal += (DuracaoHoras - 4) * 25.0m;
                
            if (GuiaIncluso)
                precoFinal += 100.0m;
                
            return precoFinal;
        }
        
        public override string ObterTipoServico()
        {
            return "Passeio";
        }
        
        public override void ExibirDetalhes()
        {
            base.ExibirDetalhes();
            Console.WriteLine($"Destino: {DestinoPasseio}");
            Console.WriteLine($"Duração: {DuracaoHoras} horas");
            Console.WriteLine($"Guia incluso: {GuiaIncluso}");
            Console.WriteLine($"Preço Final: R$ {CalcularPrecoFinal():F2}");
        }
    }

    public class Transfer : ServicoViagem
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
        public string TipoVeiculo { get; set; } // Sedan, Van, Ônibus
        public bool MotoristaIncluso { get; set; }
        
        public override decimal CalcularPrecoFinal()
        {
            decimal precoFinal = PrecoBase;
            
            switch (TipoVeiculo.ToLower())
            {
                case "van":
                    precoFinal += 50.0m;
                    break;
                case "ônibus":
                    precoFinal += 100.0m;
                    break;
            }
            
            if (MotoristaIncluso)
                precoFinal += 80.0m;
                
            return precoFinal;
        }
        
        public override string ObterTipoServico()
        {
            return "Transfer";
        }
        
        public override void ExibirDetalhes()
        {
            base.ExibirDetalhes();
            Console.WriteLine($"Rota: {Origem} → {Destino}");
            Console.WriteLine($"Veículo: {TipoVeiculo}");
            Console.WriteLine($"Motorista incluso: {MotoristaIncluso}");
            Console.WriteLine($"Preço Final: R$ {CalcularPrecoFinal():F2}");
        }
    }

    // Classe para demonstrar polimorfismo
    public class ExemploPolimorfismo
    {
        public static void DemonstrarPolimorfismo()
        {
            // POLIMORFISMO: Lista de serviços diferentes
            List<ServicoViagem> servicos = new List<ServicoViagem>
            {
                new Hospedagem 
                { 
                    Nome = "Hotel Luxo", 
                    PrecoBase = 500.0m, 
                    NumeroQuartos = 2, 
                    TipoQuarto = "Duplo", 
                    CafeIncluso = true 
                },
                new Passeio 
                { 
                    Nome = "City Tour", 
                    PrecoBase = 150.0m, 
                    DestinoPasseio = "Centro Histórico", 
                    DuracaoHoras = 6, 
                    GuiaIncluso = true 
                },
                new Transfer 
                { 
                    Nome = "Transfer Aeroporto", 
                    PrecoBase = 80.0m, 
                    Origem = "Aeroporto", 
                    Destino = "Hotel", 
                    TipoVeiculo = "Sedan", 
                    MotoristaIncluso = true 
                }
            };

            // Uso polimórfico
            foreach (ServicoViagem servico in servicos)
            {
                servico.ExibirDetalhes(); // Polimorfismo
                Console.WriteLine($"Tipo: {servico.ObterTipoServico()}");
                Console.WriteLine("---");
            }
        }
    }
}
