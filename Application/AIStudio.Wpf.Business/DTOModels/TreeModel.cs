using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Business.DTOModels
{
    public class TreeModel: INotifyPropertyChanged
    {
        /// <summary>
        /// 唯一标识Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 数据值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 父Id
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 节点深度
        /// </summary>
        public int? Level { get; set; } = 1;

        /// <summary>
        /// 显示的内容
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 孩子节点
        /// </summary>
        public List<TreeModel> Children { get; set; }

        /// <summary>
        /// 孩子节点
        /// </summary>
        public object children { get; set; }


        private bool isExpanded = true;
        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                if (value != isExpanded)
                {
                    isExpanded = value;
                    RaisePropertyChanged("IsExpanded");
                }
            }
        }

        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (value != isSelected)
                {
                    isSelected = value;
                    RaisePropertyChanged("IsSelected");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            //this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class TreeHelper
    {

        public static TreeModel GetTreeModel(IEnumerable<TreeModel> trees, string id)
        {
            TreeModel treemodel = null;
            if (trees != null)
            {
                foreach (var tree in trees)
                {
                    if (tree.Id == id)
                    {
                        treemodel = tree;
                        break;
                    }
                    else if (tree.Children != null)
                    {
                        treemodel = GetTreeModel(tree.Children, id);
                    }
                }
            }
            return treemodel;
        }
    }
}
