using System;
using System.Collections.Generic;

namespace ExemplosRelacoes.Composicao
{
    /// <summary>
    /// Exemplo de COMPOSIÇÃO entre ContaBancaria e Transacao
    /// - Transacao NÃO pode existir sem ContaBancaria
    /// - Se conta for fechada, transações são destruídas
    /// - Transação só faz sentido dentro do contexto da conta
    /// </summary>
    
    public class Transacao
    {
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        
        public Transacao(DateTime data, double valor, string tipo, string descricao)
        {
            Data = data;
            Valor = valor;
            Tipo = tipo;
            Descricao = descricao;
        }
        
        public void Mostrar()
        {
            Console.WriteLine($"  [{Data:dd/MM/yyyy HH:mm}] {Tipo}: R$ {Valor:F2} - {Descricao}");
        }
    }
    
    public class ContaBancaria
    {
        public string Numero { get; set; }
        public string Titular { get; set; }
        private double saldo;
        
        public double Saldo
        {
            get { return saldo; }
            private set { saldo = value; }
        }
        
        // Lista de transações - COMPOSIÇÃO
        // Transação não existe sem ContaBancaria
        public List<Transacao> Transacoes { get; private set; }
        
        public ContaBancaria(string numero, string titular)
        {
            Numero = numero;
            Titular = titular;
            Saldo = 0;
            Transacoes = new List<Transacao>();
        }
        
        public void Depositar(double valor, string descricao)
        {
            if (valor > 0)
            {
                Saldo += valor;
                
                // Criar transação (composta pela conta)
                Transacao trans = new Transacao(DateTime.Now, valor, "DEPOSITO", descricao);
                Transacoes.Add(trans);
                
                Console.WriteLine($"✓ Depósito de R$ {valor:F2} realizado com sucesso!");
            }
        }
        
        public bool Sacar(double valor, string descricao)
        {
            if (valor > 0 && Saldo >= valor)
            {
                Saldo -= valor;
                
                // Criar transação (composta pela conta)
                Transacao trans = new Transacao(DateTime.Now, -valor, "SAQUE", descricao);
                Transacoes.Add(trans);
                
                Console.WriteLine($"✓ Saque de R$ {valor:F2} realizado com sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine("✗ Saldo insuficiente!");
                return false;
            }
        }
        
        public void MostrarExtrato()
        {
            Console.WriteLine($"\n--- EXTRATO BANCÁRIO ---");
            Console.WriteLine($"Conta: {Numero}");
            Console.WriteLine($"Titular: {Titular}");
            Console.WriteLine($"Saldo Atual: R$ {Saldo:F2}\n");
            
            Console.WriteLine("Transações:");
            foreach (var trans in Transacoes)
            {
                trans.Mostrar();
            }
            
            Console.WriteLine($"\nTotal de transações: {Transacoes.Count}");
            Console.WriteLine($"Saldo final: R$ {Saldo:F2}\n");
        }
        
        // Ao fechar a conta, as transações são destruídas junto
        public void FecharConta()
        {
            Console.WriteLine($"\n*** Conta {Numero} encerrada ***");
            Console.WriteLine($"Transações descartadas: {Transacoes.Count}");
            Transacoes.Clear();
            Saldo = 0;
        }
    }
    
    // Programa de exemplo
    public class ExemploComposicao
    {
        public static void Executar()
        {
            Console.WriteLine("\n=== EXEMPLO DE COMPOSIÇÃO ===\n");
            
            // Criar conta bancária
            ContaBancaria conta = new ContaBancaria("12345-6", "João Silva");
            
            // Realizar operações (criam transações que fazem parte da conta)
            conta.Depositar(1000, "Salário");
            conta.Depositar(500, "Freelance");
            conta.Sacar(200, "Compra mercado");
            conta.Sacar(150, "Conta luz");
            
            // Mostrar extrato (transações só existem no contexto da conta)
            conta.MostrarExtrato();
            
            // Se a conta for fechada, transações são destruídas
            conta.FecharConta();
            
            // Não é possível acessar transações depois de fechar a conta
            Console.WriteLine($"Transações após fechamento: {conta.Transacoes.Count}");
            
            Console.WriteLine("\nTransações não têm sentido sem a conta!");
        }
    }
}


