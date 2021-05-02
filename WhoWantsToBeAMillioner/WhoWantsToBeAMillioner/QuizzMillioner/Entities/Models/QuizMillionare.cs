using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using QuizzMillioner.Entities.Interfaces;

namespace QuizzMillioner.Entities.Models
{
    public class QuizMillionare : Quiz,IHelp
    {
        public Random rnd { get; set; }

        public bool HelpAudience  { get; set; }
        public bool HelpFriend { get; set; }
        public bool HelpFiftyFifty { get; set; }
        public QuizMillionare()
        {

        }
        public QuizMillionare(string name,bool haa,bool hcf, bool hff,List<List<Question>> questions) : base(name,questions)
        {
            HelpAudience = haa;
            HelpFriend = hcf;
            HelpFiftyFifty = hff;
            rnd = new Random();
        }

        public override void Start()
        {
            while (true) 
            {
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Welcome to the Quiz --- Who Wants To Be A Millionaire?");
                Console.WriteLine();
                Console.WriteLine("If you are ready to play ----> press ENTER!");
                string userInput = Console.ReadLine();
                Console.ResetColor();
                if (userInput.ToLower() == "") break;

            }

        }
        public int GetRandomNumber()
        {
           return rnd.Next(0, 3);
        }
        //public void ShufflePossibleQuestions()
        //{
            //not really sure what is this function supposed to do, that's why I did not use it!
        //}
        public void PrintHelpOptions()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (!HelpAudience)
            {
                Console.WriteLine("You can use Help from Audience ---- press x to use it!");
            }
            if (!HelpFriend)
            {
                Console.WriteLine("You can use Help from a Friend ---- press y to use it!");
            }
            if (!HelpFiftyFifty)
            {
                Console.WriteLine("You can use Help Fifty/Fifty ---- press z to use it!");
            }

        }

        public Question GenerateQuestion(int questionNo)
        {
          
            int randomQuestionNo = rnd.Next(0, 3);
           
            return Questions[questionNo - 1][randomQuestionNo];
        }


       public void PrintQuestion(Question questionActive)
        {
           
            
            Console.WriteLine($"{questionActive.QuestionText}");
            int answersCounter = 0;
            questionActive.PossibleAnswers.ForEach(x => Console.WriteLine($" {++answersCounter}. {x} "));

        }

        public void UseHelpAudience(Question currentQuestion)
        {
            if (!HelpAudience)
            {
                int firstPercent = rnd.Next(0, 100);
                int secondPercent = rnd.Next(0, (100 - firstPercent));
                int thirdPersent = rnd.Next(0, (100 - firstPercent - secondPercent));
                int fourthPercent = 100 - firstPercent - secondPercent - thirdPersent;
                List<int> audiencePercents = new List<int>() { firstPercent, secondPercent, thirdPersent, fourthPercent };
                audiencePercents.Sort();
                Console.WriteLine();
                
                switch (currentQuestion.CorrectAnswer)
                {
                    case 1:
                        Console.WriteLine(string.Format("{0}% of the audience voted for answer number 1!",audiencePercents[3]));
                        Console.WriteLine(string.Format("{0}% of the audience voted for answer number 2!", audiencePercents[0]));
                        Console.WriteLine(string.Format("{0}% of the audience voted for answer number 3!", audiencePercents[1]));
                        Console.WriteLine(string.Format("{0}% of the audience voted for answer number 4!", audiencePercents[2]));
                        break;
                    case 2:
                        Console.WriteLine(string.Format("{0}% of the audience voted for answer number 1!", audiencePercents[0]));
                        Console.WriteLine(string.Format("{0}% of the audience voted for answer number 2!", audiencePercents[3]));
                        Console.WriteLine(string.Format("{0}% of the audience voted for answer number 3!", audiencePercents[1]));
                        Console.WriteLine(string.Format("{0}% of the audience voted for answer number 4!", audiencePercents[2]));
                        break;
                    case 3:
                        Console.WriteLine(string.Format("{0}% of the audience voted for answer number 1!", audiencePercents[0]));
                        Console.WriteLine(string.Format("{0}% of the audience voted for answer number 2!", audiencePercents[1]));
                        Console.WriteLine(string.Format("{0}% of the audience voted for answer number 3!", audiencePercents[3]));
                        Console.WriteLine(string.Format("{0}% of the audience voted for answer number 4!", audiencePercents[2]));
                        break;
                    case 4:
                        Console.WriteLine(string.Format("{0}% of the audience voted for answer number 1!", audiencePercents[0]));
                        Console.WriteLine(string.Format("{0}% of the audience voted for answer number 2!", audiencePercents[2]));
                        Console.WriteLine(string.Format("{0}% of the audience voted for answer number 3!", audiencePercents[1]));
                        Console.WriteLine(string.Format("{0}% of the audience voted for answer number 4!", audiencePercents[3]));
                        break;
                }

                HelpAudience = true;
              
            }
            else
            {
                Console.WriteLine("Sorry you have already used this help!");
            }
            Console.WriteLine();

            HelpAudience = true;

        }


        public void UseHelpFriend(Question currentQuestion)
        {

            if (!HelpFriend)
            {
                int certainPercent = rnd.Next(0, 100);
                Console.WriteLine();

                if (certainPercent < 30)
                {
                    Console.WriteLine("I am sorry my friend but I'm afarid I don't know the answer of this question!");
                }
                else if(certainPercent>30 && certainPercent < 40)
                {
                    if (currentQuestion.CorrectAnswer < 2)
                    {
                        Console.WriteLine($"I belive the correct answer is {currentQuestion.CorrectAnswer + 2}!");
                        Console.WriteLine("error1");
                    }
                    else
                    {
                        Console.WriteLine($"I belive the correct answer is {currentQuestion.CorrectAnswer - 2}!");
                        Console.WriteLine("error2");

                    }
                }
                else
                {
                    Console.WriteLine($"I belive the correct answer is the answer number {currentQuestion.CorrectAnswer}!");
                    Console.WriteLine($"{currentQuestion.PossibleAnswers[currentQuestion.CorrectAnswer-1]}");
                }


            }
            else
            {
                Console.WriteLine("Sorry you have already used this help!");
            }
            HelpFriend = true;
        }

        public void UseHelpFiftyFifty(Question currentQuestion)
        {

            if (!HelpFiftyFifty)
            {
      
                Console.WriteLine();
                int certainNumber = rnd.Next(1,5 );

                while (true)
                {
                    if (certainNumber != currentQuestion.CorrectAnswer) break;
                    certainNumber = rnd.Next(1, 5);
                }

                Console.WriteLine("One of these two is the correct answer:");
                if (currentQuestion.CorrectAnswer > certainNumber)
                {
                    Console.WriteLine($"{certainNumber}.{currentQuestion.PossibleAnswers[certainNumber-1]}");
                    Console.WriteLine($"{currentQuestion.CorrectAnswer}.{currentQuestion.PossibleAnswers[currentQuestion.CorrectAnswer-1]}");
                }
                else
                {
                    Console.WriteLine($"{currentQuestion.CorrectAnswer}.{currentQuestion.PossibleAnswers[currentQuestion.CorrectAnswer - 1]}");
                    Console.WriteLine($"{certainNumber}.{currentQuestion.PossibleAnswers[certainNumber - 1]}");
                }



            }
            else
            {
                Console.WriteLine("Sorry you have already used this help!");
            }
            HelpFiftyFifty = true;
        }

      
    }
}
