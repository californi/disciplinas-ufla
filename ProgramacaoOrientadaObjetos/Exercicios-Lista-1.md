# Lista de Exercícios 1 - Programação Orientada a Objetos (GCT052)
## Tópicos: Classes, Atributos, Métodos, Objetos, Sobrecarga, Propriedades, Encapsulamento, Associação, Composição e Agregação

---

### Questão 1 (Fechada)
**Assunto:** Classes e Atributos

Em C#, o que diferencia um atributo de uma propriedade?

a) Atributos são sempre públicos, propriedades são privadas  
b) Propriedades são métodos que encapsulam acesso a atributos, enquanto atributos são variáveis de instância  
c) Não há diferença, são termos sinônimos  
d) Atributos só podem ser de tipos primitivos, propriedades podem ser de qualquer tipo  
e) Atributos são estáticos, propriedades são de instância


---

### Questão 2 (Aberta)
**Assunto:** Classes, Objetos e Métodos

Crie uma classe `Livro` em C# com os seguintes requisitos:
- Atributos privados: `titulo` (string), `autor` (string), `anoPublicacao` (int), `preco` (decimal)
- Construtor que recebe todos os atributos
- Métodos públicos: `CalcularDesconto(decimal percentual)` que retorna o preço com desconto aplicado
- Método `ExibirInformacoes()` que retorna uma string formatada com todas as informações do livro

Escreva também um exemplo de criação de um objeto `Livro` e chamada aos métodos.

---

### Questão 3 (Fechada)
**Assunto:** Objetos e Instâncias

Qual das seguintes afirmações sobre objetos em C# é **VERDADEIRA**?

a) Um objeto é uma cópia estática da classe  
b) Um objeto é uma instância de uma classe, alocada na memória heap  
c) Objetos só podem ser criados usando a palavra-chave `new`  
d) Um objeto compartilha o mesmo estado de memória com todos os outros objetos da mesma classe  
e) Objetos não podem ter métodos, apenas propriedades

---

### Questão 4 (Aberta)
**Assunto:** Sobrecarga de Métodos

Implemente uma classe `Calculadora` com sobrecarga do método `Somar()`:
- `Somar(int a, int b)` - soma dois inteiros
- `Somar(double a, double b)` - soma dois decimais
- `Somar(int a, int b, int c)` - soma três inteiros
- `Somar(params int[] numeros)` - soma um array variável de inteiros

Crie exemplos de uso para cada sobrecarga.

---

### Questão 5 (Fechada)
**Assunto:** Propriedades

Analise o código abaixo:

```csharp
public class Pessoa
{
    private int idade;
    
    public int Idade
    {
        get { return idade; }
        set { idade = value < 0 ? 0 : value; }
    }
}
```

O que acontece se tentarmos fazer `pessoa.Idade = -5;`?

a) Lança uma exceção  
b) A propriedade Idade recebe o valor -5  
c) A propriedade Idade recebe o valor 0 (zero) devido à validação no setter  
d) O código não compila  
e) A propriedade Idade não pode ser atribuída

---

### Questão 6 (Aberta)
**Assunto:** Propriedades Auto-Implementadas e Encapsulamento

Crie uma classe `ContaBancaria` com:
- Propriedade auto-implementada `Numero` (string, somente leitura - apenas get)
- Propriedade `Saldo` (decimal) com getter público e setter privado
- Propriedade `Titular` (string) com get e set públicos
- Método `Depositar(decimal valor)` que adiciona ao saldo apenas se o valor for positivo
- Método `Sacar(decimal valor)` que subtrai do saldo apenas se houver saldo suficiente

---

### Questão 7 (Fechada)
**Assunto:** Encapsulamento

O conceito de encapsulamento em POO tem como principais objetivos:

a) Esconder a implementação interna e controlar o acesso aos dados  
b) Tornar todos os atributos públicos para facilitar o acesso  
c) Eliminar a necessidade de métodos na classe  
d) Permitir que classes filhas acessem diretamente atributos privados da classe pai  
e) Converter todos os métodos em propriedades

