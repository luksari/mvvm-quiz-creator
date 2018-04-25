using QuizCreator.Additionals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.Models
{
    public class QuestionModel : ObservableObject
    {
        private string name;
        private List<AnswerModel> answersList;
        private int questionId;
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

        public List<AnswerModel> AnswersList
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
    }
}
