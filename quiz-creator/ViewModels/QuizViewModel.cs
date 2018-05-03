using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using QuizCreator.Additionals;
using QuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.ViewModels
{
    public class QuizViewModel : ViewModelBase
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
            SaveQuizCmd = new RelayCommand(SaveQuiz);
            AddQuestionCmd = new RelayCommand(AddQuestion);
            DeleteQuestionCmd = new RelayCommand<QuestionModel>(
                param => DeleteQuestion(param),
                CurrentQuestion != null);

            Messenger.Default.Register<QuizMessage>(this, this.HandleQuizMessage);

        }
        #endregion
        #region Methods
        private void SaveQuiz()
        {
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

        }
        private void DeleteQuestion(QuestionModel currentQuestion)
        {
            QuestionsList.Remove(currentQuestion);
        }
        private void HandleQuizMessage(QuizMessage message)
        {
            this.QuizName = message.Quiz.QuizName;
            this.QuizId = message.Quiz.QuizId;
            this.QuestionsList = message.Quiz.QuestionsList;
        }
        #endregion
        #region Props / Commands
        public RelayCommand SaveQuizCmd
        {
            get;
            private set;
        }
        public RelayCommand<string> ChangeQuizNameCmd
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
                Messenger.Default.Send<string>(value);

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
    }
}
