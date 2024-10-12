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

        public static bool GetLicenseClassInfoByID(int id, ref string ClassName,ref string ClassDescription,ref int MinimumAllowedAge,ref int DefaultValidityLength, ref float ClassFees)
        {
            bool isFond = false;
            string query = "Select * from LicenseClasses where LicenseClassID=@ID";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", id);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFond = true;
                    ClassName = (string)reader["ClassName"];
                    ClassDescription=(string)reader["ClassDescription"];
                    MinimumAllowedAge = (int)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (int)reader["DefaultValidityLength"];
                    ClassFees = (float)reader["ClassFees"];

                }


            }
            catch (Exception ex)
            {
                isFond= false;
            }
            finally
            {
                connection.Close();
            }
            return isFond;
        }

        public static bool GetLicenseClassInfoByName(ref int id, string ClassName, ref string ClassDescription, ref int MinimumAllowedAge, ref int DefaultValidityLength, ref float ClassFees)
        {
            bool isFond = false;
            string query = "Select * from LicenseClasses where ClassName=@Name";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", ClassName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFond = true;
                    id = (int)reader["LicenseClassID"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (int)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (int)reader["DefaultValidityLength"];
                    ClassFees = (float)reader["ClassFees"];

                }


            }
            catch (Exception ex)
            {
                isFond = false;
            }
            finally
            {
                connection.Close();
            }
            return isFond;
        }

    }
}
