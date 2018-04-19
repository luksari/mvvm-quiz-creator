using QuizCreator.Additionals;
using QuizCreator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.ViewModels
{
    public class QuizQuestionsViewModel : ObservableObject, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Questions";
            }

            set
            {
                Name = value;
            }
        }
    }
}
