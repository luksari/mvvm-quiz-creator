using QuizCreator.Additionals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.Models
{
    public class QuizModel : ObservableObject
    {
        #region Fields
        private string quizName;
        private Guid quizId;
        private ObservableCollection<QuestionModel> questionsList;
        #endregion
        #region Properties
        public string QuizName
        {
            get
            {
                return quizName;
            }

            set
            {
                if (value != quizName)
                {
                    quizName = value;
                    OnPropertyChanged("QuizName");
                }
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
                if (value != questionsList)

                    questionsList = value;
                    OnPropertyChanged("QuestionsList");
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
                if(value != quizId)
                {
                    quizId = value;
                    OnPropertyChanged("QuizId");
                }
                
            }
        }
        #endregion

    }
}
