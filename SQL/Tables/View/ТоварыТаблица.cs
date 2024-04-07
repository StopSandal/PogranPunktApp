using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables.View
{
    public class ТоварыТаблица : ITableExtract<ТоварыТаблица>
    {
        public DateTime Дата { get; set; }
        private int ID_Товара;
        public string ФиоГражданина { get; set; }

        public string МодельАвто { get; set; }

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

        public ТоварыТаблица()
        {
        }

        public ТоварыТаблица ParseTableRow(DataRow row)
        {
            ID_Товара = Convert.ToInt32(row["ID_Товара"]);
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
        public override string ToString()
        {
            return 
                   $"Название: {Название}, " +
                   $"Вес: {Вес}, " +
                   $"Стоимость: {Стоимость}, " +
                   $"Количество: {Количество}, " +
                   $"Вид Пошлины: {ВидПошлины}, ";
        }
        public ТоварыТаблица(ТоварыТаблица other)
        {
            this.Дата = other.Дата;
            this.ID_Товара = other.ID_Товара;
            this.ФиоГражданина = other.ФиоГражданина;
            this.МодельАвто = other.МодельАвто;
            this.Название = other.Название;
            this.Вес = other.Вес;
            this.Стоимость = other.Стоимость;
            this.Количество = other.Количество;
            this.ОбщаяСумма = other.ОбщаяСумма;
            this.СуммаПошлины = other.СуммаПошлины;
            this.ВидПошлины = other.ВидПошлины;
            this.Ставка = other.Ставка;
            this.IdПеремещения = other.IdПеремещения;
            this.GroupMark = other.GroupMark;
        }
        public string ToUpdateSetValuesString()
        {
            
            return 
                   $"Название='{Название}', " +
                   $"Вес={Вес}, " +
                   $"Стоимость={Стоимость.ToString(CultureInfo.GetCultureInfo("en-GB"))}, " +
                   $"Количество={Количество}, " +
                   $"ID_Пошлины=(Select ID from Пошлина where Название='{ВидПошлины}') ";
        }
        public int GetGoodID()
        {
            return ID_Товара;
        }

        public override bool Equals(object obj)
        {
            return obj is ТоварыТаблица таблица &&
                   Название == таблица.Название &&
                   Вес == таблица.Вес &&
                   Стоимость == таблица.Стоимость &&
                   Количество == таблица.Количество &&
                   ВидПошлины == таблица.ВидПошлины;
        }
    }
}
