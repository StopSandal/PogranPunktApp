using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.CustomComponents
{
    class CompletedEventArgs : EventArgs
    {
        public bool IsCompleted { get; set; }
        public bool IsCanceled { get; set; }
        public CompletedEventArgs() {
            IsCanceled = false;
            IsCompleted = false;
        }

    }
}
