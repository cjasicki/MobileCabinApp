using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.IO;
using Cabin_App.Data;

namespace Cabin_App
{
    public partial class App : Application
    {
        static NoteDatabase database;
        internal static double ScreenWidth;
        internal static double ScreenHeight;
        
        public static NoteDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
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

