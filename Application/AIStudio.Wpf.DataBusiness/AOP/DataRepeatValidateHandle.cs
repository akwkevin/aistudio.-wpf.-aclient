using AIStudio.AOP;
using AIStudio.Core;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.DataBusiness.Base_Manage;
using AIStudio.Wpf.DataRepository;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;

namespace AIStudio.Wpf.DataBusiness.AOP
{
    public class DataRepeatValidateHandle : BaseAOPHandler
    {
        public DataRepeatValidateHandle(string[] validateFields, string[] validateFieldNames, bool allData = false, bool matchOr = true)
        {
            if (validateFields.Length != validateFieldNames.Length)
                throw new Exception("校验列与列描述信息不对应!");

            _allData = allData;
            _matchOr = matchOr;
            for (int i = 0; i < validateFields.Length; i++)
            {
                _validateFields.Add(validateFields[i], validateFieldNames[i]);
            }
        }

        private bool _allData { get; }
        private bool _matchOr { get; }
        private Dictionary<string, string> _validateFields { get; } = new Dictionary<string, string>();

        public override void Befor(IMethodInvocation input)
        {
            Type entityType = input.Arguments[0].GetType();
            var data = input.Arguments[0];
            List<string> whereList = new List<string>();
            var properties = _validateFields
                .Where(x => !data.GetPropertyValue(x.Key).IsNullOrEmpty())
                .ToList();
            properties.ForEach((aProperty, index) =>
            {
                whereList.Add($" {aProperty.Key} = @{index} ");
            });
            IQueryable q = null;
            if (_allData)
            {
                var repository = input.Target.GetPropertyValue("Service") as IDbAccessor;
                var method = repository.GetType().GetMethod("GetIQueryable");
                q = method.MakeGenericMethod(entityType).Invoke(repository, new object[] { false }) as IQueryable;
            }
            else
                q = input.Target.GetType().GetMethod("GetIQueryable").Invoke(input.Target, new object[] { false }) as IQueryable;
            q = q.Where("Id != @0", data.GetPropertyValue("Id"));
            q = q.Where(
                string.Join(_matchOr ? " || " : " && ", whereList),
                properties.Select(x => data.GetPropertyValue(x.Key)).ToArray());
            var list = q.CastToList<object>();
            if (list.Count > 0)
            {
                var repeatList = properties
                    .Where(x => list.Any(y => !y.GetPropertyValue(x.Key).IsNullOrEmpty()))
                    .Select(x => x.Value)
                    .ToList();

                throw new BusException($"{string.Join(_matchOr ? "或" : "与", repeatList)}已存在!");
            }
        }
    }

    public class DataRepeatValidateAttribute : HandlerAttribute
    {
        protected string[] _validateFields { get; }
        protected string[] _validateFieldNames { get; }
        protected bool _allData { get; }
        protected bool _matchOr { get; }

        public DataRepeatValidateAttribute(string[] validateFields, string[] validateFieldNames, bool allData = false, bool matchOr = true)
        {
            _validateFields = validateFields;
            _validateFieldNames = validateFieldNames;
            _allData = allData;
            _matchOr = matchOr;
        }

        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new DataRepeatValidateHandle(_validateFields, _validateFieldNames, _allData, _matchOr) { Order = this.Order };
        }
    }
}
