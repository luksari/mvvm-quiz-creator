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
        public string Name
        {
            get
            {
                return "Start";
            }
            
            set
            {
                Name = value;
            }
        }





        #endregion

    }
}
