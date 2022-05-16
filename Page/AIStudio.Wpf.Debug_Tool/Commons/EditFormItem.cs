using AIStudio.Wpf.Debug_Tool.Attributes;
using System.Reflection;
using System.Windows;

namespace AIStudio.Wpf.Debug_Tool.Commons
{
    public class EditFormItem : BaseControlItem
    {
        public static EditFormItem GetEditFormItem(PropertyInfo property)
        {
            EditFormItem editFormItem = new EditFormItem();
            if (GetControlItem(property, editFormItem) == false)
                return null;

            var attribute = ColumnHeaderAttribute.GetPropertyAttribute(property);
            if (attribute != null)
            {
                editFormItem.IsReadOnly = attribute.IsReadOnly;
                editFormItem.Visibility = attribute.Visibility;
            }
            else
            {
                editFormItem.Visibility = Visibility.Visible;
            }

            return editFormItem;
        }


    }
}
