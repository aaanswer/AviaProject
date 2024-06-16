using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Avia.Database
{
    internal static class DBRegistrator
    { 
        public static bool registerNewUserLogin(string email, string passwordHash)
        {
            using (SqlConnection connection = new SqlConnection(dbContainer.getAdminString()))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO UserLogins (Email, HashedPassword) VALUES (@Email, @HashedPassword)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@HashedPassword", passwordHash);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
                catch
                { 
                    return false;
                }
            }
        }

        public static bool registerUserInfo(string name, string surname, string patronymic, string passportSeries, string passportNumber, string email)
        {
            using (SqlConnection connection = new SqlConnection(dbContainer.getAdminString()))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Users (Name, Surname, Patronymic, PassportSeries, PassportNumber, Email) VALUES  (@Name, @Surname, @Patronymic,@PassportSeries, @PassportNumber, @Email)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Surname", surname);
                        command.Parameters.AddWithValue("@Patronymic", patronymic);
                        command.Parameters.AddWithValue("@PassportSeries", passportSeries);
                        command.Parameters.AddWithValue("@PassportNumber", passportNumber);
                        command.Parameters.AddWithValue("@Email", email);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool deleteFromFavorite(int flightID, int userID)
        {
            using (SqlConnection connection = new SqlConnection(dbContainer.getAdminString()))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM FavoriteFlights WHERE FlightID = @FlightID AND UserID = @UserID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FlightID", flightID);
                        command.Parameters.AddWithValue("@UserID", userID);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool insertToFavorite(int flightID, int userID)
        {
            using (SqlConnection connection = new SqlConnection(dbContainer.getAdminString()))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO FavoriteFlights (FlightID, USerID) VALUES (@FlightID, @UserID)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FlightID", flightID);
                        command.Parameters.AddWithValue("@UserID", userID);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
