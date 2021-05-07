using System;
using HeroesJoyrneyApp.HeroesJoyrneyEntities.HeroesJourneyModels;
using System.Collections.Generic;

namespace HeroesJoyrneyApp
{
    class Program
    {

        static void Main(string[] args)
        {

                List<Player> allPlayers = new List<Player>()
            {
                new Player("jelena@gmail.com","jelena123","jelena"),
                new Player("marko@gmail.com","marko123","marko")
            };
            Player playerActive=null ;
            bool nameEntered = false;
            bool characterChosen = false;
            bool typeOfCharacterChosen = false;
            Random rnd = new Random();
            bool wantToLogout = false;
            bool wantToPlayAgain = false;

            while (true)
            {
                #region LoginVerifier
                Console.WriteLine("Welcome to The Heroes Journey App!");
                Console.WriteLine("In order to login and play");
                Console.WriteLine("Please enter your email!");
                if (playerActive == null)
                {
                    string email = Console.ReadLine();
                    Console.WriteLine("Please enter your password!");
                    string password = Console.ReadLine();
                    foreach (Player player in allPlayers)
                    {
                        if (player.Email == email && player.Password == password)
                        {
                            Console.WriteLine($"{player.Name} you have successflully loged in!");
                            playerActive = player;
                            break;
                        }
                    }
                    if (playerActive == null || email=="" || password=="" || !email.Contains("@") || !email.Contains("."))
                    {
                        Console.Clear();
                        Console.WriteLine("Error in login, please try again to login!");
                        continue;
                    }
                }
                #endregion

                if (!nameEntered)
                {
                    #region SelecName
                    Console.Clear();
                    Console.WriteLine($"Last time you played HeroesJourney you used '{playerActive.Name.ToUpper()}' for your character!");
                    Console.WriteLine("Press 1 ----> to keep this name!");
                    Console.WriteLine("Press 2 ----> to change the name!");
                    Console.WriteLine();
                    string userChoise = Console.ReadLine();
                    if (userChoise == "1")
                    {
                        Console.Clear();
                        Console.WriteLine($"That's great {playerActive.Name}");
                    }
                    if (userChoise == "2")
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter the name of your character!");
                            Console.WriteLine("*** it can not be only one letter or longer than 20 characters! ");
                            string playerName = Console.ReadLine();
                            if (playerName.Length > 1 && playerName.Length <= 20)
                            {
                                playerActive.Name = playerName;
                                Console.Clear();
                                Console.WriteLine($"Excelent the name of your player {playerActive.Name.ToUpper()} is setted! ");
                                break;
                            }
                        }
                    }
                    if (userChoise != "1" && userChoise != "2") continue;
                    nameEntered = true;
                    #endregion
                }


                Console.Clear();  
                Console.WriteLine();
                while (!characterChosen)
                {
                    #region ChooseCharacter
                    Console.WriteLine($"Let's set your strenghts {playerActive.Name.ToUpper()} before you start playing!");
                    Console.WriteLine("Please choose one of the 3 races for your character!");
                    Console.WriteLine();
                    Console.WriteLine("Press 1 for ---> Dwarf");
                    Console.WriteLine("He has 100 Health!");
                    Console.WriteLine("He has 6 Strenght!");
                    Console.WriteLine("He has 2 Agility!");
                    Console.WriteLine();
                    Console.WriteLine("Press 2 for ---> Elf");
                    Console.WriteLine("He has 60 Health!");
                    Console.WriteLine("He has 4 Strenght!");
                    Console.WriteLine("He has 6 Agility!");
                    Console.WriteLine();
                    Console.WriteLine("Press 3 for ---> Human");
                    Console.WriteLine("He has 80 Health!");
                    Console.WriteLine("He has 5 Strenght!");
                    Console.WriteLine("He has 4 Agility!");
                    string userRace = Console.ReadLine();
                    if (userRace == "1")
                    {
                        Console.Clear();
                        Console.WriteLine($"Perfect {playerActive.Name.ToUpper()}, you chose Dwarf for you character");
                        playerActive.CreateDwarf();
                        playerActive.Race = "Dwarf";
                        characterChosen = true;
                        break;
                    }
                    else if (userRace == "2")
                    {
                        Console.Clear();
                        Console.WriteLine($"Perfect {playerActive.Name.ToUpper() }, you chose Elf for you character");
                        playerActive.CreateElf();
                        playerActive.Race = "Elf";
                        characterChosen = true;
                        break;
                    }
                    else if (userRace == "3")
                    {
                        Console.Clear();
                        Console.WriteLine($"Perfect {playerActive.Name.ToUpper()}, you chose Human for you character");
                        playerActive.CreateHuman();
                        playerActive.Race = "Human";
                        characterChosen = true;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Error, please choose only from the given oprions!");
                        continue;
                    }
                    #endregion
                }

