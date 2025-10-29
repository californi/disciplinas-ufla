Data 29/10/2025 - 23:59;

1) Criar uma aplicação Console a partir do contexto de "Um jogo de Futebol";

Classes iniciais:

a) Goleiro
b) Atacante
c) Técnico
d) Juiz
e) Bola
f) etc...

2) Definir atributos, propriedades e métodos para cada classe e implementar as três relações (associação, agregação e composição);

* Métodos internos devem ter retornos de strings e a aplicação console deve simular um jogo de futebol.

  Trecho exemplo no Program.cs:

  Bola objBola = new Bola();
  Trava objTrava = new Trava();
  
  Atacante objAtacante = new Atacante();
  objAtacante.chutar(objBola);

  Goleiro objGoleiro = new Goleiro();
  objGoleiro.defender(objTrava);
  


  
