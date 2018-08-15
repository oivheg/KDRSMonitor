using KDRSManager.Models;

namespace KDRSManager.ViewModels
{
    public class CompanyDetailViewModel : BaseViewModel
    {
        public Company Item { get; set; }

        public CompanyDetailViewModel(Company item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}