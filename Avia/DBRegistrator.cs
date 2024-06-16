using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
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

        public static bool addUserInfo(int userID, string name, string surname, string patronymic, string passportSeries, string passportNumber, string email)
        {
            using (SqlConnection connection = new SqlConnection(dbContainer.getAdminString()))
            {
                try
                {
                    connection.Open();
                    string query = @"INSERT INTO Users (UserID, Name, Surname, Patronymic, PassportSeries, PassportNumber, Email)
                             VALUES (@UserID, @Name, @Surname, @Patronymic, @PassportSeries, @PassportNumber, @Email)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);
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


        public static bool changeUserInfo(int userID, string name, string surname, string patronymic, string passportSeries, string passportNumber)
        {
            using (SqlConnection connection = new SqlConnection(dbContainer.getAdminString()))
            {
                try
                {
                    connection.Open();
                    string query = @"UPDATE Users SET Name = @Name, Surname = @Surname, Patronymic = @Patronymic, 
                                    PassportSeries = @PassportSeries, PassportNumber = @PassportNumber
                                    WHERE UserID = @UserID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Surname", surname);
                        command.Parameters.AddWithValue("@Patronymic", patronymic);
                        command.Parameters.AddWithValue("@PassportSeries", passportSeries);
                        command.Parameters.AddWithValue("@PassportNumber", passportNumber);
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

        public static int getCountOfSeatsViaID(int flightID)
        {
            using (SqlConnection connection = new SqlConnection(dbContainer.getAdminString()))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT CountOfFreeSeats FROM Flights WHERE FlightID = @FlightID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        return (int)command.ExecuteScalar();
                    }
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static bool bookFlight(int userID, int flightID)
        {
            using (SqlConnection connection = new SqlConnection(dbContainer.getAdminString()))
            {
                try
                {
                    connection.Open();
                    string query = @"INSERT INTO Booking (UserID, FlightID, BookingDate, SeatNumber, BookingStatus 
                                    VALUES (@UserID, @FlightID, @BookingDate, @SeatNumber, [Забронировано])";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID",userID);
                        command.Parameters.AddWithValue("@FlightID",flightID);
                        command.Parameters.AddWithValue("@BookingDate",DateTime.Now);
                        command.Parameters.AddWithValue("@SeatNumber",getCountOfSeatsViaID(flightID));

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
