
using PogranPunktApp.SQL;
using Syncfusion.Maui.Charts;
using Syncfusion.Maui.Core.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.Extensions.Listeners
{
    internal class DeleteKeyListener : IKeyboardListener
    {
        public void OnKeyDown(KeyEventArgs args)
        {
        }
        public async  void OnPreviewKeyDown(KeyEventArgs args)
        {


               
 
        }

        public void OnKeyUp(KeyEventArgs args)
        {
        }

        public  virtual Task<bool> OnDeleteAction()
        {
            return Task.FromResult(false);
        }

    }
}
