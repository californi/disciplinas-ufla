using System;

namespace ExemplosPOO
{
    public class ReservaViagem
    {
        // Atributos privados (encapsulamento)
        private decimal valorTotal;
        private string senhaAcesso;
        private bool confirmada;
        
        // Propriedades públicas com controle
        public string CodigoReserva { get; private set; }
        public string Cliente { get; set; }
        public string Destino { get; set; }
        
        // Propriedade com validação
        public decimal ValorTotal 
        { 
            get { return valorTotal; }
            private set { valorTotal = value; } // Só pode ser alterado internamente
        }
        
        // Propriedade com validação
        public bool Confirmada
        {
            get { return confirmada; }
            private set { confirmada = value; }
        }
        
        // Construtor
        public ReservaViagem(string codigo, string cliente, string destino, decimal valor)
        {
            CodigoReserva = codigo;
            Cliente = cliente;
            Destino = destino;
            valorTotal = valor;
            senhaAcesso = "123456"; // Senha padrão
            confirmada = false;
        }
        
        // Métodos públicos para operações
        public bool ConfirmarReserva(string senhaInformada)
        {
            if (senhaInformada != senhaAcesso)
                return false;
                
            if (!confirmada)
            {
                confirmada = true;
                return true;
            }
            return false;
        }
        
        public bool CancelarReserva(string senhaInformada)
        {
            if (senhaInformada != senhaAcesso)
                return false;
                
            if (confirmada)
            {
                confirmada = false;
                return true;
            }
            return false;
        }
        
        public void AdicionarTaxa(decimal taxa)
        {
            if (taxa > 0)
                valorTotal += taxa;
        }
        
        public void ExibirInformacoes()
        {
            Console.WriteLine($"Reserva: {CodigoReserva}");
            Console.WriteLine($"Cliente: {Cliente} - Destino: {Destino}");
            Console.WriteLine($"Valor: R$ {valorTotal:F2} - Confirmada: {confirmada}");
        }
    }
}
