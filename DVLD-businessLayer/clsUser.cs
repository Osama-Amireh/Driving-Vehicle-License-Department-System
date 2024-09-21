using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
namespace DVLD_businessLayer
{
    public class clsUser
    {
        public int UserID;
        public string UserName;
        public string Password;
        public bool IsActive;
        public clsPerson PersonInfo;
        public int PersonID;
        public enum enMode { AddNew = 1, Update = 2 };
        private enMode _Mode = enMode.AddNew;
        public clsUser()
        {
            UserID = -1;
            UserName = "";
            Password = "";
            IsActive = false;
            PersonInfo = new clsPerson();
            PersonID = -1;
        }
        private clsUser(int UserID, string UserName, string Password,int personID,bool IsActive)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            this.PersonInfo =  clsPerson.Find(personID);
            this.PersonID = personID;
        }

        public static DataTable GetAllUers()
        {
         return clsUsersData.GetAllUsers();
        }
    }
}
