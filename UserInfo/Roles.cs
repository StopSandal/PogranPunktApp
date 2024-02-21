namespace PogranPunktApp.UserInfo
{
    public enum Roles
    {
        Guest = 0,
        User = 1,
        Admin = 2

    }
    public static class RolesMethods
    {
        public static string RolesToString(Roles roles)
        {
            switch (roles)
            {
                case Roles.Guest: return "Гость";
                case Roles.User: return "Сотрудник";
                case Roles.Admin: return "Администратор";
                default: return "Неизвестно";
            }
        }
    }
}
