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
        #endregion
        #region Properties

        private string name;
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





        #endregion

    }
}
