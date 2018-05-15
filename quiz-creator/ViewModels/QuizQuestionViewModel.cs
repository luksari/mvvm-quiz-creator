using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using QuizCreator.Additionals;
using QuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.ViewModels
{
    public class QuizQuestionViewModel : ViewModelBase, IDataErrorInfo
    {
        #region Fields
        private string questionName;
        private string answerName;
        private ObservableCollection<AnswerModel> answersList;
        private AnswerModel currentAnswer;
        private Guid questionId;
        private IFrameNavigationService navigationService;
        #endregion
        #region Constructor
        public QuizQuestionViewModel(IFrameNavigationService navigationService)
        {
            this.navigationService = navigationService;

            AddAnswerCmd = new RelayCommand(AddAnswer, IsAnswerLooksAwesome);
            DeleteAnswerCmd = new RelayCommand<AnswerModel>(
                param => DeleteAnswer(param),
                CurrentAnswer != null
                );
            SaveQuestionCmd = new RelayCommand(SaveQuestion, IsQuestionLooksAwesome);
            NavigateToAnswerViewCmd = new RelayCommand(NavigateToAnswerView, CurrentAnswer != null);

            Messenger.Default.Register<QuestionMessage>(this, this.HandleQuestionMessage);
            Messenger.Default.Register<AnswerMessage>(this, this.HandleAnswerNameMessage);

        }


        #endregion
        #region Methods
        private void HandleAnswerNameMessage(AnswerMessage msg)
        {
            CurrentAnswer.AnswerName = msg.Answer.AnswerName;
            CurrentAnswer.IsValid = msg.Answer.IsValid;
        }
        private bool IsQuestionLooksAwesome()
        {
            if(string.IsNullOrEmpty(QuestionName) || string.IsNullOrWhiteSpace(QuestionName)) { return false; }
            return true;
        }
        private bool IsAnswerLooksAwesome()
        {
            if (string.IsNullOrEmpty(AnswerName) || string.IsNullOrWhiteSpace(AnswerName)) { return false; }
            return true;
        }
        private void DeleteAnswer(AnswerModel currentAnswer)
        {
            AnswersList.Remove(CurrentAnswer);

            Messenger.Default.Send<MVVMMessage>(
                new MVVMMessage { Message = "SAVE" }
            );
        }
        private void HandleQuestionMessage(QuestionMessage message)
        {
            this.QuestionName = message.Question.QuestionName;
            this.QuestionId = message.Question.QuestionId;
            this.AnswersList = message.Question.AnswersList;
        }
        private void SaveQuestion()
        {
            Messenger.Default.Send<MVVMMessage>(
                new MVVMMessage { Message = "SAVE" }
            );

            Messenger.Default.Send<QuestionMessage>(
                new QuestionMessage { Question = new QuestionModel { QuestionName = QuestionName } }
            );

            navigationService.NavigateTo("Quiz");
        }
        private void NavigateToAnswerView()
        {
            Messenger.Default.Send<AnswerMessage>(new AnswerMessage { Answer = CurrentAnswer });
            navigationService.NavigateTo("Answer");
        }
        private void AddAnswer()
        {
            CurrentAnswer = new AnswerModel { AnswerName = AnswerName, AnswerId = generateID(), IsValid = false };

            AnswersList.Add(CurrentAnswer);

            AnswerName = string.Empty;

            Messenger.Default.Send<MVVMMessage>(
                new MVVMMessage { Message = "SAVE" }
            );

        }
        private Guid generateID()
        {
            return Guid.NewGuid();
        }
        #endregion
        #region Properties / CMDS
        public RelayCommand AddAnswerCmd { get; private set; }
        public RelayCommand SaveQuestionCmd { get; private set; }
        public RelayCommand<AnswerModel> DeleteAnswerCmd { get; private set; }
        public RelayCommand NavigateToAnswerViewCmd { get; private set; }

        public string QuestionName
        {
            get
            {
                return questionName;
            }

            set
            {
                questionName = value;
                RaisePropertyChanged("QuestionName");
            }
        }

        public ObservableCollection<AnswerModel> AnswersList
        {
            get
            {
                return answersList;
            }

            set
            {
                answersList = value;
                RaisePropertyChanged("AnswersList");
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

        public Guid QuestionId
        {
            get
            {
                return questionId;
            }

            set
            {
                questionId = value;
                RaisePropertyChanged("QuestionID");
            }
        }

     

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
        #endregion

        #region IDataErrorInfo Members
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
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
                else if (columnName == "QuestionName")
                    if (string.IsNullOrEmpty(QuestionName))
                        result = "Please enter a Question Name";

                return result;
            }
        }
        #endregion
    }
}
