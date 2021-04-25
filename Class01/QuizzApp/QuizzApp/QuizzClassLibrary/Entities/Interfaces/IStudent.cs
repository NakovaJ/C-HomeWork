using System;
using System.Collections.Generic;
using System.Text;

namespace QuizzClassLibrary.Entities.Interfaces
{
    public interface IStudent
    {
        public void StudentAlreadyOnceLoggedIn();
        public void QuizzResults(int result);
       
    }
}
