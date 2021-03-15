using AIStudio.Core;
using AIStudio.Wpf.Home;
using AIStudio.Wpf.Home.Views;
using AIStudio.Wpf.TestUnit.TestHelpers;
using System.Threading.Tasks;
using System.Windows;
using Xunit;

namespace AIStudio.Wpf.TestUnit.Tests
{
    public class OpenWindowTest : AutomationTestBase
    {
        [Fact]
        [DisplayTestMethodName]

        public async Task OpenTest()
        {
            await TestHost.SwitchToAppThread();
            
            var homeView = new IntroduceView();
            var window = new Window();
            window.Content = homeView;
            window.ShowDialog();
            Assert.NotNull(window.Content);
        }
    }
}
