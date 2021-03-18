using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business.DTOModels.DTOModels;
using System.Collections.Generic;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class BuildCodeEditViewModel : BaseEditViewModel<BuildCode>
    {
        private string _areaName;
        public string AreaName
        {
            get { return _areaName; }
            set
            {
                SetProperty(ref _areaName, value);
            }
        }

        private List<bool> _buildType = new List<bool> { false, true, true, false, true };
        public List<bool> BuildType
        {
            get { return _buildType; }
            set
            {
                SetProperty(ref _buildType, value);
            }
        }

        private bool _isCover;
        public bool IsCover
        {
            get { return _isCover; }
            set
            {
                SetProperty(ref _isCover, value);
            }
        }

        public BuildCodeEditViewModel(BuildCode data, string identifier, string title= "编辑表单") : base(data, identifier, title)
        {
            if (Data == null)
            {
                Data = new BuildCode();
            }
            else
            {
                GetData(Data);
            }
        }


    }
}
