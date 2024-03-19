
using Microsoft.Data.SqlClient;
using System.Data;

namespace PogranPunktApp.SQL
{
    internal static class DBQuery
    {
        public static bool EstablishSQLDatabaseConnection()
        {

            if (!DBInfo.isConnectedDB())
                return false;
            DBInfo.IsTryReconnect = false;
            using (SqlConnection connetion = new SqlConnection(DBInfo.ConnectionString))
            {
                try
                {
                    connetion.Open();
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            return true;
        }
        public static DataTable getAllTable(string commandString)
        {

            using (var connetion = new SqlConnection(DBInfo.ConnectionString))
            {
                connetion.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(commandString, connetion);
                DataSet data = new DataSet();
                adapter.Fill(data);
                return data.Tables[0];
            }
        }

        public static DataRow getUserInfo(string userName)
        {
            using (var connetion = new SqlConnection(DBInfo.ConnectionString))
            {
                connetion.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from Users where @userName = Login COLLATE SQL_Latin1_General_CP1_CS_AS", connetion);
                adapter.SelectCommand.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@userName",
                    Value = userName,
                    SqlDbType = SqlDbType.VarChar,
                    
                });


                DataSet data = new DataSet();
                adapter.Fill(data);
                if (data.Tables[0].Rows.Count != 1)
                    return null;
                return data.Tables[0].Rows[0];
            }

        }
    }
}
