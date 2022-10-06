using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Core
{
    /// <summary>
    /// 前端SelectOption
    /// </summary>
    public class SelectOption : ISelectOption
    {
        public string Value { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return $"{Value}-{Text}";
        }
    }

    public class SelectOptionList : List<SelectOption>
    {

    }

    

    /// <summary>
    /// 在xaml中可以使用如下定义数据集合
    /// </summary>
    ///<ac:SelectOptionCollect x:Name="c2"  >
    ///    <ac:SelectOptionCollect.SelectOptions>
    ///        <ac:SelectOptionList>
    ///            <ac:SelectOption Value = "18" Text="A1"/>
    ///            <ac:SelectOption Value = "18" Text="A2"/>
    ///            <ac:SelectOption Value = "18" Text="A3"/>
    ///        </ac:SelectOptionList>
    ///    </ac:SelectOptionCollect.SelectOptions>
    ///</ac:SelectOptionCollect>
    public class SelectOptionCollect
    {
        public SelectOptionList SelectOptions { get; set; }
    }


}
