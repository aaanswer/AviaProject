using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Avia.Database;

public static class DBDefaultInfoChecker
{
    public static bool isEmailRegistered(string email)
    {
        using (SqlConnection connection = new SqlConnection(dbContainer.getAdminString()))
        {
            connection.Open();
            string query = "SELECT UserID FROM Users WHERE Email = @Email";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                return (int)command.ExecuteNonQuery() > 0;
            }
        }
    }

    public static int getUserIDViaEmail(string email)
    {
        using (SqlConnection connection = new SqlConnection(dbContainer.getAdminString()))
        {
            connection.Open();
            string query = "SELECT UserID FROM Users WHERE Email = @Email";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                return (int)command.ExecuteScalar();
            }
        }
    }

    public static string getPasswordHashViaEmail(string email)
    {
        using (SqlConnection connection = new SqlConnection(dbContainer.getAdminString()))
        {
            connection.Open();
            string query = "SELECT HashedPassword From UserLogins WHERE Email = @Email";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                return command.ExecuteScalar().ToString();
            }
        }
    }

    public static bool isRegisteredUserInfo(int userID)
    {
        using (SqlConnection connection = new SqlConnection(dbContainer.getAdminString()))
        {
            connection.Open();
            string query = "SELECT COUNT(*) From Users WHERE UserID = @UserID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", userID);
                return (int)command.ExecuteScalar() > 0;
            }
        }
    }

    public static List<(int, int, string, string, DateTime, DateTime, int, string)> getAllFlights()
    {
        List<(int, int, string, string, DateTime, DateTime, int, string)> flights = new List<(int, int, string, string, DateTime, DateTime, int, string)>();
        using (SqlConnection connection = new SqlConnection(dbContainer.getAdminString()))
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM Flights";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        flights.Add((reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), 
                            reader.GetString(3), reader.GetDateTime(4), reader.GetDateTime(5), reader.GetInt32(6), reader.GetString(7)));
                    }
                }
                return flights;
            }
            catch 
            {
                throw new Exception();
            }
        }
    }

    public static List<(int, int, string, string, DateTime, DateTime, int, string)> getFavoriteFlights(int userID)
    {        
        List<(int, int, string, string, DateTime, DateTime, int, string)> flights = new List<(int, int, string, string, DateTime, DateTime, int, string)>();
        using (SqlConnection connection = new SqlConnection(dbContainer.getAdminString()))
        {
            try
            {
                connection.Open();
                string query = @"
                        SELECT 
                            f.FlightID,
                            f.AirlineID,
                            f.Origin,
                            f.Destination,
                            f.DepartureTime,
                            f.ArrivalTime,
                            f.CountOfFreeSeats,
                            f.FlightStatusName
                        FROM 
                            FavoriteFlights ff
                        JOIN 
                            Flights f ON ff.FlightID = f.FlightID
                        WHERE 
                            ff.UserID = @UserID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        flights.Add((reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2),
                            reader.GetString(3), reader.GetDateTime(4), reader.GetDateTime(5), reader.GetInt32(6), reader.GetString(7)));
                    }
                }
                return flights;
            }
            catch
            {
                throw new Exception();
            }
        }
    }

    public static string getAirlinesNameByID(int id)
    {
        using (SqlConnection connection = new SqlConnection(dbContainer.getAdminString()))
        {
            try
            {
                connection.Open();
                string query = "SELECT NameAirline FROM Airlines WHERE AirlineID = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    return command.ExecuteScalar().ToString();
                }
            }
            catch 
            {
                return string.Empty;
            }
        }
    }

    public static (int, string, string, DateTime, DateTime, int, string)? getFlightInfoViaID(int flightID)
    {
        using (SqlConnection connection = new SqlConnection(dbContainer.getAdminString()))
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM Flights WHERE FlightID = @FlightID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FlightID", flightID);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (reader.GetInt32(1), reader.GetString(2),
                                reader.GetString(3), reader.GetDateTime(4), reader.GetDateTime(5), reader.GetInt32(6), reader.GetString(7));
                        }
                    }
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }

    public static bool isInFavoriteFlights(int flightID, int userID)
    {
        using (SqlConnection connection = new SqlConnection(dbContainer.getAdminString()))
        {
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM FavoriteFlights WHERE FlightID = @FlightID AND UserID = @UserID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FlightID", flightID);
                    command.Parameters.AddWithValue("@UserID", userID);
                    return (int)command.ExecuteScalar() > 0;
                }
            }
            catch
            {
                return false;
            }
        }
    }

    public static (string, string, string, string, string)? getUserInfo(int userID)
    {
        using (SqlConnection connection = new SqlConnection(dbContainer.getAdminString()))
        {
            connection.Open();
            string query = "SELECT * From Users WHERE UserID = @UserID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", userID);
                var reader = command.ExecuteReader();
                if (reader.Read())
                    return (reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
            }
        }
        return null;
    }
}
