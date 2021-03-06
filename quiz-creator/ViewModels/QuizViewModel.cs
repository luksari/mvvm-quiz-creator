﻿using QuizCreator.Additionals;
using QuizCreator.Interfaces;
using QuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.ViewModels
{
    public class QuizViewModel : ObservableObject, IPageViewModel
    {
        private string name;
        private Guid quizId;
        private ObservableCollection<QuestionModel> questionsList;
        public string PageName
        {
            get
            {
                return "Quiz";
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

        public Guid QuizId
        {
            get
            {
                return quizId;
            }

            set
            {
                quizId = value;
                OnPropertyChanged("QuizId");
            }
        }

        public ObservableCollection<QuestionModel> QuestionsList
        {
            get
            {
                return questionsList;
            }

            set
            {
                questionsList = value;
                OnPropertyChanged("QuestionsList");
            }
        }
    }
}
