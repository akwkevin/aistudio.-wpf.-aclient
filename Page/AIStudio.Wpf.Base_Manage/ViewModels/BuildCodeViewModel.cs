using AIStudio.Core;
using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.Service.AppClient;
using Newtonsoft.Json;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Util.Controls;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class BuildCodeViewModel : BaseWindowViewModel<BuildCode>
    {
        private ObservableCollection<Base_DbLinkDTO> _base_DbLinkDTO;
        public ObservableCollection<Base_DbLinkDTO> Base_DbLinkDTO
        {
            get { return _base_DbLinkDTO; }
            set
            {
                if (_base_DbLinkDTO != value)
                {
                    _base_DbLinkDTO = value;
                    RaisePropertyChanged("Base_DbLinkDTO");
                }
            }
        }

        private string _linkId;
        public string LinkId
        {
            get { return _linkId; }
            set
            {
                if (_linkId != value)
                {
                    _linkId = value;
                    RaisePropertyChanged("LinkId");
                }
            }
        }

        private string _areaName = "Base_Manage";
        public string AreaName
        {
            get { return _areaName; }
            set
            {
                SetProperty(ref _areaName, value);
            }
        }

        private ICommand _addCommand;
        public new ICommand AddCommand
        {
            get
            {
                return this._addCommand ?? (this._addCommand = new CanExecuteDelegateCommand(() => this.Edit(), () => Data != null && Data.Count(p => p.IsChecked) > 0));
            }
        }

        private ICommand _generateCommand;
        public ICommand GenerateCommand
        {
            get
            {
                return this._generateCommand ?? (this._generateCommand = new CanExecuteDelegateCommand(() => this.Generate(), () => Data != null && Data.Count(p => p.IsChecked) > 0));
            }
        }

        private string directory;
        private string tmpFileText;
        private string savePath;

        public BuildCodeViewModel() : base("Base_Manage", typeof(BuildCodeEditViewModel), typeof(BuildCodeEdit))
        {
            var basedir = AppDomain.CurrentDomain.BaseDirectory;

            directory = basedir.Substring(0, basedir.IndexOf("Application"));
        }

        public override void Initialize()
        {
            base.Initialize();
            GetData();
        }

        private async Task GetDbTableInfo()
        {
            var result = await _dataProvider.GetData<List<Base_DbLinkDTO>>($"/{Area}/BuildCode/GetAllDbLink");
            if (!result.Success)
            {
                throw new Exception(result.Msg);
            }
            else
            {
                Base_DbLinkDTO = new ObservableCollection<Base_DbLinkDTO>(result.Data);
            }
        }

        protected override async void GetData(bool iswaiting = false)
        {
            try
            {
                if (iswaiting == false)
                {
                    ShowWait();
                }

                await GetDbTableInfo();
                LinkId = Base_DbLinkDTO.FirstOrDefault()?.Id;

                var result = await _dataProvider.GetData<List<BuildCode>>($"/{Area}/{typeof(BuildCode).Name.Replace("DTO", "")}/GetDbTableList", JsonConvert.SerializeObject(new { linkId = LinkId }));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    Pagination.Total = result.Total;
                    Data = new ObservableCollection<BuildCode>(result.Data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (iswaiting == false)
                {
                    HideWait();
                }
            }
        }

        protected override async void Edit(BuildCode para = null)
        {
            var viewmodel = new BuildCodeEditViewModel(para, Identifier);
            var dialog = new BuildCodeEdit(viewmodel);
            dialog.ValidationAction = (() =>
            {
                if (viewmodel.BuildType.Any(p => p == true) == false)
                    return false;

                if (string.IsNullOrEmpty(viewmodel.AreaName))
                    return false;

                return true;
            });
            var res = (BaseDialogResult)await WindowBase.ShowDialogAsync(dialog, Identifier);
            if (res == BaseDialogResult.OK)
            {
                try
                {
                    ShowWait();

                    List<string> ids = Data.Where(p => p.IsChecked).Select(p => p.TableName).ToList();
                    List<int> types = viewmodel.BuildType.Take(4).Select((p, index) => new { value = p == true ? 1 : 0, index = index }).Where(p => p.value == 1).Select(p => p.index).ToList();

                    if (types.Count > 0)
                    {

                        var data = new
                        {
                            linkId = LinkId,
                            areaName = viewmodel.AreaName,
                            tables = ids.ToArray(),
                            buildTypes = types.ToArray()
                        };

                        var result = await _dataProvider.GetData<AjaxResult>("/Base_Manage/BuildCode/Build", JsonConvert.SerializeObject(data));
                        if (!result.Success)
                        {
                            throw new Exception(result.Msg);
                        }
                    }

                    if (viewmodel.BuildType[4] == true)
                    {
                        Generate(viewmodel.AreaName, ids, viewmodel.IsCover);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    HideWait();
                }
            }
        }

        private static readonly List<string> ignoreProperties =
            new List<string> { "Id", "CreateTime", "CreatorId", "CreatorName", "Deleted", "ModifyTime", "ModifyId", "ModifyName", "TenantId" };

        private List<BuildCode> Generate(string areaName, List<string> entityNames, bool isCover, bool preView = false)
        {
            List<BuildCode> buildCodes = new List<BuildCode>();
            foreach (var entityName in entityNames)
            {
                var buildCode = new BuildCode();
                buildCode.TableName = entityName;
                buildCode.IsChecked = true;
                buildCode.SubBuildCode = new List<SubBuildCode>();
                buildCodes.Add(buildCode);

                #region Model
                tmpFileText = File.ReadAllText(Path.Combine(directory, "Page", "AIStudio.Wpf.Home", "BuildCodeTemplate", "DTO.txt"));

                tmpFileText = tmpFileText.Replace("%areaName%", areaName).Replace("%entityName%", entityName);


                savePath = Path.Combine(
                               directory,
                               "Application",
                               "AIStudio.Wpf.Entity",                        
                               "DTOModels",
                               $"{areaName}",
                               $"{entityName}DTO.cs");

                SubBuildCode subBuildCode = new SubBuildCode();
                subBuildCode.Name = $"DTO类";
                subBuildCode.Path = savePath;
                subBuildCode.TempPath = Path.Combine(
                               directory,
                               "Application",
                               "AIStudio.Wpf.Entity",
                               "DTOModels",
                               "areaName",
                               $"{entityName}DTO.cs");
                subBuildCode.Code = tmpFileText;
                subBuildCode.FileName = $"{entityName}DTO";
                subBuildCode.Suffix = "cs"; 
                buildCode.SubBuildCode.Add(subBuildCode);

                if ((isCover || !File.Exists(savePath)) && preView == false)
                    FileHelper.WriteTxt(tmpFileText, savePath, Encoding.UTF8, FileMode.Create);
                #endregion

                #region 列表界面
                //
                List<string> selectOptionsList = new List<string>();
                List<string> listColumnsList = new List<string>();
                List<string> formColumnsList = new List<string>();

                tmpFileText = File.ReadAllText(Path.Combine(directory, "Page", "AIStudio.Wpf.Home", "BuildCodeTemplate", "List.txt"));

                tmpFileText = tmpFileText.Replace("%areaName%", areaName).Replace("%entityName%", entityName);

                tmpFileText = tmpFileText.Replace("%selectOptions%", string.Join("\r\n", selectOptionsList));
                tmpFileText = tmpFileText.Replace("%listColumns%", string.Join("\r\n", listColumnsList));

                savePath = Path.Combine(
                               directory,
                               "Page",
                               $"AIStudio.Wpf.{areaName}",
                               "Views",
                               $"{entityName}View.xaml");

                subBuildCode = new SubBuildCode();
                subBuildCode.Name = $"列表Xaml";
                subBuildCode.Path = savePath;
                subBuildCode.TempPath = Path.Combine(
                               directory,
                               "Page",
                               "AIStudio.Wpf.areaName",
                               "Views",
                               $"{entityName}View.xaml");
                subBuildCode.Code = tmpFileText;
                subBuildCode.FileName = $"{entityName}View";
                subBuildCode.Suffix = "xaml";
                buildCode.SubBuildCode.Add(subBuildCode);

                if ((isCover || !File.Exists(savePath)) && preView == false)
                    FileHelper.WriteTxt(tmpFileText, savePath, Encoding.UTF8, FileMode.Create);

                //
                tmpFileText = File.ReadAllText(Path.Combine(directory, "Page", "AIStudio.Wpf.Home", "BuildCodeTemplate", "Listcs.txt"));

                tmpFileText = tmpFileText.Replace("%areaName%", areaName).Replace("%entityName%", entityName);

                savePath = Path.Combine(
                               directory,
                               "Page",
                               $"AIStudio.Wpf.{areaName}",
                               "Views",
                               $"{entityName}View.xaml.cs");

                subBuildCode = new SubBuildCode();
                subBuildCode.Name = $"列表cs";
                subBuildCode.Path = savePath;
                subBuildCode.TempPath = Path.Combine(
                               directory,
                               "Page",
                               "AIStudio.Wpf.areaName",
                               "Views",
                               $"{entityName}View.xaml.cs");
                subBuildCode.Code = tmpFileText;
                subBuildCode.FileName = $"{entityName}View";
                subBuildCode.Suffix = "xaml.cs";
                buildCode.SubBuildCode.Add(subBuildCode);

                if ((isCover || !File.Exists(savePath)) && preView == false)
                    FileHelper.WriteTxt(tmpFileText, savePath, Encoding.UTF8, FileMode.Create);

                //
                tmpFileText = File.ReadAllText(Path.Combine(directory, "Page", "AIStudio.Wpf.Home", "BuildCodeTemplate", "Listviewmodel.txt"));

                tmpFileText = tmpFileText.Replace("%areaName%", areaName).Replace("%entityName%", entityName);

                savePath = Path.Combine(
                               directory,
                               "Page",
                               $"AIStudio.Wpf.{areaName}",
                               "ViewModels",
                               $"{entityName}ViewModel.cs");

                subBuildCode = new SubBuildCode();
                subBuildCode.Name = $"列表VM";
                subBuildCode.Path = savePath;
                subBuildCode.TempPath = Path.Combine(
                               directory,
                               "Page",
                               $"AIStudio.Wpf.areaName",
                               "ViewModels",
                               $"{entityName}ViewModel.cs");

                subBuildCode.Code = tmpFileText;
                subBuildCode.FileName = $"{entityName}ViewModel";
                subBuildCode.Suffix = "cs";
                buildCode.SubBuildCode.Add(subBuildCode);

                if ((isCover || !File.Exists(savePath)) && preView == false)
                    FileHelper.WriteTxt(tmpFileText, savePath, Encoding.UTF8, FileMode.Create);
                #endregion

                #region 编辑界面
                //
                string fullClassName = "AIStudio.Wpf.Entity.Models." + entityName;

                //根据类名称创建类实例
                var type = System.Reflection.Assembly.Load("AIStudio.Wpf.Entity").GetType(fullClassName);
                string fieldDesc = string.Empty;
                foreach (System.Reflection.PropertyInfo info in type.GetProperties().Where(p => !ignoreProperties.Contains(p.Name)))
                {
                    fieldDesc = info.Name;
                    object[] objs = info.GetCustomAttributes(typeof(DescriptionAttribute), true);
                    if (objs.Length > 0)
                    {
                        fieldDesc = ((DescriptionAttribute)objs[0]).Description;
                    }

                    selectOptionsList.Add(
$"				<ComboBoxItem Tag=\"{info.Name}\">{fieldDesc}</ComboBoxItem>");

                    listColumnsList.Add(
$"				<DataGridTextColumn Header=\"{fieldDesc}\"  Binding=\"{{Binding {info.Name}}}\" IsReadOnly=\"True\"/>");

                    formColumnsList.Add(
"                        <HeaderedContentControl Style=\"{StaticResource LeftFormItemStyle}\">" + "\r\n" +
"                            <HeaderedContentControl.Header>" + "\r\n" +
"                                <TextBlock VerticalAlignment=\"Center\">" + "\r\n" +
"                                    <Run Foreground=\"Red\">*</Run>" + "\r\n" +
"                                    <Run>" + fieldDesc + "</Run>" + "\r\n" +
"                                </TextBlock>" + "\r\n" +
"                            </HeaderedContentControl.Header>" + "\r\n" +
"                            <TextBox Text=\"{Binding " + info.Name + ",Mode=TwoWay,UpdateSourceTrigger=PropertyChanged, ValidatesOnExceptions=True, ValidatesOnDataErrors=True, NotifyOnValidationError=True}\" Style=\"{StaticResource ToolTipErrorTextBox}\" IsReadOnly=\"{ Binding Disabled}\"></TextBox>" + "\r\n" +
"                        </HeaderedContentControl>");


                }           

                tmpFileText = File.ReadAllText(Path.Combine(directory, "Page", "AIStudio.Wpf.Home", "BuildCodeTemplate", "EditForm.txt"));

                tmpFileText = tmpFileText.Replace("%areaName%", areaName).Replace("%entityName%", entityName);

                tmpFileText = tmpFileText.Replace("%formColumns%", string.Join("\r\n", formColumnsList));

                savePath = Path.Combine(
                               directory,
                               "Page",
                               $"AIStudio.Wpf.{areaName}",
                               "Views",
                               $"{entityName}Edit.xaml");

                subBuildCode = new SubBuildCode();
                subBuildCode.Name = $"编辑Xaml";
                subBuildCode.Path = savePath;
                subBuildCode.TempPath = Path.Combine(
                               directory,
                               "Page",
                               $"AIStudio.Wpf.areaName",
                               "Views",
                               $"{entityName}Edit.xaml");
                subBuildCode.FileName = $"{entityName}Edit";
                subBuildCode.Code = tmpFileText;
                subBuildCode.Suffix = "xaml";
                buildCode.SubBuildCode.Add(subBuildCode);

                if ((isCover || !File.Exists(savePath)) && preView == false)
                    FileHelper.WriteTxt(tmpFileText, savePath, Encoding.UTF8, FileMode.Create);

                //
                tmpFileText = File.ReadAllText(Path.Combine(directory, "Page", "AIStudio.Wpf.Home", "BuildCodeTemplate", "EditFormcs.txt"));

                tmpFileText = tmpFileText.Replace("%areaName%", areaName).Replace("%entityName%", entityName);

                savePath = Path.Combine(
                               directory,
                               "Page",
                               $"AIStudio.Wpf.{areaName}",
                               "Views",
                               $"{entityName}Edit.xaml.cs");

                subBuildCode = new SubBuildCode();
                subBuildCode.Name = $"编辑cs";
                subBuildCode.Path = savePath;
                subBuildCode.TempPath = Path.Combine(
                               directory,
                               "Page",
                               $"AIStudio.Wpf.areaName",
                               "Views",
                               $"{entityName}Edit.xaml.cs");
                subBuildCode.FileName = $"{entityName}Edit";
                subBuildCode.Code = tmpFileText;
                subBuildCode.Suffix = "xaml.cs";
                buildCode.SubBuildCode.Add(subBuildCode);

                if ((isCover || !File.Exists(savePath)) && preView == false)
                    FileHelper.WriteTxt(tmpFileText, savePath, Encoding.UTF8, FileMode.Create);

                tmpFileText = File.ReadAllText(Path.Combine(directory, "Page", "AIStudio.Wpf.Home", "BuildCodeTemplate", "EditFormviewmodel.txt"));

                tmpFileText = tmpFileText.Replace("%areaName%", areaName).Replace("%entityName%", entityName);

                savePath = Path.Combine(
                               directory,
                               "Page",
                               $"AIStudio.Wpf.{areaName}",
                               "ViewModels",
                               $"{entityName}EditViewModel.cs");

                subBuildCode = new SubBuildCode();
                subBuildCode.Name = $"编辑VM";
                subBuildCode.Path = savePath;
                subBuildCode.TempPath = Path.Combine(
                               directory,
                               "Page",
                               $"AIStudio.Wpf.areaName",
                               "ViewModels",
                               $"{entityName}EditViewModel.cs");
                subBuildCode.FileName = $"{entityName}EditViewModel";
                subBuildCode.Code = tmpFileText;
                subBuildCode.Suffix = "cs";
                buildCode.SubBuildCode.Add(subBuildCode);

                if ((isCover || !File.Exists(savePath)) && preView == false)
                    FileHelper.WriteTxt(tmpFileText, savePath, Encoding.UTF8, FileMode.Create);
                #endregion


                #region 打印
                tmpFileText = File.ReadAllText(Path.Combine(directory, "Page", "AIStudio.Wpf.Home", "BuildCodeTemplate", "FlowForm.txt"));

                List<string> tableColumnsList = new List<string>();
                List<string> tableCellsList = new List<string>();

                foreach (System.Reflection.PropertyInfo info in type.GetProperties().Where(p => !ignoreProperties.Contains(p.Name)))
                {
                    fieldDesc = info.Name;
                    object[] objs = info.GetCustomAttributes(typeof(DescriptionAttribute), true);
                    if (objs.Length > 0)
                    {
                        fieldDesc = ((DescriptionAttribute)objs[0]).Description;
                    }

                    tableColumnsList.Add(
$"            <TableColumn Width=\"*\"></TableColumn>");

                    tableCellsList.Add(
"                <TableCell Style=\"{ StaticResource BorderedCell}\">\r\n" +
$"                    <Paragraph>{fieldDesc}</Paragraph>\r\n" +
"               </TableCell>\r\n");
                }

                tmpFileText = tmpFileText.Replace("%tablecolumns%", string.Join("\r\n", tableColumnsList));
                tmpFileText = tmpFileText.Replace("%tablecells%", string.Join("\r\n", tableCellsList));

                savePath = Path.Combine(
                                    directory,
                                    "Page",
                                    $"AIStudio.Wpf.{areaName}",
                                    "Views",
                                    $"{entityName}FlowDocument.xaml");

                subBuildCode = new SubBuildCode();
                subBuildCode.Name = $"打印Xaml";
                subBuildCode.Path = savePath;
                subBuildCode.TempPath = Path.Combine(
                                    directory,
                                    "Page",
                                    $"AIStudio.Wpf.areaName",
                                    "Views",
                                    $"{entityName}FlowDocument.xaml");
                subBuildCode.FileName = $"{entityName}FlowDocument";
                subBuildCode.Code = tmpFileText;
                subBuildCode.Suffix = "xaml";
                buildCode.SubBuildCode.Add(subBuildCode);

                if ((isCover || !File.Exists(savePath)) && preView == false)
                    FileHelper.WriteTxt(tmpFileText, savePath, Encoding.UTF8, FileMode.Create);

                tmpFileText = File.ReadAllText(Path.Combine(directory, "Page", "AIStudio.Wpf.Home", "BuildCodeTemplate", "FlowRenderer.txt"));

                List<string> tableRowsList = new List<string>();

                foreach (System.Reflection.PropertyInfo info in type.GetProperties().Where(p => !ignoreProperties.Contains(p.Name)))
                {
                    if (info.PropertyType.ToString() == "System.String")
                    {
                        tableRowsList.Add(
$"                    cell = new TableCell(new Paragraph(new Run(item.{info.Name})));\r\n" +
"                    cell.Style = styleCell;\r\n" +
"                    row.Cells.Add(cell);\r\n");
                    }
                    else
                    {
                        tableRowsList.Add(
    $"                    cell = new TableCell(new Paragraph(new Run(item.{info.Name}.ToString())));\r\n" +
    "                    cell.Style = styleCell;\r\n" +
    "                    row.Cells.Add(cell);\r\n");
                    }
                }


                tmpFileText = tmpFileText.Replace("%areaName%", areaName).Replace("%entityName%", entityName);
                tmpFileText = tmpFileText.Replace("%tablerow%", string.Join("\r\n", tableRowsList));

                savePath = Path.Combine(
                              directory,
                              "Page",
                              $"AIStudio.Wpf.{areaName}",
                              "ViewModels",
                              $"{entityName}DocumentRenderer.cs");

                subBuildCode = new SubBuildCode();
                subBuildCode.Name = $"打印cs";
                subBuildCode.Path = savePath;
                subBuildCode.TempPath = Path.Combine(
                              directory,
                              "Page",
                              $"AIStudio.Wpf.areaName",
                              "ViewModels",
                              $"{entityName}DocumentRenderer.cs");
                subBuildCode.FileName = $"{entityName}DocumentRenderer";
                subBuildCode.Code = tmpFileText;
                subBuildCode.Suffix = "cs";
                buildCode.SubBuildCode.Add(subBuildCode);

                if ((isCover || !File.Exists(savePath)) && preView == false)
                    FileHelper.WriteTxt(tmpFileText, savePath, Encoding.UTF8, FileMode.Create);
                #endregion
            }

            return buildCodes;
        }


        private void Generate()
        {
            List<BuildCode> buildCode = Generate(AreaName, Data.Where(p => p.IsChecked).Select(p => p.TableName).ToList(), false, true);
            BuildCodeEditWindow window = new BuildCodeEditWindow();
            window.DataContext = new BuildCodeEditWindowViewModel(buildCode, AreaName, Identifier, "代码生成器");
            window.Show();
        }

    }
}
