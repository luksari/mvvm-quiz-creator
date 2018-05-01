using QuizCreator.Additionals;
using QuizCreator.Interfaces;
using QuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizCreator.ViewModels
{
    public class QuizAnswersViewModel: ObservableObject, IPageViewModel
    {
        #region Fields
        private string name;
        private int answerId;
        private AnswerModel currentAnswer;
        private ICommand getAnswerCmd;
        private ICommand saveAnswerCmd;
        #endregion
        #region Properties

        public string PageName
        {
            get
            {
                return "Answers";
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
                OnPropertyChanged("Name");
            }
        }

        public int AnswerId
        {
            get
            {
                return answerId;
            }

            set
            {
                answerId = value;
                OnPropertyChanged("AnswerId");
            }
        }

        public ICommand GetAnswerCmd
        {
            get
            {
                if(getAnswerCmd == null)
                {
                    getAnswerCmd = new RelayCommand(
                        param => GetAnswer(),
                        param => AnswerId > 0);
                }
                return getAnswerCmd;
            }

            set
            {
                getAnswerCmd = value;
            }
        }

        public ICommand SaveAnswerCmd
        {
            get
            {
                if (saveAnswerCmd == null)
                {
                    saveAnswerCmd = new RelayCommand(
                        param => SaveAnswer(),
                        param => (CurrentAnswer != null)
                    );
                }
                return saveAnswerCmd;
            }

            set
            {
                saveAnswerCmd = value;
            }
        }

        public AnswerModel CurrentAnswer
        {
            get
            {
                return currentAnswer;
            }

            set
            {
                currentAnswer = value;
                OnPropertyChanged("CurrentAnswer");
            }
        }
        #endregion
        #region Methods
        private void GetAnswer()
        {
            AnswerModel ans = new AnswerModel();
            ans.AnswerId = this.AnswerId;
            ans.Name = "Answer Name 1";
            ans.IsValid = false;
            CurrentAnswer = ans;
            
        }
        private void SaveAnswer()
        {

        }
        #endregion
    }
}
