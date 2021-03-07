using AIStudio.Wpf.Service.AppClient;
using System;

namespace AIStudio.Wpf.ServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DataProvider dataProvider = new DataProvider("http://localhost:5000", "Admin", "Admin", 1);
            var token = dataProvider.GetToken().Result;
        }
    }
}
