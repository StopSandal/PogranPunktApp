using PogranPunktApp.SQL.Tables.View;
using Syncfusion.Maui.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.CustomComponents
{
    class GroupMarkComparer : IComparer<object>, ISortDirection
    {
        private DateTime DateX;
        private DateTime DateY;

        private ListSortDirection sortDirection;

        public ListSortDirection SortDirection
        {
            get { return this.sortDirection; }
            set { this.sortDirection = value; }
        }
        public int Compare(object x, object y)
        {
            if (DateTime.TryParse(((Syncfusion.Maui.Data.Group)x!).Key.ToString().Substring(7, 18),out this.DateX))
            {
                this.DateY = DateTime.Parse(((Syncfusion.Maui.Data.Group)y!).Key.ToString().Substring(7, 18));
            }
            else
            {
                this.DateX = DateTime.Now;
                this.DateY = DateTime.Now;
            }
            if (this.DateX.CompareTo(this.DateY) > 0)
            {
                return this.SortDirection == ListSortDirection.Ascending ? 1 : -1;
            }
            else if (this.DateX.CompareTo(this.DateY) == -1)
            {
                return this.SortDirection == ListSortDirection.Ascending ? -1 : 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
