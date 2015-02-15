using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuienEsQuien.Pages;
using Xamarin.Forms;

namespace QuienEsQuien
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new PlayPage();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
