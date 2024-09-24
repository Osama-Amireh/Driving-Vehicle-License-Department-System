using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks; 
namespace DVLDClasses
{
    public class clsValidate
    {
        public static bool ValidateEmail(string emailAddress)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(emailAddress);
        }
        static public bool ValidateInteger(char c)
        {
            var regex = new Regex(@"[^0-9\b]");
            if (regex.IsMatch(c.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
