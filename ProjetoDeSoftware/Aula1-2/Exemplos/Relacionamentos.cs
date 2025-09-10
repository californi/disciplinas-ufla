using System;
using System.Collections.Generic;

namespace ExemplosPOO
{
    // ASSOCIAÇÃO: Viajante "usa" Destino
    public class Viajante
    {
        public string Nome { get; set; }
        public string Passaporte { get; set; }
        public Destino DestinoAtual { get; set; } // Associação
        
        public void ViajarPara(Destino destino)
        {
            DestinoAtual = destino;
            Console.WriteLine($"{Nome} está viajando para {destino.Nome}");
        }
    }

    // COMPOSIÇÃO: Agência "contém" Departamentos
    public class AgenciaViagem
    {
        private List<Departamento> departamentos;
        
        public AgenciaViagem()
        {
            departamentos = new List<Departamento>();
            // Departamento não existe sem Agência
            departamentos.Add(new Departamento("Reservas"));
            departamentos.Add(new Departamento("Atendimento"));
        }
        
        public void ExibirDepartamentos()
        {
            foreach (var dept in departamentos)
            {
                Console.WriteLine($"Departamento: {dept.Nome}");
            }
        }
    }

    // AGREGAÇÃO: Departamento "tem" Funcionários
    public class Departamento
    {
        public string Nome { get; set; }
        private List<Funcionario> funcionarios;
        
        public Departamento(string nome)
        {
            Nome = nome;
            funcionarios = new List<Funcionario>();
        }
        
        public void AdicionarFuncionario(Funcionario func)
        {
            // Funcionário pode existir sem Departamento
            funcionarios.Add(func);
        }
        
        public void ListarFuncionarios()
        {
            foreach (var func in funcionarios)
            {
                Console.WriteLine($"Funcionário: {func.Nome} - Departamento: {Nome}");
            }
        }
    }
    
    public class Funcionario
    {
        public string Nome { get; set; }
        public string Cargo { get; set; }
        
        public Funcionario(string nome, string cargo)
        {
            Nome = nome;
            Cargo = cargo;
        }
    }
}
