using System;

namespace Exemplos
{
    /// <summary>
    /// Classe base que representa um animal
    /// Demonstra HERANÇA - outras classes herdam desta
    /// </summary>
    public class Animal
    {
        // Atributos protegidos (acessíveis às classes derivadas)
        protected string nome;
        protected string especie;
        protected int idade;
        protected double peso;
        protected string cor;

        /// <summary>
        /// Construtor da classe Animal
        /// </summary>
        /// <param name="nome">Nome do animal</param>
        /// <param name="especie">Espécie do animal</param>
        /// <param name="idade">Idade em anos</param>
        /// <param name="peso">Peso em kg</param>
        /// <param name="cor">Cor do animal</param>
        public Animal(string nome, string especie, int idade = 0, double peso = 0.0, string cor = "Não especificada")
        {
            this.nome = nome;
            this.especie = especie;
            this.idade = Math.Max(0, idade);
            this.peso = Math.Max(0.0, peso);
            this.cor = cor;
        }

        // Properties para acesso controlado aos atributos
        public string Nome 
        { 
            get { return nome; } 
            set { nome = value; } 
        }

        public string Especie 
        { 
            get { return especie; } 
        }

        public int Idade 
        { 
            get { return idade; } 
            set { idade = Math.Max(0, value); } 
        }

        public double Peso 
        { 
            get { return peso; } 
            set { peso = Math.Max(0.0, value); } 
        }

        public string Cor 
        { 
            get { return cor; } 
            set { cor = value; } 
        }

        /// <summary>
        /// Método virtual que pode ser sobrescrito pelas classes derivadas
        /// HERANÇA: Classes filhas podem sobrescrever este método
        /// </summary>
        public virtual void FazerSom()
        {
            Console.WriteLine($"{nome} está fazendo um som genérico de animal.");
        }

        /// <summary>
        /// Método virtual para movimento
        /// HERANÇA: Classes filhas podem sobrescrever este método
        /// </summary>
        /// <param name="direcao">Direção do movimento</param>
        public virtual void Mover(string direcao = "para frente")
        {
            Console.WriteLine($"{nome} está se movendo {direcao}.");
        }

        /// <summary>
        /// Método comum a todos os animais
        /// HERANÇA: Herdado por todas as classes derivadas
        /// </summary>
        /// <param name="comida">Tipo de comida</param>
        public void Comer(string comida = "ração")
        {
            Console.WriteLine($"{nome} está comendo {comida}.");
            
            if (comida.ToLower().Contains("muito") || comida.ToLower().Contains("bastante"))
            {
                peso += 0.1;
                Console.WriteLine($"{nome} ganhou um pouco de peso!");
            }
        }

        /// <summary>
        /// Método comum a todos os animais
        /// HERANÇA: Herdado por todas as classes derivadas
        /// </summary>
        /// <param name="horas">Número de horas dormindo</param>
        public void Dormir(int horas = 8)
        {
            Console.WriteLine($"{nome} está dormindo por {horas} horas.");
            
            if (horas > 12)
            {
                Console.WriteLine($"{nome} dormiu muito! Deve estar descansado.");
            }
        }

        /// <summary>
        /// Calcula a idade do animal em meses
        /// HERANÇA: Herdado por todas as classes derivadas
        /// </summary>
        /// <returns>Idade em meses</returns>
        public int IdadeEmMeses()
        {
            return idade * 12;
        }

        /// <summary>
        /// Verifica se o animal é adulto
        /// HERANÇA: Pode ser sobrescrito pelas classes derivadas
        /// </summary>
        /// <returns>True se o animal for adulto</returns>
        public virtual bool EhAdulto()
        {
            // Padrão: 2 anos para ser adulto
            return idade >= 2;
        }

        /// <summary>
        /// Exibe informações completas do animal
        /// HERANÇA: Herdado por todas as classes derivadas
        /// </summary>
        public virtual void ExibirInformacoes()
        {
            Console.WriteLine("=== Informações do Animal ===");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Espécie: {especie}");
            Console.WriteLine($"Idade: {idade} anos ({IdadeEmMeses()} meses)");
            Console.WriteLine($"Peso: {peso:F2} kg");
            Console.WriteLine($"Cor: {cor}");
            Console.WriteLine($"Status: {(EhAdulto() ? "Adulto" : "Filhote")}");
        }

        /// <summary>
        /// Sobrescreve o método ToString para exibição personalizada
        /// HERANÇA: Pode ser sobrescrito pelas classes derivadas
        /// </summary>
        /// <returns>String com informações do animal</returns>
        public override string ToString()
        {
            return $"{nome} - {especie} - {idade} anos - {peso:F2}kg - {cor}";
        }
    }
}