---

### Questão 8 (Aberta)
**Assunto:** Encapsulamento e Modificadores de Acesso

Explique a diferença entre `private`, `public`, `protected` e `internal` em C#, e quando usar cada um. Dê um exemplo prático de classe que utiliza esses modificadores de acesso de forma apropriada.

---

### Questão 9 (Fechada)
**Assunto:** Associação

Qual das seguintes situações representa melhor uma **Associação** entre classes?

a) Uma `Casa` contém `Portas` - quando a casa é destruída, as portas também são  
b) Um `Professor` leciona para `Alunos` - ambos existem independentemente  
c) Um `Computador` possui um `Processador` - o processador não pode existir sem o computador  
d) Uma `Empresa` tem um `CNPJ` - o CNPJ não existe sem a empresa  
e) Um `Veiculo` tem uma `Placa` - a placa é destruída quando o veículo é

---

### Questão 10 (Aberta)
**Assunto:** Associação

Crie duas classes: `Aluno` e `Curso`. Um aluno pode estar matriculado em vários cursos e um curso pode ter vários alunos. Implemente essa relação de associação bidirecional usando listas. Crie métodos para matricular um aluno em um curso e para listar todos os alunos de um curso.

---

### Questão 11 (Fechada)
**Assunto:** Composição

Em uma relação de **Composição**, o que acontece com as partes quando o todo é destruído?

a) As partes continuam existindo independentemente  
b) As partes são destruídas junto com o todo  
c) As partes podem ou não ser destruídas, dependendo do caso  
d) Apenas algumas partes são destruídas  
e) Nada acontece, pois composição não implica dependência de vida

---

### Questão 12 (Aberta)
**Assunto:** Composição

Modele a classe `Pedido` que tem uma relação de **Composição** com `ItemPedido`. Um pedido não existe sem seus itens, e os itens não fazem sentido sem o pedido. Implemente:
- Classe `ItemPedido` com: `Produto` (string), `Quantidade` (int), `PrecoUnitario` (decimal)
- Classe `Pedido` com: `Numero` (string), `Data` (DateTime), e uma lista privada de `ItemPedido`
- Métodos em `Pedido`: `AdicionarItem()`, `RemoverItem()`, `CalcularTotal()`
- O construtor de `Pedido` deve inicializar a lista vazia

---

### Questão 13 (Fechada)
**Assunto:** Agregação

A diferença principal entre **Agregação** e **Composição** é:

a) Não há diferença, são termos sinônimos  
b) Na agregação, as partes podem existir sem o todo; na composição, não podem  
c) Agregação usa losango preenchido, composição usa losango vazio na UML  
d) Na agregação, as partes são sempre destruídas com o todo  
e) Composição é mais forte que agregação em todos os aspectos

---

### Questão 14 (Aberta)
**Assunto:** Agregação

Crie um sistema de biblioteca com as classes `Biblioteca` e `Livro`. A relação é de **Agregação** porque:
- Uma biblioteca pode ter vários livros
- Mas um livro pode existir sem estar em uma biblioteca (pode estar na prateleira de casa, por exemplo)

Implemente as classes com métodos para adicionar e remover livros da biblioteca, e um método para buscar livros por título.

---

### Questão 15 (Fechada)
**Assunto:** Notação UML

Na notação UML, como representamos visualmente Associação, Agregação e Composição?

a) Associação = linha simples, Agregação = losango preenchido, Composição = losango vazio  
b) Associação = losango vazio, Agregação = losango preenchido, Composição = linha simples  
c) Associação = linha simples, Agregação = losango vazio, Composição = losango preenchido  
d) Todas usam o mesmo símbolo  
e) Associação = seta, Agregação = losango vazio, Composição = losango preenchido

---

### Questão 16 (Aberta)
**Assunto:** Integração de Conceitos - Sistema Completo

