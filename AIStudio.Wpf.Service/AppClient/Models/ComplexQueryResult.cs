using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIStudio.Wpf.Service.AppClient.Models
{
    public class ComplexQueryResult
    {
        public string[] TableNames { get; }
        public string[] TableDatas { get; }

        public ComplexQueryResult(string[] tableNames, string[] tableDatas)
        {
            this.TableNames = tableNames;
            this.TableDatas = tableDatas;
        }

        public T[] GetTableData<T>(int index)
        {
            return JsonConvert.DeserializeObject<T[]>(TableDatas[index]);
        }
    }
}
