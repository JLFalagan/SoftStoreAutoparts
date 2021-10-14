using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Common.Model
{
    public class SqlServerDbConfiguration : DbConfiguration
    {
        public SqlServerDbConfiguration()
        {


            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["ModelConnection"];
            SetDefaultConnectionFactory(new SqlConnectionFactory(connectionStringSettings.ConnectionString));
            SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
            SetProviderFactory("System.Data.SqlClient", SqlClientFactory.Instance);

            this.AddInterceptor(new CreateDatabaseCollationInterceptor("SQL_Latin1_General_CP1_CI_AS"));
        }

    }
}
