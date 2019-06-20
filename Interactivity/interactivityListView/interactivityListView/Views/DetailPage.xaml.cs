using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace interactivityListView.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{
		public DetailPage ()
		{
			InitializeComponent ();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<interactiveListViewXaml, string>(this, "Invoke", async (sender, arg) =>
            {
                Debug.Write("123456---->  get one msg");
                DisplayAlert("Alert", "We have received a message.", "OK");
            });
        }

        protected async override void OnDisappearing()
        {
            base.OnDisappearing();

            Debug.Write("123456---->  OnDisappearing() is called.............");

           

            MessagingCenter.Unsubscribe<interactiveListViewXaml,string>(this, "Invoke");

        }
    }
}