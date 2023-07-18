using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2P2Tarea1Grupo1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoView : ContentPage
    {
        public VideoView()
        {
            InitializeComponent();
        }

        public async Task GrabarVideo()
        {
            var video = MediaPicker.CaptureVideoAsync();




        }
    }
}