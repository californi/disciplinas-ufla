using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AnimalMatchingGame
{
    public partial class MainWindow : Window
    {
        // Dados do jogo
        private string[] animais = { "🏃", "🐱", "🐭", "🐹", "🐰", "🦊", "🐻", "🐼" };
        private List<string> cartas = new List<string>();
        
        // Controles do jogo
        private TextBlock primeiraCarta = null;
        private TextBlock segundaCarta = null;
        private int paresEncontrados = 0;
        
        // Array de TextBlocks
        private TextBlock[,] grade = new TextBlock[4, 4];

        public MainWindow()
        {
            InitializeComponent();
            ConfigurarGrade();
            IniciarJogo();
        }

        private void ConfigurarGrade()
        {
            // Mapear TextBlocks para o array
            grade[0, 0] = TextBlock00; 
            grade[0, 1] = TextBlock01; 
            grade[0, 2] = TextBlock02; 
            grade[0, 3] = TextBlock03;
            grade[1, 0] = TextBlock10; 
            grade[1, 1] = TextBlock11; 
            grade[1, 2] = TextBlock12; 
            grade[1, 3] = TextBlock13;
            grade[2, 0] = TextBlock20; 
            grade[2, 1] = TextBlock21; 
            grade[2, 2] = TextBlock22; 
            grade[2, 3] = TextBlock23;
            grade[3, 0] = TextBlock30; 
            grade[3, 1] = TextBlock31; 
            grade[3, 2] = TextBlock32; 
            grade[3, 3] = TextBlock33;
        }

        private void IniciarJogo()
        {
            // Limpar estado
            paresEncontrados = 0;
            primeiraCarta = null;
            segundaCarta = null;
            
            // Criar cartas (cada animal aparece 2 vezes)
            cartas.Clear();
            foreach (string animal in animais)
            {
                cartas.Add(animal);
                cartas.Add(animal);
            }
            
            // Embaralhar
            Random r = new Random();
            cartas = cartas.OrderBy(x => r.Next()).ToList();
            
            // Distribuir nas células
            int index = 0;
            for (int linha = 0; linha < 4; linha++)
            {
                for (int coluna = 0; coluna < 4; coluna++)
                {
                    grade[linha, coluna].Text = "?";
                    grade[linha, coluna].Tag = cartas[index];
                    grade[linha, coluna].Background = Brushes.LightBlue;
                    index++;
                }
            }
            
            AtualizarStatus();
        }

        private void TextBlock_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TextBlock cartaClicada = sender as TextBlock;
            
            // Se já foi revelada, ignorar
            if (cartaClicada.Text != "?") return;
            
            // Revelar a carta
            cartaClicada.Text = cartaClicada.Tag.ToString();
            cartaClicada.Background = Brushes.LightYellow;
            
            // Primeira carta
            if (primeiraCarta == null)
            {
                primeiraCarta = cartaClicada;
            }
            // Segunda carta
            else
            {
                segundaCarta = cartaClicada;
                
                // Verificar se são iguais
                if (primeiraCarta.Tag.ToString() == segundaCarta.Tag.ToString())
                {
                    // Par encontrado!
                    primeiraCarta.Background = Brushes.LightGreen;
                    segundaCarta.Background = Brushes.LightGreen;
                    paresEncontrados++;
                    
                    primeiraCarta = null;
                    segundaCarta = null;
                    
                    // Verificar vitória
                    if (paresEncontrados == 8)
                    {
                        MessageBox.Show("Parabéns! Você venceu!", "Vitória!");
                    }
                }
                else
                {
                    // Par errado - esconder após 1 segundo
                    System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(1);
                    timer.Tick += (s, args) =>
                    {
                        primeiraCarta.Text = "?";
                        segundaCarta.Text = "?";
                        primeiraCarta.Background = Brushes.LightBlue;
                        segundaCarta.Background = Brushes.LightBlue;
                        primeiraCarta = null;
                        segundaCarta = null;
                        timer.Stop();
                    };
                    timer.Start();
                }
                
                AtualizarStatus();
            }
        }

        private void AtualizarStatus()
        {
            StatusText.Text = $"Pares encontrados: {paresEncontrados}/8";
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            IniciarJogo();
        }
    }
}
