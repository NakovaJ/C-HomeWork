using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTracking.Services.Interfaces
{
    public interface IUIService
    {
        List<string> MainMenuItems { get; set; }
        public List<string> AccountMenuItems { get; set; }

        void WelcomeToApp();
        int LoginRegisterMenu();
        public int ChooseMenu<T>(List<T> items);
        public int MainMenu();
        public int AccountMenu();
        public int ActivitiesMenu();
        public int ReadingTypes();
        public int ExerciseTypes();
        public int WorkingPlace();
        public int StatisticsMenu();





    }
}
