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

        public async Task GrabarVideo()
        {
            try
            {
                var video = await MediaPicker.CaptureVideoAsync();

                await LoadVideoAsync(video);

                UserDialogs.Instance.Alert($"Guardando Video {VideoPath}", "Aviso", "OK");
            }
            catch (Exception ex)
            {

                UserDialogs.Instance.Alert($"{ex}", "Aviso", "OK");
            }
          

        }
        async Task LoadVideoAsync(FileResult video)
        {
            try {


                // canceled
                if (video == null)
                {
                    VideoPath = null;
                    return;
                }
                // save the file into local storage
                var newFile = Path.Combine(FileSystem.CacheDirectory, video.FileName);
                using (var stream = await video.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                VideoPath = newFile;
            }
            catch (Exception ex) {
                UserDialogs.Instance.Alert($"{ex}", "Aviso", "OK");
            }
        }

        private async void btngrabar_Clicked(object sender, EventArgs e)
        {
           await GrabarVideo();
        }
    }
}