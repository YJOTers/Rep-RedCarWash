using Red_Car_Wash.Vista;
using Xamarin.Forms;

namespace Red_Car_Wash
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new IniciarSesion());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
