using System;
using System.IO;
using System.Windows;

public class DemoHelper
{
    static DemoHelper()
    {
        directory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).ToString()).ToString()).ToString()).ToString();
    }

    public static string GetCode(string demoName)
    {
        var uri = new Uri($"/AIStudio.Wpf.DemoPage;component/{demoName}", UriKind.Relative);
        var resourceStream = Application.GetResourceStream(uri);
        if (resourceStream != null)
        {
            using (var reader = new StreamReader(resourceStream.Stream))
            {
                var code = reader.ReadToEnd();
                return code;
            }
        }

        return "";
    }
    private static string directory;
    public static string GetCodeByFile(string demoName)
    {
        using (Stream s = new FileStream(Path.Combine(directory, "AIStudio.Wpf.DemoPage", demoName), FileMode.Open, FileAccess.Read))
        {
            using (var reader = new StreamReader(s))
            {
                var code = reader.ReadToEnd();
                return code;
            }
        }
    }
}