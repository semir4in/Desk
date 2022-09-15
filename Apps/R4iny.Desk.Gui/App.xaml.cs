using System.Windows;

namespace R4iny.Desk.Gui
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Core.Startup();
        }
    }
}
