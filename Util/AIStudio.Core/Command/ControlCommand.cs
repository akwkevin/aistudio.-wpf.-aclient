using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AIStudio.Core
{
    #region ConbrolCommand

    public interface IControlCommand
    {
        void SetControl(Control cb);

        void SetBase(IControlCommand cc);

        void Execute(object parameter);
    }

    /// <summary>
    /// ControlBase可以使用的命令类
    /// 使用此类，可以使Command具有继承的机制，在新的Command中可以调用旧的Command
    /// </summary>
    public class ControlCommand<T1> : CanExecuteDelegateCommand<ControlCommand<T1>, T1>, IControlCommand
    {
        public Control Control { get; protected set; }

        public IControlCommand Base { get; protected set; }

        public string Name { get; set; }

        public ControlCommand(Action<ControlCommand<T1>, T1> executeMethod, Func<ControlCommand<T1>, T1, bool> canExecuteMethod = null, bool isAutomaticRequeryDisabled = false, string name = "")
            : base(executeMethod, canExecuteMethod, isAutomaticRequeryDisabled)
        {
            Name = name;
        }

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(new object[] { this, parameter });
        }

        public override void Execute(object parameter)
        {
            base.Execute(new object[] { this, parameter });
        }

        public virtual void ExecuteBaseCommand(T1 parameter)
        {
            if (Base != null)
                Base.Execute((object)parameter);
        }

        public void SetControl(Control cb)
        {
            Control = cb;
        }

        public void SetBase(IControlCommand cc)
        {
            Base = cc;
        }
    }

    public class ControlCommand : CanExecuteDelegateCommand<ControlCommand>, IControlCommand
    {
        public Control Control { get; protected set; }

        public IControlCommand Base { get; protected set; }

        public string Name { get; set; }

        public ControlCommand(Action<ControlCommand> executeMethod, Func<ControlCommand, bool> canExecuteMethod = null, bool isAutomaticRequeryDisabled = false, string name = "")
            : base(executeMethod, canExecuteMethod, isAutomaticRequeryDisabled)
        {
            Name = name;
        }

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(new object[] { this });
        }

        public override void Execute(object parameter)
        {
            base.Execute(new object[] { this });
        }

        public virtual void ExecuteBaseCommand()
        {
            if (Base != null)
                Base.Execute((object)null);
        }

        public void SetControl(Control cb)
        {
            Control = cb;
        }

        public void SetBase(IControlCommand cc)
        {
            Base = cc;
        }
    }

    #endregion
}
