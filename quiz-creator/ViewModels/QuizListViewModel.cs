using QuizCreator.Additionals;
using QuizCreator.Interfaces;
using QuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizCreator.ViewModels
{
    public class QuizListViewModel : ObservableObject, IPageViewModel
    {
        #region Fields
        private ObservableCollection<QuizViewModel> quizList;
        private QuizViewModel currentQuiz;
        private string name;
        private ICommand addCmd;
        #endregion
        #region Properties
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public ObservableCollection<QuizViewModel> QuizList
        {
            get
            {
                return quizList;
            }

            set
            {
                quizList = value;
                OnPropertyChanged("QuizList");
            }
        }

        public QuizViewModel CurrentQuiz
        {
            get
            {
                return currentQuiz;
            }

            set
            {
                currentQuiz = value;
                OnPropertyChanged("CurrentQuiz");
            }
        }

        public ICommand AddCmd
        {
            get
            {
                if(addCmd == null)
                {
                    addCmd = new RelayCommand(
                        param => AddQuiz(new QuizViewModel { QuizId = 5, Name = this.Name, QuestionsList = null}),
                        param => true);
                }
                return addCmd;
            }

            set
            {
                addCmd = value;
            }
        }
        #endregion
        #region Constructors
        public QuizListViewModel()
        {
            
            QuizList = new ObservableCollection<QuizViewModel>();

        }
        #endregion
        #region Methods
        private void AddQuiz(object param)
        {
            QuizViewModel qvm = new QuizViewModel();
            qvm.Name = this.Name;
            qvm.QuizId = QuizList.IndexOf(CurrentQuiz) + 1;
            qvm.QuestionsList = null;
            CurrentQuiz = qvm;
            QuizList.Add(CurrentQuiz);
        }
        #endregion
    }
}
