using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cabin_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabPage : TabbedPage
    {
        public TabPage()
        {
            InitializeComponent();

            var browser = new WebView();
            browser.Source = new UrlWebViewSource { Url = "https://weather.com/weather/today/l/d56f361f9a20f04d7aa4dfe21b8eade363d64bd66884dcdb4e8ca598a774eb56" };
            this.Children.Add(new ContentPage
            {
                Title = "Ely Weather",
                Content = browser
            });

            var browser2 = new WebView();
            browser2.Source = new UrlWebViewSource { Url = "https://www.visitcookcounty.com/resources/webcams/" };
            this.Children.Add(new ContentPage
            {
                Title = "WebCams",
                Content = browser2
            });
        }

    }
}