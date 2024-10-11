using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
namespace DVLD_businessLayer
{
    public class clsApplications
    {
       public enum enMode { AddNew=0,Update=1};
        public enum enApplicationType { NewLocalDrivingLicense=1, RenewDrivingLicense=2, ReplacementLostDrivingLicense=3,
            ReplacementDamagedDrivingLicense=4, ReleaseDetainedDrivingLicsense=5, NewInternationalLicense=6,RetakeTest=7   };
        public enum enApplicationStatus {New=1,Cancelled=2,Completed=3 };
      public  enMode Mode=enMode.AddNew;
        public int ApplicationID { get; set; }
        public int ApplicationPersonID { get; set; }
        public string ApplicantFullName { get { return clsPerson.Find(ApplicationPersonID).FullName; } }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public clsApplicationsType ApplicationsTypeInfo;
        public enApplicationStatus ApplicationStatus { get; set; }
        public string StatusString
        { 
            get
            {
                switch(ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                     default:
                        return "UnKnown";




                }
                
            }
        }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }

        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo;

        public clsApplications()
        {
            ApplicationID = -1;
            ApplicationPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = -1;
            ApplicationStatus=enApplicationStatus.New;
            LastStatusDate=DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;

        }
        private 

    }
}
