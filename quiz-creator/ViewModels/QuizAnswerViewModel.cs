using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
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
    public class QuizAnswerViewModel: ViewModelBase, IDataErrorInfo
    {
        #region Fields
        private string answerName;
        private bool isValid;

        private IFrameNavigationService navigationService;
        #endregion
        #region Constructor
        public QuizAnswerViewModel(IFrameNavigationService navigationService)
        {
            this.navigationService = navigationService;
            SaveAnswerCmd = new RelayCommand(SaveAnswer, IsAnswerLooksAwesome);

            Messenger.Default.Register<AnswerMessage>(this, this.HandleAnswerMessage);


        }
        private bool IsAnswerLooksAwesome()
        {
            if (string.IsNullOrEmpty(AnswerName) || string.IsNullOrWhiteSpace(AnswerName)) { return false; }
            return true;
        }
        private void SaveAnswer()
        {
            Messenger.Default.Send<MVVMMessage>(
                new MVVMMessage { Message = "SAVE" }
            );

            Messenger.Default.Send<AnswerMessage>(
                new AnswerMessage { Answer = new AnswerModel { AnswerName = AnswerName, IsValid = IsValid } }
            );

            navigationService.NavigateTo("Question");
        }

        private void HandleAnswerMessage(AnswerMessage msg)
        {
            AnswerName = msg.Answer.AnswerName;
            IsValid = msg.Answer.IsValid;

            Messenger.Default.Send<MVVMMessage>(
                new MVVMMessage { Message = "SAVE" }
            );
        }
        #endregion
        #region IDataErrorInfo Members
        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "AnswerName")
                {
                    if (string.IsNullOrEmpty(AnswerName))
                        result = "Please enter an Answer Name";
                }

                return result;
            }
        }
        #endregion
        #region Properties/Commands
        public RelayCommand SaveAnswerCmd { get; private set; }
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

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsValid
        {
            get
            {
                return isValid;
            }

            set
            {
                isValid = value;
            }
        }

        #endregion
        #region Methods
        #endregion
    }
}
