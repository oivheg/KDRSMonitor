using KDRSManager.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KDRSManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Company Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Company
            {
                Text = "Company name",
                Description = "This is an item description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }
    }
}