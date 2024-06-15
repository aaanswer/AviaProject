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
}
