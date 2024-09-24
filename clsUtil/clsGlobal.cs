using DVLD_businessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DVLDClasses
{
    public class clsGlobal
    {
        public static clsUser CurrentUser;
        public static bool RememberUsernameAndPassword(string username, string password)
        {
            try
            {
                string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();
                string filePath = CurrentDirectory + "\\Data.txt";
                if (username == "" && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }
                string DataToSave = username + "#//#" + password;
                using (StreamWriter sw = new StreamWriter(filePath, false))
                {
                    sw.WriteLine(DataToSave);
                    return true;
                }

            }
            catch (Exception e)
            {

                return false;
            }

        }

        public static bool GetStoredUsernameAndPassword(ref string username, ref string password)
        {
            try
            {
                string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();
                string filePath = CurrentDirectory + "\\Data.txt";
                if (File.Exists(filePath))
                {


                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line); // Output each line of data to the console
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            username = result[0];
                            password = result[1];
                        }
                        return true;
                    }
                }

                else
                {
                    return false;
                }
            }
            catch { return false; }
        }
    }

}
    


