using System;
using System.Collections.Generic;

namespace ExemplosRelacoes.Agregacao
{
    /// <summary>
    /// Exemplo de AGREGAÇÃO entre Universidade e Departamento
    /// - Departamento faz parte da universidade
    /// - MAS departamento pode existir sem universidade
    /// - Se universidade fechar, departamentos podem continuar existindo
    /// </summary>
    
    public class Departamento
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string Localizacao { get; set; }
        
        public Departamento(string nome, string sigla, string localizacao)
        {
            Nome = nome;
            Sigla = sigla;
            Localizacao = localizacao;
        }
        
        public void MostrarInfo()
        {
            Console.WriteLine($"  Departamento: {Nome} ({Sigla}) - {Localizacao}");
        }
    }
    
    public class Universidade
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }
        
        // Lista de departamentos - Agregação
        // Departamento pode existir sem universidade
        public List<Departamento> Departamentos { get; set; }
        
        public Universidade(string nome, string sigla)
        {
            Nome = nome;
            Sigla = sigla;
            Departamentos = new List<Departamento>();
        }
        
        public void AdicionarDepartamento(Departamento dept)
        {
            if (dept != null)
            {
                Departamentos.Add(dept);
                Console.WriteLine($"Departamento {dept.Nome} adicionado à {Nome}");
            }
        }
        
        public void RemoverDepartamento(Departamento dept)
        {
            Departamentos.Remove(dept);
        }
        
        public void MostrarDepartamentos()
        {
            Console.WriteLine($"\nUniversidade: {Nome} ({Sigla})");
            Console.WriteLine($"Total de departamentos: {Departamentos.Count}\n");
            
            foreach (var dept in Departamentos)
            {
                dept.MostrarInfo();
            }
        }
    }
    
    // Programa de exemplo
    public class ExemploAgregacao
    {
        public static void Executar()
        {
            Console.WriteLine("\n=== EXEMPLO DE AGREGAÇÃO ===\n");
            
            // Criar universidade
            Universidade universidade = new Universidade("Universidade Federal de Lavras", "UFLA");
            
            // Criar departamentos (podem existir independentemente)
            Departamento dcc = new Departamento("Ciência da Computação", "DCC", "Bloco A");
            Departamento deq = new Departamento("Engenharia Química", "DEQ", "Bloco B");
            Departamento dez = new Departamento("Engenharia", "DEZ", "Bloco C");
            
            // Universidade agrega departamentos
            universidade.AdicionarDepartamento(dcc);
            universidade.AdicionarDepartamento(deq);
            universidade.AdicionarDepartamento(dez);
            
            // Mostrar relação
            universidade.MostrarDepartamentos();
            
            // Se a universidade fechar, departamentos podem continuar
            Console.WriteLine("\n--- Simulando fechamento da universidade ---");
            universidade = null;
            
            Console.WriteLine("\nDepartamentos podem continuar existindo independentemente:");
            dcc.MostrarInfo();
            deq.MostrarInfo();
            dez.MostrarInfo();
        }
    }
}


