using Xamarin.Forms;

namespace SafeWayzMap2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MapPageCS();
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
