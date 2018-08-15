namespace KDRSManager.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            LoadApplication(new KDRSManager.App());
        }
    }
}