﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace KDRSManager.Connections
{
    public class WebRequest
    {
        public async Task<String> GetXml(String _srv)
        {
            String response = null;
            //Check network status
            if (NetworkCheck.IsInternet())
            {
                DateTime DT = DateTime.Today;
                String srv = _srv;
                String RT = "2";
                int YR = DT.Year;
                int M = DT.Month;
                int D = DT.Day;
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