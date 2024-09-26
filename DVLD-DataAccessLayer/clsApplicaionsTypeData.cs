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
    public class clsApplicaionsTypeData
    {
        public static DataTable GetApllictions()
        {
            string qurey = "Select ApplicationTypeID 'ID' , ApplicationTypeTitle 'Title',ApplicationFees 'Fees' from ApplicationTypes";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command=new SqlCommand(qurey, connection);
            DataTable dataTable = new DataTable();
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

        public static bool UpdateApplication(int ID,string Title, Decimal Fee)
        {
            int rowsAffected = 0;
            string query = "Update ApplicationTypes set" +
                " ApplicationTypeTitle=@Title, ApplicationFees=@Fee where ApplicationTypeID=@ID";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Fee", Fee);
            cmd.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            { connection.Close(); }
            return rowsAffected > 0;


        }
        public static bool Find(int ID,ref string Title,ref decimal Fee)
        {
            bool Isfound=false;
            string query = "select * from ApplicationTypes where ApplicationTypeID=@ID";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Isfound = true;
               
                    Title=(string)reader["ApplicationTypeTitle"];
                    Fee = (decimal)reader["ApplicationFees"];

                }
                reader.Close();

            }

            catch (Exception ex)
            {
                Isfound = false;
            }

            return Isfound;
        }

    }
}
