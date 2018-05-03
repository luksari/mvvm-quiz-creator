using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using QuizCreator.Additionals;
using QuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizCreator.ViewModels
{
    public class QuizListViewModel : ViewModelBase
    {
        #region Fields
        private ObservableCollection<QuizModel> quizList;
        private QuizModel currentQuiz;
        private string quizName;
        private IFrameNavigationService navigationService;
        #endregion
        #region Properties
        public string PageName
        {
            get
            {
                return "QuizList";
            }
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

        public ObservableCollection<QuizModel> QuizList
        {
            get
            {
                return quizList;
            }

            set
            {
                quizList = value;
                RaisePropertyChanged("QuizList");
            }
        }

        public QuizModel CurrentQuiz
        {
            get
            {
                return currentQuiz;
            }

            set
            {
                currentQuiz = value;
                RaisePropertyChanged("CurrentQuiz");
            }
        }

        public RelayCommand AddQuizCmd
        {
            get; private set;
        }
        public RelayCommand<QuizModel> DeleteQuizCmd
        {
            get;
            private set;
        }
        public RelayCommand NavigateToQuizViewCmd { get; private set;}

        public RelayCommand SaveToJsonCmd
        {
            get; private set;
        }

        #endregion
        #region Constructors
        public QuizListViewModel(IFrameNavigationService navigationService)
        {
            this.navigationService = navigationService;
             
            AddQuizCmd = new RelayCommand(AddQuiz);
            SaveToJsonCmd = new RelayCommand(SaveToJson);
            NavigateToQuizViewCmd = new RelayCommand(NavigateToQuizView);
            DeleteQuizCmd = new RelayCommand<QuizModel>(
                param => DeleteQuiz(param),
                CurrentQuiz != null);


            LoadQuizes();

        }
        #endregion
        #region Methods
        private void AddQuiz()
        {
            CurrentQuiz = new QuizModel { QuizName = QuizName, QuizId = generateID(), QuestionsList = new ObservableCollection<QuestionModel>() };

            QuizList.Add(CurrentQuiz);

            SaveToJson();
        }
        private Guid generateID()
        {
            return Guid.NewGuid();
        }
        private void LoadQuizes()
        {
            ObservableCollection<QuizModel> quizList = new ObservableCollection<QuizModel>();

            QuizList = quizList;
        }
        private async void SaveToJson()
        {
            
            try
            {
                string newJson = JsonConvert.SerializeObject(QuizList);
                using (StreamWriter writer = File.CreateText("data.json"))
                {
                    await writer.WriteAsync(newJson);
                }
            }
            catch (FileNotFoundException e) { throw new Exception(e.Message); }
        }

        private void NavigateToQuizView()
        {
            Messenger.Default.Send<MVVMMessage>(new MVVMMessage
            {
                Quiz = CurrentQuiz

            });

            navigationService.NavigateTo("Quiz");

        }
        private void DeleteQuiz(QuizModel currentQuiz)
        {
            QuizList.Remove(currentQuiz);

            SaveToJson();
        }
        #endregion
    }
}
