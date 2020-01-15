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
    public partial class AddItemPage : ContentPage
    {
        public AddItemPage()
        {
            InitializeComponent();
        }

        async void AddBtn_Clicked(object sender, EventArgs e)
        {
            Boolean wrightdata = false;
            long x;
            if (String.IsNullOrWhiteSpace(txtName.Text) || String.IsNullOrWhiteSpace(txtSize.Text) || String.IsNullOrWhiteSpace(txtQty.Text) || String.IsNullOrWhiteSpace(txtGrade.Text))
            {
                wrightdata = false;// true is No sring
                ErrTxt.Text = "All fields must have data";
            }
            else if (long.TryParse(txtQty.Text, out x))
            {
                wrightdata = true;
            }
            else
            {
                ErrTxt.Text = "Can't have Letters in Qty fields";
                wrightdata = false;
            }


            if (wrightdata)
            {
                MainPage.lstItem.Add(new clsItem(false, txtName.Text, txtSize.Text, Convert.ToInt32(txtQty.Text), txtGrade.Text));

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

                //DisplayAlert("Add Item", " New Item Has Been Updated   ", "OK");
                await this.Navigation.PopAsync();

            }
            else
            {

            }

        }

        private void QAddBtn_Clicked(object sender, EventArgs e)
        {
            this.txtName.Text = (sender as Button).Text;
            this.txtSize.Focus();
        }
    }
}