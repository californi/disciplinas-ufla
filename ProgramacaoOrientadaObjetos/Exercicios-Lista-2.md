# Lista de Exercícios 2 - entrega 03/12/2025 - Programação Orientada a Objetos (GCT052)
## Tópicos: Associação, Composição, Agregação, Sobrecarga de Métodos, Herança e Polimorfismo

---

### Questão 1 (Fechada)
**Assunto:** Associação

Em uma relação de **Associação** entre classes, qual das seguintes características é verdadeira?

a) As classes envolvidas têm um relacionamento de dependência de vida  
b) As classes podem existir independentemente uma da outra  
c) Uma classe sempre contém a outra  
d) A relação é sempre bidirecional  
e) Uma classe não pode ter múltiplas associações com outras classes

---

### Questão 2 (Aberta)
**Assunto:** Associação

Crie um sistema de **Rede Social** com as classes `Usuario` e `Postagem`. Um usuário pode criar várias postagens, mas uma postagem pertence a apenas um usuário. Implemente:
- Classe `Usuario` com: `Nome` (string), `Email` (string) e uma lista de `Postagem`
- Classe `Postagem` com: `Titulo` (string), `Conteudo` (string), `DataPublicacao` (DateTime) e referência ao `Usuario`
- Métodos em `Usuario`: `CriarPostagem()`, `ListarPostagens()`
- Método em `Postagem`: `ExibirPostagem()` que retorna uma string formatada

---

### Questão 3 (Fechada)
**Assunto:** Composição

Qual das seguintes situações representa melhor uma relação de **Composição**?

a) Um `Aluno` frequenta uma `Escola` - o aluno pode mudar de escola  
b) Um `Carro` possui `Rodas` - as rodas não existem sem o carro  
c) Um `Professor` ensina `Alunos` - ambos existem independentemente  
d) Uma `Empresa` contrata `Funcionarios` - funcionários podem ser demitidos  
e) Um `Cliente` faz `Pedidos` - pedidos podem existir sem cliente

---

### Questão 4 (Aberta)
**Assunto:** Composição

Modele um sistema de **Documento de Texto** usando composição:
- Classe `Documento` com: `Titulo` (string), `Autor` (string) e uma lista privada de `Paragrafo`
- Classe `Paragrafo` com: `Texto` (string), `NumeroLinha` (int)
- Um parágrafo não pode existir sem um documento
- Implemente métodos em `Documento`: `AdicionarParagrafo()`, `RemoverParagrafo()`, `ContarPalavras()`, `ExibirDocumento()`
- O construtor de `Documento` deve inicializar a lista vazia

---

### Questão 5 (Fechada)
**Assunto:** Agregação

A principal diferença entre **Agregação** e **Composição** é:

a) Na agregação, as partes são sempre destruídas com o todo  
b) Na agregação, as partes podem existir independentemente do todo; na composição, não podem  
c) Agregação é representada por losango preenchido, composição por losango vazio  
d) Não há diferença prática entre elas  
e) Agregação é mais forte que composição

---

### Questão 6 (Aberta)
**Assunto:** Agregação

Crie um sistema de **Biblioteca** com agregação:
- Classe `Biblioteca` com: `Nome` (string), `Endereco` (string) e uma lista de `Livro`
- Classe `Livro` com: `Titulo` (string), `Autor` (string), `ISBN` (string)
- Um livro pode existir sem estar em uma biblioteca (pode estar em casa, emprestado, etc.)
- Implemente métodos em `Biblioteca`: `AdicionarLivro()`, `RemoverLivro()`, `BuscarPorTitulo()`, `BuscarPorAutor()`, `ContarLivros()`

---

### Questão 7 (Fechada)
**Assunto:** Sobrecarga de Métodos

Em C#, a sobrecarga de métodos é determinada por:

a) Apenas pelo nome do método  
b) Pelo nome e pelo tipo de retorno  
c) Pelo nome, número e tipos dos parâmetros  
d) Pelo nome e pelos modificadores de acesso  
e) Pelo nome e pelo corpo do método

---

### Questão 8 (Aberta)
**Assunto:** Sobrecarga de Métodos

Implemente uma classe `Matematica` com sobrecarga do método `Calcular()`:
- `Calcular(int a, int b)` - retorna a soma de dois inteiros
- `Calcular(double a, double b)` - retorna a soma de dois decimais
- `Calcular(int a, int b, int c)` - retorna a soma de três inteiros
- `Calcular(int a, int b, string operacao)` - retorna o resultado da operação especificada ("soma", "subtracao", "multiplicacao", "divisao")
- `Calcular(params int[] numeros)` - retorna a soma de um array variável de inteiros

Crie exemplos de uso para cada sobrecarga.

---

### Questão 9 (Fechada)
**Assunto:** Herança

Qual das seguintes afirmações sobre **Herança** em C# é **FALSA**?

