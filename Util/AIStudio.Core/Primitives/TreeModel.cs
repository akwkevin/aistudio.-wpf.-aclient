using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Core
{
    public class TreeModel: ISelectOption, INotifyPropertyChanged
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

        private bool _isChecked = false;
        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    RaisePropertyChanged("IsChecked");

                    SetChildChecked(_isChecked);
                }
            }
        }

        public bool IsCheckedOnlySelf
        {
            get
            {
                return _isChecked;
            }
            set
            {
                _isChecked = value;
                RaisePropertyChanged("IsChecked");
            }
        }

        private void SetChildChecked(bool isChecked)
        {
            if (Children != null)
            {
                foreach (var child in Children)
                {
                    child.IsChecked = isChecked;
                    child.SetChildChecked(isChecked);
                }
            }
        }

        public override string ToString()
        {
            return $"{Value}-{Text}";
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

        public static List<TreeModel> GetTreeToList(IEnumerable<TreeModel> trees)
        {
            List<TreeModel> treemodels = new List<TreeModel>();
            if (trees != null)
            {
                foreach (var tree in trees)
                {
                    treemodels.Add(tree);

                    if (tree.Children != null)
                    {
                        treemodels.AddRange(GetTreeToList(tree.Children));
                    }
                }
            }
            return treemodels;
        }

        #region 外部接口

        /// <summary>
        /// 建造树结构
        /// </summary>
        /// <param name="allNodes">所有的节点</param>
        /// <returns></returns>
        public static List<T> BuildTree<T>(List<T> allNodes) where T : TreeModel, new()
        {
            List<T> resData = new List<T>();
            var rootNodes = allNodes.Where(x => x.ParentId == "0" || x.ParentId.IsNullOrEmpty()).ToList();
            resData = rootNodes;
            resData.ForEach(aRootNode =>
            {
                if (HaveChildren(allNodes, aRootNode.Id))
                    aRootNode.Children = _GetChildren(allNodes, aRootNode);
            });

            return resData;
        }

        /// <summary>
        /// 获取所有子节点
        /// 注：包括自己
        /// </summary>
        /// <typeparam name="T">节点类型</typeparam>
        /// <param name="allNodes">所有节点</param>
        /// <param name="parentNode">父节点</param>
        /// <param name="includeSelf">是否包括自己</param>
        /// <returns></returns>
        public static List<T> GetChildren<T>(List<T> allNodes, T parentNode, bool includeSelf) where T : TreeModel
        {
            List<T> resList = new List<T>();
            if (includeSelf)
                resList.Add(parentNode);
            _getChildren(allNodes, parentNode, resList);

            return resList;

            void _getChildren(List<T> _allNodes, T _parentNode, List<T> _resNodes)
            {
                var children = _allNodes.Where(x => x.ParentId == _parentNode.Id).ToList();
                _resNodes.AddRange(children);
                children.ForEach(aChild =>
                {
                    _getChildren(_allNodes, aChild, _resNodes);
                });
            }
        }

        #endregion

        #region 私有成员

        /// <summary>
        /// 获取所有子节点
        /// </summary>
        /// <typeparam name="T">树模型（TreeModel或继承它的模型）</typeparam>
        /// <param name="nodes">所有节点列表</param>
        /// <param name="parentNode">父节点Id</param>
        /// <returns></returns>
        private static List<TreeModel> _GetChildren<T>(List<T> nodes, T parentNode) where T : TreeModel, new()
        {
            Type type = typeof(T);
            var properties = type.GetProperties().ToList();
            List<TreeModel> resData = new List<TreeModel>();
            var children = nodes.Where(x => x.ParentId == parentNode.Id).ToList();
            children.ForEach(aChildren =>
            {
                T newNode = new T();
                resData.Add(newNode);

                //赋值属性
                properties.Where(x => x.CanWrite).ForEach(aProperty =>
                {
                    var value = aProperty.GetValue(aChildren, null);
                    aProperty.SetValue(newNode, value);
                });
                //设置深度
                newNode.Level = parentNode.Level + 1;

                if (HaveChildren(nodes, aChildren.Id))
                    newNode.Children = _GetChildren(nodes, newNode);
            });

            return resData;
        }

        /// <summary>
        /// 判断当前节点是否有子节点
        /// </summary>
        /// <typeparam name="T">树模型</typeparam>
        /// <param name="nodes">所有节点</param>
        /// <param name="nodeId">当前节点Id</param>
        /// <returns></returns>
        private static bool HaveChildren<T>(List<T> nodes, string nodeId) where T : TreeModel, new()
        {
            return nodes.Exists(x => x.ParentId == nodeId);
        }

        #endregion
    }
}
