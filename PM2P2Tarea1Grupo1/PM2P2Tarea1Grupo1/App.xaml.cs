using PM2P2Tarea1Grupo1.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2P2Tarea1Grupo1
{
    public partial class App : Application
    {
        public  App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new VideoView());

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
