using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avia.Database;

public static class DBDefaultInfoChecker
{
    public static bool isEmailRegistered(string email)
    {
        using (SqlConnection connection = new SqlConnection(dbContainer.getAdminString()))
        {
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
            string query = "SELECT UserID FROM Users WHERE Email = @Email";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                return (int)command.ExecuteScalar();
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
}
