using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIStudio.Wpf.DataRepository
{
    public class BaseDbContextFactory : IDesignTimeDbContextFactory<BaseDbContext>
    {
        public BaseDbContext CreateDbContext(string[] args)
        {
            string conString = "Data Source=Admin.db";
            DatabaseType dbType = DatabaseType.SQLite;
            return DbFactory.GetDbContext(conString, dbType);
        }
    }
}
