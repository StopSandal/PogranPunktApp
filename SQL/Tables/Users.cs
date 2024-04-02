using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables
{
    internal class Users : ITableExtract<Users>
    {
        public long Id { get; set; }

        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int LevelOfRules { get; set; }

        public string UserName { get; set; } = null!;

        public int? IdСотрудника { get; set; }
        public Users ParseTableRow(DataRow row)
        {
            Id = Convert.ToInt32(row["ID"]);
            Login = Convert.ToString(row["Login"]);
            Password = Convert.ToString(row["Password"]);
            LevelOfRules = Convert.ToInt32(row["LevelOfRules"]);
            UserName = Convert.ToString(row["UserName"]);
            IdСотрудника = row["ID_Сотрудника"] as int?;
            return this;
        }
    }
}
