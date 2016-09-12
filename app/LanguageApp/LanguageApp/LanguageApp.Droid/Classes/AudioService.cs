using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using LanguageApp.Classes;
using LanguageApp.Classes.Interfaces;
using LanguageApp.Droid.Classes;
using Android.Media;

[assembly: Dependency(typeof(AudioService))]
namespace LanguageApp.Droid.Classes
{
    public class AudioService : IAudioPlayer
    {
        public AudioService() { }

        public void PlayAudioFile(string fileName)
        {
            var player = new MediaPlayer();
            var fileDir = Android.App.Application.Context.Assets.OpenFd(fileName);
            player.Prepared += (s, e) =>
            {
                player.Start();
            };
            player.SetDataSource(fileDir.FileDescriptor, fileDir.StartOffset, fileDir.Length);
            player.Prepare();
        }
    }
}