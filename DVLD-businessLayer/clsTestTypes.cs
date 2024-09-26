using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_businessLayer
{
    public class clsTestTypes
    {
        public int TestID { get; set; }
        public string TestName { get; set; }
        public string Description { get; set; }
        public Decimal TestFee { get; set; }
        enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        clsTestTypes()
        {

            TestID = 0;
            TestName = "";
            Description = "";
            TestFee = -1;
            _Mode = enMode.AddNew;
        }
        clsTestTypes(int testID, string testName, string description, decimal testFee)
        {
            TestID = testID;
            TestName = testName;
            Description = description;
            TestFee = testFee;
            _Mode = enMode.Update;
        }
        public static DataTable GetAllTypes()
        {
            return clsTestTypesData.GetAllTests();
        }
        public static clsTestTypes Find(int testID)
        {
            string Title = "", Descrtion = ""; decimal Fee = -1;
            if (clsTestTypesData.Find(testID, ref Title, ref Descrtion, ref Fee))
            {
                return new clsTestTypes(testID, Title, Descrtion, Fee);
            }
            else
            {
                return null;
            }

        }

        private bool _UpdateTest()
        {
            return clsTestTypesData.UpdateTest(this.TestID, this.TestName, this.Description, this.TestFee);
        }

        public bool save()
        {
            switch (_Mode)
            {
                case enMode.Update:
                    {

                        return _UpdateTest();
                    }
            }
            return false;

        }
    }
}
