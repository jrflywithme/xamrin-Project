using JituTestApp_S_.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace JituTestApp_S_.view
{
	public partial class menupage : ContentPage
	{
		public menupage ()
		{
			InitializeComponent ();

            this.menuList.ItemsSource = new MenuItem[]{
                new MenuItem{ Title = "Home", Type = typeof(HomePage) },
                 new MenuItem{ Title = "Multiple List Example", Type = typeof(multipleList) },
                 new MenuItem{ Title = "List Example", Type = typeof(listViewexample) },

            };

            this.menuList.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => {
                MenuItem item = (MenuItem)e.SelectedItem;
                RootPage.Navigate(item.Type);
            };

           
        }

        public class MenuItem
        {
            public string Title
            {
                get;
                set;
            }

            public Type Type
            {
                get;
                set;
            }
        }
    }
}
