using System;

namespace ExemplosPOO
{
    // ABSTRAÇÃO: Classe que representa um Destino de Viagem
    public class Destino
    {
		int Codigo;
		string Descricao;
		string Cidade;
		
		
        // Propriedades essenciais (abstração)
        public string Nome { get; set; }
        public string Pais { get; set; }
        public string Cidade { get; set; }
        public string Clima { get; set; }
        public bool Disponivel { get; set; }
        
        // Métodos essenciais (abstração)
        public void Reservar() 
        { 
            if (Disponivel)
                Disponivel = false;
			
			this.Codigo = 3;
        }
        
        public void CancelarReserva() 
        { 
            Disponivel = true; 
        }
        
        public bool EstaDisponivel() 
        { 
            return Disponivel; 
        }
        
        public void ExibirInformacoes()
        {
            Console.WriteLine($"Destino: {Nome} - {Cidade}, {Pais}");
            Console.WriteLine($"Clima: {Clima} - Disponível: {Disponivel}");
        }
    }
}
