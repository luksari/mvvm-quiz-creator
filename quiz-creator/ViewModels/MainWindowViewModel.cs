using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using QuizCreator.Additionals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizCreator.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields
        IFrameNavigationService navigationService;

        #endregion
        #region Constructor
        public MainWindowViewModel(IFrameNavigationService navigationService)
        {
            this.navigationService = navigationService;

            //NavigateToPreviousViewCmd = new RelayCommand(NavigateToPreviousView);

            //Messenger.Default.Register<NavigationMessage>(this, this.HandleNavigationMessage);

        }
        #endregion
        #region Properties / Commands
        //public RelayCommand NavigateToPreviousViewCmd { get; private set; }
        #endregion
        #region Methods
        //private void NavigateToPreviousView()
        //{
        //    Console.WriteLine(navigationService.CurrentPageKey);
        //    navigationService.GoBack();
        //}



        #endregion
    }
}
