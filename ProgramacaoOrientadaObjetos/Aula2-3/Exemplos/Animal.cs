using System;

namespace Exemplos
{
    /// <summary>
    /// Classe que representa um animal
    /// </summary>
    public class Animal
    {
        // Atributos privados
        private string nome;
        private string especie;
        private int idade;
        private double peso;
        private string cor;

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
            this.idade = Math.Max(0, idade); // Idade não pode ser negativa
            this.peso = Math.Max(0.0, peso); // Peso não pode ser negativo
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
        /// Calcula a idade do animal em meses
        /// </summary>
        /// <returns>Idade em meses</returns>
        public int IdadeEmMeses()
        {
            return idade * 12;
        }

        /// <summary>
        /// Simula o animal comendo
        /// </summary>
        /// <param name="comida">Tipo de comida</param>
        public void Comer(string comida = "ração")
        {
            Console.WriteLine($"{nome} está comendo {comida}.");
            
            // Aumenta o peso baseado na comida
            if (comida.ToLower().Contains("muito") || comida.ToLower().Contains("bastante"))
            {
                peso += 0.1;
                Console.WriteLine($"{nome} ganhou um pouco de peso!");
            }
        }

        /// <summary>
        /// Simula o animal dormindo
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
        /// Simula o animal se movendo
        /// </summary>
        /// <param name="direcao">Direção do movimento</param>
        public void Mover(string direcao = "para frente")
        {
            Console.WriteLine($"{nome} está se movendo {direcao}.");
            
            // Diferentes comportamentos baseados na espécie
            switch (especie.ToLower())
            {
                case "cachorro":
                    Console.WriteLine($"{nome} está correndo alegremente!");
                    break;
                case "gato":
                    Console.WriteLine($"{nome} está se movendo silenciosamente.");
                    break;
                case "pássaro":
                    Console.WriteLine($"{nome} está voando!");
                    break;
                case "peixe":
                    Console.WriteLine($"{nome} está nadando na água.");
                    break;
                default:
                    Console.WriteLine($"{nome} está se movendo normalmente.");
                    break;
            }
        }

        /// <summary>
        /// Simula o animal fazendo som
        /// </summary>
        public void FazerSom()
        {
            Console.WriteLine($"{nome} está fazendo som:");
            
            // Sons diferentes baseados na espécie
            switch (especie.ToLower())
            {
                case "cachorro":
                    Console.WriteLine("Au au! Au au!");
                    break;
                case "gato":
                    Console.WriteLine("Miau! Miau!");
                    break;
                case "pássaro":
                    Console.WriteLine("Piu piu! Piu piu!");
                    break;
                case "vaca":
                    Console.WriteLine("Muuu! Muuu!");
                    break;
                case "galo":
                    Console.WriteLine("Cocoricó! Cocoricó!");
                    break;
                default:
                    Console.WriteLine("Som genérico de animal.");
                    break;
            }
        }

        /// <summary>
        /// Verifica se o animal é adulto
        /// </summary>
        /// <returns>True se o animal for adulto</returns>
        public bool EhAdulto()
        {
            // Diferentes idades para diferentes espécies
            switch (especie.ToLower())
            {
                case "cachorro":
                    return idade >= 2;
                case "gato":
                    return idade >= 1;
                case "pássaro":
                    return idade >= 1;
                case "vaca":
                    return idade >= 3;
                default:
                    return idade >= 2;
            }
        }

        /// <summary>
        /// Calcula o IMC do animal (peso / altura²)
        /// </summary>
        /// <param name="altura">Altura em metros</param>
        /// <returns>IMC do animal</returns>
        public double CalcularIMC(double altura)
        {
            if (altura <= 0)
            {
                Console.WriteLine("Erro: Altura deve ser positiva!");
                return 0;
            }
            
            double imc = peso / (altura * altura);
            Console.WriteLine($"IMC de {nome}: {imc:F2}");
            return imc;
        }

        /// <summary>
        /// Exibe informações completas do animal
        /// </summary>
        public void ExibirInformacoes()
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
        /// </summary>
        /// <returns>String com informações do animal</returns>
        public override string ToString()
        {
            return $"{nome} - {especie} - {idade} anos - {peso:F2}kg - {cor}";
        }
    }
}
