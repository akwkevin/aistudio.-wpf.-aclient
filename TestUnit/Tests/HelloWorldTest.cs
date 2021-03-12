using System.Windows;
using Xunit;

namespace AIStudio.Wpf.TestUnit.Tests
{
    public class Class1
    {
        public double GetSomeValue(double d)
        {
            return d * d;
        }
    }

    public class ClassTest
    {
        [Fact]
        public void TestRun()     
        {
            Class1 obj = new Class1();

            double expected = 9;
            double result = obj.GetSomeValue(3);
            Assert.Equal(expected, result);
        }

        [StaFact]
        public void TestMessageBox()
        {
            var result = MessageBox.Show("HelloWorld", "标题", MessageBoxButton.YesNo, MessageBoxImage.Information);
            Assert.Equal(MessageBoxResult.Yes, result);
        }
    }
}
