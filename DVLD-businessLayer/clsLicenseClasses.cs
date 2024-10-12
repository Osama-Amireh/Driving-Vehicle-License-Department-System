using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
namespace DVLD_businessLayer
{
    public class clsLicenseClasses
    {
        public int LicenseClassID { get; set; }
        public string LicenseName { get; set; }
        public string LicenseDescription { get; set; }
        public  int MinimumAllowedAge { get; set; }
        public int DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }
        public enum enMode { AddNew = 0, Update = 1 };

        enMode Mode= enMode.AddNew;
        public clsLicenseClasses()
        {
            LicenseClassID = -1;
            LicenseName = "";
            LicenseDescription = "";
            MinimumAllowedAge = 18;
            DefaultValidityLength = -1;
            ClassFees = 0;
            Mode = enMode.AddNew;
        }
        private clsLicenseClasses(int licenseClassID, string licenseName, string licenseDescription, int minimumAllowedAge, int defaultValidityLength, float classFees)
        {
            LicenseClassID = licenseClassID;
            LicenseName = licenseName;
            LicenseDescription = licenseDescription;
            MinimumAllowedAge = minimumAllowedAge;
            DefaultValidityLength = defaultValidityLength;
            ClassFees = classFees;
            Mode = enMode.Update;
        }

        public static DataTable GetAllLicenseClass()
        {
            return clsLicenseClassesData.GetAllLicenseClass();
        }
        public static clsLicenseClasses Find(int id)
        {
            string LicenseName = "", LicenseDescription = "";
            int MinimumAllowedAge=18, DefaultValidityLength= -1;
            float ClassFees = 0;
            if (clsLicenseClassesData.GetLicenseClassInfoByID(id, ref LicenseName, ref LicenseDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
            {
                return new clsLicenseClasses(id, LicenseName, LicenseDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            else
            {
                return null;
            }
        }
        public static clsLicenseClasses Find(string LicenseName)
        {
            string LicenseDescription = "";
            int ID=-1, MinimumAllowedAge = 18, DefaultValidityLength = -1;
            float ClassFees = 0;
            if (clsLicenseClassesData.GetLicenseClassInfoByName( ref ID,  LicenseName, ref LicenseDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
            {
                return new clsLicenseClasses(ID, LicenseName, LicenseDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            else
            {
                return null;
            }
        }
    }
}
