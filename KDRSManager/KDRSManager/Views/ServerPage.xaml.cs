using KDRSManager.Models;
using KDRSManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KDRSManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServerPage : ContentPage
    {
        private ServerViewModel viewModel;
        public ServerPage()
        {
            InitializeComponent();
            //BindingContext = viewModel = new ServerViewModel();
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    if (viewModel.Servers.Count == 0)
        //        viewModel.LoadServersCommand.Execute(null);
        //}
    }
}