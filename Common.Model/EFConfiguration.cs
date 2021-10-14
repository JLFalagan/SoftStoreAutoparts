using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Common.Model
{
    public class EFConfiguration : DbConfiguration
    {
        public EFConfiguration()
        {
            //this.AddInterceptor(new CreateDatabaseCollationInterceptor("Modern_Spanish_CI_AS"));
            this.AddInterceptor(new CreateDatabaseCollationInterceptor("SQL_Latin1_General_CP1_CI_AS"));
        }

    }
}
