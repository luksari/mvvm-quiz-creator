using QuizCreator.Additionals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.Models
{
    public class AnswerModel : ObservableObject
    {
        #region Fields
        private string name;
        private bool isValid;
        private int answerId;
        #endregion
        #region Properties
        public string Name
        {
            get
            {
                return name;

            }
            set
            {
                if( name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }

            }
        }

        public bool IsValid
        {
            get
            {
                return isValid;

            }
            set
            {
                if (isValid != value)
                {
                    isValid = value;
                    OnPropertyChanged("IsValid");
                }
            }
        }

        public int AnswerId
        {
            get
            {
                return answerId;
            }

            set
            {
                if(value != answerId)
                {
                    answerId = value;
                    OnPropertyChanged("AnswerId");
                }
                
            }
        }
        #endregion
    }
}
