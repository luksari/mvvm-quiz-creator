using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using QuizCreator.Additionals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizCreator.ViewModels
{
    public class QuizStartViewModel : ViewModelBase
    {
        #region Fields
        private string name;
        IFrameNavigationService navigationService;
        #endregion
        #region Properties

        public RelayCommand NavigateToQuizListViewCmd{ get; private set; }
        public string Name
        {
            get
            {
                return name;
            }
            
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }
        #endregion
        public QuizStartViewModel(IFrameNavigationService navigationService)
        {
            this.navigationService = navigationService;

            NavigateToQuizListViewCmd = new RelayCommand(NavigateToQuizList);
        }
        #region Methods
        private void NavigateToQuizList()
        {
            navigationService.NavigateTo("QuizList");
        }
        #endregion
    }
}
