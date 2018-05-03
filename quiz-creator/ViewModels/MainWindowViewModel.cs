using GalaSoft.MvvmLight;
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

        public MainWindowViewModel(IFrameNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
        #region Properties / Commands

        #endregion

        #region Methods



        #endregion
    }
}
