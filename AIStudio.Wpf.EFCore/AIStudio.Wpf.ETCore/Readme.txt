Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.SqlServer.Design

 Scaffold-DbContext "Server=.;Database=Food;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
  
 Scaffold-DbContext "Data Source=121.36.12.76;Initial Catalog=Colder.Admin.Core;uid=sa;pwd=aic3600!" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -UseDatabaseNames