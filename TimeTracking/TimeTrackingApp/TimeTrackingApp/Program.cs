using System;
using TimeTracking.Services.Implementation;
using TimeTracking.Services.Interfaces;
using TImeTracking.Domain.Core.Entities;
using TImeTracking.Domain.Core.Enums;
using TimeTracking.Services.Helpers;
using System.Linq;
using System.Collections.Generic;

namespace TimeTrackingApp
{
    class Program
    {
        public static IUserService<User> _userUserService = new UserService<User>();
        public static IActivityService<Activity> _activitiesService = new ActivityService<Activity>();
        public static IUIService _IUIService = new UIService();
        public static User _activeUser;
        public static Activity _currentActivity;

        public static void Seed()
        {
            if (_userUserService.IsDbEmpty())
            {
                _userUserService.Register(new User() { FirstName = "Jelena", LastName = "Nakova", Username = "jelena01", Password = "Jelena01" });
                _activitiesService.AddActivity(new Reading() { Pages = 5, TypeOfBook = ReadingType.BelleLetters, UserDoingActivityId = 1 ,TimeSpentOnActivityThisTime=new TimeSpan(10,10,10)});
                _activitiesService.AddActivity(new Exercising() { TypeOfExercise = ExercisingType.Pillates, UserDoingActivityId=1,TimeSpentOnActivityThisTime = new TimeSpan(15, 10, 20) });
                _activitiesService.AddActivity(new Working() { TypeOfWorking = WorkinType.FromHome, UserDoingActivityId = 1, TimeSpentOnActivityThisTime = new TimeSpan(30, 30, 12) });
                _activitiesService.AddActivity(new OtherHobies() { UserDoingActivityId = 1, NameOfHobby = "Dancing" });
                _activitiesService.AddActivity(new OtherHobies() { UserDoingActivityId = 1, NameOfHobby = "Dancing" });
                _activitiesService.AddActivity(new Reading() { Pages = 2, TypeOfBook = ReadingType.MotivationalLiterature, UserDoingActivityId = 1 ,TimeSpentOnActivityThisTime=new TimeSpan(100,10,10)});
                _activitiesService.AddActivity(new Reading() { Pages = 1, TypeOfBook = ReadingType.ReadingToYourKids, UserDoingActivityId = 1 ,TimeSpentOnActivityThisTime=new TimeSpan(4,10,10)});
                _activitiesService.AddActivity(new Reading() { Pages = 107, TypeOfBook = ReadingType.ProfessionalLiterature, UserDoingActivityId = 1, TimeSpentOnActivityThisTime = new TimeSpan(0, 30, 10) });
                _activitiesService.AddActivity(new Reading() { Pages = 10, TypeOfBook = ReadingType.ProfessionalLiterature, UserDoingActivityId = 1, TimeSpentOnActivityThisTime = new TimeSpan(0, 30, 10) });


            }
        }
        static void Main(string[] args)
        {
            Seed();

            while (true)
            {
                if (_activeUser == null)
                {
                    Console.Clear();
                    _IUIService.WelcomeToApp();
                    int userChoice=_IUIService.LoginRegisterMenu();
                    if (userChoice == 0) break;
                    switch (userChoice)
                    {
                        case 1:
                            Console.WriteLine("Please enter your username!");
                            string username = Console.ReadLine();
                            Console.WriteLine("Please enter your password!");
                            string password = Console.ReadLine();
                            _activeUser=_userUserService.Login(username, password);
                            break;
                        case 2:
                            User newUser = new User();
                            bool firstNamePassed = false;
                            bool lastNamePassed = false;
                            bool agePassed = false;
                            bool usernamePassed = false;
                            bool passwordPassed = false;
                            while (true)
                            {
                                if (!firstNamePassed)
                                {
                                    Console.WriteLine("Please enter your FirstName!");
                                    Console.WriteLine("It can not be shorter than 2 letters!");
                                    newUser.FirstName = ValidationHelper.ValidateIfContainsDigits(Console.ReadLine(), 2);
                                    if (newUser.FirstName == null)
                                    {
                                        MessageHelper.Color("[Error] FirstName should not be shorter than 2 letters or contain digits!", ConsoleColor.Red);
                                        continue;
                                    }
                                }
                                firstNamePassed = true;
                                if (!lastNamePassed)
                                {
                                    Console.WriteLine("Please enter your LastName!");
                                    Console.WriteLine("It can not be shorter than 4 letters!");
                                    newUser.LastName = ValidationHelper.ValidateIfContainsDigits(Console.ReadLine(), 4);
                                    if (newUser.LastName == null)
                                    {
                                        MessageHelper.Color("[Error] LastName can not be shorter than 4 letters, or contain digits!", ConsoleColor.Red);
                                        continue;
                                    }
                                }
                                lastNamePassed = true;
                                if (!agePassed)
                                {
                                    Console.WriteLine("Please enter your age!");
                                    newUser.Age = ValidationHelper.ValidateNumber(Console.ReadLine(), 18,120);
                                    if (newUser.Age == -1)
                                    {
                                        MessageHelper.Color("[Error] Entered age is not valid!", ConsoleColor.Red);
                                        continue;
                                    }
                                }
                                agePassed = true;
                                if (!usernamePassed)
                                {
                                    Console.WriteLine("Pease enter your username!");
                                    Console.WriteLine("It can not be shorter than 5 characters!");
                                    newUser.Username = ValidationHelper.ValidateString(Console.ReadLine(), 5);
                                    if (newUser.Username == null)
                                    {
                                        MessageHelper.Color("[Error] Username should not be shorter than 5 characters!", ConsoleColor.Red);
                                        continue;
                                    }
                                    if (_userUserService.CheckAllUsers().Select(x => x.Username).Any(x => x == newUser.Username))
                                    {
                                        MessageHelper.Color("[Error] There is already such a username, please try with other one!", ConsoleColor.Red);
                                        continue;
                                    }
                                }
                                usernamePassed = true;
                                if (!passwordPassed)
                                {
                                    Console.WriteLine("Please enter a password!");
                                    Console.WriteLine("Password should not be shorter than 6 characters and must contain at least one Uppercase letter and one number!");

                                    newUser.Password = ValidationHelper.ValidatePassword(Console.ReadLine());

                                    if (newUser.Password == null)
                                    {
                                        MessageHelper.Color("[Error] Password should not be shorter than 6 characters, must contain at least one number and one UpperCase Letter", ConsoleColor.Red);
                                        continue;
                                    }
                                    Console.WriteLine("Please confirm your password!");
                                    string confirmPassword = Console.ReadLine();
                                    if (confirmPassword != newUser.Password)
                                    {
                                        MessageHelper.Color("[Error] Passwords do not match!", ConsoleColor.Red);
                                        continue;
                                    }
                                }
                           
                                _userUserService.Register(newUser);
                                MessageHelper.Color("You have succesfully registered!", ConsoleColor.Green);
                                MessageHelper.Color("Press any key to go back!", ConsoleColor.Green);

                                Console.ReadLine();
                                
                                break;
                            }
                            break;

                    }
                    if (_activeUser != null)
                    {
                        while (true)
                        {
                            int mainMenuChoice = _IUIService.MainMenu();
                            if (mainMenuChoice == 4)
                            {
                                _activeUser = null;
                                break;
                            }
                            
                            switch (mainMenuChoice)
                            {
                                case 1:
                                    int activitesChoise = _IUIService.ActivitiesMenu();
                                    switch (activitesChoise)
                                    {
                                        case 1:
                                             _currentActivity = new Reading() { UserDoingActivityId=_activeUser.Id};
                                           Reading currentActivity1 = (Reading)_currentActivity;
                                            Console.WriteLine("Press enter to start counting time while reading!");
                                            Console.ReadLine();
                                            currentActivity1.TrackActivity();
                     
                                            currentActivity1.EnterPagesRead();
                                            Console.WriteLine("Press enter and select which genre of book you were reading this time, for the records!");
                                            Console.ReadLine();
                                            currentActivity1.SelectTypeOfLiterature( _IUIService.ReadingTypes());
                                            _activitiesService.AddActivity(currentActivity1);
                                            Console.WriteLine("Reading was recorded!");
                                            Console.WriteLine($"You spent {currentActivity1.TimeSpentOnActivityThisTime.Minutes} minutes  and {currentActivity1.TimeSpentOnActivityThisTime.Seconds} seconds reading  {currentActivity1.TypeOfBook}!");
                                            Console.WriteLine($"Pages read this time -> {currentActivity1.Pages}");
                                            Console.ReadLine();
                                            break;
                                        case 2:
                                            _currentActivity = new Exercising() { UserDoingActivityId = _activeUser.Id };
                                            Exercising currentActivity2 = (Exercising)_currentActivity;
                                            Console.WriteLine("Press enter to start counting time while exercising!");
                                            Console.ReadLine();
                                            currentActivity2.TrackActivity();
                                            Console.WriteLine("Press enter and select which activity were you exercising this time, for the records!");
                                            Console.ReadLine();
                                            currentActivity2.SelectTypeOfExercise(_IUIService.ExerciseTypes());
                                            _activitiesService.AddActivity(currentActivity2);
                                            Console.WriteLine("Exercising was recorded!");
                                            Console.WriteLine($"You spent {currentActivity2.TimeSpentOnActivityThisTime.Minutes} minutes  and {currentActivity2.TimeSpentOnActivityThisTime.Seconds} seconds on {currentActivity2.TypeOfExercise}!");
                                            Console.ReadLine();
                                            break;
                                        case 3:
                                            _currentActivity = new Working() { UserDoingActivityId = _activeUser.Id };
                                            Working currentActivity3 = (Working)_currentActivity;
                                            Console.WriteLine("Press enter to start counting time while working!");
                                            Console.ReadLine();
                                            currentActivity3.TrackActivity();
                                            Console.WriteLine("Press enter and select where were you working from, for the records!");
                                            Console.ReadLine();
                                            currentActivity3.SelectWorkingLocation(_IUIService.WorkingPlace());
                                            _activitiesService.AddActivity(currentActivity3);
                                            Console.WriteLine("Working was recorded!");
                                            Console.WriteLine($"You spent {currentActivity3.TimeSpentOnActivityThisTime.Minutes} minutes  and {currentActivity3.TimeSpentOnActivityThisTime.Seconds} seconds working {currentActivity3.TypeOfWorking}!");
                                            Console.ReadLine();
                                            break;
                                        case 4:
                                            _currentActivity = new OtherHobies() { UserDoingActivityId = _activeUser.Id };
                                            OtherHobies currentActivity4 = (OtherHobies)_currentActivity;
                                            Console.WriteLine("Press enter to start counting time while doing your hobby!");
                                            Console.ReadLine();
                                            currentActivity4.TrackActivity();
                                            currentActivity4.EnterNameOfHobby();
                                            _activitiesService.AddActivity(currentActivity4);
                                            Console.WriteLine($"{currentActivity4.NameOfHobby} was recorded!");
                                            Console.WriteLine($"You spent {currentActivity4.TimeSpentOnActivityThisTime.Minutes} minutes  and {currentActivity4.TimeSpentOnActivityThisTime.Seconds} seconds doing your hobby - {currentActivity4.NameOfHobby}!");
                                            Console.ReadLine();
                                            break;
                                        case 5:
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("YOUR STATISTICS:");
                                    int statsChoise = _IUIService.StatisticsMenu();
                                    switch (statsChoise)
                                    {
                                        case 1:
                                            if (_activitiesService.GetActivities().Count == 0)
                                            {
                                                Console.WriteLine("You have no such activities yet in the app!");

                                            }
                                            else
                                            {
                                                List<Reading> allReadings = _activitiesService.GetActivities()
                                                                                        .Where(x => x.UserDoingActivityId == _activeUser.Id)
                                                                                       .Where(x => x.TypeOfActivity == ActivityType.Reading)
                                                                                       .Cast<Reading>()
                                                                                       .ToList();
                                                if (allReadings.Count() == 0)
                                                {
                                                    Console.WriteLine("You have no such activities yet in the app!");
                                                }
                                                else
                                                {
                                                    List<TimeSpan> allTS = allReadings
                                                                         .Select(x => x.TimeSpentOnActivityThisTime)
                                                                         .ToList();
                                                    TimeSpan totalH = new TimeSpan(allTS.Sum(x => x.Ticks));
                                                    int totalPages = allReadings.Select(x => x.Pages).Sum();
                                                    int maxFavouriteType = allReadings.GroupBy(x => x.TypeOfBook)
                                                                                   .Select(x => x.Count())
                                                                                   .Max();
                                                    List<ReadingType> favoriteType = allReadings.GroupBy(x => x.TypeOfBook)
                                                                                 .Where(x => x.Count() == maxFavouriteType)
                                                                                 .Select(x => x.Key)
                                                                                 .ToList();
                                                    TimeSpan averageOfActivity = new TimeSpan(Convert.ToInt64(allTS.Average(x => x.Ticks)));



                                                    Console.Clear();
                                                    Console.WriteLine("READING");
                                                    Console.WriteLine();


                                                    Console.WriteLine($"-> Total time (in hours)  spend on reading is {totalH.TotalHours} hours!");
                                                    Console.WriteLine();

                                                    Console.WriteLine($"-> Average of all reading activity records is {averageOfActivity.TotalHours}( in hours )!");
                                                    Console.WriteLine();
                                                    Console.WriteLine($"-> The total number of pages read is {totalPages} pages!");
                                                    Console.WriteLine();
                                                    if (favoriteType.Count == 1) Console.WriteLine("-> Your Favorie Reading Genre is: ");
                                                    else Console.WriteLine($"-> Your Favorite Reading Genres are:");
                                                    favoriteType.ForEach(x => Console.WriteLine($" - {x}"));
                                                }
                                            
                                            }
                                            Console.ReadLine();

                                            break;
                                        case 2:
                                            if (_activitiesService.GetActivities().Count == 0)
                                            {
                                                Console.WriteLine("You have no such activities yet in the app!");

                                            }
                                            else
                                            {
                                                List<Exercising> allExercising = _activitiesService.GetActivities()
                                                                                      .Where(x => x.UserDoingActivityId == _activeUser.Id)
                                                                                      .Where(x => x.TypeOfActivity == ActivityType.Exercising)
                                                                                      .Cast<Exercising>()
                                                                                      .ToList();
                                                if (allExercising.Count == 0)
                                                {
                                                    Console.WriteLine("You have no such activities yet in the app!");

                                                }
                                                else
                                                {
                                                    List<TimeSpan> allTS2 = allExercising
                                                                                                                             .Select(x => x.TimeSpentOnActivityThisTime)
                                                                                                                             .ToList();
                                                    TimeSpan totalH2 = new TimeSpan(allTS2.Sum(x => x.Ticks));

                                                    int maxFavouriteType2 = allExercising.GroupBy(x => x.TypeOfExercise)
                                                                                   .Select(x => x.Count())
                                                                                   .Max();
                                                    List<ExercisingType> favoriteType2 = allExercising.GroupBy(x => x.TypeOfExercise)
                                                                                 .Where(x => x.Count() == maxFavouriteType2)
                                                                                 .Select(x => x.Key)
                                                                                 .ToList();
                                                    TimeSpan averageOfActivity2 = new TimeSpan(Convert.ToInt64(allTS2.Average(x => x.Ticks)));



                                                    Console.Clear();
                                                    Console.WriteLine("EXERCISING:");
                                                    Console.WriteLine();
                                                    Console.WriteLine($"-> Total time (in hours)  spend on exercising is {totalH2.TotalHours} hours!");
                                                    Console.WriteLine();

                                                    Console.WriteLine($"-> Average of all exercising activity records is {averageOfActivity2.TotalMinutes}( in minutes )!");

                                                    Console.WriteLine();
                                                    if (favoriteType2.Count == 1) Console.WriteLine("-> Your Favorite Exercising Activity is: ");
                                                    else Console.WriteLine($"-> Your Favorite Exercising Activities are: are:");
                                                    favoriteType2.ForEach(x => Console.WriteLine($" - {x}"));
                                                }
                                                
                                                
                                            }
                                               
                                             Console.ReadLine();
                                            break;
                                        case 3:
                                            if (_activitiesService.GetActivities().Count == 0)
                                            {
                                                Console.WriteLine("You have no such activities yet in the app!");

                                            }
                                            else
                                            {
                                                List<Working> allWorking = _activitiesService.GetActivities()
                                                                                    .Where(x => x.UserDoingActivityId == _activeUser.Id)
                                                                                    .Where(x => x.TypeOfActivity == ActivityType.Working)
                                                                                    .Cast<Working>()
                                                                                    .ToList();
                                                if (allWorking.Count==0)
                                                {
                                                    Console.WriteLine("You have no such activities yet in the app!");

                                                }
                                                else
                                                {
                                                  
                                                    List<TimeSpan> allTS3 = allWorking
                                                                             .Select(x => x.TimeSpentOnActivityThisTime)
                                                                             .ToList();
                                                    TimeSpan totalH3 = new TimeSpan(allTS3.Sum(x => x.Ticks));


                                                    TimeSpan averageOfActivity3 = new TimeSpan(Convert.ToInt64(allTS3.Average(x => x.Ticks)));

                                                    List<TimeSpan> timeWorkingHome = allWorking.Where(x => x.TypeOfWorking == WorkinType.FromHome)
                                                                                       .Select(x => x.TimeSpentOnActivityThisTime)
                                                                                       .ToList();
                                                    List<TimeSpan> timeWorkingOffice = allWorking.Where(x => x.TypeOfWorking == WorkinType.AtOffice)
                                                                                       .Select(x => x.TimeSpentOnActivityThisTime)
                                                                                       .ToList();
                                                    TimeSpan ttlTimeHome = new TimeSpan(timeWorkingHome.Sum(x => x.Ticks));
                                                    TimeSpan ttlTimeOffice = new TimeSpan(timeWorkingOffice.Sum(x => x.Ticks));
                                                    Console.Clear();
                                                    Console.WriteLine("WORKING:");
                                                    Console.WriteLine();
                                                    Console.WriteLine($"-> Total time (in hours)  spend on WORKING is {totalH3.TotalHours} hours!");
                                                    Console.WriteLine();
                                                    Console.WriteLine($"-> Average of all working records is {averageOfActivity3.TotalHours}( in hours )!");
                                                    Console.WriteLine();
                                                    Console.WriteLine($"-> Total time working from home in hours is {ttlTimeHome.TotalHours}h.");
                                                    Console.WriteLine();
                                                    Console.WriteLine($"-> Total time working from the office in hours is {ttlTimeOffice.TotalHours}h.");
                                                }
                                            }
                                               
                                            Console.ReadLine();
                                            break;
                                        case 4:
                                            if (_activitiesService.GetActivities().Count == 0)
                                            {
                                                Console.WriteLine("You have no such activities yet in the app!");

                                            }
                                            else
                                            {
                                                List<OtherHobies> allOtherHobbies = _activitiesService.GetActivities()
                                                                                                      .Where(x => x.UserDoingActivityId == _activeUser.Id)
                                                                                                      .Where(x => x.TypeOfActivity == ActivityType.OtherHobbies)
                                                                                                      .Cast<OtherHobies>()
                                                                                                      .ToList();

                                                if (allOtherHobbies.Count==0)
                                                {
                                                    Console.WriteLine("You have no such activities yet in the app!");

                                                }
                                                else
                                                {
                                                                                                                                 
                                                    List<TimeSpan> allTS4 = allOtherHobbies
                                                                             .Select(x => x.TimeSpentOnActivityThisTime)
                                                                             .ToList();
                                                    TimeSpan totalH4 = new TimeSpan(allTS4.Sum(x => x.Ticks));
                                                    List<string> hobbiesNames = allOtherHobbies.Select(x => x.NameOfHobby)
                                                                                            .Distinct()
                                                                                            .ToList();
                                                    Console.Clear();
                                                    Console.WriteLine("OTHER HOBBIES:");
                                                    Console.WriteLine();
                                                    Console.WriteLine($"-> Total time (in hours)  spend on All Other Hobbies is {totalH4.TotalHours} hours!");
                                                    Console.WriteLine();
                                                    Console.WriteLine("These are all the hobbies you have been doing so far:");
                                                    for (int i = 0; i < hobbiesNames.Count(); i++)
                                                    {
                                                        Console.WriteLine($"- {i + 1}) {hobbiesNames[i]}");
                                                    }
                                                }
                                            }
                                               
                                            Console.ReadLine();
                                            break;

                                        case 5:
                                            if (_activitiesService.GetActivities().Where(x=>x.UserDoingActivityId==_activeUser.Id).ToList().Count==0)
                                            {
                                                Console.WriteLine("You have no activities yet in the app!");

                                            }
                                            else
                                            {
                                                List<Activity> allActivities = _activitiesService.GetActivities()
                                                                                              .Where(x => x.UserDoingActivityId == _activeUser.Id)
                                                                                              .Cast<Activity>()
                                                                                              .ToList();
                                                List<TimeSpan> allTS5 = allActivities
                                                                        .Select(x => x.TimeSpentOnActivityThisTime)
                                                                        .ToList();
                                                TimeSpan totalH5 = new TimeSpan(allTS5.Sum(x => x.Ticks));
                                                TimeSpan maxTImeActivity = allActivities.Select(x => x.TimeSpentOnActivityThisTime)
                                                                                      .ToList()
                                                                                      .Max();
                                                List<Activity> favoriteActvity = allActivities.Where(x => x.TimeSpentOnActivityThisTime == maxTImeActivity)
                                                                                      .ToList();
                                                Console.Clear();
                                                Console.WriteLine("GLOBAL:");
                                                Console.WriteLine();
                                                Console.WriteLine($"-> Total time of all your activites is {totalH5.TotalHours} hours!");
                                                Console.WriteLine();
                                                if (favoriteActvity.Count() == 1) Console.WriteLine($"-> It seems like your favourite activity is {favoriteActvity[0].TypeOfActivity}");
                                                else
                                                {
                                                    Console.WriteLine($"-> It seems like your favourite activities are:");
                                                    favoriteActvity.ForEach(x => Console.WriteLine(x.TypeOfActivity));
                                                }
                                                Console.WriteLine();
                                                Console.WriteLine($"-> As you have spent in total {favoriteActvity[0].TimeSpentOnActivityThisTime.TotalHours} hours doing it!");
                                            }
                                            Console.ReadLine();
                                            break;
                                    }

                                    break;
                                case 3:
                                    int accountChoise=_IUIService.AccountMenu();
                                    switch (accountChoise)
                                    {
                                        case 1:
                                            Console.Clear();
                                            Console.WriteLine("Enter old password:");
                                            string oldPass = Console.ReadLine();
                                            Console.WriteLine("Enter new password:");
                                            string newPass = Console.ReadLine();
                                            _userUserService.ChangePassword(_activeUser, oldPass, newPass);
                                            break;
                                        case 2:
                                            Console.Clear();
                                            Console.WriteLine("Enter new First Name:");
                                            string firstName = Console.ReadLine();
                                            Console.WriteLine("Enter new Last Name:");
                                            string lastName = Console.ReadLine();
                                            _userUserService.ChangeInfo(_activeUser, firstName, lastName);
                                            break;
                                        case 3:
                                            _userUserService.DeActivateAcount(_activeUser);
                                            break;
                                        case 4:
                                            break;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    
                }

 
            }
           

        }
    }
}
