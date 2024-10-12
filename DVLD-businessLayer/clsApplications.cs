using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
namespace DVLD_businessLayer
{
    public class clsApplications
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enum enApplicationType
        {
            NewLocalDrivingLicense = 1, RenewDrivingLicense = 2, ReplacementLostDrivingLicense = 3,
            ReplacementDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };
        public enMode Mode = enMode.AddNew;
        public int ApplicationID { get; set; }
        public int ApplicationPersonID { get; set; }
        public clsPerson PersonInfo;
        public string ApplicantFullName { get { return clsPerson.Find(ApplicationPersonID).FullName; } }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public clsApplicationsType ApplicationsTypeInfo;
        public enApplicationStatus ApplicationStatus { get; set; }
        public string StatusString
        {
            get
            {
                switch (ApplicationStatus)
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
            ApplicationStatus = enApplicationStatus.New;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            Mode = enMode.AddNew;

        }
        private clsApplications(int applicationID, int applicationPersonID, DateTime ApplicationDate,
            int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            ApplicationID = applicationID;
            ApplicationPersonID = applicationPersonID;
            this.PersonInfo = clsPerson.Find(ApplicationPersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            ApplicationsTypeInfo = clsApplicationsType.Find(ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            CreatedByUserInfo = clsUser.FindUserByID(CreatedByUserID);
            Mode = enMode.Update;

        }

        private bool _AddNewApplication()
        {

            ApplicationID = clsApplicationsData.AddNewApplication(this.ApplicationPersonID, this.ApplicationTypeID,
                this.ApplicationDate, (short)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
            return (ApplicationID != 0);
        }
        private bool _UpdateApplication()
        {
            return clsApplicationsData.UpdateApplication(ApplicationID, this.ApplicationPersonID, this.ApplicationTypeID,
                this.ApplicationDate, (short)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        public static clsApplications FindBaseApplication(int ApplicationID)
        {
            int ApplicationPersonID = -1, ApplicationTypeID = -1, CreatedByUserID = -1;
            short ApplicationStatus = 0; DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now; float PaidFees = 0;

            if (clsApplicationsData.GetApplicationByID(ApplicationID, ref ApplicationPersonID, ref ApplicationTypeID, ref ApplicationDate, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new clsApplications(ApplicationID, ApplicationPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);

            }
            else
            {
                return null;
            }

        }
        public bool Cancel()
        {
            return clsApplicationsData.UpdateSataus(ApplicationID, 2);
        }
        public bool SetCompelete()
        {
            return clsApplicationsData.UpdateSataus(ApplicationID, 3);
        }
        public bool Save()
        {
            switch (Mode)
            {

                case enMode.AddNew:
                    {
                        if (_AddNewApplication())
                        {
                            return true;
                        }
                        return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateApplication();
                    }

            }
            return false;
        }
        public bool Delete()
        {
            return clsApplicationsData.DeleteApplication(ApplicationID);
        }
        public static bool IsApplicationExisit(int ApplicationID)
        {
            return clsApplicationsData.IsApplicationExist(ApplicationID);
        }

        public static bool DosePersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return clsApplicationsData.DosePersonHaveActiveApplication(PersonID, ApplicationTypeID);
        }
        public bool DosePersonHaveActiveApplication(int ApplicationTypeID)
        {
            return clsApplicationsData.DosePersonHaveActiveApplication(ApplicationPersonID, ApplicationTypeID);
        }
        public static int GetActiveApplicationID(int personId, clsApplications.enApplicationType applicationType)
        {
            return clsApplicationsData.GetActiveApplicationID(personId, (int)applicationType);
        }
        public int GetActiveApplicationID( clsApplications.enApplicationType applicationType)
        {
            return clsApplicationsData.GetActiveApplicationID(ApplicationPersonID, (int)applicationType);
        }

        public static int GetActiveApplicationIDForLicenseCalss(int personId, clsApplications.enApplicationType applicationType,int LicenseCalss)
        {
            return clsApplicationsData.GetActiveApplicationIDForLicenseCalss(personId,(int)applicationType, LicenseCalss);
        }




    }
}
