using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace Cabin_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SupplyPage : ContentPage
    {
        public SupplyPage()
        {
            InitializeComponent();
            layoutListView.ItemsSource = MainPage.lstItem;

            layoutListView.RefreshCommand = new Command(() => {
                //Do your stuff.
                RefreshData();
                layoutListView.IsRefreshing = false;
            });
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //layoutListView.ItemsSource = MainPage.lstItem;
            RefreshData();
        }
        public void RefreshData()
        {

            layoutListView.ItemsSource = null;
            layoutListView.ItemsSource = MainPage.lstItem;
        }
        async void NextPage_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ListPage());
        }
        async void AddItemPage_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new AddItemPage());

        }


        async void DeleteClicked(object sender, EventArgs e)
        {

            bool answer = await DisplayAlert("Delete Item?", "Are you sure you want to delete;", "Yes", "No");
            if (answer)
            {
                var button = sender as Button;
                var item = (Xamarin.Forms.Button)sender;
                clsItem listitem = (from itm in MainPage.lstItem  //allItems
                                    where itm.Name == button.CommandParameter.ToString()
                                    select itm)
                                .FirstOrDefault<clsItem>();
                MainPage.lstItem.Remove(listitem);

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
                RefreshData();
                layoutListView.IsRefreshing = false;
            }
        }

        private void DeleteAction(object sender, EventArgs e)
        {

        }

        private void EvetClicked(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}