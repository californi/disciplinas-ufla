using System.Windows;

namespace AnimalMatchingGame
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            // Configurações globais da aplicação
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
        }
        
        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            // Tratamento de exceções não capturadas
            MessageBox.Show($"Ocorreu um erro inesperado:\n{e.Exception.Message}", 
                          "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }
    }
}
