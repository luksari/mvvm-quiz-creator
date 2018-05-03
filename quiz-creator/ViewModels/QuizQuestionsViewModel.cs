using GalaSoft.MvvmLight;
using QuizCreator.Additionals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.ViewModels
{
    public class QuizQuestionsViewModel : ViewModelBase
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
                RaisePropertyChanged("Name");
            }
        }
    }
}
