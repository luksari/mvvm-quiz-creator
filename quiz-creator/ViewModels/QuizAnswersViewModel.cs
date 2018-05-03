using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using QuizCreator.Additionals;
using QuizCreator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizCreator.ViewModels
{
    public class QuizAnswersViewModel: ViewModelBase, INotifyPropertyChanged
    {
        #region Fields
        private string answerName;
        private int answerId;
        private AnswerModel currentAnswer;
        #endregion
        #region Properties

        public string AnswerName
        {
            get
            {
                return answerName;
            }

            set
            {
                answerName = value;
                RaisePropertyChanged("AnswerName");
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
                RaisePropertyChanged("AnswerId");
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
                RaisePropertyChanged("CurrentAnswer");
            }
        }
        #endregion
        #region Methods
        #endregion
    }
}
