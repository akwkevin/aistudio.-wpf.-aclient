using AIStudio.Wpf.DemoPage.Views.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Util.Controls.PropertyGrid;
using Util.Controls.PropertyGrid.Attributes;
using Util.Controls.PropertyGrid.Editors;

namespace AIStudio.Wpf.DemoPage.Models
{
    [CategoryOrder("Information", 0)]
    [CategoryOrder("Conections", 1)]
    [CategoryOrder("Other", 2)]
    public abstract class Person : INotifyPropertyChanged
    {
        // All properties have their own "[Category(...)]" attribute to specify which category they
        // belong to when the "Categorized" layout is used by the PropertyGrid.

        [Category("Information")]
        [Description("This property uses the [DisplayName(\"Is a Men\")] attribute to customize the name of this property.")]
        [DisplayName("Is male")]
        public bool IsMale { get; set; }

        [Category("Information")]
        [Description("This property uses the [Editor(..)] attribute to provide a custom editor using the 'FirstNameEditor' class. In the Plus version, it also depends on the IsMale property to change its foreground and source.")]
        [Editor(typeof(FirstNameEditor), typeof(FirstNameEditor))]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; RaisePropertyChanged("FirstName"); }
        }
        private string _firstName;

        [Category("Information")]
        [Description("This property uses the [Editor(..)] attribute to provide a custom editor using the 'LastNameUserControlEditor' user control.")]
        [Editor(typeof(LastNameUserControlEditor), typeof(LastNameUserControlEditor))]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; RaisePropertyChanged("LastName"); }
        }
        private string _lastName;

        [Category("Conections")]
        [Description("This property uses the [NewItemTypes(...)] attribute to provide the underlying CollectionEditor with class types (eg. Man, Woman) that can be inserted in the collection.")]
        [NewItemTypes(typeof(Man), typeof(Woman))]
        public List<Person> Friends { get; set; }

        [Category("Information")]
        [DisplayName("Writing Font Size")]
        [Description("This property defines the [ItemsSource(..)] attribute that allows you to specify a ComboBox editor and control its items.")]
        [ItemsSource(typeof(FontSizeItemsSource))]
        [RefreshProperties(RefreshProperties.All)]    //This will reload the PropertyGrid
        public double WritingFontSize { get; set; }

        [Category("Conections")]
        [Description("This property defines the [ExpandableObject()] attribute. This allows you to expand this property and drill down through its values.")]
        [ExpandableObject()]
        public Person Spouse { get; set; }

        [Category("Other")]
        [Description("This property uses the [PropertyOrder(1)] attribute to control its position in the categorized and non-categorized views. Otherwise, alphabetical order is used.")]
        [PropertyOrder(1)]
        public string A_SecondProperty { get; set; }

        [Category("Other")]
        [Description("This property uses the [PropertyOrder(0)] attribute to control its position in the categorized and non-categorized view. Otherwise, alphabetical order is used.")]
        [PropertyOrder(0)]
        public string B_FirstProperty { get; set; }

        [Category("Other")]
        [Description("This property uses the [ParenthesizePropertyName()] attribute to force the name to be displayed within round brackets.")]
        [ParenthesizePropertyNameAttribute(true)]
        public string NameInParentheses { get; set; }

        [Category("Other")]
        [Description("This property uses the [Browsable(false)] attribute to not display the property")]
        [BrowsableAttribute(false)]
        public string InvisibleProperty
        {
            get;
            set;
        }

        [Range(0d, 10d)]
        [Category("Other")]
        [DefaultValue(5d)]
        [Description("This property uses the [Range(0,10)] and DefaultValue attributes to set the Minimum, Maximum and default properties.")]
        public double RangeDouble
        {
            get;
            set;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    // The "Man" and "Woman" classes are referenced by the "NewItemTypesAttribute"
    // of the "Friends" property.
    //
    // Theses are the types that can be instantiated in the CollectionEditor
    // of the property.
    public class Man : Person
    {
        [Display(Name = "Favorite Sport"
                , Prompt = "Enter your favorite sport"
                , Description = "This property uses the Display attribute to set different PropertyItem fields."
                , GroupName = "Information"
                , AutoGenerateField = true
                , AutoGenerateFilter = false)]
        public string FavoriteSport { get; set; }
        public Man() { this.IsMale = true; }
    }
    public class Woman : Person
    {
        [Category("Information")]
        [Description("This property has no special attribute besides [Categroy(\"Information\")] and [Description(...)]")]
        public string FavoriteRestaurant { get; set; }
        public Woman() { this.IsMale = false; }
    }

    // This is the custom editor referenced by the "EditorAttribute"
    // of the "FirstName" property.
    //
    // This class must implement the
    //   Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor 
    // interface
    public class FirstNameEditor : ITypeEditor
    {
        public FrameworkElement ResolveEditor(PropertyItem propertyItem)
        {
            TextBox textBox = new TextBox();
            textBox.Background = new SolidColorBrush(Colors.Red);
            //create the binding from the bound property item to the editor
            var _binding = new Binding("Value"); //bind to the Value property of the PropertyItem
            _binding.Source = propertyItem;
            _binding.ValidatesOnExceptions = true;
            _binding.ValidatesOnDataErrors = true;
            _binding.Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay;
            BindingOperations.SetBinding(textBox, TextBox.TextProperty, _binding);
            return textBox;
        }
    }

    // This is the ItemsSource provider referenced by the "ItemsSourceAttribute"
    // of the "WritingFontSize" property.
    //
    // This class must implement the
    //   Xceed.Wpf.Toolkit.PropertyGrid.Attributes.IItemsSource 
    // interface
    public class FontSizeItemsSource : IItemsSource
    {
        public Util.Controls.PropertyGrid.Attributes.ItemCollection GetValues()
        {
            var sizes = new Util.Controls.PropertyGrid.Attributes.ItemCollection();
            sizes.Add(5.0, "Five");
            sizes.Add(5.5);
            sizes.Add(6.0, "Six");
            sizes.Add(6.5);
            sizes.Add(7.0, "Seven");
            sizes.Add(7.5);
            sizes.Add(8.0, "Eight");
            sizes.Add(8.5);
            sizes.Add(9.0, "Nine");
            sizes.Add(9.5);
            sizes.Add(10.0);
            sizes.Add(12.0, "Twelve");
            sizes.Add(14.0);
            sizes.Add(16.0);
            sizes.Add(18.0);
            sizes.Add(20.0);
            return sizes;
        }
    }

    [CategoryOrder("Information", 1)]
    [CategoryOrder("Hobbies", 2)]
    [CategoryOrder("Connections", 3)]
    public class PersonOrdered : PersonBase { }

    public class PersonNonOrdered : PersonBase { }

    public abstract class PersonBase
    {
        [Category("Information")]
        public string FirstName { get; set; }

        [Category("Information")]
        public string LastName { get; set; }

        [Category("Hobbies")]
        public bool Baseball { get; set; }

        [Category("Hobbies")]
        public bool Football { get; set; }

        [Category("Hobbies")]
        public bool Basketball { get; set; }

        [Category("Connections")]
        public string Father { get; set; }

        [Category("Connections")]
        public string Mother { get; set; }

        [Category("Connections")]
        public bool HasChildren { get; set; }

        public static PersonBase InitPerson(PersonBase person)
        {
            person.FirstName = "John";
            person.LastName = "Doe";
            person.Baseball = true;
            person.Football = false;
            person.Basketball = true;
            person.Father = "William Doe";
            person.Mother = "Jennifer Doe";
            person.HasChildren = false;
            return person;
        }
    }

    public class AllEditorTypes
    {
        [Category("Non-Numeric Editors")]
        [Description("(C# string type) This property uses a TextBox as the default editor.")]
        public string String { get; set; }
        [Category("Non-Numeric Editors")]
        [Description("(C# bool type) This property uses a CheckBox as the default editor.")]
        public bool Boolean { get; set; }
        [Category("Numeric Editors")]
        [Description("(C# int type) This property uses an IntegerUpDown as the default editor.")]
        public int Int32 { get; set; }
        [Category("Numeric Editors")]
        [Description("(C# double type) This property uses a DoubleUpDown as the default editor.")]
        public double Double { get; set; }
        [Category("Numeric Editors")]
        [Description("(C# short type) This property uses a ShortUpDown as the default editor.")]
        public short Int16 { get; set; }
        [Category("Numeric Editors")]
        [Description("(C# long type) This property uses a LongUpDown as the default editor.")]
        public long Int64 { get; set; }
        [Category("Numeric Editors")]
        [Description("(C# float type) This property uses a SingleUpDown as the default editor.")]
        public float Single { get; set; }
        [Category("Numeric Editors")]
        [Description("(C# decimal type) This property uses a Decimal as the default editor.")]
        public decimal Decimal
        {
            get;
            set;
        }
        [Category("Numeric Editors")]
        [Description("(C# byte type) This property uses a ByteUpDown as the default editor.")]
        public byte Byte { get; set; }
        [Category("Numeric Editors")]
        [Description("(C# sbyte type) This property uses a SByteUpDown as the default editor. This is an internal class for CLS compliance reasons. Can only be autogenerated.")]
        public sbyte SByte { get; set; }
        [Category("Numeric Editors")]
        [Description("(C# uint type) This property uses a UInteger as the default editor. This is an internal class for CLS compliance reasons. Can only be autogenerated.")]
        public uint UInt32 { get; set; }
        [Category("Numeric Editors")]
        [Description("(C# ulong type) This property uses a ULongUpDown as the default editor. This is an internal class for CLS compliance reasons. Can only be autogenerated.")]
        public ulong UInt64 { get; set; }
        [Category("Numeric Editors")]
        [Description("(C# ushort type) This property uses a UShortUpDown as the default editor. This is an internal class for CLS compliance reasons. Can only be autogenerated.")]
        public ushort UInt16 { get; set; }
        [Category("Non-Numeric Editors")]
        [Description("This property uses a DateTimeUpDown as the default editor.")]
        public System.DateTime DateTime { get; set; }
        [Category("Non-Numeric Editors")]
        [Description("This property uses a TimeSpanUpDown as the default editor.")]
        public System.TimeSpan TimeSpan { get; set; }
        [Category("Non-Numeric Editors")]
        [Description("This property uses a ColorPicker as the default editor.")]
        public System.Windows.Media.Color? Color { get; set; }
        [Category("Non-Numeric Editors")]
        [Description("(C# enum type) This property uses a ComboBox as the default editor. The ComboBox is auto-populated with the enum values.")]
        public HorizontalAlignment Enum { get; set; }
        [Category("Non-Numeric Editors")]
        [Description("This property uses a ComboBox as the default editor.")]
        public FontFamily FontFamily { get; set; }
        [Category("Non-Numeric Editors")]
        [Description("This property uses a ComboBox as the default editor.")]
        public FontWeight FontWeight { get; set; }
        [Category("Non-Numeric Editors")]
        [Description("This property uses a ComboBox as the default editor.")]
        public FontStyle FontStyle { get; set; }
        [Category("Non-Numeric Editors")]
        [Description("This property uses a ComboBox as the default editor.")]
        public FontStretch FontStretch { get; set; }
        [Category("Non-Numeric Editors")]
        [Description("This property uses a Guid as the default editor.")]
        public Guid Guid { get; set; }
        [Category("Non-Numeric Editors")]
        [Description("This property uses a Char as the default editor.")]
        public Char Char { get; set; }
        [Category("Non-Numeric Editors")]
        [Description("This property uses a PrimitiveTypeCollectionEditor as the default editor.")]
        public List<string> ListOfStrings { get; set; }
        [Category("Non-Numeric Editors")]
        [Description("This property uses a PrimitiveTypeCollectionEditor as the default editor.")]
        public List<int> ListOfInt32 { get; set; }
        [Category("Non-Numeric Editors")]
        [Description("(C# IList<T> type) This property uses a CollectionEditor as the default editor.")]
        public List<Person4> ListOfPerson { get; set; }
        [Category("Non-Numeric Editors")]
        [Description("(C# IDictionary<T> type) This property uses a CollectionEditor as the default editor.")]
        public Dictionary<int, System.Windows.Media.Color> Dictionary { get; set; }
        [Category("Non-Numeric Editors")]
        [Description("(C# ICollection<T> type) This property uses a CollectionEditor as the default editor.")]
        public Collection<Person4> CollectionOfPerson
        {
            get; set;
        }
        [Category("Non-Numeric Editors")]
        [Description("This property is a complex property and has no default editor.")]
        public Person4 Person { get; set; }
    }

    public class Person1
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ExpandableObject()]
        public Person1 Friend { get; set; }
    }

    public class Person2
    {
        [Category("Information")]
        [DisplayName("First Name")]
        [Description("This property uses a TextBox as the default editor.")]
        public string FirstName
        {
            get;
            set;
        }

        [Category("Information")]
        [DisplayName("Last Name")]
        [Description("This property uses a TextBox as the default editor.")]
        public string LastName
        {
            get;
            set;
        }

        public Dimension Dimensions
        {
            get;
            set;
        }

        public static Person2 CreatePerson()
        {
            var person = new Person2();
            person.FirstName = "John";
            person.LastName = "Doe";
            person.Dimensions = new Dimension()
            {
                Height = 75.0,
                Weight = 185.76
            };
            return person;
        }

    }

    public class Person3
    {
        [Category("Information")]
        [Description("This property uses the editor defined by EditorTemplateDefinition #2 because it targets the property named 'FirstName'.")]
        public string FirstName
        {
            get;
            set;
        }

        [Category("Information")]
        [Description("This property uses the editor defined by EditorTemplateDefinition #2 because it targets the property named 'LastName'.")]
        public string LastName
        {
            get;
            set;
        }

        [Category("Information")]
        [Description("This property uses the editor defined by EditorTemplateDefinition #3 because it targets all properties of Type 'DateTime'.")]
        public System.DateTime DateOfBirth
        {
            get;
            set;
        }

        [Category("Information")]
        [Description("This property uses the editor defined by EditorTemplateDefinition #1 because it targets all properties of Type 'Double'.")]
        public double GradePointAvg
        {
            get;
            set;
        }

        [Category("Information")]
        [Description("This property uses the editor defined by EditorTemplateDefinition #3 because it targets the property named 'Age'.")]
        public int Age
        {
            get;
            set;
        }

        [Category("Information")]
        [Description("Friends")]
        public List<string> Friends
        {
            get;
            set;
        }

        [Category("Information")]
        [Description("This property uses the editor defined by EditorTemplateDefinition #4 because it targets all properties of Type 'Boolean'.")]
        public bool IsMale
        {
            get;
            set;
        }

        [Category("Information")]
        [Description("This property uses the default editor because no EditorDefinition targets this property name or type.")]
        public System.Windows.Media.Color? FavoriteColor
        {
            get;
            set;
        }

        [Category("Writing")]
        [Description("This property uses the editor defined by EditorTemplateDefinition #4 because it targets all properties of Type 'HorizontalAlignment'.")]
        public HorizontalAlignment WritingHand
        {
            get;
            set;
        }

        [Category("Writing")]
        [Description("This property uses the editor defined by EditorTemplateDefinition #2 because it targets the property named 'WritingFont'. Although EditorTemplateDefinition #4 targets 'FontFamily' type, priority is given to the name.")]
        public FontFamily WritingFont
        {
            get;
            set;
        }

        [Category("Writing")]
        [Description("This property uses the editor defined by EditorTemplateDefinition #1 because it targets all properties of Type 'Double'.")]
        public double WritingFontSize
        {
            get;
            set;
        }
    }

    public class Person4
    {
        public string Name { get; set; }
    }

    public class Person5
    {
        [Category("Information")]
        [DisplayName("First Name")]
        [Description("This property uses a TextBox as the default editor.")]
        public string FirstName
        {
            get;
            set;
        }

        [Category("Information")]
        [DisplayName("Last Name")]
        [Description("This property uses a TextBox as the default editor.")]
        public string LastName
        {
            get;
            set;
        }

        [Category("Information")]
        [DisplayName("Date of Birth")]
        [Description("This property uses the DateTimeUpDown as the default editor.")]
        public System.DateTime DateOfBirth
        {
            get;
            set;
        }

        [DisplayName("Grade Point Average")]
        [Description("This property uses the DoubleUpDown as the default editor.")]
        public double GradePointAvg
        {
            get;
            set;
        }

        [Category("Information")]
        [Description("This property uses the IntegerUpDown as the default editor.")]
        public int Age
        {
            get;
            set;
        }

        [Category("Information")]
        [DisplayName("Is Male")]
        [Description("This property uses a CheckBox as the default editor.")]
        public bool IsMale
        {
            get;
            set;
        }

        [Category("Information")]
        [DisplayName("Favorite Color")]
        [Description("This property uses the ColorPicker as the default editor.")]
        public System.Windows.Media.Color? FavoriteColor
        {
            get;
            set;
        }

        [Category("Writing")]
        [DisplayName("Writing Hand")]
        [Description("This property uses a ComboBox as the default editor.  The ComboBox is auto populated with the enum values")]
        public HorizontalAlignment WritingHand
        {
            get;
            set;
        }

        [Category("Writing")]
        [DisplayName("Writing Font")]
        [Description("This property uses a ComboBox as the default editor.  The ComboBox is auto populated with the enum values")]
        public FontFamily WritingFont
        {
            get;
            set;
        }

        [Category("Writing")]
        [DisplayName("Writing Font Size")]
        [Description("This property uses the DoubleUpDown as the default editor.")]
        public double WritingFontSize
        {
            get;
            set;
        }

        [Category("Conections")]
        [DisplayName("Pet Names")]
        [Description("This property uses the PrimitiveTypeCollectionEditor as the default editor.")]
        public List<String> PetNames
        {
            get;
            set;
        }

        [Category("Conections")]
        [Description("This property uses the CollectionEditor as the default editor.")]
        public List<Person5> Friends
        {
            get;
            set;
        }

        [Category("Conections")]
        [Description("This property is a complex property and has no default editor.")]
        public Person5 Spouse
        {
            get;
            set;
        }

        public static Person5 CreatePerson()
        {
            var person = new Person5();
            person.FirstName = "John";
            person.LastName = "Doe";
            person.DateOfBirth = new System.DateTime(1975, 1, 23);
            person.Age = System.DateTime.Today.Year - person.DateOfBirth.Year;
            person.GradePointAvg = 3.98;
            person.IsMale = true;
            person.FavoriteColor = Colors.Blue;
            person.WritingHand = System.Windows.HorizontalAlignment.Right;
            person.WritingFont = new FontFamily("Arial");
            person.WritingFontSize = 12.5;
            person.PetNames = new List<string>() { "Pet 1", "Pet 2", "Pet 3" };
            person.Friends = new List<Person5>() { new Person5() { FirstName = "First", LastName = "Friend" }, new Person5() { FirstName = "Second", LastName = "Friend" } };
            person.Spouse = new Person5()
            {
                FirstName = "Jane",
                LastName = "Doe"
            };
            return person;
        }
    }
}
