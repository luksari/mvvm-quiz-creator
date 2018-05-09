using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using QuizCreator.Additionals;
using QuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.ViewModels
{
    public class QuizViewModel : ViewModelBase, IDataErrorInfo
    {
        #region Fields
        private string quizName;
        private string questionName;
        private Guid quizId;
        private ObservableCollection<QuestionModel> questionsList;
        private IFrameNavigationService navigationService;
        private QuestionModel currentQuestion;
        #endregion
        #region Constructors
        public QuizViewModel(IFrameNavigationService navigationService)
        {
            this.navigationService = navigationService;
            SaveQuizCmd = new RelayCommand(SaveQuiz, IsQuizLooksAwesome);
            AddQuestionCmd = new RelayCommand(AddQuestion, IsQuestionLooksAwesome);

            DeleteQuestionCmd = new RelayCommand<QuestionModel>(
                param => DeleteQuestion(param),
                CurrentQuestion != null);
            NavigateToQuestionViewCmd = new RelayCommand(NavigateToQuestionView);

            Messenger.Default.Register<QuizMessage>(this, this.HandleQuizMessage);
            Messenger.Default.Register<QuestionMessage>(this, this.HandleQuestionNameMessage);


        }
        #endregion
        #region Methods
        private void HandleQuestionNameMessage(QuestionMessage msg)
        {
            CurrentQuestion.QuestionName = msg.Question.QuestionName;
        }

        private bool IsQuestionLooksAwesome()
        {
            if (string.IsNullOrEmpty(QuestionName) || string.IsNullOrWhiteSpace(QuestionName)) { return false; }
            return true;
        }

        private bool IsQuizLooksAwesome()
        {
            if (string.IsNullOrEmpty(QuizName) || string.IsNullOrWhiteSpace(QuizName)) { return false; }
            return true;
        }

        private void SaveQuiz()
        {
            Messenger.Default.Send<QuizMessage>(
                new QuizMessage { Quiz = new QuizModel { QuizName = QuizName } }
            );

            Messenger.Default.Send<MVVMMessage>( 
                new MVVMMessage { Message = "SAVE" }
            );

            navigationService.NavigateTo("QuizList");


        }
        private Guid generateID()
        {
            return Guid.NewGuid();
        }
        private void AddQuestion()
        {
            CurrentQuestion = new QuestionModel{ QuestionName = QuestionName, QuestionId = generateID(), AnswersList = new ObservableCollection<AnswerModel>() };

            QuestionsList.Add(CurrentQuestion);

            QuestionName = string.Empty;

            Messenger.Default.Send<MVVMMessage>(
                new MVVMMessage { Message = "SAVE" }
            );

        }
        private void DeleteQuestion(QuestionModel currentQuestion)
        {
            QuestionsList.Remove(currentQuestion);

            Messenger.Default.Send<MVVMMessage>(
                new MVVMMessage { Message = "SAVE" }
            );
        }
        private void HandleQuizMessage(QuizMessage message)
        {
            this.QuizName = message.Quiz.QuizName;
            this.QuizId = message.Quiz.QuizId;
            this.QuestionsList = message.Quiz.QuestionsList;
        }
        private void NavigateToQuestionView()
        {
           Messenger.Default.Send<QuestionMessage>(new QuestionMessage { Question = CurrentQuestion });

           navigationService.NavigateTo("Question");
        }
        #endregion
        #region Props / Commands
        public RelayCommand SaveQuizCmd
        {
            get;
            private set;
        }
        public RelayCommand AddQuestionCmd
        {
            get;
            private set;
        }
        public RelayCommand<QuestionModel> DeleteQuestionCmd
        {
            get;
            private set;
        }
        public RelayCommand NavigateToQuestionViewCmd
        {
            get;
            private set;
        }
        public string QuizName
        {
            get
            {
                return quizName;
            }

            set
            {
                quizName = value;
                RaisePropertyChanged("QuizName");

                
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

        public QuestionModel CurrentQuestion
        {
            get
            {
                return currentQuestion;
            }

            set
            {
                currentQuestion = value;
                RaisePropertyChanged("CurrentQuestion");
            }
        }

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
                if (columnName == "QuizName")
                {
                    if (string.IsNullOrEmpty(QuizName))
                        result = "Please enter a Quiz Name";
                }
                else if(columnName == "QuestionName")
                    if (string.IsNullOrEmpty(QuestionName))
                        result = "Please enter a Question Name";

                return result;
            }
        }
        #endregion
    }
}
