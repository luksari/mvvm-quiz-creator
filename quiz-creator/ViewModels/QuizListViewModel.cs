using QuizCreator.Additionals;
using QuizCreator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.ViewModels
{
    public class QuizListViewModel : ObservableObject, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Name";
            }

            set
            {
                Name = value;
            }
        }
    }
}
