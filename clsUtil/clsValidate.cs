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
