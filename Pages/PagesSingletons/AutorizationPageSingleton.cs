using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.Pages.PagesSingletons
{
    internal class AutorizationPageSingleton
    {

        private AutorizationPage singleton;
        public AutorizationPage getAutorizationPage()
        {
            if(singleton == null)
                singleton = new AutorizationPage();
            return singleton;
        }
    }
}
