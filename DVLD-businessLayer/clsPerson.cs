using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
namespace DVLD_businessLayer
{
    public class clsPerson
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public byte Gender { get; set; }
        public string NationalNo { get; set; }
        public DateTime BirthOfDate { get; set; }
        public int Nationality { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FullName { get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; } }
        public string ImagePath { get; set; }
        public string Address { get; set; }

        public enum enMode { AddNew = 1, Update = 2 };
        private enMode _Mode = enMode.AddNew;

        public clsPerson()
        {
            PersonID = -1;
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            Gender = 0;
            Nationality = -1;
            NationalNo = "";
            BirthOfDate = DateTime.Now;
            Email = "";
            Phone = "";
            ImagePath = "";
            Address = "";
            _Mode = enMode.AddNew;
        }
        private clsPerson(int personID, string firstName, string secondName, string thirdName, string lastName, byte gender, string nationalNo, DateTime birthOfDate, int nationality, string email, string phone, string imagePath, string address)
        {
            PersonID = personID;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            Gender = gender;
            NationalNo = nationalNo;
            BirthOfDate = birthOfDate;
            Nationality = nationality;
            Email = email;
            Phone = phone;
            this.ImagePath = imagePath;

            _Mode = enMode.Update;
            Address = address;
        }
        public static DataTable GetAllPeople()
        {

            return clsPersonData.GetAllPeople();
        }
        public static bool IsNationalNoExisit(string nationalNo)
        {
            return clsPersonData.IsPersonExist(nationalNo);

        }
        public static bool IsPersonIDExisit(int PersonID)
        {
            return clsPersonData.IsPersonExist(PersonID);

        }
        public static bool IsEmailExisit(string Email)
        {
            return clsPersonData.IsEmailExisit(Email);

        }
        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.Gender, this.Phone, this.Email,
                this.Nationality, this.NationalNo, this.BirthOfDate.Date, this.ImagePath, this.Address);
            return (this.PersonID != -1);

        }
        public static clsPerson Find(int PersonID)
        {
            string FirstName = "", SecondName = "", ThiredName = "", LastName = "", ImagePath = "", Address = "", Phone = "", Email = "", NationalNo = "";
            byte Gender = 0; int Nationality = -1; DateTime BirthOfDate = DateTime.Now;
            if (clsPersonData.FindByPersonID(PersonID, ref FirstName, ref SecondName, ref ThiredName, ref LastName, ref Phone, ref Email
                , ref Nationality, ref NationalNo, ref Gender, ref BirthOfDate, ref ImagePath, ref Address))
            {
                return new clsPerson(PersonID, FirstName, SecondName, ThiredName, LastName, Gender, NationalNo, BirthOfDate, Nationality, Email,
                    Phone, ImagePath, Address);
            }
            else
            {
                return null;
            }


        }
        public static clsPerson Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThiredName = "", LastName = "", ImagePath = "", Address = "", Phone = "", Email = "";int PersonID = -1;
            byte Gender = 0; int Nationality = -1; DateTime BirthOfDate = DateTime.Now;
            if (clsPersonData.FindByNationalNo(ref PersonID, ref FirstName, ref SecondName, ref ThiredName, ref LastName, ref Phone, ref Email
                , ref Nationality, ref NationalNo, ref Gender, ref BirthOfDate, ref ImagePath, ref Address))
            {
                return new clsPerson(PersonID, FirstName, SecondName, ThiredName, LastName, Gender, NationalNo, BirthOfDate, Nationality, Email,
                    Phone, ImagePath, Address);
            }
            else
            {
                return null;
            }


        }
        private bool _UpdatePerson()
        {
            if (clsPersonData.UpdatePerson(this.PersonID, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.Gender, this.Phone, this.Email,
                this.Nationality, this.NationalNo, this.BirthOfDate.Date, this.ImagePath, this.Address))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool Save()
        {


            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }

            


            return false;
        }

        public static bool DeletePerson(int ID)
        {
            if (clsPersonData.DeletePerson(ID))
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
