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

        var list = new TableCollection<�����������������>(DBQuery.getAllTable($"Select ���������.ID,���,����_��������,��������,���������_�����,���������_������ from ���������,����������,��������� where  ����������.ID=���������.ID_���������� and ID_���������=���������.ID"));
        foreach(var item in list)
        {
            appointment.Add(new SchedulerAppointment()
            {
                StartTime = item.�������������������,
                EndTime = item.������������������,
                Subject = item.��� + ' ' + item.������������ + ' ' + item.�����������������,
                IsAllDay = false,
                Background = Color.FromHex(stringToHex(item.���, item.������������))
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