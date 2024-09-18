using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessSetting;
namespace DVLD_DataAccessLayer
{
    public class clsPersonData
    {

        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();
            string query = "Select PersonId,NationalNo ,FirstName  'First Name',SecondName 'Second Name',ThirdName 'Third Name',LastName 'Last Name', case Gendor when 0 then 'Male' when 1 then 'female' end as 'Gender'" +
                ", DateOfBirth 'Date of Birth',(select Countries.CountryName from Countries where Countries.CountryID=People.NationalityCountryID) as Nationality,phone, Email from People";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    reader.Close();
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;

        }
        public static bool IsNationalNoExisit(string nationalNo)
        {
            bool isFound = false;
            string query = "select 1 from People where Upper(NationalNo)=Upper(@nationalNo)";

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@nationalNo", nationalNo);

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
        public static int AddNewPerson(string firstName, string secondName, string thirdName, string lastName, byte gender, string phone,
            string email, int NationalID, string NationalNo, DateTime dateOfBirth, string ImagePath, string address)
        {

            int PersonID = -1;
            string query = @"INSERT INTO People
           (NationalNo,FirstName ,SecondName ,ThirdName ,LastName ,DateOfBirth ,Gendor ,Address ,Phone ,Email ,NationalityCountryID ,ImagePath)
     VALUES
           (@NationalNo ,@FirstName, @SecondName,@ThirdName,@LastName,@DateOfBirth,@Gender,@Address,@Phone,@Email,@NationalID,@ImagePath);
                 SELECT SCOPE_IDENTITY();";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@SecondName", secondName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@Gender", gender);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@NationalID", NationalID);

            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            if (email != "" && email != null)
                command.Parameters.AddWithValue("@Email", email);
            else
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);

            if (thirdName != "" && thirdName != null)
                command.Parameters.AddWithValue("@ThirdName", thirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return PersonID;


        }
        public static bool FindByPersonID(int personID, ref string FirstName, ref string SecondName, ref string ThirdName
            , ref string LastName, ref string Phone, ref string Email, ref int Nationality, ref string NationalNo, ref byte Gender, ref DateTime DateOfBirth,
        ref string ImagePath, ref string Address)
        {
            bool isFound = false;
            string query = "select * from People where PersonID=@personID";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@personID", personID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];
                    else ThirdName = "";
                    LastName = (string)reader["LastName"];
                    Phone = (string)reader["Phone"];
                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else Email = "";
                    Nationality = (int)reader["NationalityCountryID"];
                    NationalNo = (string)reader["NationalNo"];
                    Gender = (byte)reader["Gendor"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else ImagePath = "";
                    Address = (string)reader["Address"];




                }

            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {

                connection.Close();
            }
            return isFound;

        }

        public static bool FindByNationalNo(ref int personID, ref string FirstName, ref string SecondName, ref string ThirdName
    , ref string LastName, ref string Phone, ref string Email, ref int Nationality, string nationalNo, ref byte Gender, ref DateTime DateOfBirth,
ref string ImagePath, ref string Address)
        {
            bool isFound = false;
            string query = "select * from People where NationalNo=@nationalNo";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@nationalNo", nationalNo);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    personID = (int)reader["personID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];
                    else ThirdName = "";
                    LastName = (string)reader["LastName"];
                    Phone = (string)reader["Phone"];
                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else Email = "";
                    Nationality = (int)reader["NationalityCountryID"];
                    Gender = (byte)reader["Gendor"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else ImagePath = "";
                    Address = (string)reader["Address"];




                }

            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {

                connection.Close();
            }
            return isFound;

        }

        public static bool IsEmailExisit(string email)
        {
            bool isFound = false;
            string query = "select 1 from People where Upper(Email)=Upper(@email)";

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@email", email);

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

        public static bool UpdatePerson(int personID, string firstName, string secondName, string thirdName, string lastName, byte gender, string phone,
            string email, int NationalID, string NationalNo, DateTime dateOfBirth, string ImagePath, string address)
        {
            int rowsAffected = 0;

            string query = "UPDATE People   SET " +
                "NationalNo = @NationalNo, FirstName = @FirstName, SecondName=@SecondName ,ThirdName =@ThirdName" +
                "   ,LastName = @LastName , DateOfBirth =@DateOfBirth ,Gendor = @Gendor ,Address = @Address" +
                "  ,Phone = @Phone ,Email = @Email  ,NationalityCountryID = @NationalityCountryID ,ImagePath =@ImagePath" +
                  "  WHERE PersonID=@PersonID";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@SecondName", secondName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@Gendor", gender);
            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalID);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@PersonID", personID);


            if (thirdName != "" && thirdName != null)
                command.Parameters.AddWithValue("@ThirdName", thirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            if (email != "" && email != null)
                command.Parameters.AddWithValue("@Email", email);
            else
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);

            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);

        }
        public static bool DeletePerson(int ID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Delete People 
                                where PersonID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }


    }
}
