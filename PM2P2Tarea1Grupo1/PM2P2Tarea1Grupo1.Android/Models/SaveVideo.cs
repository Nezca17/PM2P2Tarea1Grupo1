using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PM2P2Tarea1Grupo1.Droid.Models
{
    public class SaveVideo
    {

        string VideoPath;
        public async Task<string> ObtenerRuta(FileResult video)
        {

            try
            {

                VideoPath = "";
                // canceled
                if (video == null)
                {
                    VideoPath = null;
                    return VideoPath;
                }
                // save the file into local storage
                var newFile = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "files/my_movies/", video.FileName);
                using (var stream = await video.OpenReadAsync())
                using (var newStream = System.IO.File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

                VideoPath = newFile;

                return VideoPath;

            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert($"{ex}", "Aviso", "OK");
                return "No se logro Guardar";
            }
        }
    }

    
}