Crie um sistema para uma **Loja de Eletrônicos** com as seguintes classes:
1. `Produto`: Classe base com `Codigo` (string), `Nome` (string), `Preco` (decimal). Use encapsulamento adequado.
2. `Cliente`: Com `CPF`, `Nome`, `Email`. Propriedades com validação.
3. `Venda`: Relação de **Composição** com `ItemVenda` (cada item tem produto e quantidade).
4. `Cliente` e `Venda`: Relação de **Associação** (cliente faz vendas, mas pode existir sem vendas).

Implemente métodos para calcular total da venda e aplicar desconto. Use sobrecarga para métodos de desconto (desconto fixo e desconto percentual).

---

### Questão 17 (Fechada)
**Assunto:** Propriedades e Encapsulamento

Analise o código:

```csharp
public class Carro
{
    private double velocidade;
    
    public double Velocidade
    {
        get { return velocidade; }
        private set { velocidade = value > 200 ? 200 : value; }
    }
    
    public void Acelerar(double incremento)
    {
        Velocidade += incremento;
    }
}
```

Qual das afirmações é **FALSA**?

a) A propriedade Velocidade tem setter privado  
b) É possível alterar a velocidade através do método `Acelerar()`  
c) A velocidade máxima permitida é 200  
d) É possível fazer `carro.Velocidade = 150;` diretamente de fora da classe  
e) O getter é público

---

### Questão 18 (Aberta)
**Assunto:** Sobrecarga de Construtores

Implemente uma classe `Pessoa` com três construtores sobrecarregados:
1. Construtor sem parâmetros (inicializa com valores padrão)
2. Construtor que recebe `nome` (string) e `idade` (int)
3. Construtor que recebe `nome` (string), `idade` (int) e `email` (string)

Use `this` para chamar um construtor a partir de outro, quando apropriado.

---

### Questão 19 (Fechada)
**Assunto:** Relações entre Classes

Em um sistema de **Universidade**, temos as classes `Universidade`, `Departamento`, `Professor` e `Aluno`. Qual relação é mais apropriada para:

- `Universidade` ↔ `Departamento`
- `Departamento` ↔ `Professor`
- `Professor` ↔ `Aluno`

a) Composição, Agregação, Associação  
b) Agregação, Composição, Associação  
c) Associação, Agregação, Composição  
d) Agregação, Agregação, Associação  
e) Composição, Composição, Agregação

---

### Questão 20 (Aberta)
**Assunto:** Sistema Completo com Todos os Conceitos

Implemente um sistema de **Cadastro de Funcionários** para uma empresa com:

**Requisitos:**
1. Classe `Funcionario` com:
   - Atributos privados: `nome`, `cpf`, `salario`, `dataAdmissao`
   - Propriedades públicas com validação (salário não pode ser negativo)
   - Métodos: `CalcularSalarioLiquido(decimal desconto)` e `CalcularSalarioLiquido(decimal desconto, decimal bonus)` (sobrecarga)
   - Método `AnosDeEmpresa()` que retorna quantos anos o funcionário está na empresa

2. Classe `Departamento` com relação de **Agregação** com `Funcionario` (funcionários podem ser transferidos entre departamentos)

3. Classe `Projeto` com relação de **Composição** com `Tarefa` (tarefas não existem sem projeto)

4. Classe `Empresa` com relação de **Associação** com `Funcionario` e `Projeto`

Crie exemplos demonstrando o uso de todas as classes e relações implementadas.

---

## Observações para o Professor

- **Questões Fechadas (1, 3, 5, 7, 9, 11, 13, 15, 17, 19):** 10 questões de múltipla escolha cobrindo todos os tópicos.
- **Questões Abertas (2, 4, 6, 8, 10, 12, 14, 16, 18, 20):** 10 questões práticas de implementação, progressivamente mais complexas.
- A lista segue uma ordem lógica de complexidade, começando com conceitos básicos e evoluindo para sistemas mais completos.
- Questão 20 integra todos os conceitos da disciplina.

---

**Data de criação:** 2025  
**Disciplina:** GCT052 - Programação Orientada a Objetos  
**Professor:** Prof. Dr. Bento Rafael Siqueira

