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
        private clsUser(int UserID, string UserName, string Password, int personID, bool IsActive)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            this.PersonInfo = clsPerson.Find(personID);
            this.PersonID = personID;
            _Mode
                = enMode.Update;    
        }

        public static DataTable GetAllUers()
        {
            return clsUsersData.GetAllUsers();
        }
        public static clsUser FindUserByID(int UserID)
        {
            {
                string UserName = "", Password = ""; int personID = -1; bool IsActive = false;
                if (clsUsersData.GetUserByID(UserID, ref UserName, ref Password, ref personID, ref IsActive))
                {
                    return new clsUser(UserID, UserName, Password, personID, IsActive);
                }
                else
                { return null; }

            }
        }
        public static bool IsUserExsistForPersonID(int PersonID)
        {
            return clsUsersData.IsUserExsistForPersonID(PersonID);
        }
        public static clsUser FindUserByUserName(string UserName)
        {
            {
                int ID = -1;string  Password = ""; int personID = -1; bool IsActive = false;
                if (clsUsersData.GetUserByUsername(ref ID, ref UserName, ref Password, ref personID, ref IsActive))
                {
                    return new clsUser(ID, UserName, Password, personID, IsActive);
                }
                else
                { return null; }

            }
        }
        public static bool IsUserExsistByID(int ID  )
        {
            return clsUsersData.IsUserExsistByID((int)ID);

        }
        public static bool IsUserExsistByUserName(string Username)
        {
            return clsUsersData.IsUserExsistByUserName(Username);

        }
        private bool _AddNewUser()
        {
            this.UserID = clsUsersData.AddNewUser(this.UserName, this.PersonID, this.Password, this.IsActive);
            return (UserID != -1);


        }
        private bool _UpdateUser()
        {
            return clsUsersData.UpdateUser(UserID, this.UserName, this.Password,this.PersonID, this.IsActive);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewUser())
                        {

                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    {
                        return _UpdateUser();

                    }

            }
            return false;
        }
        public static bool DeleteUser(int UserID)
        {
            return clsUsersData.DeleteUser(UserID);
        }
    }
}
