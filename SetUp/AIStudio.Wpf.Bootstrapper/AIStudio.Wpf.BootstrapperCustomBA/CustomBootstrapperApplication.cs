using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using CustomBA.Models;
using CustomBA.ViewModels;
using CustomBA.Views;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using WinForms = System.Windows.Forms;


namespace CustomBA
{
    public class CustomBootstrapperApplication:BootstrapperApplication
    {
        public static Dispatcher Dispatcher { get; set; }
        static public DiaViewModel Model { get; private set; }
        static public InstallView View { get; private set; }

        protected override void Run()
        {
            Model = new DiaViewModel(this);
            Dispatcher = Dispatcher.CurrentDispatcher;
            var model = new BootstrapperApplicationModel(this);
            var viewModel = new InstallViewModel(model);
            View = new InstallView(viewModel);
            model.SetTargetFolderPath(viewModel.InstallFollder);
            model.SetWindowHandle(View);
            this.Engine.Detect();
            View.Show();
            Dispatcher.Run();
            this.Engine.Quit(model.FinalResult);
         
        }

        public static void Plan(LaunchAction action)
        {
             Model.PlannedAction = action;
             Model.Engine.Plan(Model.PlannedAction);
        }

      

        public static void PlanLayout()
        {
            // Either default or set the layout directory
            if (String.IsNullOrEmpty(Model.Command.LayoutDirectory))
            {
                Model.LayoutDirectory = Directory.GetCurrentDirectory();

                // Ask the user for layout folder if one wasn't provided and we're in full UI mode
                if (Model.Command.Display == Display.Full)
                {
                    Dispatcher.Invoke((Action)delegate()
                    {
                        WinForms.FolderBrowserDialog browserDialog = new WinForms.FolderBrowserDialog();
                        browserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

                        // Default to the current directory.
                        browserDialog.SelectedPath = Model.LayoutDirectory;
                        WinForms.DialogResult result = browserDialog.ShowDialog();

                        if (WinForms.DialogResult.OK == result)
                        {
                            Model.LayoutDirectory = browserDialog.SelectedPath;
                            Plan(Model.Command.Action);
                        }
                        else
                        {
                            View.Close();
                        }
                    }
                    );
                }
            }
            else
            {
                Model.LayoutDirectory = Model.Command.LayoutDirectory;
                Plan(Model.Command.Action);
            }
        }
    }
}
