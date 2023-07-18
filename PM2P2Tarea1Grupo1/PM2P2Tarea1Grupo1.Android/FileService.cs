using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PM2P2Tarea1Grupo1.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PM2P2Tarea1Grupo1.Droid
{
    public class FileService : IFileService
    {

        public string GetRootPath()
        {
            return Application.Context.GetExternalFilesDir(null).ToString();
        }

        public void CreateFile(String video)
        {
            var filename = "text.txt";
            var destination = Path.Combine(GetRootPath(), filename);

            File.WriteAllText(filename, video);

        }
    }
}