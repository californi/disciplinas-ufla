using System;

namespace ExemplosPOO
{
    public class PacoteViagem
    {
        // Atributos
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int DuracaoDias { get; set; }
        
        // Construtor padrão
        public PacoteViagem()
        {
            Codigo = "000000";
            Nome = "Pacote Padrão";
            Preco = 0.0m;
            DuracaoDias = 1;
        }
        
        // Construtor parametrizado
        public PacoteViagem(string codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
            Preco = 0.0m;
            DuracaoDias = 1;
        }
        
        // Construtor completo
        public PacoteViagem(string codigo, string nome, decimal preco, int duracaoDias)
        {
            Codigo = codigo;
            Nome = nome;
            Preco = preco;
            DuracaoDias = duracaoDias;
        }
        
        // Método para exibir informações
        public void ExibirInformacoes()
        {
            Console.WriteLine($"Pacote: {Nome} (Código: {Codigo})");
            Console.WriteLine($"Preço: R$ {Preco:F2} - Duração: {DuracaoDias} dias");
        }
    }
    
    // Classe para demonstrar uso dos objetos
    public class ExemploObjetos
    {
        public static void DemonstrarConstrutores()
        {
            // OBJETOS E CONSTRUTORES (Sobrecarga)
            PacoteViagem pacote1 = new PacoteViagem(); // Construtor padrão
            PacoteViagem pacote2 = new PacoteViagem("PAC001", "Paris Romântica"); // Parametrizado
            PacoteViagem pacote3 = new PacoteViagem("PAC002", "Nova York Completa", 5000.0m, 7); // Completo
            
            // Exibir informações
            pacote1.ExibirInformacoes();
            pacote2.ExibirInformacoes();
            pacote3.ExibirInformacoes();
        }
    }
}