a) Uma classe pode herdar de apenas uma classe base  
b) Uma classe filha herda todos os membros públicos e protegidos da classe pai  
c) A palavra-chave `base` é usada para acessar membros da classe base  
d) Uma classe pode herdar de múltiplas classes simultaneamente  
e) A herança permite reutilização de código

---

### Questão 10 (Aberta)
**Assunto:** Herança

Crie uma hierarquia de classes para representar **Veículos**:
- Classe base `Veiculo` com: `Marca` (string), `Modelo` (string), `Ano` (int), `VelocidadeAtual` (double)
- Métodos virtuais: `Acelerar()`, `Frear()`, `ExibirInformacoes()`
- Classe `Carro` que herda de `Veiculo` com atributo adicional: `NumeroPortas` (int)
- Classe `Moto` que herda de `Veiculo` com atributo adicional: `Cilindrada` (int)
- Sobrescreva os métodos `Acelerar()` e `ExibirInformacoes()` em ambas as classes filhas

---

### Questão 11 (Fechada)
**Assunto:** Herança e Modificadores

Analise o código:

```csharp
public class Animal
{
    protected string nome;
    public virtual void EmitirSom() { }
}

public class Cachorro : Animal
{
    public override void EmitirSom() { }
}
```

Qual modificador de acesso permite que `Cachorro` acesse o atributo `nome` de `Animal`, mas não permite acesso de fora das classes?

a) `private`  
b) `public`  
c) `protected`  
d) `internal`  
e) `protected internal`

---

### Questão 12 (Aberta)
**Assunto:** Herança e Construtores

Crie uma hierarquia de classes para **Funcionários**:
- Classe base `Funcionario` com: `Nome` (string), `CPF` (string), `SalarioBase` (decimal)
- Construtor em `Funcionario` que recebe todos os parâmetros
- Classe `Gerente` que herda de `Funcionario` com atributo adicional: `Bonus` (decimal)
- Classe `Vendedor` que herda de `Funcionario` com atributo adicional: `Comissao` (decimal)
- Use `base()` nos construtores das classes filhas para inicializar os atributos da classe base
- Implemente método `CalcularSalario()` em cada classe (Gerente: salário base + bônus; Vendedor: salário base + comissão)

---

### Questão 13 (Fechada)
**Assunto:** Polimorfismo

O **Polimorfismo** em POO permite:

a) Criar múltiplas classes com o mesmo nome  
b) Um objeto de uma classe filha ser tratado como objeto da classe base  
c) Herdar de múltiplas classes simultaneamente  
d) Ter métodos com o mesmo nome em classes não relacionadas  
e) Modificar a estrutura de uma classe em tempo de execução

---

### Questão 14 (Aberta)
**Assunto:** Polimorfismo

Implemente um sistema de **Formas Geométricas** usando polimorfismo:
- Classe abstrata `Forma` com método abstrato `CalcularArea()` e método virtual `ExibirInfo()`
- Classe `Retangulo` que herda de `Forma` com: `Largura` (double), `Altura` (double)
- Classe `Circulo` que herda de `Forma` com: `Raio` (double)
- Classe `Triangulo` que herda de `Forma` com: `Base` (double), `Altura` (double)
- Crie uma lista de `Forma` e adicione diferentes tipos de formas
- Itere pela lista chamando `CalcularArea()` e `ExibirInfo()` para demonstrar polimorfismo

---

### Questão 15 (Fechada)
**Assunto:** Métodos Virtuais e Override

Qual é a diferença entre `virtual` e `abstract` em C#?

a) Não há diferença, são sinônimos  
b) `virtual` permite sobrescrita opcional, `abstract` obriga implementação nas classes filhas  
c) `abstract` só pode ser usado em interfaces  
d) `virtual` não pode ser sobrescrito, `abstract` pode  
e) `virtual` é usado apenas em classes abstratas

---

### Questão 16 (Aberta)
**Assunto:** Polimorfismo e Classes Abstratas

Crie um sistema de **Animais** usando classes abstratas e polimorfismo:
- Classe abstrata `Animal` com: `Nome` (string), `Idade` (int)
- Método abstrato `EmitirSom()`
- Método virtual `Mover()` que retorna uma string genérica
- Classe `Cachorro` que herda de `Animal` e implementa `EmitirSom()` retornando "Au Au"
- Classe `Gato` que herda de `Animal` e implementa `EmitirSom()` retornando "Miau"
- Classe `Passaro` que herda de `Animal`, implementa `EmitirSom()` retornando "Piu Piu" e sobrescreve `Mover()` retornando "Voando"
- Crie uma lista de `Animal` e demonstre polimorfismo chamando os métodos

---

### Questão 17 (Fechada)
**Assunto:** Relações entre Classes

