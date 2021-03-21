using AIStudio.Core;
using AIStudio.Wpf.EFCore.Models;
using System.Collections.Generic;

namespace AIStudio.Wpf.EFBusiness.Base_Manage
{
    public interface IBuildCodeBusiness
    {
        List<Base_DbLink> GetAllDbLink();

        List<DbTableInfo> GetDbTableList(string linkId);

        void Build(BuildInputDTO input);
    }

    public class DbTablesInputDTO
    {
        public string linkId { get; set; }
    }

    public class BuildInputDTO
    {
        public string linkId { get; set; }
        public string areaName { get; set; }
        public List<string> tables { get; set; }
        public List<int> buildTypes { get; set; }
    }
}
