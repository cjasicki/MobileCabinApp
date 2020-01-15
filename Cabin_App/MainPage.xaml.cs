using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace Cabin_App
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static List<clsItem> lstItem = new List<clsItem>();
        //  public static List<clsItem> lstItem = JsonConvert.DeserializeObject<List<clsItem>>(App.Current.Properties["MyData"].ToString());

        public MainPage()
        {
            InitializeComponent();
        }

        async void Weather_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TabPage());
        }
        async void Plan_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlanPage());
        }

        async void Supply_Clicked(object sender, EventArgs e)
        {
            if (App.Current.Properties.ContainsKey("MyData"))
            {
                lstItem = JsonConvert.DeserializeObject<List<clsItem>>(App.Current.Properties["MyData"].ToString());

            }
            else
            {
                lstItem.Add(new clsItem(false, "2x4", "0", 0, "A"));
                lstItem.Add(new clsItem(false, "2x6", "0", 0, "A"));
                lstItem.Add(new clsItem(false, "2x8", "0", 0, "B"));
                lstItem.Add(new clsItem(false, "2x10", "0", 0, "A"));
                lstItem.Add(new clsItem(false, "2x12", "0", 0, "D"));
                lstItem.Add(new clsItem(false, "2x14", "0", 0, "A"));
                lstItem.Add(new clsItem(false, "2x16", "0", 0, "A"));

            }

            await Navigation.PushAsync(new SupplyPage());
        }

        async void Notes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotesPage());
        }

        private void MenuItem_OnClicked(object sender, EventArgs e)
        {

        }
    }
}