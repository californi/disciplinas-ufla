using System;
using System.Collections.Generic;

namespace ExemplosPOO
{
    // ABSTRAÇÃO: Classe base para serviços de viagem
    public abstract class ServicoBase
    {
        protected string nome;
        protected string codigo;
        protected bool disponivel;
        
        // CONSTRUTORES (SOBRECARGA)
        public ServicoBase() { }
        public ServicoBase(string nome, string codigo)
        {
            this.nome = nome;
            this.codigo = codigo;
            this.disponivel = true;
        }
        
        // ENCAPSULAMENTO
        public string Nome { get { return nome; } }
        public string Codigo { get { return codigo; } }
        public bool Disponivel { get { return disponivel; } }
        
        // MÉTODOS ABSTRATOS (POLIMORFISMO)
        public abstract string ObterTipo();
        public abstract void ExibirDetalhes();
        
        public virtual void Reservar()
        {
            if (disponivel)
                disponivel = false;
        }
    }

    // HERANÇA: Hospedagem herda de ServicoBase
    public class Hospedagem : ServicoBase
    {
        private string hotel;
        private int quartos;
        
        // CONSTRUTORES (SOBRECARGA)
        public Hospedagem() : base() { }
        public Hospedagem(string nome, string codigo, string hotel) 
            : base(nome, codigo)
        {
            this.hotel = hotel;
        }
        
        public Hospedagem(string nome, string codigo, string hotel, int quartos)
            : base(nome, codigo)
        {
            this.hotel = hotel;
            this.quartos = quartos;
        }
        
        // POLIMORFISMO: Implementação específica
        public override string ObterTipo() { return "Hospedagem"; }
        
        public override void ExibirDetalhes()
        {
            Console.WriteLine($"Hospedagem: {nome} - Hotel: {hotel}");
        }
    }

    // HERANÇA: Transporte herda de ServicoBase
    public class Transporte : ServicoBase
    {
        private string companhia;
        private string tipo;
        
        public Transporte(string nome, string codigo, string companhia)
            : base(nome, codigo)
        {
            this.companhia = companhia;
        }
        
        // POLIMORFISMO: Implementação específica
        public override string ObterTipo() { return "Transporte"; }
        
        public override void ExibirDetalhes()
        {
            Console.WriteLine($"Transporte: {nome} - Companhia: {companhia}");
        }
    }

    // COMPOSIÇÃO: Agência contém departamentos
    public class AgenciaViagem
    {
        private List<Departamento> departamentos;
        private List<Cliente> clientes;
        
        public AgenciaViagem()
        {
            departamentos = new List<Departamento>();
            clientes = new List<Cliente>();
        }
        
        // AGREGAÇÃO: Agência tem serviços
        public void AdicionarServico(ServicoBase servico, string departamento)
        {
            // Lógica para adicionar serviço
        }
    }

    // ASSOCIAÇÃO: Cliente usa Agência
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        private List<ServicoBase> servicosContratados;
        
        public Cliente(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
            servicosContratados = new List<ServicoBase>();
        }
        
        public void ContratarServico(ServicoBase servico)
        {
            if (servico.Disponivel)
            {
                servico.Reservar();
                servicosContratados.Add(servico);
            }
        }
    }

    // COMPOSIÇÃO: Departamento pertence à Agência
    public class Departamento
    {
        public string Nome { get; set; }
        private List<ServicoBase> servicos;
        
        public Departamento(string nome)
        {
            Nome = nome;
            servicos = new List<ServicoBase>();
        }
    }

    // Classe principal para demonstrar todos os conceitos
    public class SistemaViagem
    {
        public static void DemonstrarSistema()
        {
            // Criação de objetos usando diferentes construtores
            AgenciaViagem agencia = new AgenciaViagem();

            // OBJETOS E CONSTRUTORES (Sobrecarga)
            Hospedagem hospedagem1 = new Hospedagem();
            Hospedagem hospedagem2 = new Hospedagem("Hotel Luxo", "HOT001", "Grand Hotel");
            Hospedagem hospedagem3 = new Hospedagem("Suíte Premium", "HOT002", "Palace Hotel", 3);

            Transporte transporte1 = new Transporte("Voo Direto", "VO001", "LATAM");

            // POLIMORFISMO: Lista de serviços diferentes
            List<ServicoBase> servicos = new List<ServicoBase>
            {
                hospedagem2, hospedagem3, transporte1
            };

            foreach (ServicoBase servico in servicos)
            {
                servico.ExibirDetalhes(); // Polimorfismo
                Console.WriteLine("Tipo: " + servico.ObterTipo());
            }

            // CLIENTES E CONTRATAÇÕES
            Cliente cliente1 = new Cliente("João Silva", "123.456.789-00");
            cliente1.ContratarServico(hospedagem2);

            // RELACIONAMENTOS
            Departamento deptHospedagem = new Departamento("Hospedagem");
            Departamento deptTransporte = new Departamento("Transporte");
        }
    }
}
