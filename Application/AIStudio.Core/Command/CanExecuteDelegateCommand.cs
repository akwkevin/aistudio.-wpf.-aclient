using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AIStudio.Core
{
    /// <summary>
    ///     This class allows delegating the commanding logic to methods passed as parameters,
    ///     and enables a View to bind commands to objects that are not part of the element tree.
    /// </summary>
	public class CanExecuteDelegateCommand : IDelegateCommand
    {
        #region Constructors

        /// <summary>
        ///     Constructor
        /// </summary>
        public CanExecuteDelegateCommand(Action executeMethod)
            : this(executeMethod, null, false)
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public CanExecuteDelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
            : this(executeMethod, canExecuteMethod, false)
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public CanExecuteDelegateCommand(Action executeMethod, Func<bool> canExecuteMethod, bool isAutomaticRequeryDisabled)
        {
            if (executeMethod == null)
            {
                throw new ArgumentNullException("executeMethod");
            }

            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
            _isAutomaticRequeryDisabled = isAutomaticRequeryDisabled;
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Method to determine if the command can be executed
        /// </summary>
        public bool CanExecute()
        {
            if (_canExecuteMethod != null)
            {
                return _canExecuteMethod();
            }
            return true;
        }

        /// <summary>
        ///     Execution of the command
        /// </summary>
        public void Execute()
        {
            if (_executeMethod != null)
            {
                _executeMethod();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public object Target
        {
            get
            {
                if (_executeMethod == null)
                    return null;

                return _executeMethod.Target;
            }
        }

        /// <summary>
        ///     Property to enable or disable CommandManager's automatic requery on this command
        /// </summary>
        public bool IsAutomaticRequeryDisabled
        {
            get
            {
                return _isAutomaticRequeryDisabled;
            }
            set
            {
                if (_isAutomaticRequeryDisabled != value)
                {
                    if (value)
                    {
                        CommandManagerHelper.RemoveHandlersFromRequerySuggested(_canExecuteChangedHandlers);
                    }
                    else
                    {
                        CommandManagerHelper.AddHandlersToRequerySuggested(_canExecuteChangedHandlers);
                    }
                    _isAutomaticRequeryDisabled = value;
                }
            }
        }

        /// <summary>
        ///     Raises the CanExecuteChaged event
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }

        /// <summary>
        ///     Protected virtual method to raise CanExecuteChanged event
        /// </summary>
        protected virtual void OnCanExecuteChanged()
        {
            CommandManagerHelper.CallWeakReferenceHandlers(_canExecuteChangedHandlers);
        }

        #endregion

        #region ICommand Members

        /// <summary>
        ///     ICommand.CanExecuteChanged implementation
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (!_isAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested += value;
                }
                CommandManagerHelper.AddWeakReferenceHandler(ref _canExecuteChangedHandlers, value, 2);
            }
            remove
            {
                if (!_isAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested -= value;
                }
                CommandManagerHelper.RemoveWeakReferenceHandler(_canExecuteChangedHandlers, value);
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        void ICommand.Execute(object parameter)
        {
            Execute();
        }

        #endregion

        #region Data

        private readonly Action _executeMethod = null;
        private readonly Func<bool> _canExecuteMethod = null;
        private bool _isAutomaticRequeryDisabled = false;
        private List<WeakReference> _canExecuteChangedHandlers;

        #endregion
    }

    public class CanExecuteDelegateCommand<T1> : IDelegateCommand
    {
        #region Constructors

        /// <summary>
        ///     Constructor
        /// </summary>
        public CanExecuteDelegateCommand(Action<T1> executeMethod)
            : this(executeMethod, null, false)
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public CanExecuteDelegateCommand(Action<T1> executeMethod, Func<T1, bool> canExecuteMethod)
            : this(executeMethod, canExecuteMethod, false)
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public CanExecuteDelegateCommand(Action<T1> executeMethod, Func<T1, bool> canExecuteMethod, bool isAutomaticRequeryDisabled)
        {
            if (executeMethod == null)
            {
                throw new ArgumentNullException("executeMethod");
            }

            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
            _isAutomaticRequeryDisabled = isAutomaticRequeryDisabled;
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Method to determine if the command can be executed
        /// </summary>
        public bool CanExecute(T1 parameter1)
        {
            if (_canExecuteMethod != null)
            {
                return _canExecuteMethod(parameter1);
            }
            return true;
        }

        /// <summary>
        ///     Execution of the command
        /// </summary>
        public void Execute(T1 parameter1)
        {
            if (_executeMethod != null)
            {
                _executeMethod(parameter1);
            }
        }

        /// <summary>
        ///     Raises the CanExecuteChaged event
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }

        /// <summary>
        ///     Protected virtual method to raise CanExecuteChanged event
        /// </summary>
        protected virtual void OnCanExecuteChanged()
        {
            CommandManagerHelper.CallWeakReferenceHandlers(_canExecuteChangedHandlers);
        }

        /// <summary>
        ///     Property to enable or disable CommandManager's automatic requery on this command
        /// </summary>
        public bool IsAutomaticRequeryDisabled
        {
            get
            {
                return _isAutomaticRequeryDisabled;
            }
            set
            {
                if (_isAutomaticRequeryDisabled != value)
                {
                    if (value)
                    {
                        CommandManagerHelper.RemoveHandlersFromRequerySuggested(_canExecuteChangedHandlers);
                    }
                    else
                    {
                        CommandManagerHelper.AddHandlersToRequerySuggested(_canExecuteChangedHandlers);
                    }
                    _isAutomaticRequeryDisabled = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public object Target
        {
            get
            {
                if (_executeMethod == null)
                    return null;

                return _executeMethod.Target;
            }
        }

        #endregion

        #region ICommand Members

        /// <summary>
        ///     ICommand.CanExecuteChanged implementation
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (!_isAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested += value;
                }
                CommandManagerHelper.AddWeakReferenceHandler(ref _canExecuteChangedHandlers, value, 2);
            }
            remove
            {
                if (!_isAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested -= value;
                }
                CommandManagerHelper.RemoveWeakReferenceHandler(_canExecuteChangedHandlers, value);
            }
        }

        public virtual bool CanExecute(object parameter)
        {
            if (parameter == null || (parameter is object[] && (parameter as object[]).Length < 1))
                return false;

            if (parameter is object[])
            {
                object[] parameters = parameter as object[];

                // if T is of value type and the parameter is not
                // set yet, then return false if CanExecute delegate
                // exists, else return true
                if ((parameters[0] != null && !typeof(T1).IsAssignableFrom(parameters[0].GetType()))
                    || (parameters[0] == null && typeof(T1).IsValueType)
                    )
                {
                    return false;
                }

                return CanExecute((T1)parameters[0]);
            }
            else
            {
                if (parameter != null && !typeof(T1).IsAssignableFrom(parameter.GetType()))
                    parameter = null;

                return CanExecute((T1)parameter);
            }
        }

        public virtual void Execute(object parameter)
        {
            //如果T1不允许为空，而parameter参数又为空，则直接返回
            if (typeof(T1).IsValueType && (parameter == null || (parameter is object[] && (parameter as object[]).Length < 1)))
                return;

            if (parameter is object[])
            {
                object[] parameters = parameter as object[];

                // if T1 is of value type and the parameter is not
                // set yet, then return false if CanExecute delegate
                // exists, else return true
                if ((parameters[0] != null && !typeof(T1).IsAssignableFrom(parameters[0].GetType()))
                    || (parameters[0] == null && typeof(T1).IsValueType)
                    )
                    return;

                Execute((T1)parameters[0]);
            }
            else
            {
                if (parameter != null && !typeof(T1).IsAssignableFrom(parameter.GetType()))
                    parameter = null;

                Execute((T1)parameter);
            }
        }

        #endregion

        #region Data

        private readonly Action<T1> _executeMethod = null;
        private readonly Func<T1, bool> _canExecuteMethod = null;
        private bool _isAutomaticRequeryDisabled = false;
        private List<WeakReference> _canExecuteChangedHandlers;

        #endregion
    }

    public class CanExecuteDelegateCommand<T1, T2> : IDelegateCommand
    {
        #region Constructors

        /// <summary>
        ///     Constructor
        /// </summary>
        public CanExecuteDelegateCommand(Action<T1, T2> executeMethod)
            : this(executeMethod, null, false)
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public CanExecuteDelegateCommand(Action<T1, T2> executeMethod, Func<T1, T2, bool> canExecuteMethod)
            : this(executeMethod, canExecuteMethod, false)
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public CanExecuteDelegateCommand(Action<T1, T2> executeMethod, Func<T1, T2, bool> canExecuteMethod, bool isAutomaticRequeryDisabled)
        {
            if (executeMethod == null)
            {
                throw new ArgumentNullException("executeMethod");
            }

            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
            _isAutomaticRequeryDisabled = isAutomaticRequeryDisabled;
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Method to determine if the command can be executed
        /// </summary>
        public bool CanExecute(T1 parameter1, T2 parameter2)
        {
            if (_canExecuteMethod != null)
            {
                return _canExecuteMethod(parameter1, parameter2);
            }
            return true;
        }

        /// <summary>
        ///     Execution of the command
        /// </summary>
        public void Execute(T1 parameter1, T2 parameter2)
        {
            if (_executeMethod != null)
            {
                _executeMethod(parameter1, parameter2);
            }
        }

        /// <summary>
        ///     Raises the CanExecuteChaged event
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }

        /// <summary>
        ///     Protected virtual method to raise CanExecuteChanged event
        /// </summary>
        protected virtual void OnCanExecuteChanged()
        {
            CommandManagerHelper.CallWeakReferenceHandlers(_canExecuteChangedHandlers);
        }

        /// <summary>
        ///     Property to enable or disable CommandManager's automatic requery on this command
        /// </summary>
        public bool IsAutomaticRequeryDisabled
        {
            get
            {
                return _isAutomaticRequeryDisabled;
            }
            set
            {
                if (_isAutomaticRequeryDisabled != value)
                {
                    if (value)
                    {
                        CommandManagerHelper.RemoveHandlersFromRequerySuggested(_canExecuteChangedHandlers);
                    }
                    else
                    {
                        CommandManagerHelper.AddHandlersToRequerySuggested(_canExecuteChangedHandlers);
                    }
                    _isAutomaticRequeryDisabled = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public object Target
        {
            get
            {
                if (_executeMethod == null)
                    return null;

                return _executeMethod.Target;
            }
        }

        #endregion

        #region ICommand Members

        /// <summary>
        ///     ICommand.CanExecuteChanged implementation
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (!_isAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested += value;
                }
                CommandManagerHelper.AddWeakReferenceHandler(ref _canExecuteChangedHandlers, value, 2);
            }
            remove
            {
                if (!_isAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested -= value;
                }
                CommandManagerHelper.RemoveWeakReferenceHandler(_canExecuteChangedHandlers, value);
            }
        }

        public virtual bool CanExecute(object parameter)
        {
            if (parameter == null || !(parameter is object[]) || (parameter as object[]).Length < 2)
                return false;

            object[] parameters = parameter as object[];

            // if T is of value type and the parameter is not
            // set yet, then return false if CanExecute delegate
            // exists, else return true
            if ((parameters[0] != null && !typeof(T1).IsAssignableFrom(parameters[0].GetType()))
                || (parameters[0] == null && typeof(T1).IsValueType)
                || (parameters[1] != null && !typeof(T2).IsAssignableFrom(parameters[1].GetType()))
                || (parameters[1] == null && typeof(T2).IsValueType)
                )
            {
                return false;
            }

            return CanExecute((T1)parameters[0], (T2)parameters[1]);
        }

        public virtual void Execute(object parameter)
        {
            if (parameter == null || !(parameter is object[]) || (parameter as object[]).Length < 2)
                return;

            object[] parameters = parameter as object[];

            // if T is of value type and the parameter is not
            // set yet, then return false if CanExecute delegate
            // exists, else return true
            if ((parameters[0] != null && !typeof(T1).IsAssignableFrom(parameters[0].GetType()))
                || (parameters[0] == null && typeof(T1).IsValueType)
                || (parameters[1] != null && !typeof(T2).IsAssignableFrom(parameters[1].GetType()))
                || (parameters[1] == null && typeof(T2).IsValueType)
                )
                return;

            Execute((T1)parameters[0], (T2)parameters[1]);
        }

        #endregion

        #region Data

        private readonly Action<T1, T2> _executeMethod = null;
        private readonly Func<T1, T2, bool> _canExecuteMethod = null;
        private bool _isAutomaticRequeryDisabled = false;
        private List<WeakReference> _canExecuteChangedHandlers;

        #endregion
    }

    public class CanExecuteDelegateCommand<T1, T2, T3> : IDelegateCommand
    {
        #region Constructors

        /// <summary>
        ///     Constructor
        /// </summary>
        public CanExecuteDelegateCommand(Action<T1, T2, T3> executeMethod)
            : this(executeMethod, null, false)
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public CanExecuteDelegateCommand(Action<T1, T2, T3> executeMethod, Func<T1, T2, T3, bool> canExecuteMethod)
            : this(executeMethod, canExecuteMethod, false)
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public CanExecuteDelegateCommand(Action<T1, T2, T3> executeMethod, Func<T1, T2, T3, bool> canExecuteMethod, bool isAutomaticRequeryDisabled)
        {
            if (executeMethod == null)
            {
                throw new ArgumentNullException("executeMethod");
            }

            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
            _isAutomaticRequeryDisabled = isAutomaticRequeryDisabled;
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Method to determine if the command can be executed
        /// </summary>
        public bool CanExecute(T1 parameter1, T2 parameter2, T3 parameter3)
        {
            if (_canExecuteMethod != null)
            {
                return _canExecuteMethod(parameter1, parameter2, parameter3);
            }
            return true;
        }

        /// <summary>
        ///     Execution of the command
        /// </summary>
        public void Execute(T1 parameter1, T2 parameter2, T3 parameter3)
        {
            if (_executeMethod != null)
            {
                _executeMethod(parameter1, parameter2, parameter3);
            }
        }

        /// <summary>
        ///     Raises the CanExecuteChaged event
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }

        /// <summary>
        ///     Protected virtual method to raise CanExecuteChanged event
        /// </summary>
        protected virtual void OnCanExecuteChanged()
        {
            CommandManagerHelper.CallWeakReferenceHandlers(_canExecuteChangedHandlers);
        }

        /// <summary>
        ///     Property to enable or disable CommandManager's automatic requery on this command
        /// </summary>
        public bool IsAutomaticRequeryDisabled
        {
            get
            {
                return _isAutomaticRequeryDisabled;
            }
            set
            {
                if (_isAutomaticRequeryDisabled != value)
                {
                    if (value)
                    {
                        CommandManagerHelper.RemoveHandlersFromRequerySuggested(_canExecuteChangedHandlers);
                    }
                    else
                    {
                        CommandManagerHelper.AddHandlersToRequerySuggested(_canExecuteChangedHandlers);
                    }
                    _isAutomaticRequeryDisabled = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public object Target
        {
            get
            {
                if (_executeMethod == null)
                    return null;

                return _executeMethod.Target;
            }
        }

        #endregion

        #region ICommand Members

        /// <summary>
        ///     ICommand.CanExecuteChanged implementation
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (!_isAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested += value;
                }
                CommandManagerHelper.AddWeakReferenceHandler(ref _canExecuteChangedHandlers, value, 2);
            }
            remove
            {
                if (!_isAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested -= value;
                }
                CommandManagerHelper.RemoveWeakReferenceHandler(_canExecuteChangedHandlers, value);
            }
        }

        public virtual bool CanExecute(object parameter)
        {
            if (parameter == null || !(parameter is object[]) || (parameter as object[]).Length < 3)
                return false;

            object[] parameters = parameter as object[];

            // if T is of value type and the parameter is not
            // set yet, then return false if CanExecute delegate
            // exists, else return true
            if ((parameters[0] != null && !typeof(T1).IsAssignableFrom(parameters[0].GetType()))
                || (parameters[0] == null && typeof(T1).IsValueType)
                || (parameters[1] != null && !typeof(T2).IsAssignableFrom(parameters[1].GetType()))
                || (parameters[1] == null && typeof(T2).IsValueType)
                || (parameters[2] != null && !typeof(T3).IsAssignableFrom(parameters[2].GetType()))
                || (parameters[2] == null && typeof(T3).IsValueType)
                )
            {
                return false;
            }

            return CanExecute((T1)parameters[0], (T2)parameters[1], (T3)parameters[2]);
        }

        public virtual void Execute(object parameter)
        {
            if (parameter == null || !(parameter is object[]) || (parameter as object[]).Length < 3)
                return;

            object[] parameters = parameter as object[];

            // if T is of value type and the parameter is not
            // set yet, then return false if CanExecute delegate
            // exists, else return true
            if ((parameters[0] != null && !typeof(T1).IsAssignableFrom(parameters[0].GetType()))
                || (parameters[0] == null && typeof(T1).IsValueType)
                || (parameters[1] != null && !typeof(T2).IsAssignableFrom(parameters[1].GetType()))
                || (parameters[1] == null && typeof(T2).IsValueType)
                || (parameters[2] != null && !typeof(T3).IsAssignableFrom(parameters[2].GetType()))
                || (parameters[2] == null && typeof(T3).IsValueType)
                )
                return;

            Execute((T1)parameters[0], (T2)parameters[1], (T3)parameters[2]);
        }

        #endregion

        #region Data

        private readonly Action<T1, T2, T3> _executeMethod = null;
        private readonly Func<T1, T2, T3, bool> _canExecuteMethod = null;
        private bool _isAutomaticRequeryDisabled = false;
        private List<WeakReference> _canExecuteChangedHandlers;

        #endregion
    }

    public interface IDelegateCommand : ICommand
    {
        object Target { get; }
    }

    /// <summary>
    ///     This class contains methods for the CommandManager that help avoid memory leaks by
    ///     using weak references.
    /// </summary>
    internal class CommandManagerHelper
    {
        internal static void CallWeakReferenceHandlers(List<WeakReference> handlers)
        {
            if (handlers != null)
            {
                // Take a snapshot of the handlers before we call out to them since the handlers
                // could cause the array to me modified while we are reading it.

                EventHandler[] callees = new EventHandler[handlers.Count];
                int count = 0;

                for (int i = handlers.Count - 1; i >= 0; i--)
                {
                    WeakReference reference = handlers[i];
                    EventHandler handler = reference.Target as EventHandler;
                    if (handler == null)
                    {
                        // Clean up old handlers that have been collected
                        handlers.RemoveAt(i);
                    }
                    else
                    {
                        callees[count] = handler;
                        count++;
                    }
                }

                // Call the handlers that we snapshotted
                for (int i = 0; i < count; i++)
                {
                    EventHandler handler = callees[i];
                    handler(null, EventArgs.Empty);
                }
            }
        }

        internal static void AddHandlersToRequerySuggested(List<WeakReference> handlers)
        {
            if (handlers != null)
            {
                foreach (WeakReference handlerRef in handlers)
                {
                    EventHandler handler = handlerRef.Target as EventHandler;
                    if (handler != null)
                    {
                        CommandManager.RequerySuggested += handler;
                    }
                }
            }
        }

        internal static void RemoveHandlersFromRequerySuggested(List<WeakReference> handlers)
        {
            if (handlers != null)
            {
                foreach (WeakReference handlerRef in handlers)
                {
                    EventHandler handler = handlerRef.Target as EventHandler;
                    if (handler != null)
                    {
                        CommandManager.RequerySuggested -= handler;
                    }
                }
            }
        }

        internal static void AddWeakReferenceHandler(ref List<WeakReference> handlers, EventHandler handler)
        {
            AddWeakReferenceHandler(ref handlers, handler, -1);
        }

        internal static void AddWeakReferenceHandler(ref List<WeakReference> handlers, EventHandler handler, int defaultListSize)
        {
            if (handlers == null)
            {
                handlers = (defaultListSize > 0 ? new List<WeakReference>(defaultListSize) : new List<WeakReference>());
            }

            handlers.Add(new WeakReference(handler));
        }

        internal static void RemoveWeakReferenceHandler(List<WeakReference> handlers, EventHandler handler)
        {
            if (handlers != null)
            {
                for (int i = handlers.Count - 1; i >= 0; i--)
                {
                    WeakReference reference = handlers[i];
                    EventHandler existingHandler = reference.Target as EventHandler;
                    if ((existingHandler == null) || (existingHandler == handler))
                    {
                        // Clean up old handlers that have been collected
                        // in addition to the handler that is to be removed.
                        handlers.RemoveAt(i);
                    }
                }
            }
        }
    }
}
