Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.SqlServer.Design

 Scaffold-DbContext "Server=.;Database=Colder.Admin.AntdVue;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -UseDatabaseNames
  
 Scaffold-DbContext "Data Source=121.36.12.76;Initial Catalog=Colder.Admin.AntdVue;uid=sa;pwd=aic3600!" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -UseDatabaseNames