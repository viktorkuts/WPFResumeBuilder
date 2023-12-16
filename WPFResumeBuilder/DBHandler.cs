using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Collections;

namespace WPFResumeBuilder
{
    public sealed class DBHandler
    {
        static readonly string connectionString = ConfigurationManager.ConnectionStrings["ResumeDB"].ConnectionString;
        private static readonly DBHandler instance = new DBHandler();
        public static DBHandler Instance
        {
            get
            {
                return instance;
            }
        }
        public User createUserObj()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                SQLiteCommand com = new SQLiteCommand("SELECT * FROM contactinfo", connection);
                SQLiteDataReader reader = com.ExecuteReader();
                User user = null;
                List<string> phones = new List<string>();
                SQLiteCommand com2 = new SQLiteCommand("SELECT * FROM contactdetails", connection);
                SQLiteDataReader reader2 = com2.ExecuteReader();
                while (reader2.Read())
                {
                    phones.Add(reader2["phone"].ToString());
                }
                SQLiteCommand com3 = new SQLiteCommand("SELECT * FROM education", connection);
                SQLiteDataReader reader3 = com3.ExecuteReader();
                List<string> education = new List<string>();
                while (reader3.Read())
                {
                    education.Add(reader3["school"].ToString());
                }
                SQLiteCommand com4 = new SQLiteCommand("SELECT * FROM work", connection);
                SQLiteDataReader reader4 = com4.ExecuteReader();
                List<string> work = new List<string>();
                while (reader4.Read())
                {
                    work.Add(reader4["work"].ToString());
                }
                while (reader.Read())
                {
                    user = new User(reader["fname"].ToString(), reader["lname"].ToString(), reader["address"].ToString(), phones, reader["created"].ToString(), reader["modified"].ToString(), education, work);
                }
                connection.Close();
                return user;
            }
        }
        public void updatePhone(string oldPhone, string newPhone)
        {
            if (oldPhone == "")
            {
                // Add new phone
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    SQLiteCommand com = new SQLiteCommand("INSERT INTO contactdetails (phone) VALUES (@phone)", connection);
                    com.Parameters.AddWithValue("@phone", newPhone);
                    com.ExecuteNonQuery();
                    connection.Close();
                }
            }
            else
            {
                // Update phone by using WHERE query with oldPhone var
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    SQLiteCommand com = new SQLiteCommand("UPDATE contactdetails SET phone = @newPhone WHERE phone = @oldPhone", connection);
                    com.Parameters.AddWithValue("@newPhone", newPhone);
                    com.Parameters.AddWithValue("@oldPhone", oldPhone);
                    com.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        public void deletePhone(string phone)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                SQLiteCommand com = new SQLiteCommand("DELETE FROM contactdetails WHERE phone = @phone", connection);
                com.Parameters.AddWithValue("@phone", phone);
                com.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void updatePersonalInfo(string fname, string lname, string address)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                SQLiteCommand com = new SQLiteCommand("UPDATE contactinfo SET fname = @fname, lname = @lname, address = @address, modified = @modified", connection);
                com.Parameters.AddWithValue("@fname", fname);
                com.Parameters.AddWithValue("@lname", lname);
                com.Parameters.AddWithValue("@address", address);
                com.Parameters.AddWithValue("@modified", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                com.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void updateSchool(string oldSchool, string newSchool)
        {
            if (oldSchool == "")
            {
                // Add new school
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    SQLiteCommand com = new SQLiteCommand("INSERT INTO education (school) VALUES (@school)", connection);
                    com.Parameters.AddWithValue("@school", newSchool);
                    com.ExecuteNonQuery();
                    connection.Close();
                }
            }
            else
            {
                // Update school by using WHERE query with oldSchool var
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    SQLiteCommand com = new SQLiteCommand("UPDATE education SET school = @newSchool WHERE school = @oldSchool", connection);
                    com.Parameters.AddWithValue("@newSchool", newSchool);
                    com.Parameters.AddWithValue("@oldSchool", oldSchool);
                    com.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        public void deleteSchool(string school)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                SQLiteCommand com = new SQLiteCommand("DELETE FROM education WHERE school = @school", connection);
                com.Parameters.AddWithValue("@school", school);
                com.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void updateWork(string oldWork, string newWork)
        {
            if (oldWork == "")
            {
                // Add new work
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    SQLiteCommand com = new SQLiteCommand("INSERT INTO work (work) VALUES (@work)", connection);
                    com.Parameters.AddWithValue("@work", newWork);
                    com.ExecuteNonQuery();
                    connection.Close();
                }
            }
            else
            {
                // Update work by using WHERE query with oldWork var
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    SQLiteCommand com = new SQLiteCommand("UPDATE work SET work = @newWork WHERE work = @oldWork", connection);
                    com.Parameters.AddWithValue("@newWork", newWork);
                    com.Parameters.AddWithValue("@oldWork", oldWork);
                    com.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        public void deleteWork(string work)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                SQLiteCommand com = new SQLiteCommand("DELETE FROM work WHERE work = @work", connection);
                com.Parameters.AddWithValue("@work", work);
                com.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
