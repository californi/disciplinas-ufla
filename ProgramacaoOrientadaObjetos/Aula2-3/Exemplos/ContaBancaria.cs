using System;

namespace Exemplos
{
    /// <summary>
    /// Classe que representa uma conta bancária
    /// </summary>
    public class ContaBancaria
    {
        // Atributos privados
        private string numero;
        private string titular;
        private double saldo;
        private string tipo;

        /// <summary>
        /// Construtor da classe ContaBancaria
        /// </summary>
        /// <param name="numero">Número da conta</param>
        /// <param name="titular">Nome do titular</param>
        /// <param name="tipo">Tipo da conta (Corrente ou Poupança)</param>
        public ContaBancaria(string numero, string titular, string tipo)
        {
            this.numero = numero;
            this.titular = titular;
            this.tipo = tipo;
            this.saldo = 0.0; // Saldo inicial sempre zero
        }

        /// <summary>
        /// Construtor com saldo inicial
        /// </summary>
        /// <param name="numero">Número da conta</param>
        /// <param name="titular">Nome do titular</param>
        /// <param name="tipo">Tipo da conta</param>
        /// <param name="saldoInicial">Saldo inicial da conta</param>
        public ContaBancaria(string numero, string titular, string tipo, double saldoInicial)
        {
            this.numero = numero;
            this.titular = titular;
            this.tipo = tipo;
            this.saldo = saldoInicial;
        }

        // Properties para acesso controlado aos atributos
        public string Numero 
        { 
            get { return numero; } 
        }

        public string Titular 
        { 
            get { return titular; } 
            set { titular = value; } 
        }

        public double Saldo 
        { 
            get { return saldo; } 
        }

        public string Tipo 
        { 
            get { return tipo; } 
        }

        /// <summary>
        /// Deposita um valor na conta
        /// </summary>
        /// <param name="valor">Valor a ser depositado</param>
        /// <returns>True se o depósito foi realizado com sucesso</returns>
        public bool Depositar(double valor)
        {
            if (valor > 0)
            {
                saldo += valor;
                Console.WriteLine($"Depósito de R$ {valor:F2} realizado com sucesso!");
                Console.WriteLine($"Novo saldo: R$ {saldo:F2}");
                return true;
            }
            else
            {
                Console.WriteLine("Erro: Valor do depósito deve ser positivo!");
                return false;
            }
        }

        /// <summary>
        /// Saca um valor da conta
        /// </summary>
        /// <param name="valor">Valor a ser sacado</param>
        /// <returns>True se o saque foi realizado com sucesso</returns>
        public bool Sacar(double valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Erro: Valor do saque deve ser positivo!");
                return false;
            }

            if (valor > saldo)
            {
                Console.WriteLine("Erro: Saldo insuficiente!");
                Console.WriteLine($"Saldo atual: R$ {saldo:F2}");
                Console.WriteLine($"Valor solicitado: R$ {valor:F2}");
                return false;
            }

            saldo -= valor;
            Console.WriteLine($"Saque de R$ {valor:F2} realizado com sucesso!");
            Console.WriteLine($"Novo saldo: R$ {saldo:F2}");
            return true;
        }

        /// <summary>
        /// Verifica o saldo atual da conta
        /// </summary>
        public void VerificarSaldo()
        {
            Console.WriteLine($"=== Saldo da Conta {numero} ===");
            Console.WriteLine($"Titular: {titular}");
            Console.WriteLine($"Tipo: {tipo}");
            Console.WriteLine($"Saldo atual: R$ {saldo:F2}");
        }

        /// <summary>
        /// Transfere dinheiro para outra conta
        /// </summary>
        /// <param name="contaDestino">Conta de destino</param>
        /// <param name="valor">Valor a ser transferido</param>
        /// <returns>True se a transferência foi realizada com sucesso</returns>
        public bool Transferir(ContaBancaria contaDestino, double valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Erro: Valor da transferência deve ser positivo!");
                return false;
            }

            if (valor > saldo)
            {
                Console.WriteLine("Erro: Saldo insuficiente para transferência!");
                return false;
            }

            // Realiza o saque na conta origem
            if (Sacar(valor))
            {
                // Realiza o depósito na conta destino
                if (contaDestino.Depositar(valor))
                {
                    Console.WriteLine($"Transferência de R$ {valor:F2} realizada com sucesso!");
                    Console.WriteLine($"De: {titular} (Conta {numero})");
                    Console.WriteLine($"Para: {contaDestino.titular} (Conta {contaDestino.numero})");
                    return true;
                }
                else
                {
                    // Se o depósito falhou, devolve o dinheiro
                    Depositar(valor);
                    Console.WriteLine("Erro: Falha na transferência. Dinheiro devolvido.");
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Exibe informações completas da conta
        /// </summary>
        public void ExibirInformacoes()
        {
            Console.WriteLine("=== Informações da Conta ===");
            Console.WriteLine($"Número: {numero}");
            Console.WriteLine($"Titular: {titular}");
            Console.WriteLine($"Tipo: {tipo}");
            Console.WriteLine($"Saldo: R$ {saldo:F2}");
        }

        /// <summary>
        /// Sobrescreve o método ToString para exibição personalizada
        /// </summary>
        /// <returns>String com informações da conta</returns>
        public override string ToString()
        {
            return $"Conta {numero} - {titular} - {tipo} - Saldo: R$ {saldo:F2}";
        }
    }
}
