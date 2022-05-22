using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnukhinPr15.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HystoryPage : ContentPage
    {
        public HystoryPage()
        {
            InitializeComponent();

        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all the notes from the database, and set them as the
            // data source for the CollectionView.
            collectionView.ItemsSource = await App.DataBase.GetTimesAsync();
        }
    }
}