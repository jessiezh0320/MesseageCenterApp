using interactivityListView.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace interactivityListView
{
	public partial class interactiveListViewXaml : ContentPage
	{
		public static ObservableCollection<string> items { get; set; }

		public interactiveListViewXaml ()
		{
            items = new ObservableCollection<string> () { "Speaker", "Pen", "Lamp", "Monitor", "Bag", "Book", "Cap", "Tote", "Floss", "Phone"};
			InitializeComponent ();
		}

		//void OnSelection (object sender, SelectedItemChangedEventArgs e)
		//{
		//	if (e.SelectedItem == null) 
  //          {
		//		return;
		//	}
		//	DisplayAlert ("Item Selected", e.SelectedItem.ToString (), "Ok");
		//}

		void OnRefresh (object sender, EventArgs e)
		{
			var list = (ListView)sender;
			//put your refreshing logic here
			var itemList = items.Reverse().ToList();
			items.Clear ();
			foreach (var s in itemList) {
				items.Add (s);
			}
			//make sure to end the refresh state
			list.IsRefreshing = false;
		}

      

        async void OnTap (object sender, EventArgs e)//ItemTappedEventArgs   //EventArgs
        {
            await Navigation.PushAsync(new DetailPage());
            try
            {
                MessagingCenter.Send(this, "Invoke", "Invokedtrue");
                //MessagingCenter.Send<object, object>(this, "Invoke", "Invokedtrue");
                Debug.Write("123456---->  send one msg");

            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }

        }

		void OnMore (object sender, EventArgs e)
		{
			var item = (MenuItem)sender;
			DisplayAlert("More Context Action", item.CommandParameter + " more context action", "OK");
		}

		void OnDelete (object sender, EventArgs e)
		{
			var item = (MenuItem)sender;
			items.Remove (item.CommandParameter.ToString());
		}
	}
}

