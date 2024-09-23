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
        public static bool GetUserByID(int ID, ref string username,ref string Password,ref int PersonID,ref bool IsActive )
        {
            bool IsFound = false;
            string qeury = "select * from Users where UserId=@ID";
            SqlConnection connection=new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command=new SqlCommand(qeury, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    IsFound = true;
                    username = (string)reader["Username"];
                    Password = (string)reader["Password"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];

                }

            }
            catch (Exception ex)
            {
                IsFound= false;
            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }
        public static bool GetUserByUsername( ref int ID,ref string username, ref string Password, ref int PersonID,ref bool IsActive)
        {
            bool IsFound = false;
            string qeury = "select * from Users where Username=@username";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(qeury, connection);
            command.Parameters.AddWithValue("@username", username);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    username = (string)reader["Username"];
                    Password = (string)reader["Password"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];
                    ID = (int)reader["UserID"];
                }

            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }
        public static bool IsUserExsistByID(int ID)
        {
            bool isFound = false;
            string qeury = "select Found= 1 from Users where UserId=@ID";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(qeury, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static bool IsUserExsistByUserName(string Username)
        {
            bool isFound = false;
            string qeury = "select Found= 1 from Users where upper(Username)=Upper(@username)";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(qeury, connection);
            command.Parameters.AddWithValue("@username", Username);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static bool IsUserExsistForPersonID(int PersonID) 
        {
        bool IsExist=false;
            string query = "select Exist=1 from Users where Users.PersonID=@personID";
            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command= new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@personID", PersonID);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsExist = reader.HasRows;
                reader.Close();

            }
            catch (Exception ex)
            {
                IsExist = false;
            }
            finally
            {
                conn.Close();
            }
            return IsExist;
        }
        public static int AddNewUser(string Username,int PersonID,string  Password,bool IsActive)
        {
            int UserID=-1;
            string query= @"insert into Users(Username,PersonID,Password,IsActive)values(@username,@persinId,@password,@isActive);   SELECT SCOPE_IDENTITY() ";
            SqlConnection connection =new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", Username);
            command.Parameters.AddWithValue("@persinId", PersonID);
            command.Parameters.AddWithValue("@password", Password);
            command.Parameters.AddWithValue("@isActive", IsActive);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    UserID = insertedID;
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }

            return UserID;
        }

        public static bool UpdateUser(int UserID,string Username,string Password,int PersonID,bool isAvtrive)
        {
            int rowsAffected = 0;
            string query = "Update Users set username=@Username, personID=@PersonID,password=@Password,isactive=@IsActive where UserId=@userID";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command =new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@userID", UserID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@IsActive", isAvtrive);
            try
            {

                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return rowsAffected > 0;
        }
        public static bool DeleteUser(int UserID)
        {
            string query = "Delete from Users Where userid=@userID";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@userID", UserID);
            int rowsAffected = 0;
            try
            {
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return rowsAffected > 0;

        }
    }
}
