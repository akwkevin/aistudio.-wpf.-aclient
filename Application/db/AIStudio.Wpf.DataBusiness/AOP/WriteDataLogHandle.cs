using AIStudio.AOP;
using AIStudio.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;

namespace AIStudio.Wpf.DataBusiness.AOP
{
    public class WriteDataLogHandle : BaseAOPHandler
    {
        protected UserLogType _logType { get; }
        protected string _dataName { get; }
        protected string _nameField { get; }

        public WriteDataLogHandle(UserLogType logType, string nameField, string dataName)
        {
            _logType = logType;
            _dataName = dataName;
            _nameField = nameField;
        }
    }

   
}
