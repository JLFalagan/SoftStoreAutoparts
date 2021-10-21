using Common.Business;
using Common.Model;
using Common.Model.Entities;
using Common.Model.Log;
using Common.Model.Process;
using Common.Model.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.EFCore
{
    //TODO: Revisar y experimentar una Base de contexto usando los BaseModelContextNew y BaseModelContextOld que estan excluidos
    public class BaseModelContext : DbContext
    {
        private static bool IsEncryption = false;
        private static string StringConnection;

        public static string GetConnectionStringEncrypted()
        {
            StringConnection = "ModelConnection";

            if (IsEncryption)
            {
                if (!string.IsNullOrEmpty(StringConnection))
                {
                    var desencrypt = EncryptionUtilities.Decrypt(StringConnection, "Neyti123");
                    StringConnection = desencrypt;
                }
            }

            return StringConnection;
        }

        public int SaveChangesWithTracker(bool changeTracker = true)
        {
            int retVal;
            if (changeTracker)
                retVal = this.SaveChanges();
            else
                retVal = base.SaveChanges();

            return retVal;
        }

        public Task<int> SaveChangesWithTrackerAsync(bool changeTracker = true)
        {
            if (changeTracker)
                return this.SaveChangesAsync();
            else
                return base.SaveChangesAsync();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        // Security
        public DbSet<AppUser> UserApp { get; set; }
        public DbSet<AppUserRole> AppUserRole { get; set; }
        public DbSet<AppRole> AppRole { get; set; }
        public DbSet<SecurityGroup> SecurityGroup { get; set; }
        public DbSet<SecurityItem> SecurityItem { get; set; }
        public DbSet<Permission> Permission { get; set; }
        //Audit
        public DbSet<EventLogType> EventLogType { get; set; }
        public DbSet<EntityEventLog> EntityEventLog { get; set; }
        public DbSet<BusinessEventLog> BusinessEventLog { get; set; }

        // Batch Process
        public DbSet<BaseTask> BaseTask { get; set; }
        public DbSet<BaseTaskArgs> BaseTaskArgs { get; set; }
        public DbSet<TaskState> TaskState { get; set; }
        //public DbSet<Process.Batch> Batch { get; set; }
        //public DbSet<Process.BatchItemState> BatchItemState { get; set; }

        //Config
        public DbSet<SystemParameterGroup> SystemParameterGroup { get; set; }
        public DbSet<SystemParameter> SystemParameter { get; set; }
    }
}
