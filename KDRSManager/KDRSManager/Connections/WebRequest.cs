using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KDRSManager.Connections
{
    public class WebRequest
    {
        public async Task<String> GetXml()
        {
            String response = null;
            //Check network status
            if (NetworkCheck.IsInternet())
            {
                String srv = "91.192.221.234";
                String RT = "2";
                int YR = 2018;
                int M = 7;
                int D = 11;
                int username = 999;
                String pw = "fuglekasser";
                Uri geturi = new Uri("http://" + srv + ":8008/KDRPhoneService.svc/GetSalesReport?reportType=" + RT + "&yr=" + YR + "&m=" + M + "&d=" + D + "&username=%27" + username + "%27&password=%27" + pw + "%27"); //replace your xml url
                HttpClient client = new HttpClient();
                HttpResponseMessage responseGet = await client.GetAsync(geturi);
                response = await responseGet.Content.ReadAsStringAsync();//Getting response
            }

            return response;
        }
    }
}