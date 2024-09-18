using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
namespace DVLD_businessLayer
{
    public class clsCountries
    {
        public int CountryID
        { get; set; }
        public string CountryName { get; set; }
        public static DataTable GetAllCountries()
        {

            return clsCountriesData.GetAllCountries();
        }
        clsCountries(int countryID, string countryName)
        {
            CountryID = countryID;
            CountryName = countryName;
        }

        public static clsCountries Find(int countryID)
        {
            string countryName = "";
            if (clsCountriesData.GetCountryInfoByID(countryID, ref countryName))
            {
                return new clsCountries(countryID, countryName);

            }
            else
            {
                return null;
            }


        }
        public static clsCountries Find(string countryName)
        {
            int countryID = -1;
            if (clsCountriesData.GetCountryInfoByName(ref countryID, countryName))
            {
                return new clsCountries(countryID, countryName);

            }
            else
            {
                return null;
            }


        }
    }
}
