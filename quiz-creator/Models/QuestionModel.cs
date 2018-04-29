using QuizCreator.Additionals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.Models
{
    public class QuestionModel : ObservableObject
    {
        #region Fields
        private string name;
        private ObservableCollection<AnswerModel> answersList;
        private int questionId;
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if(value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
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
                if (value != answersList)
                {
                    answersList = value;
                    OnPropertyChanged("AnswerList");
                }
            }
        }
        public int QuestionId
        {
            get
            {
                return questionId;
            }

            set
            {
                if (value != questionId)
                {
                    questionId = value;
                    OnPropertyChanged("QuestionId");
                }

            }
        }
        #endregion
    }
}
