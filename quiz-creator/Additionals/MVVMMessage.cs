using QuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.Additionals
{
    public class MVVMMessage
    {
        public QuizModel Quiz { get; set; }
        public QuizListModel QuizList{ get; set; }
   
        public AnswerModel Answer { get; set; }
        public QuestionModel Question { get; set; }
    }
}
