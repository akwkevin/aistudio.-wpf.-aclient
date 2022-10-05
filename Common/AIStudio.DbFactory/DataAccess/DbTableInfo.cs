namespace AIStudio.DbFactory.DataAccess
{
    public class DbTableInfo 
    {   /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 表描述说明
        /// </summary>
        public string Description { get; set; }
        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
