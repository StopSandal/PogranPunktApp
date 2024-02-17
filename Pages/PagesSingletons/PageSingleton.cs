using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.Pages.PagesSingletons
{
    internal class PageSingleton<T> where T : Page,new()
    {
        private T singleton;
        public T getAutorizationPage()
        {
            if (singleton == null)
                singleton = new T();
            return singleton;
        }
    }
}
