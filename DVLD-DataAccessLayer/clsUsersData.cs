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
    public class clsUsersData
    {
        public static DataTable GetAllUsers()
        {
            string query = "Select UserID 'User ID',Users.PersonID 'Person ID','Full Name'=(People.FirstName+' '+People.SecondName+' '+People.ThirdName+' '+People.Lastname) " +
                " ,UserName 'User Name',IsActive 'Is Active'" +
                "From Users, People " +
                "where Users.PersonID=People.PersonID";
            SqlConnection connection =new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command =new SqlCommand(query, connection);
            DataTable table =new DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    table.Load(reader);

                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally {
                connection.Close();
            }

                return table;

        }

    }
}
