using QuizCreator.Additionals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.Models
{
    public class Model: ObservableObject
    {
        List<QuizModel> quizesList;

        public List<QuizModel> QuizesList
        {
            get
            {
                return quizesList;
            }

            set
            {
                if (value != quizesList)
                {
                    quizesList = value;
                    OnPropertyChanged("QuizesList");
                }
            }
        }
    }
}
