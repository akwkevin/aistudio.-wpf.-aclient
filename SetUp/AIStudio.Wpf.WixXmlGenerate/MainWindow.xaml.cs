using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace AIStudio.Wpf.WixXmlGenerate
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        string _directory = AppDomain.CurrentDomain.BaseDirectory;

        public MainWindow()
        {
            InitializeComponent();

            txtSourcePath.Text = LocalSetting.SourcePath;
            txtDestPath.Text = LocalSetting.DestPath;
            txtFilter.Text = LocalSetting.Filter;

            var tmpFileText = File.ReadAllText(Path.Combine(_directory, "BuildCodeTemplate", "Product.txt"));

            textEditor.Text = tmpFileText;
        }

        private void btnBrowerSource_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "请选择源路径";
            folderBrowserDialog.SelectedPath = txtSourcePath.Text;
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtSourcePath.Text = folderBrowserDialog.SelectedPath;
                LocalSetting.SetAppSetting("SourcePath", txtSourcePath.Text);
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            List<string> refList = new List<string>();
            List<string> dirList = new List<string>();
            List<string> fileList = new List<string>();
            List<string> dirComponentList = new List<string>();
            var filters = txtFilter.Text.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
          
            List<FileTree> trees = new List<FileTree>();
            var parenttree = GetFileTree(txtSourcePath.Text, trees, filters);
            //遍历文件
            foreach (FileInfo NextFile in parenttree.DirectoryInfo.GetFiles())
            {
                if (filters.Any(p => NextFile.Name.Contains(p)))
                    continue;

                string file = $"        <File Id=\"{NextFile.Name.Replace("-", "")}\"  Source=\"{NextFile.FullName}\" />";
                fileList.Add(file);
            }

            //遍历文件jia
            foreach (var tree in trees.Except(new List<FileTree> { parenttree }))
            {
                if (tree.DirectoryInfo.GetFiles().Length == 0)
                    continue;

                string comref = $"      <ComponentRef Id=\"{tree.DirectoryInfo.Name.Replace("-", "")}Ref\" />";
                refList.Add(comref);

                List<string> subfileList = new List<string>();
                foreach (FileInfo NextFile in tree.DirectoryInfo.GetFiles())
                {
                    if (filters.Any(p => NextFile.Name.Contains(p)))
                        continue;

                    string file = $"        <File Id=\"{tree.DirectoryInfo.Name.Replace("-", "") + NextFile.Name.Replace("-", "")}\"  Source=\"{NextFile.FullName}\" />";
                    subfileList.Add(file);
                }

                string dirComponent = $"    <DirectoryRef Id=\"{tree.DirectoryInfo.Name.Replace("-", "")}\">\r\n"
                   + $"      <Component Id = \"{tree.DirectoryInfo.Name.Replace("-", "")}Ref\" Guid = \"{Guid.NewGuid()}\">\r\n"
                   + string.Join("\r\n", subfileList) + "\r\n"
                   + "      </Component>\r\n"
                   + "    </DirectoryRef>\r\n";

                dirComponentList.Add(dirComponent);
            }

            SetDirectory(parenttree, dirList, 0);

            //DirectoryInfo TheFolder = new DirectoryInfo(txtSourcePath.Text);
            ////遍历文件夹
            //foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
            //{
            //    string dir = $"        <Directory Id =\"{NextFolder.Name.Replace("-", "")}\" Name = \"{NextFolder.Name}\" />";
            //    dirList.Add(dir);               

            //    string comref = $"      <ComponentRef Id=\"{NextFolder.Name.Replace("-", "")}Ref\" />";
            //    refList.Add(comref);


            //    List<string> subfileList = new List<string>();
            //    foreach (FileInfo NextFile in NextFolder.GetFiles())
            //    {
            //        string file = $"        <File Id=\"{NextFolder.Name.Replace("-", "") + NextFile.Name}\"  Source=\"{NextFile.FullName}\" />";
            //        subfileList.Add(file);
            //    }

            //    string dirComponent = $"    <DirectoryRef Id=\"{NextFolder.Name.Replace("-", "")}\">\r\n"
            //       + $"      <Component Id = \"{NextFolder.Name.Replace("-", "")}Ref\" Guid = \"{Guid.NewGuid()}\">\r\n"
            //       + string.Join("\r\n", subfileList) + "\r\n"
            //       + "      </Component>\r\n"
            //       + "    </DirectoryRef>\r\n";

            //    dirComponentList.Add(dirComponent);
            //}


            ////遍历文件
            //foreach (FileInfo NextFile in TheFolder.GetFiles())
            //{
            //    string file = $"        <File Id=\"{NextFile.Name}\"  Source=\"{NextFile.FullName}\" />";
            //    fileList.Add(file);
            //}

            var tmpFileText = File.ReadAllText(Path.Combine(_directory, "BuildCodeTemplate", "Product.txt"));
            tmpFileText = tmpFileText.Replace("%componentRef%", string.Join("\r\n", refList));
            tmpFileText = tmpFileText.Replace("%file%", string.Join("\r\n", fileList));
            tmpFileText = tmpFileText.Replace("%dir%", string.Join("\r\n", dirList));
            tmpFileText = tmpFileText.Replace("%dirComponent%", string.Join("\r\n", dirComponentList));
            textEditor.Text = tmpFileText;
        }

        private FileTree GetFileTree(string path, List<FileTree> trees, string[] filters)
        {
            DirectoryInfo TheFolder = new DirectoryInfo(path);          

            FileTree tree = new FileTree();
            trees.Add(tree);

            tree.DirectoryInfo = TheFolder;
            GetChildren(tree, TheFolder, trees, filters);

            return tree;
        }

        public void GetChildren(FileTree tree, DirectoryInfo TheFolder, List<FileTree> trees, string[] filters)
        {
           
            foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
            {
                if (filters.Any(p => tree.DirectoryInfo.Name.Contains(p)))
                    continue;

                FileTree childtree = new FileTree();
                trees.Add(childtree);

                childtree.DirectoryInfo = NextFolder; 
                tree.Children.Add(childtree);

                GetChildren(childtree, NextFolder, trees, filters);
            }
        }

        public void SetDirectory(FileTree tree, List<string> list, int level)
        {    
            if (level != 0)
            {
                list.Add("".PadLeft(level, ' ') + $"        <Directory Id =\"{tree.DirectoryInfo.Name.Replace("-", "")}\" Name = \"{tree.DirectoryInfo.Name}\" >");
            }
            
            foreach(var child in tree.Children)
            {
                SetDirectory(child, list, level + 4);
            }

            if (level != 0)
            {
                list.Add("".PadLeft(level, ' ') + "        </Directory>");
            }
        }

        private void btnBrowerDest_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = txtDestPath.Text;
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)//注意，此处一定要手动引入System.Window.Forms空间，否则你如果使用默认的DialogResult会发现没有OK属性
            {
                txtDestPath.Text = saveFileDialog.FileName;
                LocalSetting.SetAppSetting("DestPath", txtDestPath.Text);

                using (FileStream fileStream = new FileStream(txtDestPath.Text, FileMode.Create))
                {
                    using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                    {
                        streamWriter.Write(textEditor.Text);
                        streamWriter.Flush();
                    }
                }
            }
        }

    }

    public class FileTree
    {
        public List<FileTree> Children { get; set; } = new List<FileTree>();

        public DirectoryInfo DirectoryInfo { get; set; }
    }
}
