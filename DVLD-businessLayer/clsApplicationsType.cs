using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_businessLayer
{
    public class clsApplicationsType
    {
        public int ID { get; set; }
        public Decimal Fee { get; set; }
        public string ApplicaionTitle { get; set; }
        enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

     public  clsApplicationsType()
        {
            ID = -1;
            Fee = 0;
            ApplicaionTitle = "";
            _Mode=enMode.AddNew;
        }
        private clsApplicationsType(int iD, Decimal fee, string applicaionTitle)
        {
            ID = iD;
            Fee = fee;
            ApplicaionTitle = applicaionTitle;
            _Mode = enMode.Update;
        }

        public static DataTable  GetApllictions()
        {
            return clsApplicaionsTypeData.GetApllictions();

        }
        private  bool _UpdateApplication()
        {
            return clsApplicaionsTypeData.UpdateApplication(this.ID,this.ApplicaionTitle,this.Fee);
        }
        public static clsApplicationsType Find(int ID)
        {
            string Title = ""; Decimal Fee = 0;
            if(clsApplicaionsTypeData.Find(ID,ref Title,ref Fee))
            {
                return new clsApplicationsType(ID,Fee,Title);
            }
            else
            {
                return null;
            }
        }
        public  bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        return false;
                        break;
                    }
                case enMode.Update:
                    {
                        return _UpdateApplication();
                    }

            }
            return false;
        }
    }
}
