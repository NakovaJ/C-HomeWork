using System;
using System.Collections.Generic;
using System.Text;
using QuizzMillioner.Entities.Models;

namespace QuizzMillioner.Entities.Interfaces
{
    public interface IHelp
    {
        void UseHelpFriend(Question currentQuestion);
        void UseHelpFiftyFifty(Question currentQuestion);
        void UseHelpAudience(Question curentQuestion);
    }
}
