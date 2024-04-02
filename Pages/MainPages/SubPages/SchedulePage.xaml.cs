using PogranPunktApp.SQL.Tables;
using PogranPunktApp.SQL;
using Syncfusion.Maui.Scheduler;
using System.Collections.ObjectModel;
using System.Text;


namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class SchedulePage : ContentPage
{
	public SchedulePage()
	{
		InitializeComponent();
        setAllAppointments();
      
    }
    private void setAllAppointments()
    {
        var appointment = new ObservableCollection<SchedulerAppointment>();

        var list = new TableCollection<ДежурныйСотрудник>(DBQuery.getAllTable($"Select Дежурства.ID,ФИО,Дата_Рождения,Название,ДатаВремя_Конца,ДатаВремя_Начала from Дежурства,Сотрудники,Должность where  Сотрудники.ID=Дежурства.ID_Сотрудника and ID_Должности=Должность.ID"));
        foreach(var item in list)
        {
            appointment.Add(new SchedulerAppointment()
            {
                StartTime = item.ДатаНачалаДежурства,
                EndTime = item.ДатаКонцаДежурства,
                Subject = item.Фио + ' ' + item.ДатаРождения + ' ' + item.НазваниеДолжности,
                IsAllDay = false,
                Background = Color.FromHex(stringToHex(item.Фио, item.ДатаРождения))
            }); 

        }
        
        this.scheduler.AppointmentsSource = appointment;
    }
    private string stringToHex(string str,DateTime date)
    {
        StringBuilder sb = new StringBuilder("#");
        
        var listFirstLets = str.Split(' ').Select(x => x[0]).ToList();
        sb.Append( (((int)listFirstLets[0]*753 + date.Day) % 256).ToString("X"));
        sb.Append((((int)listFirstLets[1]*596 + date.Month) % 256).ToString("X"));
        sb.Append((((int)listFirstLets[2]*147 + date.Year) % 256).ToString("X"));
        return sb.ToString();
    }
}