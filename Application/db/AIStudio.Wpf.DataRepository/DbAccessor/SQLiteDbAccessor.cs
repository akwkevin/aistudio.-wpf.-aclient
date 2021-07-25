using System.Collections.Generic;

namespace AIStudio.Wpf.DataRepository
{
    internal class SQLiteDbAccessor : GenericDbAccessor, IDbAccessor
    {
        public SQLiteDbAccessor(string conString, ICollection<TableMapperRule> rules)
             : base(conString, DatabaseType.SQLite, rules)
        {
        }

        protected override string FormatFieldName(string name)
        {
            return $"\"{name}\"";
        }

        protected override string GetSchema(string schema)
        {
            return null;
        }
    }
}
