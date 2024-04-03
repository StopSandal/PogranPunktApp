﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables
{
    class Пошлина : ITableExtract<Пошлина>
    {
        public int ID {  get; set; }
        public string Название { get; set; }
        public decimal Ставка {  get; set; }

        public Пошлина ParseTableRow(DataRow row)
        {
            ID = Convert.ToInt32(row["ID"]);
            Название = Convert.ToString(row["Название"]);
            Ставка = Convert.ToDecimal(row["Ставка"]);
            return this;
        }
    }
}
