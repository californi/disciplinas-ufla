using System;
using System.Collections.Generic;

namespace ExemplosRelacoes.Associacao
{
    /// <summary>
    /// Exemplo de ASSOCIAÇÃO entre Professor e Aluno
    /// - São classes independentes
    /// - Professor pode ter ou não alunos
    /// - Aluno pode existir sem professor
    /// </summary>
    
    public class Professor
    {
        public string Nome { get; set; }
        public string Disciplina { get; set; }
        
        // Lista de alunos - Associação (não é propriedade)
        public List<Aluno> Alunos { get; set; }
        
        public Professor(string nome, string disciplina)
        {
            Nome = nome;
            Disciplina = disciplina;
            Alunos = new List<Aluno>();
        }
        
        public void AdicionarAluno(Aluno aluno)
        {
            if (aluno != null)
            {
                Alunos.Add(aluno);
                Console.WriteLine($"{aluno.Nome} foi adicionado às turmas de {Nome}");
            }
        }
        
        public void RemoverAluno(Aluno aluno)
        {
            Alunos.Remove(aluno);
        }
        
        public void MostrarAlunos()
        {
            Console.WriteLine($"\nProfessor: {Nome}");
            Console.WriteLine($"Disciplina: {Disciplina}");
            Console.WriteLine($"Alunos: {Alunos.Count}");
            
            foreach (var aluno in Alunos)
            {
                Console.WriteLine($"  - {aluno.Nome} ({aluno.Matricula})");
            }
        }
    }
    
    public class Aluno
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        
        public Aluno(string nome, string matricula)
        {
            Nome = nome;
            Matricula = matricula;
        }
        
        public void MostrarInfo()
        {
            Console.WriteLine($"Aluno: {Nome} - Matrícula: {Matricula}");
        }
    }
    
    // Programa de exemplo
    public class ExemploAssociacao
    {
        public static void Executar()
        {
            Console.WriteLine("=== EXEMPLO DE ASSOCIAÇÃO ===\n");
            
            // Criar aluno (existe independentemente)
            Aluno aluno1 = new Aluno("João Silva", "2024001");
            Aluno aluno2 = new Aluno("Maria Santos", "2024002");
            Aluno aluno3 = new Aluno("Pedro Oliveira", "2024003");
            
            // Criar professor
            Professor professor = new Professor("Dr. Bento", "Programação Orientada a Objetos");
            
            // Professor associa alunos (relação de uso, não de propriedade)
            professor.AdicionarAluno(aluno1);
            professor.AdicionarAluno(aluno2);
            professor.AdicionarAluno(aluno3);
            
            // Mostrar relação
            professor.MostrarAlunos();
            
            // Alunos podem existir sem professor
            Console.WriteLine("\nApós professor ser removido, alunos continuam existindo:");
            aluno1.MostrarInfo();
            aluno2.MostrarInfo();
            aluno3.MostrarInfo();
        }
    }
}

