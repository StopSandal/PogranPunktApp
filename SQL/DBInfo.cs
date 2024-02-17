
using CommunityToolkit.Maui.Views;
using Microsoft.Data.SqlClient;
using Microsoft.Maui.Controls;
using PogranPunktApp.Pages;
using PogranPunktApp.Popups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL
{
    public static class DBInfo
    {
        private static string m_ConnectionString;
        private static bool m_IsConnected = false;
        public static bool IsTryReconnect = true;
        private static CancellationTokenSource cancellation;
        public static bool IsConnected {  get { return m_IsConnected; } }   
        public static string ConnectionString { get { return m_ConnectionString; } }
        static DBInfo(){

            m_ConnectionString = "Server=DESKTOP-UAUG3OJ;Database=PogranPunkt;Trusted_Connection=True;TrustServerCertificate=True;";
        }
        private static SqlConnection m_SqlConnection;
        public static SqlConnection SqlConnection { get {  return m_SqlConnection; } }  
        public async static Task<bool> InitializeConnectionAsync()
        {
            cancellation = new CancellationTokenSource(5000);

            m_SqlConnection = new SqlConnection(m_ConnectionString);
            try
            {
                await m_SqlConnection.OpenAsync(cancellation.Token);
                await m_SqlConnection.CloseAsync();
                m_IsConnected= true;
            }
            catch (Exception ex)
            {
                return false;
            }

            m_IsConnected = !cancellation.IsCancellationRequested;
            if(cancellation.IsCancellationRequested)
                cancellation.Token.ThrowIfCancellationRequested();
            return m_IsConnected;
        }
        public static void AbroadConnection()
        {
            if(cancellation.Token.CanBeCanceled)
                cancellation.Cancel();
        }
        public static bool isConnectedDB() {

            try
            {
                InitializeConnectionAsync().Wait();
            }
            catch (AggregateException ex)
            {
                m_IsConnected = false;
                return m_IsConnected;
            }

            if (!m_IsConnected)
            {
                return false;
            }

            return m_IsConnected;
        }

    }
}
