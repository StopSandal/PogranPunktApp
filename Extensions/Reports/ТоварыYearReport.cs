using PogranPunktApp.SQL.Tables.View;
using System;
using System.Collections.Generic;
#if WINDOWS
using PogranPunktApp.SupportClasses;
#endif
using OfficeOpenXml;
using System.IO;

namespace PogranPunktApp.Extensions.Reports
{
    public class ТоварыYearReport
    {
        public static void GenerateAllTimeReport(IEnumerable<ТоварыТаблица> товары)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("Report");

                // Set title
                worksheet.Cells["A1"].Value = "Отчёт о работе предприятия\n за всё время работы";
                worksheet.Row(1).Style.Font.Bold = true;
                worksheet.Row(1).Style.Font.Size = 36;

                // Set column headers
                worksheet.Cells["A2"].Value = "Дата";
                worksheet.Cells["B2"].Value = "ФИО Гражданина";
                worksheet.Cells["C2"].Value = "Модель Авто";
                worksheet.Cells["D2"].Value = "Название";
                worksheet.Cells["E2"].Value = "Вес";
                worksheet.Cells["F2"].Value = "Стоимость";
                worksheet.Cells["G2"].Value = "Количество";
                worksheet.Cells["H2"].Value = "Общая Сумма";
                worksheet.Cells["I2"].Value = "Сумма Пошлины";
                worksheet.Cells["J2"].Value = "Вид Пошлины";
                worksheet.Cells["K2"].Value = "Ставка";
                worksheet.Row(2).Style.Font.Bold = true;
                worksheet.Row(2).Style.Font.Size = 18;