Em um sistema de **Universidade**, qual relação é mais apropriada para:
- `Universidade` ↔ `Departamento`
- `Departamento` ↔ `Professor`
- `Professor` ↔ `Aluno`

a) Composição, Agregação, Associação  
b) Agregação, Composição, Associação  
c) Associação, Agregação, Composição  
d) Agregação, Agregação, Associação  
e) Composição, Composição, Agregação

---

### Questão 18 (Aberta)
**Assunto:** Herança e Sobrescrita de Métodos

Crie uma hierarquia de classes para **Contas Bancárias**:
- Classe base `ContaBancaria` com: `Numero` (string), `Titular` (string), `Saldo` (decimal)
- Métodos virtuais: `Depositar(decimal valor)`, `Sacar(decimal valor)`, `CalcularTaxa()`
- Classe `ContaCorrente` que herda de `ContaBancaria`:
  - Sobrescreve `CalcularTaxa()` retornando 0.05% do saldo
  - Sobrescreve `Sacar()` aplicando uma taxa de 0.50 por saque
- Classe `ContaPoupanca` que herda de `ContaBancaria`:
  - Sobrescreve `CalcularTaxa()` retornando 0.10% do saldo
  - Não permite saque se o saldo ficar negativo
- Implemente validações adequadas em todos os métodos

---

### Questão 19 (Fechada)
**Assunto:** Polimorfismo e Casting

Analise o código:

```csharp
Animal animal = new Cachorro();
Cachorro cachorro = (Cachorro)animal;
```

O que acontece neste código?

a) Erro de compilação, pois não é possível fazer casting  
b) Erro em tempo de execução, pois `animal` não é do tipo `Cachorro`  
c) Funciona corretamente, pois `animal` referencia um objeto `Cachorro`  
d) Funciona, mas `cachorro` será null  
e) O código não compila porque `Animal` não pode ser instanciado

---

### Questão 20 (Aberta)
**Assunto:** Sistema Completo - Integração de Todos os Conceitos

Implemente um sistema completo de **Gestão de Biblioteca** que integre todos os conceitos estudados:

**Requisitos:**

1. **Herança e Polimorfismo:**
   - Classe abstrata `ItemBiblioteca` com: `Titulo` (string), `AnoPublicacao` (int), `Disponivel` (bool)
   - Método abstrato `CalcularMulta(int diasAtraso)`
   - Método virtual `ExibirInformacoes()`
   - Classe `Livro` que herda de `ItemBiblioteca` com: `Autor` (string), `ISBN` (string)
   - Classe `Revista` que herda de `ItemBiblioteca` com: `Editora` (string), `NumeroEdicao` (int)
   - Implemente `CalcularMulta()`: Livro = R$ 2,00 por dia; Revista = R$ 1,00 por dia

2. **Associação:**
   - Classe `Usuario` com: `Nome` (string), `CPF` (string), `Email` (string)
   - Relação de associação entre `Usuario` e `ItemBiblioteca` (usuário pode emprestar itens)

3. **Agregação:**
   - Classe `Biblioteca` com relação de agregação com `ItemBiblioteca` (itens podem existir fora da biblioteca)

4. **Composição:**
   - Classe `Emprestimo` com relação de composição com `ItemBiblioteca` e `Usuario` (um empréstimo não existe sem item e usuário)
   - Atributos: `DataEmprestimo` (DateTime), `DataDevolucaoPrevista` (DateTime), `DataDevolucaoReal` (DateTime?)

5. **Sobrecarga:**
   - Método `Emprestar()` na classe `Biblioteca` com sobrecarga:
     - `Emprestar(Usuario usuario, ItemBiblioteca item)` - empréstimo padrão de 7 dias
     - `Emprestar(Usuario usuario, ItemBiblioteca item, int dias)` - empréstimo com prazo customizado

6. **Métodos adicionais:**
   - `Devolver()` em `Biblioteca`
   - `ListarItensDisponiveis()` em `Biblioteca`
   - `ListarEmprestimos()` em `Usuario`

Crie exemplos demonstrando o uso de todas as classes, relações e conceitos implementados.

---

## Observações para o Professor

- **Questões Fechadas (1, 3, 5, 7, 9, 11, 13, 15, 17, 19):** 10 questões de múltipla escolha cobrindo todos os tópicos.
- **Questões Abertas (2, 4, 6, 8, 10, 12, 14, 16, 18, 20):** 10 questões práticas de implementação, progressivamente mais complexas.
- A lista segue uma ordem lógica de complexidade, começando com conceitos básicos (associação, composição, agregação) e evoluindo para conceitos mais avançados (herança e polimorfismo).
- Questão 20 integra todos os conceitos da lista em um sistema completo.

---

**Data de criação:** 2025  
**Disciplina:** GCT052 - Programação Orientada a Objetos  
**Professor:** Prof. Dr. Bento Rafael Siqueira

