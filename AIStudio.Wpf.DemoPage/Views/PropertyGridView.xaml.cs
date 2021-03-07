using AIStudio.Wpf.DemoPage.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Util.Controls.PropertyGrid;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// PropertyGridView.xaml 的交互逻辑
    /// </summary>
    public partial class PropertyGridView : UserControl
    {
        public PropertyGridView()
        {
            InitializeComponent();

            {
                var range = new Range();
                range.IntText = 1;
                range.MultiComboBox = new List<string>();
                range.ComboBox = "1";

                propertiesView.DataContext = range;
            }

            {
                var person = new Man();
                person.FirstName = "John";
                person.LastName = "Doe";
                person.WritingFontSize = 12;
                person.Friends = new List<Person>() { new Man() { FirstName = "First", LastName = "Friend" }, new Woman() { FirstName = "Second", LastName = "Friend" } };
                person.Spouse = new Woman()
                {
                    FirstName = "Jane",
                    LastName = "Doe"
                };

                _propertyGridAttributes.DataContext = person;
            }

            {
                _propertyGridBindingToStructs.SelectedObject = Person2.CreatePerson();
            }

            {
                _propertyGridCategoryOrder1.SelectedObject = PersonBase.InitPerson(new PersonNonOrdered());
                _propertyGridCategoryOrder2.SelectedObject = PersonBase.InitPerson(new PersonOrdered());
            }

            {
                var person = new Person3();
                person.FirstName = "John";
                person.LastName = "Doe";
                person.DateOfBirth = new System.DateTime(1975, 1, 23);
                person.Age = System.DateTime.Today.Year - person.DateOfBirth.Year;
                person.GradePointAvg = 3.98;
                person.IsMale = true;
                person.FavoriteColor = Colors.Blue;
                person.WritingFont = new FontFamily("Arial");
                person.WritingHand = System.Windows.HorizontalAlignment.Right;
                person.WritingFontSize = 12.5;

                _propertyGridCustomEditors.DataContext = person;
            }

            {
                var selectedObject = new AllEditorTypes();
                selectedObject.Boolean = true;
                selectedObject.Byte = (byte)1;
                selectedObject.Color = Colors.Blue;
                selectedObject.DateTime = System.DateTime.Now;
                selectedObject.Decimal = (decimal)2;
                selectedObject.Double = (double)3;
                selectedObject.Enum = HorizontalAlignment.Center;
                selectedObject.FontFamily = new FontFamily("Arial");
                selectedObject.FontStretch = FontStretches.Normal;
                selectedObject.FontStyle = FontStyles.Italic;
                selectedObject.FontWeight = FontWeights.Bold;
                selectedObject.Guid = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4");
                selectedObject.Char = 'T';
                selectedObject.Int16 = (short)4;
                selectedObject.Int32 = (int)5;
                selectedObject.Int64 = (long)6;
                selectedObject.ListOfInt32 = new List<int>() { 1, 2, 3 };
                selectedObject.ListOfPerson = new List<Person4>() { new Person4() { Name = "John Smith" }, new Person4() { Name = "Robert King" } };
                selectedObject.ListOfStrings = new List<string>() { "string1", "string2", "string3" };
                selectedObject.Dictionary = new Dictionary<int, System.Windows.Media.Color>() { { 22, System.Windows.Media.Color.FromRgb(255, 0, 0) }, { 33, System.Windows.Media.Color.FromRgb(0, 255, 0) } };
                selectedObject.CollectionOfPerson = new Collection<Person4>() { new Person4() { Name = "Tom McNeil" }, new Person4() { Name = "Mike Campbell" } };
                selectedObject.Person = new Person4() { Name = "John Smith" };
                selectedObject.SByte = (sbyte)7;
                selectedObject.Single = (float)8;
                selectedObject.String = "this is a string";
                selectedObject.TimeSpan = System.TimeSpan.FromHours(2);
                selectedObject.UInt16 = (ushort)9;
                selectedObject.UInt32 = (uint)10;
                selectedObject.UInt64 = (ulong)11;

                _propertyGridDefaultEditors.DataContext = selectedObject;
            }

            {
                var selObject = new Person1();
                selObject.Friend = new Person1();
                _propertyGridPropertyItemStyle.DataContext = selObject;
            }

            {
                _propertyGridSpecifyingProperties.SelectedObject = Person5.CreatePerson();
            }
        }

        private void OnControlGetFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            _propertyGridSelectedObject.SelectedObject = e.Source;
        }

        private void OnPreparePropertyItem(object sender, Util.Controls.PropertyGrid.PropertyItemEventArgs e)
        {
            var propertyItem = e.PropertyItem as PropertyItem;
            // Parent of top-level properties is the PropertyGrid itself.
            bool isTopLevelProperty =
              (propertyItem.ParentElement is PropertyGrid);

            if (isTopLevelProperty && propertyItem.PropertyDescriptor.Name == "Friend")
            {
                propertyItem.DisplayName = "Friend (renamed)";
            }
        }
    }
}
