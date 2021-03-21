using AIStudio.Wpf.Business;

namespace AIStudio.Wpf.ServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiDataProvider dataProvider = new ApiDataProvider("http://localhost:5000", "Admin", "Admin", 1);
            var token = dataProvider.GetToken().Result;
        }
    }
}
