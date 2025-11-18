using System;

namespace Exemplos
{
    /// <summary>
    /// Classe principal que demonstra os diferentes tipos de relacionamentos
    /// entre objetos: Associação, Agregação e Composição
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== DEMONSTRAÇÃO DE RELACIONAMENTOS ENTRE OBJETOS ===\n");
            
            // Demonstração de ASSOCIAÇÃO
            DemonstrarAssociacao();
            
            Console.WriteLine("\n" + new string('=', 60) + "\n");
            
            // Demonstração de AGREGAÇÃO
            DemonstrarAgregacao();
            
            Console.WriteLine("\n" + new string('=', 60) + "\n");
            
            // Demonstração de COMPOSIÇÃO
            DemonstrarComposicao();
            
            Console.WriteLine("\n" + new string('=', 60) + "\n");
            
            // Demonstração combinada
            DemonstrarRelacionamentosCombinados();
            
            Console.WriteLine("\n=== FIM DA DEMONSTRAÇÃO ===");
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        /// <summary>
        /// Demonstra ASSOCIAÇÃO entre Bibliotecario e Livro
        /// Relacionamento mais fraco - objetos independentes
        /// </summary>
        static void DemonstrarAssociacao()
        {
            Console.WriteLine("1. DEMONSTRAÇÃO DE ASSOCIAÇÃO");
            Console.WriteLine("   Relacionamento entre Bibliotecario e Livro\n");
            
            // Criação de objetos independentes
            Bibliotecario bibliotecario = new Bibliotecario("Maria Silva", "BIB001", "Catalogação");
            Livro livro1 = new Livro("C# Completo", "João Santos", "978-1234567890", "Programação", 2023);
            Livro livro2 = new Livro("POO Fundamentos", "Ana Costa", "978-0987654321", "Programação", 2022);
            
            Console.WriteLine("Objetos criados independentemente:");
            bibliotecario.ExibirInformacoes();
            Console.WriteLine();
            livro1.ExibirInformacoes();
            Console.WriteLine();
            
            // ASSOCIAÇÃO: Bibliotecario processa livros (relacionamento temporário)
            Console.WriteLine("ASSOCIAÇÃO: Bibliotecario processando livros:");
            bibliotecario.ProcessarLivro(livro1);
            Console.WriteLine();
            
            bibliotecario.CatalogarLivro(livro2);
            Console.WriteLine();
            
            // Verificação de disponibilidade
            bool disponivel = bibliotecario.VerificarDisponibilidade(livro1);
            Console.WriteLine();
            
            // Demonstração de independência
            Console.WriteLine("Demonstração de independência:");
            Console.WriteLine("- Bibliotecario pode existir sem livros");
            Console.WriteLine("- Livros podem existir sem bibliotecario");
            Console.WriteLine("- Relacionamento é temporário e baseado em métodos");
        }

        /// <summary>
        /// Demonstra AGREGAÇÃO entre Universidade e Professor
        /// Relacionamento "tem um" - professores podem existir independentemente
        /// </summary>
        static void DemonstrarAgregacao()
        {
            Console.WriteLine("2. DEMONSTRAÇÃO DE AGREGAÇÃO");
            Console.WriteLine("   Relacionamento entre Universidade e Professor\n");
            
            // Criação da universidade
            Universidade universidade = new Universidade("UFLA", "Campus Universitário", "Lavras", 1908);
            
            // Criação de professores independentes
            Professor prof1 = new Professor("Dr. João Silva", "Programação", "Doutorado", 8000.00, 15);
            Professor prof2 = new Professor("Dra. Maria Santos", "Banco de Dados", "Doutorado", 8500.00, 12);
            Professor prof3 = new Professor("Dr. Pedro Costa", "Algoritmos", "Mestrado", 7000.00, 8);
            
            Console.WriteLine("Universidade criada:");
            universidade.ExibirInformacoes();
            Console.WriteLine();
            
            Console.WriteLine("Professores criados independentemente:");
            prof1.ExibirInformacoes();
            Console.WriteLine();
            
            // AGREGAÇÃO: Universidade adiciona professores
            Console.WriteLine("AGREGAÇÃO: Universidade adicionando professores:");
            universidade.AdicionarProfessor(prof1);
            universidade.AdicionarProfessor(prof2);
            universidade.AdicionarProfessor(prof3);
            Console.WriteLine();
            
            // Listagem de professores
            universidade.ListarProfessores();
            Console.WriteLine();
            
            // Operações com professores agregados
            Console.WriteLine("Operações com professores agregados:");
            Professor profEncontrado = universidade.BuscarProfessor("João Silva");
            if (profEncontrado != null)
            {
                profEncontrado.MinistrarAula("Relacionamentos entre Objetos");
                Console.WriteLine();
            }
            
            // Cálculo de estatísticas
            universidade.CalcularMediaSalarial();
            Console.WriteLine($"Professores de Programação: {universidade.ContarProfessoresPorDisciplina("Programação")}");
            Console.WriteLine();
            
            // Demonstração de independência
            Console.WriteLine("Demonstração de independência:");
            Console.WriteLine("- Professores podem existir sem universidade");
            Console.WriteLine("- Professores podem trabalhar em outras universidades");
            Console.WriteLine("- Relacionamento é de propriedade fraca");
            
            // Remoção de professor (continua existindo)
            universidade.RemoverProfessor(prof2);
            Console.WriteLine();
            Console.WriteLine("Professor removido, mas ainda existe:");
            prof2.ExibirInformacoes();
        }

