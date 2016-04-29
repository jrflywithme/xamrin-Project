using JituTestApp_S_.view;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JituTestApp_S_
{
    public  class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            Current = this;

            Master = new menupage();

            Navigate(typeof(HomePage));

            InvalidateMeasure();

        }

        private static Dictionary<Type, NavigationPage> cache = new Dictionary<Type, NavigationPage>();

        public static void Navigate(Type type)
        {
            try
            {
                NavigationPage page = null;
                if (!cache.TryGetValue(type, out page))
                {
                    ContentPage cp = (ContentPage)Activator.CreateInstance(type);
                    page = new NavigationPage(cp);
                    cache[type] = page;
                }
                Current.Detail = page;

                if (Device.Idiom != TargetIdiom.Tablet)
                {
                    Current.IsPresented = false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed creating {type.FullName}\r\n{ex}");
            }
        }
        public static RootPage Current { get; private set; }

        public static INavigation CurrentPage
        {
            get
            {
                return (INavigation)Current.Detail.Navigation;
            }
        }

    }
}
