﻿using QuizCreator.Additionals;
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
    }
}