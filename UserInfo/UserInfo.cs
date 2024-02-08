using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.UserInfo
{
    public static class UserInfo
    {
        private static string m_UserLogin;
        public static string UserLogin {  get { return m_UserLogin; } }
        private static string m_UserName;
        public static string UserName { get { return m_UserName; } }
        private static Roles m_LevelOfRules = Roles.Guest;
        public static Roles LevelOfRules { get {  return m_LevelOfRules; } }
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
            if(m_LevelOfRules == Roles.Guest) return false;

            return true;
        }
        public static void LoginUser(string UserName, string UserLogin ,Roles levelOfRules)
        {
            m_UserLogin = UserLogin;
            m_UserName = UserName;
            m_LevelOfRules = levelOfRules;
        }

    }
}
