namespace AIStudio.Core
{
    public enum ControlType
    {
        None,
        TextBox,
        ComboBox,
        PasswordBox,
        DatePicker,
        TreeSelect,
        MultiComboBox,
        MultiTreeSelect,
        CheckBox,
        ToggleButton,

        IntegerUpDown = 100,
        LongUpDown,
        DoubleUpDown,
        DecimalUpDown,
        DateTimeUpDown,

        Query = 200,
        Submit,
        Add,
        Delete,
    }
}
