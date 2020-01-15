using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cabin_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
            lblErr.Text = "";
            //The Layoutlistview2 is defined in the listpage
            layoutListView2.ItemsSource = MainPage.lstItem;
        }

        //method for saving data in the listview 
        async void Save_Clicked(object sender, EventArgs e)
        {
            var LunberOrderJson = JsonConvert.SerializeObject(MainPage.lstItem);
            if (Application.Current.Properties.ContainsKey("MyData"))
            {
                if (LunberOrderJson != null)
                {
                    App.Current.Properties["MyData"] = LunberOrderJson;
                }

                await App.Current.SavePropertiesAsync();
            }
            else
            {
                if (LunberOrderJson != null)
                {
                    App.Current.Properties.Add("MyData", LunberOrderJson);

                }
                await App.Current.SavePropertiesAsync();
            }
            // move back a page
            await this.Navigation.PopAsync();
        }

        //method for loading saved data into listview 
        void GetData(object sender, EventArgs e)
        {
            string strRetVal = "";
            if (App.Current.Properties.ContainsKey("MyData"))
            {
                strRetVal = App.Current.Properties["MyData"].ToString();
            }
            else
            {
                strRetVal = "No data was stored in the memory";
            }
        }

        private void txtCount_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}