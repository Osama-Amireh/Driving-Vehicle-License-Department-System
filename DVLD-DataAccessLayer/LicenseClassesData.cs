using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessSetting;
namespace DVLD_DataAccessLayer
{
    public class clsLicenseClassesData
    {
        public static DataTable GetAllLicenseClass()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from LicenseClasses";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command=new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    dataTable.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }

            return dataTable;
            
        }

    }
}
