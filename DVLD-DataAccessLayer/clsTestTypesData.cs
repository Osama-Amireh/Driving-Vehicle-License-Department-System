using DVLD_DataAccessSetting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsTestTypesData
    {
        public static DataTable GetAllTests()
        {
            DataTable table = new DataTable();
            string query = "select TestTypeID 'ID', TestTypeTitle 'Title', TestTypeDescription 'Description',TestTypeFees 'Fees' from TestTypes";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    table.Load(reader);
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return table;
        }

        public static bool Find(int ID, ref string Title, ref string Description, ref Decimal Fee)
        {
            bool found = false;
            string qeury = "select * from TestTypes where TestTypeID=@ID";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(qeury, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    found = true;
                    Title = (string)reader["TestTypeTitle"];
                    Description = (string)reader["TestTypeDescription"];
                    Fee = (decimal)reader["TestTypeFees"];
                }
                reader.Close();


            }
            catch (Exception ex)
            {
                found = false;
            }
            finally
            {
                connection.Close();
            }
            return found;
        }

        public static bool UpdateTest(int ID, string Title, string Description, Decimal Fees)
        {

            int rowsAffected = 0;
            string query = "Update TestTypes set" +
                " TestTypeTitle=@Title, TestTypeDescription=@Description, TestTypeFees=@Fee where TestTypeID=@ID";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Fee", Fees);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Description", Description);

            try
            {
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return rowsAffected > 0;


        }




        
    }
}


