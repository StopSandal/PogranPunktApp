using PogranPunktApp.SQL;

namespace PogranPunktApp
{
    public partial class App : Application
    {
        public App()
        {

            InitializeComponent();

            MainPage = new AppShell();
        }
        protected override void OnStart()
        {
            base.OnStart();
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            DBInfo.InitializeConnectionAsync();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

    }
}
