using KDRSManager.Connections;
using KDRSManager.Data;
using KDRSManager.Models;
using KDRSManager.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;

namespace KDRSManager.ViewModels
{
    public class CompanyViewModel : BaseViewModel
    {
        public ObservableCollection<Company> Companies { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CompanyViewModel()
        {
            Title = "Browse";
            Companies = new ObservableCollection<Company>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadCompaniesCommand().ConfigureAwait(false));

            MessagingCenter.Subscribe<NewItemPage, Company>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Company;
                Companies.Add(_item);
                await DataStore.AddItemAsync(_item);
            });
        }

        private WebRequest wb = new WebRequest();

        private async Task ExecuteLoadCompaniesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            foreach (var servers in StoredData.GetServers())
            {
                try
                {
                    //this.Companies.Clear();

                    // var items = await DataStore.GetItemsAsync(true);
                    foreach (var item in await LoadXMLCompanies(await wb.GetXml(servers.Adress).ConfigureAwait(false)))
                    {
                        Companies.Add(item);
                    }
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

        private async Task<List<Company>> LoadXMLCompanies(String xml)
        {
            List<Company> rawData = null;
            await Task.Factory.StartNew(delegate
            {
                XNamespace m = XNamespace.Get("http://schemas.microsoft.com/ado/2007/08/dataservices/metadata");
                XNamespace d = XNamespace.Get("http://schemas.microsoft.com/ado/2007/08/dataservices");
                XDocument doc = XDocument.Parse(xml);
                IEnumerable<Company> Companies = from s in doc.Descendants().Where(x => x.Name.LocalName == "properties")

                                                 select new Company
                                                 {
                                                     Id = s.Element(d + "ID").Value,
                                                     Text = s.Element(d + "Name").Value,
                                                     Description = "Totalt Salg i dag:  " + s.Element(d + "SalesAmount").Value,
                                                 };
                rawData = Companies.ToList();
            });

            return rawData;
        }
    }
}