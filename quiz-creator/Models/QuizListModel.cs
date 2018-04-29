using QuizCreator.Additionals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.Models
{
    public class QuizListModel: ObservableObject
    {
        #region Fields
        private ObservableCollection<QuizModel> quizesList;

        #endregion

        #region Properties
        public ObservableCollection<QuizModel> QuizesList
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
        #endregion
        
    }
}
