
## Atividade Individual (30% do peso de atividades) para apresentar no dia 30/09: somente será contabilizada se apresentada e Submetida via GitHub


## Gerenciamento de Inscrições para Corrida Beneficente

### Contexto

Uma ONG de proteção animal está organizando uma corrida de rua para arrecadar fundos. Para gerenciar as inscrições dos participantes de forma eficiente, é necessário desenvolver um software. Este software deve demonstrar os conceitos de Programação Orientada a Objetos (POO), como Abstração, Classes e Objetos, e Encapsulamento, além de utilizar uma Interface Gráfica (GUI) desenvolvida com WPF (Windows Presentation Foundation) em C#.

### Objetivos da Atividade

Ao final desta atividade:

1.  **Aplicar Abstração:** Identificar e modelar entidades do mundo real como classes, abstraindo seus comportamentos e características essenciais.
2.  **Utilizar Classes e Objetos:** Criar classes com atributos e métodos, e instanciar objetos a partir dessas classes.
3.  **Implementar Encapsulamento:** Proteger o estado interno dos objetos, controlando o acesso aos seus atributos através de propriedades.
4.  **Desenvolver Interface Gráfica com WPF:** Criar uma interface de usuário intuitiva e funcional para interagir com o sistema de gerenciamento de inscrições.
5.  **Integrar Lógica de Negócios e GUI:** Conectar a camada de apresentação (WPF) com a camada de lógica de negócios (classes C#).

### Requisitos Funcionais

O software deve permitir:

*   Cadastrar novos participantes com informações como Nome, CPF, Email e Telefone.
*   Visualizar a lista de todos os participantes inscritos.
*   Remover um participante da lista de inscritos.
*   Exibir o total de participantes e o valor total arrecadado (considerando uma taxa de inscrição fixa).

### Requisitos Técnicos

*   Linguagem de Programação: C#
*   Framework: .NET (preferencialmente .NET Core ou .NET 5+)
*   Interface Gráfica: WPF
*   Conceitos de POO: Abstração, Classes e Objetos, Encapsulamento.

### Estrutura Sugerida (Classes e Conceitos de POO)

#### 1. Abstração

Vamos abstrair as entidades principais do nosso sistema:

*   **Pessoa:** Uma abstração para qualquer entidade que represente um indivíduo, como um participante. Pode ser uma classe abstrata ou uma interface.
*   **Participante:** Representa uma pessoa que se inscreveu na corrida.
*   **Corrida:** Representa o evento da corrida em si, com suas características e regras.
*   **GerenciadorInscricoes:** Responsável por toda a lógica de negócios, como adicionar, remover e listar participantes.

#### 2. Classes e Objetos

**Classe `Pessoa` **

Esta classe servirá como base para `Participante`.

*   **Atributos (privados com propriedades públicas para acesso):**
    *   `Nome` (string)
    *   `CPF` (string)
    *   `Email` (string)
    *   `Telefone` (string)

**Classe `Participante`**

Herda de `Pessoa` (ou implementa `IPessoa`).

*   **Atributos:**
    *   `NumeroInscricao` (int - gerado automaticamente)
    *   `ValorInscricao` (decimal - constante ou definido na criação)
*   **Métodos:**
    *   Construtor para inicializar os dados do participante.
    *   Exibir informações do participante de forma amigável.

**Classe `Corrida`**

Representa a corrida de rua.

*   **Atributos:**
    *   `NomeCorrida` (string)
    *   `DataCorrida` (DateTime)
    *   `ValorPadraoInscricao` (decimal - valor fixo da inscrição)
    *   `ListaParticipantes` (List<Participante> - lista de participantes inscritos)
*   **Métodos:**
    *   Construtor.
    *   `AdicionarParticipante(Participante participante)`
    *   `RemoverParticipante(int numeroInscricao)`
    *   `ObterTotalParticipantes()` (retorna a contagem)
    *   `CalcularTotalArrecadado()` (soma os `ValorInscricao` de todos os participantes)

**Classe `GerenciadorInscricoes`**

Esta classe pode ser uma fachada para a `Corrida` ou conter a instância da `Corrida` e expor métodos para a GUI.

*   **Atributos:**
    *   `CorridaAtual` (instância da classe `Corrida`)
*   **Métodos:**
    *   `CadastrarParticipante(string nome, string cpf, string email, string telefone)`
    *   `ListarParticipantes()`
    *   `RemoverParticipante(int numeroInscricao)`
    *   `ObterEstatisticas()` (total de participantes, total arrecadado).

#### 3. Encapsulamento

Todos os atributos das classes (`Nome`, `CPF`, `Email`, `Telefone`, `NumeroInscricao`, etc.) devem ser declarados como `private` e acessados/modificados através de `public properties` (propriedades get/set). Isso garante que o acesso aos dados seja controlado e que a integridade dos objetos seja mantida.

### Interface Gráfica (WPF)

A interface deve ser simples e funcional, contendo:

*   **Campos de Entrada:** `TextBox` para Nome, CPF, Email, Telefone do participante.
*   **Botões:** `Button` para 


Cadastrar Participante`, `Remover Participante`.
*   **Exibição de Dados:** `ListView` ou `DataGrid` para listar os participantes inscritos.
*   **Informações de Status:** `TextBlock` ou `Label` para exibir o total de participantes e o valor total arrecadado.

### Guia de Implementação (Passo a Passo)

1.  **Criar um Novo Projeto WPF:** No Visual Studio, crie um novo projeto do tipo "WPF Application" (C#).
2.  **Definir as Classes de Modelo:** Crie as classes `Pessoa` (ou `IPessoa`), `Participante`, `Corrida` e `GerenciadorInscricoes` em arquivos `.cs` separados.
3.  **Implementar a Lógica de Negócios:** Preencha os métodos das classes com a lógica necessária para gerenciar as inscrições.
4.  **Desenhar a Interface (XAML):** No arquivo `MainWindow.xaml`, adicione os controles visuais (TextBox, Button, ListView, TextBlock) conforme o layout desejado.
5.  **Conectar a Interface com a Lógica (Code-behind):** No arquivo `MainWindow.xaml.cs` (code-behind), implemente os manipuladores de eventos para os botões e atualize a interface com os dados do `GerenciadorInscricoes`.
    *   Ao clicar em `Cadastrar Participante`, crie um objeto `Participante` e adicione-o ao `GerenciadorInscricoes`.
    *   Ao clicar em `Remover Participante`, obtenha o `NumeroInscricao` do participante selecionado na lista e remova-o.
    *   Atualize o `ListView`/`DataGrid` e os `TextBlock` de estatísticas sempre que houver uma alteração na lista de participantes.


### Considerações Finais

Esta atividade oferece uma base sólida para entender e aplicar os princípios de POO em um contexto prático com interface gráfica. Os alunos são encorajados a expandir a funcionalidade, adicionando validações de entrada, persistência de dados (salvar/carregar em arquivo), ou até mesmo funcionalidades de busca e edição de participantes.