        /// <summary>
        /// Demonstra COMPOSIÇÃO entre Casa e Quarto
        /// Relacionamento "possui" - quartos não podem existir sem casa
        /// </summary>
        static void DemonstrarComposicao()
        {
            Console.WriteLine("3. DEMONSTRAÇÃO DE COMPOSIÇÃO");
            Console.WriteLine("   Relacionamento entre Casa e Quarto\n");
            
            // Criação da casa
            Casa casa = new Casa("Rua das Flores, 123", "Lavras", 2020, 150.0);
            
            Console.WriteLine("Casa criada:");
            casa.ExibirInformacoes();
            Console.WriteLine();
            
            // COMPOSIÇÃO: Casa cria seus próprios quartos
            Console.WriteLine("COMPOSIÇÃO: Casa criando seus quartos:");
            casa.AdicionarQuarto("Quarto Principal", 20.0, "Dormitório");
            casa.AdicionarQuarto("Quarto de Hóspedes", 15.0, "Dormitório");
            casa.AdicionarQuarto("Banheiro Principal", 8.0, "Banheiro");
            casa.AdicionarQuarto("Cozinha", 12.0, "Cozinha");
            casa.AdicionarQuarto("Sala de Estar", 25.0, "Sala");
            Console.WriteLine();
            
            // Listagem de quartos
            casa.ListarQuartos();
            Console.WriteLine();
            
            // Operações com quartos compostos
            Console.WriteLine("Operações com quartos compostos:");
            Quarto quartoPrincipal = casa.BuscarQuarto("Quarto Principal");
            if (quartoPrincipal != null)
            {
                quartoPrincipal.AdicionarJanela();
                quartoPrincipal.AdicionarArmario();
                quartoPrincipal.UsarQuarto("dormir");
                Console.WriteLine();
                quartoPrincipal.ExibirInformacoes();
                Console.WriteLine();
            }
            
            // Cálculos de área
            casa.CalcularAreaQuartos();
            casa.CalcularAreaRestante();
            Console.WriteLine($"Quartos de dormitório: {casa.ContarQuartosPorTipo("Dormitório")}");
            Console.WriteLine();
            
            // Demonstração de dependência
            Console.WriteLine("Demonstração de dependência:");
            Console.WriteLine("- Quartos não podem existir sem casa");
            Console.WriteLine("- Quartos são criados pela casa");
            Console.WriteLine("- Relacionamento é de propriedade forte");
            
            // Tentativa de remoção (quarto deixa de existir)
            casa.RemoverQuarto("Quarto de Hóspedes");
            Console.WriteLine();
            Console.WriteLine("Quarto removido - não existe mais independentemente");
        }

        /// <summary>
        /// Demonstra relacionamentos combinados em um sistema mais complexo
        /// </summary>
        static void DemonstrarRelacionamentosCombinados()
        {
            Console.WriteLine("4. DEMONSTRAÇÃO COMBINADA");
            Console.WriteLine("   Sistema com múltiplos relacionamentos\n");
            
            // Criação de objetos para demonstração combinada
            Universidade ufla = new Universidade("UFLA", "Campus Universitário", "Lavras", 1908);
            Professor profPOO = new Professor("Dr. Bento Siqueira", "POO", "Doutorado", 9000.00, 20);
            
            Bibliotecario bibliotecario = new Bibliotecario("Ana Costa", "BIB002", "Sistemas");
            Livro livroPOO = new Livro("POO Avançado", "Bento Siqueira", "978-1111111111", "Programação", 2024);
            
            Casa casaProfessor = new Casa("Rua Acadêmica, 456", "Lavras", 2018, 200.0);
            
            Console.WriteLine("Sistema combinado criado:");
            Console.WriteLine();
            
            // AGREGAÇÃO: Universidade tem professor
            ufla.AdicionarProfessor(profPOO);
            Console.WriteLine("Professor agregado à universidade");
            
            // ASSOCIAÇÃO: Bibliotecario processa livro do professor
            bibliotecario.ProcessarLivro(livroPOO);
            Console.WriteLine("Bibliotecario processou livro do professor");
            
            // COMPOSIÇÃO: Casa do professor tem quartos
            casaProfessor.AdicionarQuarto("Escritório", 18.0, "Escritório");
            casaProfessor.AdicionarQuarto("Quarto", 16.0, "Dormitório");
            casaProfessor.AdicionarQuarto("Biblioteca", 20.0, "Sala");
            Console.WriteLine("Casa do professor criada com quartos");
            
            Console.WriteLine();
            Console.WriteLine("Resumo dos relacionamentos:");
            Console.WriteLine("- AGREGAÇÃO: Universidade tem Professor");
            Console.WriteLine("- ASSOCIAÇÃO: Bibliotecario processa Livro");
            Console.WriteLine("- COMPOSIÇÃO: Casa possui Quartos");
            
            Console.WriteLine();
            Console.WriteLine("Demonstração de flexibilidade:");
            Console.WriteLine("- Professor pode sair da universidade (agregação)");
            Console.WriteLine("- Bibliotecario pode processar outros livros (associação)");
            Console.WriteLine("- Quartos não podem existir sem casa (composição)");
        }
    }
}
