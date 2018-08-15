using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using KDRSManager.Models;
using KDRSManager.ViewModels;

namespace KDRSManager.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CompanyDetailPage : ContentPage
    {
        private CompanyDetailViewModel viewModel;

        public CompanyDetailPage(CompanyDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public CompanyDetailPage()
        {
            InitializeComponent();

            var item = new Company
            {
                Text = "Company 1",
                Description = "This is an item description."
            };

            viewModel = new CompanyDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}