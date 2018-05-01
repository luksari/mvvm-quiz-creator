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
        #region Fields
        private string name;
        #endregion
        public string PageName
        {
            get
            {
                return "Questions";
            }
        }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
    }
}
