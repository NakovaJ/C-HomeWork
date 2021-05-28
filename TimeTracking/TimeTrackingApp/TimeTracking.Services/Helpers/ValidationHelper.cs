using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTracking.Services.Helpers
{
    public static class ValidationHelper
    {
		public static string ValidatePassword(string password)
		{
			if (password.Length < 6) return null;
			int num;
			bool isNum = false;
			foreach (char item in password)
			{
				isNum = int.TryParse(item.ToString(), out num);
			}
			if (!isNum) return null;
			if (!password.Any(char.IsUpper)) return null;
			return password;
		}
        public static string ValidateIfContainsDigits(string str,int no)
        {
			if (str.Length < no) return null;

			int num;
			bool isNum = false;
			foreach (char item in str)
			{
				isNum = int.TryParse(item.ToString(), out num);
			}
			if (isNum) return null;
			return str;

		}
        public static int ValidateNumber(string number, int rangeStart, int rangeEnd)
		{
			int num = 0;
			bool isNumber = int.TryParse(number, out num);
			if (!isNumber) return -1;
			if (num <= rangeStart || num > rangeEnd) return -1;
			return num;
		}
		public static string ValidateString(string str,int no)
		{
			if (str.Length < no) return null;
		
			return str;
		}
	}
}
