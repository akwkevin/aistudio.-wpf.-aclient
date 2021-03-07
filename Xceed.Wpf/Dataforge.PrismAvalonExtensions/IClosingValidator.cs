using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dataforge.PrismAvalonExtensions
{
    public interface IClosingValidator
    {
        /// <summary>
        /// Return true to allow closing, false to prevent closing.
        /// </summary>
        /// <returns></returns>
        bool OnClosing();
        bool IsDirty { get; }
    }
}
