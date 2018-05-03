using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using QuizCreator.Additionals;
using QuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.ViewModels
{
    public class QuizViewModel : ViewModelBase
    {
        #region Fields
        private string name;
        private Guid quizId;
        private ObservableCollection<QuestionModel> questionsList;
        private IFrameNavigationService navigationService;
        #endregion
        #region Constructors
        public QuizViewModel(IFrameNavigationService navigationService)
        {
            this.navigationService = navigationService;
            NavigateToQuizListViewCmd = new RelayCommand(NavigateToQuizListView);

        }
        #endregion
        #region Methods
        private void NavigateToQuizListView()
        {
            navigationService.NavigateTo("QuizList");
        }
        #endregion
        #region Props / Commands
        public RelayCommand NavigateToQuizListViewCmd
        {
            get;
            private set;
        }
        public string PageName
        {
            get
            {
                return "Quiz";
            }
        }

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

        public Guid QuizId
        {
            get
            {
                return quizId;
            }

            set
            {
                quizId = value;
                RaisePropertyChanged("QuizId");
            }
        }

        public ObservableCollection<QuestionModel> QuestionsList
        {
            get
            {
                return questionsList;
            }

            set
            {
                questionsList = value;
                RaisePropertyChanged("QuestionsList");
            }
        }
        #endregion
    }
}
