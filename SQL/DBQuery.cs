
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                catch(SqlException ex)
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
        public static DataRow getUserInfo(string userName) {
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
