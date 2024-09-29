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

        public static DataTable GetAllLicenseClass()
        {
            return clsLicenseClassesData.GetAllLicenseClass();
        }
    }
}
