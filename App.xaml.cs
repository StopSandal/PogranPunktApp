#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
#endif
using PogranPunktApp.Pages;
using PogranPunktApp.SQL;

namespace PogranPunktApp
{
    public partial class App : Application
    {
        public App()
        {

            InitializeComponent();
            MainPage = new NavigationPages(new AutorizationPage());
#if WINDOWS
    
    SetWinNoResizable();
#endif

        }
        protected override void OnStart()
        {
            base.OnStart();
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            DBInfo.InitializeConnectionAsync();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        public void SetWinNoResizable()
        {
            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow),(handler, view) =>
            {
                #if WINDOWS
                    var nativeWindow = handler.PlatformView;
                    IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
                    WindowId WindowId = Win32Interop.GetWindowIdFromWindow(windowHandle);
                    AppWindow appWindow = AppWindow.GetFromWindowId(WindowId);
                    var presenter = appWindow.Presenter as OverlappedPresenter;
                    
                    presenter.IsResizable = false;
                #endif
            });
        }

    }


}
