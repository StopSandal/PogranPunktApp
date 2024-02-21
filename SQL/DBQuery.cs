
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
        public static SqlDataReader getAllTable(string tableName)
        {
            return null;
        }

        /* Unmerged change from project 'PogranPunktApp (net7.0-android)'
        Before:
                public static DataRow getUserInfo(string userName) {
                using (var connetion = new SqlConnection(DBInfo.ConnectionString))
        After:
                public static DataRow getUserInfo(string userName)
                {
                    using (var connetion = new SqlConnection(DBInfo.ConnectionString))
        */

        /* Unmerged change from project 'PogranPunktApp (net7.0-windows10.0.19041.0)'
        Before:
                public static DataRow getUserInfo(string userName) {
                using (var connetion = new SqlConnection(DBInfo.ConnectionString))
        After:
                public static DataRow getUserInfo(string userName)
                {
                    using (var connetion = new SqlConnection(DBInfo.ConnectionString))
        */

        /* Unmerged change from project 'PogranPunktApp (net7.0-maccatalyst)'
        Before:
                public static DataRow getUserInfo(string userName) {
                using (var connetion = new SqlConnection(DBInfo.ConnectionString))
        After:
                public static DataRow getUserInfo(string userName)
                {
                    using (var connetion = new SqlConnection(DBInfo.ConnectionString))
        */
        public static DataRow getUserInfo(string userName)
        {
            using (var connetion = new SqlConnection(DBInfo.ConnectionString))
            {
                connetion.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from Users where '" + userName + "' = Login", connetion);
                DataSet data = new DataSet();
                adapter.Fill(data);
                if (data.Tables[0].Rows.Count != 1)
                    return null;
                return data.Tables[0].Rows[0];
            }

        }
    }
}
