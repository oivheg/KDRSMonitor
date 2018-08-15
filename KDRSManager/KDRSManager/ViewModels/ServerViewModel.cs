using KDRSManager.Connections;
using KDRSManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
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