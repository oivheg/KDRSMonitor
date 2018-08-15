using KDRSManager.Models;
using KDRSManager.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KDRSManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompanyPage : ContentPage
    {
        private CompanyViewModel viewModel;

        public CompanyPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CompanyViewModel();
        }

        private async void OnCompanySelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Company;
            if (item == null)
                return;

            await Navigation.PushAsync(new CompanyDetailPage(new CompanyDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Companies.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}