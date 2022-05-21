using AIStudio.Wpf.AgileDevelopment.Attributes;
using AIStudio.Wpf.AgileDevelopment.ItemSources;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace AIStudio.Wpf.AgileDevelopment.Commons
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

            if (ItemSourceDictionary.ReadOnlySource.Contains(property.Name))
            {
                editFormItem.IsReadOnly = true;
            }
   
            return editFormItem;
        }
    }
}