                // Group and write data
                int currentRow = 3;
                var groupedData = товары.GroupBy(t => t.GroupMark);
                foreach (var group in groupedData)
                {
                    bool Header = true;

                    // Write data for each item in the group
                    foreach (var item in group)
                    {
                        if (Header) {
                            worksheet.Cells[currentRow, 1].Value = item.Дата.ToString();
                            worksheet.Cells[currentRow, 2].Value = item.ФиоГражданина;
                            worksheet.Cells[currentRow, 3].Value = item.МодельАвто;
                            currentRow++;
                            Header = false;
                        }
                        

                        worksheet.Cells[currentRow, 4].Value = item.Название;
                        worksheet.Cells[currentRow, 5].Value = item.Вес;
                        worksheet.Cells[currentRow, 6].Value = item.Стоимость;
                        worksheet.Cells[currentRow, 7].Value = item.Количество;
                        worksheet.Cells[currentRow, 8].Value = item.ОбщаяСумма;
                        worksheet.Cells[currentRow, 9].Value = item.СуммаПошлины;
                        worksheet.Cells[currentRow, 10].Value = item.ВидПошлины;
                        worksheet.Cells[currentRow, 11].Value = item.Ставка;
                        currentRow++;
                    }

                    // Write group summaries
                    worksheet.Cells[currentRow, 1].Value = "Всего товаров:";
                    worksheet.Cells[currentRow, 2].Value = group.Count();
                    worksheet.Cells[currentRow , 4].Value = "Общая сумма:";
                    worksheet.Cells[currentRow , 5].Value = group.Sum(t => t.ОбщаяСумма);
                    worksheet.Cells[currentRow , 7].Value = "Сумма пошлин:";
                    worksheet.Cells[currentRow , 8].Value = group.Sum(t => t.СуммаПошлины);
                    worksheet.Row(currentRow).Style.Font.Bold = true;
                    worksheet.Row(currentRow).Style.Font.Size = 16;
                    currentRow += 2;
                }
                worksheet.Cells[currentRow, 1].Value = "Итого всего товаров:";
                worksheet.Cells[currentRow, 2].Value = товары.Count();
                worksheet.Cells[currentRow, 4].Value = "Итоговая общая сумма:";
                worksheet.Cells[currentRow, 5].Value = товары.Sum(t => t.ОбщаяСумма);
                worksheet.Cells[currentRow, 7].Value = "Итоговая сумма пошлин:";
                worksheet.Cells[currentRow, 8].Value = товары.Sum(t => t.СуммаПошлины);
                worksheet.Row(currentRow).Style.Font.Bold = true;
                worksheet.Row(currentRow).Style.Font.Size = 20;
                worksheet.Cells.AutoFitColumns();
                // SaveAndView(works)

#if WINDOWS
                using (var reportStream = new MemoryStream())
                {
                    excelPackage.SaveAs(reportStream);
                    reportStream.Seek(0, SeekOrigin.Begin);
                    SaveService saveService = new();
                    
                    saveService.SaveAndView("Отчёт за всё время работы предприятия.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", reportStream);
                }
#endif
            }
        }



        public static void GenerateYearTimeReport(IEnumerable<ТоварыТаблица> товары, int year)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("Report");

                // Set title
                worksheet.Cells["A1"].Value = "Отчёт о перемещённых товарах\nза " + year + " год";
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.Font.Size = 36;
                // Set column headers
                worksheet.Cells["A2"].Value = "Дата";
                worksheet.Cells["B2"].Value = "ФИО Гражданина";
                worksheet.Cells["C2"].Value = "Модель Авто";
                worksheet.Cells["D2"].Value = "Название";
                worksheet.Cells["E2"].Value = "Вес";
                worksheet.Cells["F2"].Value = "Стоимость";
                worksheet.Cells["G2"].Value = "Количество";
                worksheet.Cells["H2"].Value = "Общая Сумма";
                worksheet.Cells["I2"].Value = "Сумма Пошлины";
                worksheet.Cells["J2"].Value = "Вид Пошлины";
                worksheet.Cells["K2"].Value = "Ставка";

                worksheet.Row(2).Style.Font.Bold = true;
                worksheet.Row(2).Style.Font.Size = 18;
                // Group and write data
                int currentRow = 3;
                var yearData = товары.Where(x => x.Дата.Year==year).ToList();
                for (int i = 0; i < 12; i++)
                {

                    var groupedData = yearData.Where(x=>x.Дата.Month==i+1).GroupBy(t => t.GroupMark);
                    if(groupedData.Any()) {
                        worksheet.Cells[currentRow, 1].Value = "За " + MonthToString(i);
                        worksheet.Row(currentRow).Style.Font.Bold = true;
                        worksheet.Row(currentRow).Style.Font.Size = 16;
                        currentRow++;
                    }
                    foreach (var group in groupedData)
                    {
                        bool Header = true;
                        
                        // Write data for each item in the group
                        foreach (var item in group)
                        {
                            if (Header)
                            {
                                worksheet.Cells[currentRow, 1].Value = item.Дата.ToString();
                                worksheet.Cells[currentRow, 2].Value = item.ФиоГражданина;
                                worksheet.Cells[currentRow, 3].Value = item.МодельАвто;
                                currentRow++;
                                Header = false;
                            }


                            worksheet.Cells[currentRow, 4].Value = item.Название;
                            worksheet.Cells[currentRow, 5].Value = item.Вес;
                            worksheet.Cells[currentRow, 6].Value = item.Стоимость;
                            worksheet.Cells[currentRow, 7].Value = item.Количество;
                            worksheet.Cells[currentRow, 8].Value = item.ОбщаяСумма;
                            worksheet.Cells[currentRow, 9].Value = item.СуммаПошлины;
                            worksheet.Cells[currentRow, 10].Value = item.ВидПошлины;
                            worksheet.Cells[currentRow, 11].Value = item.Ставка;
                            currentRow++;
                        }

                        // Write group summaries
                        worksheet.Cells[currentRow, 1].Value = "Всего товаров:";
                        worksheet.Cells[currentRow, 2].Value = group.Count();
                        worksheet.Cells[currentRow, 4].Value = "Общая сумма:";
                        worksheet.Cells[currentRow, 5].Value = group.Sum(t => t.ОбщаяСумма);
                        worksheet.Cells[currentRow, 7].Value = "Сумма пошлин:";
                        worksheet.Cells[currentRow, 8].Value = group.Sum(t => t.СуммаПошлины);
                        worksheet.Row(currentRow).Style.Font.Bold = true;
                        worksheet.Row(currentRow).Style.Font.Size = 14;

                        currentRow++;
                    }
                    if (groupedData.Any())
                    {
                        var temp = yearData.Where(x => x.Дата.Month == i + 1);
                        worksheet.Cells[currentRow, 1].Value = "Товаров за месяц:";
                        worksheet.Cells[currentRow, 2].Value = temp.Count();
                        worksheet.Cells[currentRow, 4].Value = "Сумма за месяц:";
                        worksheet.Cells[currentRow, 5].Value = temp.Sum(t => t.ОбщаяСумма);
                        worksheet.Cells[currentRow, 7].Value = "Уплачено пошлины за месяц:";
                        worksheet.Cells[currentRow, 8].Value = temp.Sum(t => t.СуммаПошлины);
                        worksheet.Row(currentRow).Style.Font.Bold = true;
                        worksheet.Row(currentRow).Style.Font.Size = 16;
                        currentRow += 3;
                    }

                }
                currentRow += 1;
                worksheet.Cells[currentRow, 1].Value = "Товаров за год:";
                worksheet.Cells[currentRow, 2].Value = yearData.Count();
                worksheet.Row(currentRow).Style.Font.Bold = true;
                worksheet.Row(currentRow).Style.Font.Size = 20;
                worksheet.Cells[currentRow + 1, 1].Value = "Итого за год:";
                worksheet.Cells[currentRow + 1, 2].Value = yearData.Sum(t => t.ОбщаяСумма);
                worksheet.Row(currentRow + 1).Style.Font.Bold = true;
                worksheet.Row(currentRow + 1).Style.Font.Size = 20;
                worksheet.Cells[currentRow+2, 1].Value = "Итого Пошлины за год:";
                worksheet.Cells[currentRow+2, 2].Value = yearData.Sum(t => t.СуммаПошлины);
                worksheet.Row(currentRow + 2).Style.Font.Bold = true;
                worksheet.Row(currentRow + 2).Style.Font.Size = 20;

                worksheet.Cells.AutoFitColumns();
#if WINDOWS
                using (var reportStream = new MemoryStream())
                {
                    excelPackage.SaveAs(reportStream);
                    SaveService saveService = new();
                    saveService.SaveAndView($"Годовой отчёт за {year} год.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", reportStream);
                }
#endif

            }
        }


        private static string MonthToString(int month)
        {
            switch (month)
            {
                case 0: return "январь";
                case 1: return "февраль";
                case 2: return "март";
                case 3: return "апрель";
                case 4: return "май";
                case 5: return "июнь";
                case 6: return "июль";
                case 7: return "август";
                case 8: return "сентябрь";
                case 9: return "октябрь";
                case 10: return "ноябрь";
                case 11: return "декабрь";
                default: return "NUll";
            }
        }
    }
}
