﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables.FunctionAdapter
{
    internal class ГражданинAdapter : Adapter
    {
        public ГражданинAdapter(int iD, string filteringField) : base(iD, filteringField)
        {
        }
    }
}
