using Newtonsoft.Json;
using QuizCreator.Additionals;
using QuizCreator.Interfaces;
using QuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizCreator.ViewModels
{
    public class QuizListViewModel : ObservableObject, IPageViewModel
    {
        #region Fields
        private ObservableCollection<QuizModel> quizList;
        private QuizModel currentQuiz;
        private string quizName;
        private ICommand addQuizCmd;
        private ICommand saveToJsonCmd;
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
                OnPropertyChanged("QuizName");
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
                OnPropertyChanged("QuizList");
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
                OnPropertyChanged("CurrentQuiz");
            }
        }

        public ICommand AddQuizCmd
        {
            get
            {
                if(addQuizCmd == null)
                {
                    addQuizCmd = new RelayCommand(
                        param => AddQuiz(),
                        param => true);
                }
                return addQuizCmd;
            }

            set
            {
                addQuizCmd = value;
            }
        }

        public ICommand SaveToJsonCmd
        {
            get
            {
                if (saveToJsonCmd == null)
                {
                    saveToJsonCmd = new RelayCommand(
                        param => SaveToJson(),
                        param => (QuizList != null));
                }
                return saveToJsonCmd;
            }

            set
            {
                saveToJsonCmd = value;
            }
        }

        #endregion
        #region Constructors
        public QuizListViewModel()
        {

            LoadQuizes();

        }
        #endregion
        #region Methods
        private void AddQuiz()
        {
            CurrentQuiz = new QuizModel { QuizName = QuizName, QuizId = generateID(), QuestionsList = new ObservableCollection<QuestionModel>() };

            QuizList.Add(CurrentQuiz);
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
        #endregion
    }
}
