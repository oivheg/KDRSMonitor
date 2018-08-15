using KDRSManager.Connections;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace KDRSManager.ViewModels
{
    public class ServerViewModel : BaseViewModel
    {
        public ServerViewModel()
        {
            Title = "Server";
            WebRequest wb = new WebRequest();

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
            //OpenWebCommand = new Command(async () => LoadXMLCompanies(await wb.GetXml().ConfigureAwait(false)));
        }

        public ICommand OpenWebCommand { get; }
    }
}