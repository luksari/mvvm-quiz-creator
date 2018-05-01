using QuizCreator.Additionals;
using QuizCreator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizCreator.ViewModels
{
    public class QuizStartViewModel : ObservableObject, IPageViewModel
    {
        #region Fields
        private string name;
        #endregion
        #region Properties
        public string PageName
        {
            get
            {
                return "Start";
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
        #endregion
    }
}
