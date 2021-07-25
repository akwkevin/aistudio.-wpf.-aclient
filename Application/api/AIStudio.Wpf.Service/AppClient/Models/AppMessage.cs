namespace AIStudio.Wpf.Service.AppClient.Models
{
    public class AppMessage
    {
        public CompressionType Zip { get; set; }

        public WebMessageType Type { get; set; }

        public string Verson { get; set; }

        public string[] Datas { get; set; }
    }
}
