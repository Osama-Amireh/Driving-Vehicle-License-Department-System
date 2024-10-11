using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessSetting;
using static System.Net.Mime.MediaTypeNames;
namespace DVLD_DataAccessLayer
{
    public class clsApplicationsData
    {
        public static bool GetApplicationByID(int AppliactionID, ref int PersonID, ref int ApplicationTypeID, ref DateTime Applicationdate
            , ref short ApplicationStatus, ref DateTime LastStatusDate, ref float PaidFee, ref int CreatedByUserID)
        {
            bool IsFound = false;

            string query = "Select * from Applications where AppliactionID=@AppliactionID";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AppliactionID", AppliactionID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)reader["ApplicantPersonID"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    Applicationdate = (DateTime)reader["ApplicationDate"];
                    ApplicationStatus = (short)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFee = (float)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

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
        public static int AddNewApplication(int PersonID, int ApplicationTypeID, DateTime Applicationdate
            , short ApplicationStatus, DateTime LastStatusDate, float PaidFee, int CreatedByUserID)
        {
            int ID = -1;
            string qurey = @"inserst into Applications (ApplicantPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID)
                               values(@PersonID,@Applicationdate,@ApplicationTypeID,@ApplicationStatus,@LastStatusDate,@PaidFee,@CreatedByUserID) SELECT SCOPE_IDENTITY()";

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(qurey, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@Applicationdate", Applicationdate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFee", PaidFee);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ID = insertedID;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return ID;


        }
        public static bool UpdateApplication(int ApplicationID, int PersonID, int ApplicationTypeID, DateTime Applicationdate
            , short ApplicationStatus, DateTime LastStatusDate, float PaidFee, int CreatedByUserID)
        {
            string query = "Update Applications set" +
                "ApplicantPersonID=@PersonID, ApplicationDate=@applicationDate,ApplicationTypeID=@applicationTypeID,ApplicationStatus=@applicationStatus" +
                ",LastStatusDate=@lastStatusDate,PaidFees=@PaidFee,CreatedByUserID=@createdByUserID where ApplicationID=@applicationID";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@applicationID", ApplicationID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@applicationDate", Applicationdate);
            command.Parameters.AddWithValue("@applicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@applicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@lastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFee", PaidFee);
            command.Parameters.AddWithValue("@createdByUserID", CreatedByUserID);
            int hasRow = 0;

            try
            {
                hasRow = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return hasRow > 0;

        }
        public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();
            string query = "Select * form Applications";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    dt.Load(reader);
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
        public static bool DeleteApplication(int  ApplicationID)
        {
            string query = "delete from Applications where ApplicationID=@applicationID";

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@applicationID", ApplicationID);
            int rowsAffected = 0;

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
            return rowsAffected>0;


        }
        public static bool IsApplicationExist(int ApplicationID)
        {
            string query = "select Found=1 from Applications where ApplicationID=@applicationID";
            SqlConnection connection = new SqlConnection( clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            int rowsAffected = 0;

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
        public static bool DosePersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return (GetActiveApplicationID(PersonID, ApplicationTypeID) != -1);
        }
        public static int GetActiveApplicationID(int personId, int ApplicationTypeID)
        {
            int ActiveApplicationID = -1;
            string query = "Select ActiveApplicationID=ApplicationID from Applications Where ApplicantPersonID=@PersonID and ApplicationTypeID=@applicationTypeID and applicationStatus=1";


            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personId);
            command.Parameters.AddWithValue("@applicationTypeID", ApplicationTypeID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ActiveApplicationID = insertedID;
                }

            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
            return ActiveApplicationID;


        }
        public static int GetActiveApplicationIDForLicenseCalss(int PersonID, int ApplicationTypeID, int LicenseCalssID) 
        {
            string query = "SELECT ActiveApplicationID= Applications.ApplicationID FROM  " +
                "   Applications INNER JOIN  LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID INNER JOIN" +
                " LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = @LicenseClasses.LicenseClassID where ApplicantPersonID=@PersonID" +
                " and ApplicationTypeID=@applicationTypeID and  applicationStatus=1";

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@applicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@LicenseClasses.LicenseClassID", LicenseCalssID);
            int ActiveApplicationID = -1;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ActiveApplicationID = insertedID;
                }

            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
            return ActiveApplicationID;


        }
        public static bool UpdateSataus(int ApplicaionID, short Sataus)
        {
            int rowAffected = -1;
            string query = "Update Applications set" +
                "applicationStatus=@Sataus,LastStatusDate=@lastStatusDate where ApplicationID=@applicationID";
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@applicationID", ApplicaionID);
            command.Parameters.AddWithValue("@lastStatusDate", DateTime.Now);
            command.Parameters.AddWithValue("@applicationStatus", Sataus);
            try
            {
                connection.Open();
                rowAffected = command.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return rowAffected > 0;




        }
    }
}
