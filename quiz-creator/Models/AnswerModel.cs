using GalaSoft.MvvmLight;
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
                    RaisePropertyChanged("Name");
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
                    RaisePropertyChanged("IsValid");
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
                    RaisePropertyChanged("AnswerId");
                }
                
            }
        }
        #endregion
    }
}
