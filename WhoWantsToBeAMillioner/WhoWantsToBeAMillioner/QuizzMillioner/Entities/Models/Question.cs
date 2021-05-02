using System;
using System.Collections.Generic;
using System.Text;

namespace QuizzMillioner.Entities.Models
{
    public class Question
    {
        public string QuestionText { get; set; }
        public List<string> PossibleAnswers { get; set; }
        //string CorrectAnswer { get; set; }
        public int CorrectAnswer { get; set; }
        public Question()
        {

        }
        public Question(string questionText,string answer1, string answer2, string answer3, string answer4, int corectAnswer)
        {
            QuestionText = questionText;
            PossibleAnswers = new List<string>() { answer1, answer2, answer3, answer4 };
            CorrectAnswer = corectAnswer;

        }
    }
}
