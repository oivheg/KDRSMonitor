using System;
using System.Collections.Generic;
using System.Text;

namespace KDRSManager.Connections
{
    internal class NetworkCheck
    {
        public static bool IsInternet()
        {
            return true;
            //if (CrossConnectivity.Current.IsConnected)
            //{
            //    return true;
            //}
            //else
            //{
            //    // write your code if there is no Internet available
            //    return false;
            //}
        }
    }
}