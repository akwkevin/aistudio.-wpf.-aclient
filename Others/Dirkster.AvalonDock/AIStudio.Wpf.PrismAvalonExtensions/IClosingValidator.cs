namespace AIStudio.Wpf.PrismAvalonExtensions
{
    public interface IClosingValidator
    {
        /// <summary>
        /// Return true to allow closing, false to prevent closing.
        /// </summary>
        /// <returns></returns>
        bool OnClosing();
        bool IsDirty
        {
            get;
        }
    }
}