                while (!typeOfCharacterChosen)
                {
                    #region ChooseTypeOfCharacter
                    Console.WriteLine();
                    Console.WriteLine($"Now it is time to choose the the profile of your {playerActive.Race}!");
                    Console.WriteLine($"Please choose one of the 3 profiles for your {playerActive.Race}!");
                    Console.WriteLine();
                    Console.WriteLine("Press 1 for ---> Warrior");
                    Console.WriteLine("+20 Health");
                    Console.WriteLine("-1 Agillity");
                    Console.WriteLine();
                    Console.WriteLine("Press 2 for ---> Rogue");
                    Console.WriteLine("-20 Health");
                    Console.WriteLine("+1 Agillity");
                    Console.WriteLine();
                    Console.WriteLine("Press 3 for ---> Mage");
                    Console.WriteLine("+20 Health");
                    Console.WriteLine("-1 Strength");
                    Console.WriteLine();
                    string userProfile = Console.ReadLine();
                    if (userProfile == "1")
                    {
                        playerActive.BecomeWarrior();
                        playerActive.Type = "Warrior";
                        typeOfCharacterChosen = true;
                        Console.WriteLine($"Great your {playerActive.Race} is {playerActive.Type}!");
                    }
                    if (userProfile == "2")
                    {
                        playerActive.BecomeRogue();
                        playerActive.Type = "Rogue";
                        typeOfCharacterChosen = true;
                        Console.WriteLine($"Great your {playerActive.Race} is {playerActive.Type}!");
                    }
                    if (userProfile == "3")
                    {
                        playerActive.BecomeMage();
                        playerActive.Type = "Mage";
                        typeOfCharacterChosen = true;
                        Console.WriteLine($"Great your {playerActive.Race} is {playerActive.Type}!");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Please select only from the given options!");
                    }
                    #endregion
                }
                Console.Clear();
                Console.WriteLine($"That's excelent {playerActive.Name.ToUpper()}, now just a short reveiw of your character and you can start playing!");
                Console.WriteLine($"{playerActive.Name.ToUpper()} ({playerActive.Race}) - The {playerActive.Type}");
                Console.WriteLine($"Statistics: HEALTH:{playerActive.Health}, STRENGTH:{playerActive.Strength}, AGILITY:{playerActive.Agility}");
                Console.WriteLine();
                Console.WriteLine("Please press ENTER to start playing!");
                if (Console.ReadLine() != "") continue;

