using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables.View
{
    public class ТоварыТаблица : ITableExtract<ТоварыТаблица>
    {
        public DateTime Дата { get; set; }

        public string? ФиоГражданина { get; set; }

        public string? МодельАвто { get; set; }

        public string Название { get; set; } = null!;

        public decimal Вес { get; set; }

        public decimal Стоимость { get; set; }

        public int Количество { get; set; }

        public decimal ОбщаяСумма { get; set; }

        public decimal СуммаПошлины { get; set; }

        public string ВидПошлины { get; set; } = null!;

        public decimal Ставка { get; set; }

        public int IdПеремещения { get; set; }

        public string GroupMark {  get; set; }

        public ТоварыТаблица ParseTableRow(DataRow row)
        {
            Дата = Convert.ToDateTime(row["Дата"]);
            ФиоГражданина = Convert.ToString(row["ФИО_Гражданина"]);
            МодельАвто = Convert.ToString(row["МодельАвто"]);
            Название = Convert.ToString(row["Название"]);
            Вес = Convert.ToDecimal(row["Вес"]);
            Стоимость = Convert.ToDecimal(row["Стоимость"]);
            Количество = Convert.ToInt32(row["Количество"]);
            ОбщаяСумма = Convert.ToDecimal(row["ОбщаяСумма"]);
            СуммаПошлины = Convert.ToDecimal(row["СуммаПошлины"]);
            ВидПошлины = Convert.ToString(row["ВидПошлины"]);
            Ставка = Convert.ToDecimal(row["Ставка,%"]);
            IdПеремещения = Convert.ToInt32(row["ID_Перемещения"]);
            GroupMark = "Дата : " + Дата.ToString() +" ФИО : "+ ФиоГражданина +" Автомобиль : "+ МодельАвто;
            return this;
        }
    }
}
