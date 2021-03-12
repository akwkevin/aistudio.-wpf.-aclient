using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Business.DTOModels
{
    public interface IIsChecked
    {
        string Id { get; set; }
        bool IsChecked { get; set; }

        string Error { get; }
    }
}
