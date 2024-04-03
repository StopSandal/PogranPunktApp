using Syncfusion.Maui.Core.Internals;
using Syncfusion.Maui.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.Extensions.Listeners
{
    class TypeGDeleteListener : DeleteKeyListener
    {
        public TypeGDeleteListener(int iD, SfDataGrid grid) : base(iD, grid)
        {
        }

        public override void OnPreviewKeyDown(KeyEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
