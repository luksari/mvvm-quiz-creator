using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
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
    public class QuizQuestionViewModel : ViewModelBase
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

            AddAnswerCmd = new RelayCommand(AddAnswer);
            DeleteAnswerCmd = new RelayCommand<AnswerModel>(
                param => DeleteAnswer(param),
                CurrentAnswer != null
                );
            SaveQuestionCmd = new RelayCommand(SaveQuestion);

            Messenger.Default.Register<QuestionMessage>(this, this.HandleQuestionMessage);
        }
        #endregion
        #region Methods
        private void DeleteAnswer(AnswerModel currentAnswer)
        {
            AnswersList.Remove(CurrentAnswer);
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
            navigationService.NavigateTo("Quiz");
        }
        private void NavigateToAnswerView()
        {
            navigationService.NavigateTo("Answers");
        }
        private void AddAnswer()
        {
            CurrentAnswer = new AnswerModel { AnswerName = AnswerName, AnswerId = generateID(), IsValid = false };

            AnswersList.Add(CurrentAnswer);

            AnswerName = string.Empty;

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
    }
}
