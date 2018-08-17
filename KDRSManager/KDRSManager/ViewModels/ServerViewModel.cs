using KDRSManager.Connections;
using KDRSManager.Data;
using KDRSManager.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace KDRSManager.ViewModels
{
    public class ServerViewModel : BaseViewModel
    {
        public Command LoadServersCommand { get; set; }
        public ObservableCollection<Server> Servers { get; set; }
        public ServerViewModel()
        {
            Title = "Server";
            WebRequest wb = new WebRequest();
            Servers = new ObservableCollection<Server>();
            LoadServersCommand = new Command(() => ExecuteLoadServersCommand());
        }
        private void ExecuteLoadServersCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            foreach (var server in StoredData.GetServers())
            {
                try
                {
                    Server srv = new Server(server.Adress, server.UserID, server.Password);
                    Servers.Add(srv);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }

        public ICommand OpenWebCommand { get; }
    }
}