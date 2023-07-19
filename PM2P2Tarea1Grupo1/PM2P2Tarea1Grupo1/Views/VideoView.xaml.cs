using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;
using System.IO;
using System.Runtime.InteropServices;
using Xamarin.CommunityToolkit;
using Xamarin.CommunityToolkit.Core;

namespace PM2P2Tarea1Grupo1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoView : ContentPage
    {

        public VideoView()
        {
            InitializeComponent();
        }

        string VideoPath;
        static string DEFAULTPATH = "/storage/emulated/0/Android/data/com.companyname.pm2p2tarea1grupo1/files";

        private async void btngrabar_Clicked(object sender, EventArgs e)
        {
          string path= await GrabarVideo2("Video1");
            UserDialogs.Instance.Alert($"Guardando Video {path}", "Aviso", "OK");
            mediaElement.Source = new FileMediaSource {
                File = path
            };
        }

        public async Task<string> GrabarVideo2(string filename)
        {

            try
            {
                FileResult videoGrabado = await MediaPicker.CaptureVideoAsync();

                var file = Path.Combine(DEFAULTPATH, videoGrabado.FileName);
                using (var stream = await videoGrabado.OpenReadAsync())
                using (var newStream = File.OpenWrite(file))
                    await stream.CopyToAsync(newStream);

                return file;
            }
            catch (Exception e) {

                UserDialogs.Instance.Alert($"File{e}","Aviso","Ok");
                return "";
            }
        }



        private async void btngrabar_Clicked(object sender, EventArgs e)
        {
           await GrabarVideo();
           
        }
    }
    
}