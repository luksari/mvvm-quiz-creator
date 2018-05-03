using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using QuizCreator.Views;
using QuizCreator.ViewModels;
using QuizCreator.Additionals;

namespace QuizCreator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IFrameNavigationService navigationService = new FrameNavigationService();
            MainWindowView app = new MainWindowView();
            MainWindowViewModel context = new MainWindowViewModel(navigationService);
            app.DataContext = context;
            app.Show();
        }
    }
}
