using PogranPunktApp.Extensions;
using System.Data;

namespace PogranPunktApp.UserInfo
{
    public static class UserInfo
    {
        private static string m_UserLogin = string.Empty;
        public static string UserLogin { get { return m_UserLogin; } }
        private static string m_UserName;
        public static string UserName { get { return m_UserName; } }
        private static Roles m_LevelOfRules = Roles.Guest;
        public static Roles LevelOfRules { get { return m_LevelOfRules; } }
        public static DateTime LoginTime = DateTime.Now;

        public static bool UnloginUser()
        {
            m_UserLogin = string.Empty;
            m_UserName = string.Empty;
            m_LevelOfRules = Roles.Guest;
            return true;
        }
        public static bool IsLogin()
        {
            if (m_LevelOfRules == Roles.Guest) return false;

            return true;
        }

        /* Unmerged change from project 'PogranPunktApp (net7.0-android)'
        Before:
                public static void LoginUser(string UserName, string UserLogin ,Roles levelOfRules)
        After:
                public static void LoginUser(string UserName, string UserLogin, Roles levelOfRules)
        */

        /* Unmerged change from project 'PogranPunktApp (net7.0-windows10.0.19041.0)'
        Before:
                public static void LoginUser(string UserName, string UserLogin ,Roles levelOfRules)
        After:
                public static void LoginUser(string UserName, string UserLogin, Roles levelOfRules)
        */

        /* Unmerged change from project 'PogranPunktApp (net7.0-maccatalyst)'
        Before:
                public static void LoginUser(string UserName, string UserLogin ,Roles levelOfRules)
        After:
                public static void LoginUser(string UserName, string UserLogin, Roles levelOfRules)
        */
        public static void LoginUser(string UserName, string UserLogin, Roles levelOfRules)
        {
            m_UserLogin = UserLogin;
            m_UserName = UserName;
            m_LevelOfRules = levelOfRules;
        }
        public static bool ParseUser(DataRow row, string userPassword)
        {
            if (row == null || row.IsNull(0))
                return false;
            string password = (String)row[2];
            if (userPassword.GetMd5Hash() == password)
            {
                LoginUser((String)row[4], (String)row[1], (Roles)(int)row[3]);
                return true;
            }
            return false;

        }

    }
}
