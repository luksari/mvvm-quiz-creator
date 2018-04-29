﻿using QuizCreator.Additionals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.Models
{
    public class QuizModel : ObservableObject
    {
        #region Fields
        private string name;
        private int quizId;
        private ObservableCollection<QuestionModel> questionsList;
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
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public ObservableCollection<QuestionModel> Questions
        {
            get
            {
                return questionsList;
            }

            set
            {
                if (value != questionsList)

                    questionsList = value;
                    OnPropertyChanged("QuestionsList");
                }
            }

        public int QuizId
        {
            get
            {
                return quizId;
            }

            set
            {
                if(value != quizId)
                {
                    quizId = value;
                    OnPropertyChanged("QuizId");
                }
                
            }
        }
        #endregion

    }
}