                while (true)
                {
                    wantToPlayAgain = false;
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("LEVEL 1");
                    Console.WriteLine("Bandits attack you out of nowhere. They seem very dangerous...");
                    Console.WriteLine("Press 1 ---->  to fight!");
                    Console.WriteLine("Press 2 ---->  to runaway!");
                    Console.WriteLine();
                    Console.WriteLine($"Statistics: HEALTH:{playerActive.Health}, STRENGTH:{playerActive.Strength}, AGILITY:{playerActive.Agility}");
                    string userDecision = Console.ReadLine();
                    if (userDecision != "1" && userDecision!="2") continue;
                    int neededNumber = rnd.Next(1, 10);
                    switch (userDecision)
                    {
                        case "1":
                            if (playerActive.Strength <= neededNumber)
                            {
                                playerActive.Health -= 20;
                                Console.WriteLine($"These bandits were really strong with strenght {neededNumber}, and you lost!");
                                Console.WriteLine("- 20 Health!");
                            }
                            else
                            {
                                Console.WriteLine($"These bandits were really strong with strenght {neededNumber}, but you were stronger and you won!");
                            }
                            break;
                        case "2":
                            if (playerActive.Agility <= neededNumber)
                            {
                                playerActive.Health -= 20;
                                Console.WriteLine($"These bandits were really fast with agility {neededNumber}, and you lost!");
                                Console.WriteLine("- 20 Health!");
                            }
                            else
                            {
                                Console.WriteLine($"These bandits were really fast with agility {neededNumber}, but you were faster and you won!");
                            }
                            break;

                    }
                    Console.WriteLine();
                    Console.WriteLine("Check your updated stats!");
                    Console.WriteLine($"Statistics: HEALTH:{playerActive.Health}, STRENGTH:{playerActive.Strength}, AGILITY:{playerActive.Agility}");
                    break;
                }
                while (true)
                {
                    Console.WriteLine("Press ENTER to go on the next level!");
                    if (Console.ReadLine() == "") break;
                }
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("LEVEL 2");
                    Console.WriteLine("You bump in to one of the guards of the nearby village. They attack you without warning...");
                    Console.WriteLine("Press 1 ---->  to fight!");
                    Console.WriteLine("Press 2 ---->  to runaway!");
                    Console.WriteLine();
                    Console.WriteLine($"Statistics: HEALTH:{playerActive.Health}, STRENGTH:{playerActive.Strength}, AGILITY:{playerActive.Agility}");
                    string userDecision = Console.ReadLine();
                    if (userDecision != "1" && userDecision != "2") continue;
                    int neededNumber = rnd.Next(1, 10);
                    switch (userDecision)
                    {
                        case "1":
                            if (playerActive.Strength <= neededNumber)
                            {
                                playerActive.Health -= 30;
                                Console.WriteLine($"These guards were really strong with strenght {neededNumber}, and you lost!");
                                Console.WriteLine("- 30 Health!");
                            }
                            else
                            {
                                Console.WriteLine($"These guards were really strong with strenght {neededNumber}, but you were stronger and you won!");
                            }
                            break;
                        case "2":
                            if (playerActive.Agility <= neededNumber)
                            {
                                playerActive.Health -= 30;
                                Console.WriteLine($"These guards were really fast with agility {neededNumber}, and you lost!");
                                Console.WriteLine("- 30 Health!");
                            }
                            else
                            {
                                Console.WriteLine($"These guards were really fast with agility {neededNumber}, but you were faster and you won!");
                            }
                            break;

                    }
                    Console.WriteLine();
                    if (playerActive.Health > 0)
                    {
                        Console.WriteLine("Check your updated stats!");
                        Console.WriteLine($"Statistics: HEALTH:{playerActive.Health}, STRENGTH:{playerActive.Strength}, AGILITY:{playerActive.Agility}");
                        break;
                    }
                    else
                    {
                        while (true)
                        {
                            //
                            Console.WriteLine($"{playerActive.Name.ToUpper()} ({playerActive.Race}) - the {playerActive.Type} you lost all your health!");
                            Console.WriteLine();
                            Console.WriteLine("Press 1 ---- to play again!");
                            Console.WriteLine("Press 2 ---- to logout!");
                            string userPreference = Console.ReadLine();
                            if (userPreference != "1" && userPreference != "2") continue;
                            if (userPreference == "2")
                            {
                                wantToLogout = true;
                                break;
                            }
                            if (userPreference == "1")
                            {
                                wantToPlayAgain = true;
                                playerActive.Health = 0;
                                playerActive.Agility = 0;
                                playerActive.Strength = 0;
                                switch (playerActive.Race)
                                {
                                    case "Dwarf":
                                        playerActive.CreateDwarf();
                                        break;
                                    case "Elf":
                                        playerActive.CreateElf();
                                        break;
                                    case "Human":
                                        playerActive.CreateHuman();
                                        break;
                                }

                                switch (playerActive.Type)
                                {
                                    case "Warrior":
                                        playerActive.BecomeWarrior();
                                        break;
                                    case "Rogue":
                                        playerActive.BecomeRogue();
                                        break;
                                    case "Mage":
                                        playerActive.BecomeMage();
                                        break;
                                };
                                break;
                            }
                        }
                       

                    }break;

                }
                if (wantToLogout) break;
                if (wantToPlayAgain) continue;

                
                while (true)
                {
                    Console.WriteLine("Press ENTER to go on the next level!");
                    if (Console.ReadLine() == "") break;
                }
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("LEVEL 3");
                    Console.WriteLine("A Land Shark appears. It starts chasing you down to eat you...");
                    Console.WriteLine("Press 1 ---->  to fight!");
                    Console.WriteLine("Press 2 ---->  to runaway!");
                    Console.WriteLine();
                    Console.WriteLine($"Statistics: HEALTH:{playerActive.Health}, STRENGTH:{playerActive.Strength}, AGILITY:{playerActive.Agility}");
                    string userDecision = Console.ReadLine();
                    if (userDecision != "1" && userDecision != "2") continue;
                    int neededNumber = rnd.Next(1, 10);
                    switch (userDecision)
                    {
                        case "1":
                            if (playerActive.Strength <= neededNumber)
                            {
                                playerActive.Health -= 50;
                                Console.WriteLine($"The Land Shark was really strong with strenght {neededNumber}, and you lost!");
                                Console.WriteLine("- 50 Health!");
                            }
                            else
                            {
                                Console.WriteLine($"The Land Shark was really strong with strenght {neededNumber}, but you were stronger and you won!");
                            }
                            break;
                        case "2":
                            if (playerActive.Agility <= neededNumber)
                            {
                                playerActive.Health -= 50;
                                Console.WriteLine($"The Land Shark was really strong with strenght  {neededNumber}, and you lost!");
                                Console.WriteLine("- 50 Health!");
                            }
                            else
                            {
                                Console.WriteLine($"The Land Shark was really strong with strenght {neededNumber}, but you were faster and you won!");
                            }
                            break;

                    }
                    Console.WriteLine();
                    if (playerActive.Health > 0)
                    {
                        Console.WriteLine("Check your updated stats!");
                        Console.WriteLine($"Statistics: HEALTH:{playerActive.Health}, STRENGTH:{playerActive.Strength}, AGILITY:{playerActive.Agility}");
                        break;
                    }
                    else
                    {
                        while (true)
                        {
                            //Console.Clear();
                            Console.WriteLine($"{playerActive.Name.ToUpper()} ({playerActive.Race}) - the {playerActive.Type} you lost all your health!");
                            Console.WriteLine();
                            Console.WriteLine("Press 1 ---- to play again!");
                            Console.WriteLine("Press 2 ---- to logout!");
                            string userPreference = Console.ReadLine();
                            if (userPreference != "1" && userPreference != "2") continue;
                            if (userPreference == "2")
                            {
                                wantToLogout = true;
                                break;
                            }
                            if (userPreference == "1")
                            {
                                wantToPlayAgain = true;
                                playerActive.Health = 0;
                                playerActive.Agility = 0;
                                playerActive.Strength = 0;
                                switch (playerActive.Race)
                                {
                                    case "Dwarf":
                                        playerActive.CreateDwarf();
                                        break;
                                    case "Elf":
                                        playerActive.CreateElf();
                                        break;
                                    case "Human":
                                        playerActive.CreateHuman();
                                        break;
                                }

                                switch (playerActive.Type)
                                {
                                    case "Warrior":
                                        playerActive.BecomeWarrior();
                                        break;
                                    case "Rogue":
                                        playerActive.BecomeRogue();
                                        break;
                                    case "Mage":
                                        playerActive.BecomeMage();
                                        break;
                                };
                                break;
                            }
                        }


                    }break;


                }
                if (wantToLogout) break;
                if (wantToPlayAgain) continue;
                 while (true)
                {
                    Console.WriteLine("Press ENTER to go on the next level!");
                    if (Console.ReadLine() == "") break;
                }
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("LEVEL 3");
                    Console.WriteLine("A Land Shark appears. It starts chasing you down to eat you...");
                    Console.WriteLine("Press 1 ---->  to fight!");
                    Console.WriteLine("Press 2 ---->  to runaway!");
                    Console.WriteLine();
                    Console.WriteLine($"Statistics: HEALTH:{playerActive.Health}, STRENGTH:{playerActive.Strength}, AGILITY:{playerActive.Agility}");
                    string userDecision = Console.ReadLine();
                    if (userDecision != "1" && userDecision != "2") continue;
                    int neededNumber = rnd.Next(1, 10);
                    switch (userDecision)
                    {
                        case "1":
                            if (playerActive.Strength <= neededNumber)
                            {
                                playerActive.Health -= 50;
                                Console.WriteLine($"The Land Shark was really strong with strenght {neededNumber}, and you lost!");
                                Console.WriteLine("- 50 Health!");
                            }
                            else
                            {
                                Console.WriteLine($"The Land Shark was really strong with strenght {neededNumber}, but you were stronger and you won!");
                            }
                            break;
                        case "2":
                            if (playerActive.Agility <= neededNumber)
                            {
                                playerActive.Health -= 50;
                                Console.WriteLine($"The Land Shark was really strong with strenght  {neededNumber}, and you lost!");
                                Console.WriteLine("- 50 Health!");
                            }
                            else
                            {
                                Console.WriteLine($"The Land Shark was really strong with strenght {neededNumber}, but you were faster and you won!");
                            }
                            break;

                    }
                    Console.WriteLine();
                    if (playerActive.Health > 0)
                    {
                        Console.WriteLine("Check your updated stats!");
                        Console.WriteLine($"Statistics: HEALTH:{playerActive.Health}, STRENGTH:{playerActive.Strength}, AGILITY:{playerActive.Agility}");
                        break;
                    }
                    else
                    {
                        while (true)
                        {
                           // Console.Clear();
                            Console.WriteLine($"{playerActive.Name.ToUpper()} ({playerActive.Race}) - the {playerActive.Type} you lost all your health!");
                            Console.WriteLine();
                            Console.WriteLine("Press 1 ---- to play again!");
                            Console.WriteLine("Press 2 ---- to logout!");
                            string userPreference = Console.ReadLine();
                            if (userPreference != "1" && userPreference != "2") continue;
                            if (userPreference == "2")
                            {
                                wantToLogout = true;
                                break;
                            }
                            if (userPreference == "1")
                            {
                                wantToPlayAgain = true;
                                playerActive.Health = 0;
                                playerActive.Agility = 0;
                                playerActive.Strength = 0;
                                switch (playerActive.Race)
                                {
                                    case "Dwarf":
                                        playerActive.CreateDwarf();
                                        break;
                                    case "Elf":
                                        playerActive.CreateElf();
                                        break;
                                    case "Human":
                                        playerActive.CreateHuman();
                                        break;
                                }

                                switch (playerActive.Type)
                                {
                                    case "Warrior":
                                        playerActive.BecomeWarrior();
                                        break;
                                    case "Rogue":
                                        playerActive.BecomeRogue();
                                        break;
                                    case "Mage":
                                        playerActive.BecomeMage();
                                        break;
                                };
                                break;
                            }
                        }


                    }break;


                }
                if (wantToLogout) break;
                if (wantToPlayAgain) continue;
                while (true)
                {
                    Console.WriteLine("Press ENTER to go on the next level!");
                    if (Console.ReadLine() == "") break;
                }
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("LEVEL 4");
                    Console.WriteLine("You accidentally step on a rat. His friends are not happy. They attack...");
                    Console.WriteLine("Press 1 ---->  to fight!");
                    Console.WriteLine("Press 2 ---->  to runaway!");
                    Console.WriteLine();
                    Console.WriteLine($"Statistics: HEALTH:{playerActive.Health}, STRENGTH:{playerActive.Strength}, AGILITY:{playerActive.Agility}");
                    string userDecision = Console.ReadLine();
                    if (userDecision != "1" && userDecision != "2") continue;
                    int neededNumber = rnd.Next(1, 10);
                    switch (userDecision)
                    {
                        case "1":
                            if (playerActive.Strength <= neededNumber)
                            {
                                playerActive.Health -= 10;
                                Console.WriteLine($"The rats were really strong with strenght {neededNumber}, and you lost!");
                                Console.WriteLine("- 10 Health!");
                            }
                            else
                            {
                                Console.WriteLine($"The rats were really strong with strenght {neededNumber}, but you were stronger and you won!");
                            }
                            break;
                        case "2":
                            if (playerActive.Agility <= neededNumber)
                            {
                                playerActive.Health -= 10;
                                Console.WriteLine($"The rats were really strong with strenght  {neededNumber}, and you lost!");
                                Console.WriteLine("- 10 Health!");
                            }
                            else
                            {
                                Console.WriteLine($"The rats were really strong with strenght {neededNumber}, but you were faster and you won!");
                            }
                            break;

                    }
                    Console.WriteLine();
                    if (playerActive.Health > 0)
                    {
                        Console.WriteLine("Check your updated stats!");
                        Console.WriteLine($"Statistics: HEALTH:{playerActive.Health}, STRENGTH:{playerActive.Strength}, AGILITY:{playerActive.Agility}");
                        break;
                    }
                    else
                    {
                        while (true)
                        {
                           // Console.Clear();
                            Console.WriteLine($"{playerActive.Name.ToUpper()} ({playerActive.Race}) - the {playerActive.Type} you lost all your health!");
                            Console.WriteLine();
                            Console.WriteLine("Press 1 ---- to play again!");
                            Console.WriteLine("Press 2 ---- to logout!");
                            string userPreference = Console.ReadLine();
                            if (userPreference != "1" && userPreference != "2") continue;
                            if (userPreference == "2")
                            {
                                wantToLogout = true;
                                break;
                            }
                            if (userPreference == "1")
                            {
                                wantToPlayAgain = true;
                                playerActive.Health = 0;
                                playerActive.Agility = 0;
                                playerActive.Strength = 0;
                                switch (playerActive.Race)
                                {
                                    case "Dwarf":
                                        playerActive.CreateDwarf();
                                        break;
                                    case "Elf":
                                        playerActive.CreateElf();
                                        break;
                                    case "Human":
                                        playerActive.CreateHuman();
                                        break;
                                }

                                switch (playerActive.Type)
                                {
                                    case "Warrior":
                                        playerActive.BecomeWarrior();
                                        break;
                                    case "Rogue":
                                        playerActive.BecomeRogue();
                                        break;
                                    case "Mage":
                                        playerActive.BecomeMage();
                                        break;
                                };
                                break;
                            }
                        }


                    }break;


                }
                if (wantToLogout) break;
                if (wantToPlayAgain) continue;
                while (true)
                {
                    Console.WriteLine("Press ENTER to go on the next level!");
                    if (Console.ReadLine() == "") break;
                }
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("LEVEL 5");
                    Console.WriteLine("You find a huge rock. It comes alive somehow and tries to smash you...");
                    Console.WriteLine("Press 1 ---->  to fight!");
                    Console.WriteLine("Press 2 ---->  to runaway!");
                    Console.WriteLine();
                    Console.WriteLine($"Statistics: HEALTH:{playerActive.Health}, STRENGTH:{playerActive.Strength}, AGILITY:{playerActive.Agility}");
                    string userDecision = Console.ReadLine();
                    if (userDecision != "1" && userDecision != "2") continue;
                    int neededNumber = rnd.Next(1, 10);
                    switch (userDecision)
                    {
                        case "1":
                            if (playerActive.Strength <= neededNumber)
                            {
                                playerActive.Health -= 30;
                                Console.WriteLine($"The rock hit you very strong with strenght {neededNumber}, and you lost!");
                                Console.WriteLine("- 30 Health!");
                            }
                            else
                            {
                                Console.WriteLine($"The rock hit you very strong with strenght {neededNumber}, but you were stronger and you won!");
                            }
                            break;
                        case "2":
                            if (playerActive.Agility <= neededNumber)
                            {
                                playerActive.Health -= 30;
                                Console.WriteLine($"The rock hit you very strong with strenght {neededNumber}, and you lost!");
                                Console.WriteLine("- 30 Health!");
                            }
                            else
                            {
                                Console.WriteLine($"The rock hit you very strong with strenght {neededNumber}, but you were stronger and you won!");
                            }
                            break;

                    }
                    Console.WriteLine();
                    if (playerActive.Health > 0)
                    {
                        Console.WriteLine("Congrats YOU WON YOU WON YOU WON!");
                        Console.WriteLine("Check your updated stats!");
                        Console.WriteLine($"Statistics: HEALTH:{playerActive.Health}, STRENGTH:{playerActive.Strength}, AGILITY:{playerActive.Agility}");
                        
                    }
                    else
                    {
                        Console.WriteLine($"{playerActive.Name.ToUpper()} ({playerActive.Race}) - the {playerActive.Type} you lost all your health!");

                    }
                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Press 1 ---- to play again!");
                        Console.WriteLine("Press 2 ---- to logout!");
                        string userPreference = Console.ReadLine();
                        if (userPreference != "1" && userPreference != "2") continue;
                        if (userPreference == "2")
                        {
                            wantToLogout = true;
                            break;
                        }
                        if (userPreference == "1")
                        {
                            wantToPlayAgain = true;
                            playerActive.Health = 0;
                            playerActive.Agility = 0;
                            playerActive.Strength = 0;
                            switch (playerActive.Race)
                            {
                                case "Dwarf":
                                    playerActive.CreateDwarf();
                                    break;
                                case "Elf":
                                    playerActive.CreateElf();
                                    break;
                                case "Human":
                                    playerActive.CreateHuman();
                                    break;
                            }

                            switch (playerActive.Type)
                            {
                                case "Warrior":
                                    playerActive.BecomeWarrior();
                                    break;
                                case "Rogue":
                                    playerActive.BecomeRogue();
                                    break;
                                case "Mage":
                                    playerActive.BecomeMage();
                                    break;
                            };
                            break;
                        }
                    }
                    if (wantToLogout) break;
                    if (wantToPlayAgain) break;
                  


                }
                if (wantToLogout) break;


            }



        }
    }
}
