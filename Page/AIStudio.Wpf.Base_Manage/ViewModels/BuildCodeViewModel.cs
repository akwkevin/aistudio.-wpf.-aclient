using AIStudio.Core;
using AIStudio.DbFactory.DataAccess;
using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Entity.DTOModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        public BuildCodeViewModel() : base("Base_Manage", typeof(BuildCodeEditViewModel), typeof(BuildCodeEdit),"")
        {
            var basedir = AppDomain.CurrentDomain.BaseDirectory;

            directory = basedir.Substring(0, basedir.IndexOf("Application"));
        }

        public override async void Initialize()
        {
            if (IsInitialize)
            {
                return;
            }
            await GetDbTableInfo();
            base.Initialize();          
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
                LinkId = Base_DbLinkDTO.FirstOrDefault()?.Id;
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
                Controls.MessageBox.Error(ex.Message);
            }
            finally
            {
                if (iswaiting == false)
                {
                    HideWait();
                }
            }
        }

        #region 此方法是服务端代码生成的,不在客户端里搞了,废弃
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
            var res = (BaseDialogResult)await WindowBase.ShowDialogAsync2(dialog, Identifier);
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
                }
                catch (Exception ex)
                {
                    Controls.MessageBox.Error(ex.Message);
                }
                finally
                {
                    HideWait();
                }
            }
        }
        #endregion

        private async void Generate()
        {
            try
            {
                ShowWait();
                List<string> ids = Data.Where(p => p.IsChecked).Select(p => p.TableName).ToList();
                var data = new
                {
                    linkId = LinkId,
                    tables = ids.ToArray(),
                };

                var result = await _dataProvider.GetData<Dictionary<string, List<TableInfo>>>("/Base_Manage/BuildCode/GetDbTableInfo",
                    JsonConvert.SerializeObject(data));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }

                HideWait();

                List<BuildCode> buildCode = Generate(AreaName,
                    result.Data, false, true);
                BuildCodeEditWindow window = new BuildCodeEditWindow();
                window.DataContext = new BuildCodeEditWindowViewModel(buildCode, AreaName, Identifier, "代码生成器");
                window.Show();
            }
            catch (Exception ex)
            {
                Controls.MessageBox.Error(ex.Message);
            }
            finally
            {
                HideWait();
            }
        }

        private static readonly List<string> ignoreProperties =
            new List<string> { "Id", "CreateTime", "CreatorId", "CreatorName", "Deleted", "ModifyTime", "ModifyId", "ModifyName", "TenantId" };

        private List<BuildCode> Generate(string areaName, Dictionary<string, List<TableInfo>> entityInfos, bool isCover, bool preView = false)
        {
            List<BuildCode> buildCodes = new List<BuildCode>();
            foreach (var entityInfo in entityInfos)
            {
                var buildCode = new BuildCode();
                buildCode.TableName = entityInfo.Key;
                buildCode.IsChecked = true;
                buildCode.SubBuildCode = new List<SubBuildCode>();
                buildCodes.Add(buildCode);

                #region Model

                savePath = Path.Combine(
                    directory,
                    "Application",
                    "AIStudio.Wpf.Entity",
                    "Models",
                    $"{entityInfo.Key}.cs");

               
                var dbHelper = GetTheDbHelper(LinkId);

                string nameSpace = "AIStudio.Wpf.Entity.Models";

                tmpFileText = dbHelper.GetEntityString(entityInfo.Value, entityInfo.Key, Data.FirstOrDefault(p => p.TableName == entityInfo.Key).Description, nameSpace);

                SubBuildCode subBuildCode = new SubBuildCode();
                subBuildCode.Name = $"类";
                subBuildCode.Path = savePath;
                subBuildCode.TempPath = Path.Combine(
                    directory,
                    "Application",
                    "AIStudio.Wpf.Entity",
                    "Models",
                    $"{entityInfo.Key}.cs");
                subBuildCode.Code = tmpFileText;
                subBuildCode.FileName = $"{entityInfo.Key}";
                subBuildCode.Suffix = "cs";
                buildCode.SubBuildCode.Add(subBuildCode);

                if ((isCover || !File.Exists(savePath)) && preView == false)
                    FileHelper.WriteTxt(tmpFileText, savePath, Encoding.UTF8, FileMode.Create);
                #endregion

                #region DTOModel
                tmpFileText = File.ReadAllText(Path.Combine(directory, "Page", "AIStudio.Wpf.Home", "BuildCodeTemplate", "DTO.txt"));

                tmpFileText = tmpFileText.Replace("%areaName%", areaName).Replace("%entityName%", entityInfo.Key);


                savePath = Path.Combine(
                               directory,
                               "Application",
                               "AIStudio.Wpf.Entity",                        
                               "DTOModels",
                               $"{areaName}",
                               $"{entityInfo.Key}DTO.cs");
                subBuildCode = new SubBuildCode();
                subBuildCode.Name = $"DTO类";
                subBuildCode.Path = savePath;
                subBuildCode.TempPath = Path.Combine(
                               directory,
                               "Application",
                               "AIStudio.Wpf.Entity",
                               "DTOModels",
                               "areaName",
                               $"{entityInfo.Key}DTO.cs");
                subBuildCode.Code = tmpFileText;
                subBuildCode.FileName = $"{entityInfo.Key}DTO";
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

                //
                //string fullClassName = "AIStudio.Wpf.Entity.Models." + entityInfo;
                //根据类名称创建类实例
                //var type = System.Reflection.Assembly.Load("AIStudio.Wpf.Entity").GetType(fullClassName);


                tmpFileText = File.ReadAllText(Path.Combine(directory, "Page", "AIStudio.Wpf.Home", "BuildCodeTemplate", "List.txt"));
    
                foreach (var aField in entityInfo.Value.Where(x => !ignoreProperties.Contains(x.Name)))
                {
                    var fieldDesc = aField.Description;

                    selectOptionsList.Add(
                        $"				<ComboBoxItem Tag=\"{aField.Name}\">{fieldDesc}</ComboBoxItem>");

                    listColumnsList.Add(
                        $"				<DataGridTextColumn Header=\"{fieldDesc}\"  Binding=\"{{Binding {aField.Name}}}\" IsReadOnly=\"True\"/>");
                }

                tmpFileText = tmpFileText.Replace("%areaName%", areaName).Replace("%entityName%", entityInfo.Key);
                tmpFileText = tmpFileText.Replace("%selectOptions%", string.Join("\r\n", selectOptionsList));
                tmpFileText = tmpFileText.Replace("%listColumns%", string.Join("\r\n", listColumnsList));

                savePath = Path.Combine(
                               directory,
                               "Page",
                               $"AIStudio.Wpf.{areaName}",
                               "Views",
                               $"{entityInfo.Key}View.xaml");

                subBuildCode = new SubBuildCode();
                subBuildCode.Name = $"列表Xaml";
                subBuildCode.Path = savePath;
                subBuildCode.TempPath = Path.Combine(
                               directory,
                               "Page",
                               "AIStudio.Wpf.areaName",
                               "Views",
                               $"{entityInfo.Key}View.xaml");
                subBuildCode.Code = tmpFileText;
                subBuildCode.FileName = $"{entityInfo.Key}View";
                subBuildCode.Suffix = "xaml";
                buildCode.SubBuildCode.Add(subBuildCode);

                if ((isCover || !File.Exists(savePath)) && preView == false)
                    FileHelper.WriteTxt(tmpFileText, savePath, Encoding.UTF8, FileMode.Create);

                //
                tmpFileText = File.ReadAllText(Path.Combine(directory, "Page", "AIStudio.Wpf.Home", "BuildCodeTemplate", "Listcs.txt"));

                tmpFileText = tmpFileText.Replace("%areaName%", areaName).Replace("%entityName%", entityInfo.Key);

                savePath = Path.Combine(
                               directory,
                               "Page",
                               $"AIStudio.Wpf.{areaName}",
                               "Views",
                               $"{entityInfo.Key}View.xaml.cs");

                subBuildCode = new SubBuildCode();
                subBuildCode.Name = $"列表cs";
                subBuildCode.Path = savePath;
                subBuildCode.TempPath = Path.Combine(
                               directory,
                               "Page",
                               "AIStudio.Wpf.areaName",
                               "Views",
                               $"{entityInfo.Key}View.xaml.cs");
                subBuildCode.Code = tmpFileText;
                subBuildCode.FileName = $"{entityInfo.Key}View";
                subBuildCode.Suffix = "xaml.cs";
                buildCode.SubBuildCode.Add(subBuildCode);

                if ((isCover || !File.Exists(savePath)) && preView == false)
                    FileHelper.WriteTxt(tmpFileText, savePath, Encoding.UTF8, FileMode.Create);

                //
                tmpFileText = File.ReadAllText(Path.Combine(directory, "Page", "AIStudio.Wpf.Home", "BuildCodeTemplate", "Listviewmodel.txt"));

                tmpFileText = tmpFileText.Replace("%areaName%", areaName).Replace("%entityName%", entityInfo.Key);

                savePath = Path.Combine(
                               directory,
                               "Page",
                               $"AIStudio.Wpf.{areaName}",
                               "ViewModels",
                               $"{entityInfo.Key}ViewModel.cs");

                subBuildCode = new SubBuildCode();
                subBuildCode.Name = $"列表VM";
                subBuildCode.Path = savePath;
                subBuildCode.TempPath = Path.Combine(
                               directory,
                               "Page",
                               $"AIStudio.Wpf.areaName",
                               "ViewModels",
                               $"{entityInfo.Key}ViewModel.cs");

                subBuildCode.Code = tmpFileText;
                subBuildCode.FileName = $"{entityInfo.Key}ViewModel";
                subBuildCode.Suffix = "cs";
                buildCode.SubBuildCode.Add(subBuildCode);

                if ((isCover || !File.Exists(savePath)) && preView == false)
                    FileHelper.WriteTxt(tmpFileText, savePath, Encoding.UTF8, FileMode.Create);
                #endregion

                #region 编辑界面
                
                foreach (var info in entityInfo.Value.Where(x => !ignoreProperties.Contains(x.Name)))
                {
                    var fieldDesc = info.Description;

                    formColumnsList.Add(
"                        <ac:FormItem>" + "\r\n" +
"                            <ac:FormItem.Header>" + "\r\n" +
"                                <TextBlock>" + "\r\n" +
"                                    <Run Foreground = \"Red\" > *</Run>" + "\r\n" +
"                                    <Run>" + fieldDesc + "</Run>" + "\r\n" +
"                                </TextBlock>" + "\r\n" +
"                            </ac:FormItem.Header>" + "\r\n" +
"                            <TextBox Text=\"{Binding " + info.Name + ",Mode=TwoWay,UpdateSourceTrigger=PropertyChanged, ValidatesOnExceptions=True, ValidatesOnDataErrors=True, NotifyOnValidationError=True}\" IsReadOnly=\"{ Binding Disabled}\"></TextBox>" + "\r\n" +
"                        </ac:FormItem>");


                }           

                tmpFileText = File.ReadAllText(Path.Combine(directory, "Page", "AIStudio.Wpf.Home", "BuildCodeTemplate", "EditForm.txt"));

                tmpFileText = tmpFileText.Replace("%areaName%", areaName).Replace("%entityName%", entityInfo.Key);

                tmpFileText = tmpFileText.Replace("%formColumns%", string.Join("\r\n", formColumnsList));

                savePath = Path.Combine(
                               directory,
                               "Page",
                               $"AIStudio.Wpf.{areaName}",
                               "Views",
                               $"{entityInfo.Key}Edit.xaml");

                subBuildCode = new SubBuildCode();
                subBuildCode.Name = $"编辑Xaml";
                subBuildCode.Path = savePath;
                subBuildCode.TempPath = Path.Combine(
                               directory,
                               "Page",
                               $"AIStudio.Wpf.areaName",
                               "Views",
                               $"{entityInfo.Key}Edit.xaml");
                subBuildCode.FileName = $"{entityInfo.Key}Edit";
                subBuildCode.Code = tmpFileText;
                subBuildCode.Suffix = "xaml";
                buildCode.SubBuildCode.Add(subBuildCode);

                if ((isCover || !File.Exists(savePath)) && preView == false)
                    FileHelper.WriteTxt(tmpFileText, savePath, Encoding.UTF8, FileMode.Create);

                //
                tmpFileText = File.ReadAllText(Path.Combine(directory, "Page", "AIStudio.Wpf.Home", "BuildCodeTemplate", "EditFormcs.txt"));

                tmpFileText = tmpFileText.Replace("%areaName%", areaName).Replace("%entityName%", entityInfo.Key);

                savePath = Path.Combine(
                               directory,
                               "Page",
                               $"AIStudio.Wpf.{areaName}",
                               "Views",
                               $"{entityInfo.Key}Edit.xaml.cs");

                subBuildCode = new SubBuildCode();
                subBuildCode.Name = $"编辑cs";
                subBuildCode.Path = savePath;
                subBuildCode.TempPath = Path.Combine(
                               directory,
                               "Page",
                               $"AIStudio.Wpf.areaName",
                               "Views",
                               $"{entityInfo.Key}Edit.xaml.cs");
                subBuildCode.FileName = $"{entityInfo.Key}Edit";
                subBuildCode.Code = tmpFileText;
                subBuildCode.Suffix = "xaml.cs";
                buildCode.SubBuildCode.Add(subBuildCode);

                if ((isCover || !File.Exists(savePath)) && preView == false)
                    FileHelper.WriteTxt(tmpFileText, savePath, Encoding.UTF8, FileMode.Create);

                tmpFileText = File.ReadAllText(Path.Combine(directory, "Page", "AIStudio.Wpf.Home", "BuildCodeTemplate", "EditFormviewmodel.txt"));

                tmpFileText = tmpFileText.Replace("%areaName%", areaName).Replace("%entityName%", entityInfo.Key);

                savePath = Path.Combine(
                               directory,
                               "Page",
                               $"AIStudio.Wpf.{areaName}",
                               "ViewModels",
                               $"{entityInfo.Key}EditViewModel.cs");

                subBuildCode = new SubBuildCode();
                subBuildCode.Name = $"编辑VM";
                subBuildCode.Path = savePath;
                subBuildCode.TempPath = Path.Combine(
                               directory,
                               "Page",
                               $"AIStudio.Wpf.areaName",
                               "ViewModels",
                               $"{entityInfo.Key}EditViewModel.cs");
                subBuildCode.FileName = $"{entityInfo.Key}EditViewModel";
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

                foreach (var aField in entityInfo.Value.Where(x => !ignoreProperties.Contains(x.Name)))
                {
                    var fieldDesc = aField.Description;

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
                                    $"{entityInfo.Key}FlowDocument.xaml");

                subBuildCode = new SubBuildCode();
                subBuildCode.Name = $"打印Xaml";
                subBuildCode.Path = savePath;
                subBuildCode.TempPath = Path.Combine(
                                    directory,
                                    "Page",
                                    $"AIStudio.Wpf.areaName",
                                    "Views",
                                    $"{entityInfo.Key}FlowDocument.xaml");
                subBuildCode.FileName = $"{entityInfo.Key}FlowDocument";
                subBuildCode.Code = tmpFileText;
                subBuildCode.Suffix = "xaml";
                buildCode.SubBuildCode.Add(subBuildCode);

                if ((isCover || !File.Exists(savePath)) && preView == false)
                    FileHelper.WriteTxt(tmpFileText, savePath, Encoding.UTF8, FileMode.Create);

                tmpFileText = File.ReadAllText(Path.Combine(directory, "Page", "AIStudio.Wpf.Home", "BuildCodeTemplate", "FlowRenderer.txt"));

                List<string> tableRowsList = new List<string>();

                foreach (var aField in entityInfo.Value.Where(x => !ignoreProperties.Contains(x.Name)))
                {
                    if (dbHelper.DbTypeStr_To_CsharpType(aField.Type) == typeof(string))
                    {
                        tableRowsList.Add(
                            $"                    cell = new TableCell(new Paragraph(new Run(item.{aField.Name})));\r\n" +
                            "                    cell.Style = styleCell;\r\n" +
                            "                    row.Cells.Add(cell);\r\n");
                    }
                    else
                    {
                        tableRowsList.Add(
                            $"                    cell = new TableCell(new Paragraph(new Run(item.{aField.Name}.ToString())));\r\n" +
                            "                    cell.Style = styleCell;\r\n" +
                            "                    row.Cells.Add(cell);\r\n");
                    }
                }



                tmpFileText = tmpFileText.Replace("%areaName%", areaName).Replace("%entityName%", entityInfo.Key);
                tmpFileText = tmpFileText.Replace("%tablerow%", string.Join("\r\n", tableRowsList));

                savePath = Path.Combine(
                              directory,
                              "Page",
                              $"AIStudio.Wpf.{areaName}",
                              "ViewModels",
                              $"{entityInfo.Key}DocumentRenderer.cs");

                subBuildCode = new SubBuildCode();
                subBuildCode.Name = $"打印cs";
                subBuildCode.Path = savePath;
                subBuildCode.TempPath = Path.Combine(
                              directory,
                              "Page",
                              $"AIStudio.Wpf.areaName",
                              "ViewModels",
                              $"{entityInfo.Key}DocumentRenderer.cs");
                subBuildCode.FileName = $"{entityInfo.Key}DocumentRenderer";
                subBuildCode.Code = tmpFileText;
                subBuildCode.Suffix = "cs";
                buildCode.SubBuildCode.Add(subBuildCode);

                if ((isCover || !File.Exists(savePath)) && preView == false)
                    FileHelper.WriteTxt(tmpFileText, savePath, Encoding.UTF8, FileMode.Create);
                #endregion
            }

            return buildCodes;
        }


        private DbHelper GetTheDbHelper(string linkId)
        {
            var theLink = Base_DbLinkDTO.FirstOrDefault(p => p.Id == linkId);
            DbHelper dbHelper = DbHelperFactory.GetDbHelper(theLink.DbType.ToEnum<DatabaseType>(), theLink.ConnectionStr);

            return dbHelper;
        }

    }
}
