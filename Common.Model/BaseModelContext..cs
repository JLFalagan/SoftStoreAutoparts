using Common.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common.Model
{
    public class BaseModelContext : DbContext
    {
        public BaseModelContext() : base(GetConnectionString())
        {
            this.SetCommandTimeOut(300);
        }

        public BaseModelContext(string modelName) : base(modelName)
        {
            this.SetCommandTimeOut(180);
        }
        public void SetCommandTimeOut(int timeout)
        {
            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = timeout;
        }

        private static bool isEncryption = false;
        private static string stringConnection;
        
        public static string GetConnectionString()
        {
            stringConnection = ConfigurationManager.ConnectionStrings["ModelConnection"].ConnectionString;

            if (isEncryption)
            {
                if (!string.IsNullOrEmpty(stringConnection))
                {
                    var encryptSc = ConfigurationManager.ConnectionStrings["ModelConnection"].ConnectionString;
                    var desencrypt = EncryptionUtils.Decrypt(encryptSc, "Neyti123");
                    stringConnection = desencrypt;
                }
            }

            return stringConnection;
        }


        public int SaveChangesWithTracker(bool changeTracker = true)
        {
            int retVal = 0;
            if (changeTracker)
                retVal = this.SaveChanges();
            else
                retVal = base.SaveChanges();

            return retVal;
        }

        //public override int SaveChanges()
        //{
        //    var serverDate = this.GetServerDate();

        //    var addedEntities = ChangeTracker.Entries().Where(p => p.State == EntityState.Added).ToList();
        //    var deletedEntities = ChangeTracker.Entries().Where(p => p.State == EntityState.Deleted).ToList();
        //    foreach (var change in addedEntities)
        //    {
        //        var baseEntity = change.Entity as AuditEntity;
        //        if (baseEntity != null)
        //        {
        //            //baseEntity.CreatorUserId = LoggedUserApp.Id;
        //            baseEntity.Created = serverDate;
        //        }
                    

        //        Dictionary<string, object> oldValues = new Dictionary<string, object>();
        //        Dictionary<string, object> newValues = new Dictionary<string, object>();
        //        var entityType = change.Entity.GetDiscriminatorFromType();
        //        var primaryKey = GetPrimaryKeyValue(change);

        //        foreach (var prop in change.CurrentValues.PropertyNames)
        //        {
                    
        //            var currentValue = change.CurrentValues[prop]?.ToString();
        //            newValues.Add(prop, currentValue);
        //        }
        //        long entityId = 0;
        //        long.TryParse(primaryKey.ToString(), out entityId);
        //        var log = new EntityEventLog(NeyTI.Core.Model.Entities.EventLogType.AddedId, entityType, entityId, System.Environment.MachineName);
        //        log.OldValues = JsonConvert.SerializeObject(oldValues, Formatting.Indented);
        //        log.NewValues = JsonConvert.SerializeObject(newValues, Formatting.Indented);
        //        //log.CreatorUserId = LoggedUserApp.Id;
        //        log.CreatedBy = LoggedUserApp.UserName;

        //        this.EntityEventLog.Add(log);
        //    }

        //    var modifiedEntities = ChangeTracker.Entries().Where(p => p.State == EntityState.Modified).ToList();
        //    foreach (var change in modifiedEntities)
        //    {
        //        var baseEntity = change.Entity as AuditEntity;
        //        if (baseEntity != null)
        //            baseEntity.Updated = serverDate;

        //        Dictionary<string, object> oldValues = new Dictionary<string, object>();
        //        Dictionary<string, object> newValues = new Dictionary<string, object>();
        //        bool isModified = false;
        //        var entityType = change.Entity.GetDiscriminatorFromType();
        //        var primaryKey = GetPrimaryKeyValue(change);

        //        foreach (var prop in change.OriginalValues.PropertyNames)
        //        {
        //            var originalValue = change.OriginalValues[prop]?.ToString();
        //            var currentValue = change.CurrentValues[prop]?.ToString();
        //            if (originalValue != null && currentValue != null && !originalValue.Equals(currentValue)) //Only create a log if the value changes
        //            {
        //                isModified = true;
        //                oldValues.Add(prop, originalValue);
        //                newValues.Add(prop, currentValue);
        //            }
        //        }

        //        if (isModified)
        //        {
        //            long entityId = 0;
        //            long.TryParse(primaryKey.ToString(), out entityId); 
        //             var log = new EntityEventLog(NeyTI.Core.Model.Entities.EventLogType.ModifiedId, entityType, entityId, System.Environment.MachineName);
        //            //log.CreatorUserId = LoggedUserApp.Id;
        //            log.CreatedBy = LoggedUserApp.UserName;

        //            log.OldValues = JsonConvert.SerializeObject(oldValues);
        //            log.NewValues = JsonConvert.SerializeObject(newValues);

        //            this.EntityEventLog.Add(log);
        //        };
        //    }

        //    return base.SaveChanges();
        //}

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public Task<int> SaveChangesWithTrackerAsync(bool changeTracker = true)
        {
            if (changeTracker)
                return this.SaveChangesAsync();
            else
                return base.SaveChangesAsync();
        }


        public override Task<int> SaveChangesAsync()
        {
            var serverDate = this.GetServerDate();
            //var hostname = HttpContext.Current.Request.Url.Host;
            var addedEntities = ChangeTracker.Entries().Where(p => p.State == EntityState.Added).ToList();
            var deletedEntities = ChangeTracker.Entries().Where(p => p.State == EntityState.Deleted).ToList();
            foreach (var change in addedEntities)
            {
                //var baseEntity = change.Entity as AuditEntity;
                //if (baseEntity != null)
                //{
                //    //baseEntity.CreatorUserId = LoggedUserApp.Id;
                //    baseEntity.Created = serverDate;
                //}


                Dictionary<string, object> oldValues = new Dictionary<string, object>();
                Dictionary<string, object> newValues = new Dictionary<string, object>();
                var entityType = change.Entity.GetDiscriminatorFromType();
                var primaryKey = GetPrimaryKeyValue(change);

                foreach (var prop in change.CurrentValues.PropertyNames)
                {
                    var currentValue = change.CurrentValues[prop]?.ToString();
                    newValues.Add(prop, currentValue);
                }
                long entityId = 0;
                long.TryParse(primaryKey.ToString(), out entityId);
                var log = new EntityEventLog(NeyTI.Core.Model.Entities.EventLogType.AddedId, entityType, entityId, System.Environment.MachineName);
                log.OldValues = JsonConvert.SerializeObject(oldValues, Formatting.Indented);
                log.NewValues = JsonConvert.SerializeObject(newValues, Formatting.Indented);
                //log.CreatorUserId = LoggedUserApp.Id;

                this.EntityEventLog.Add(log);
            }

            var modifiedEntities = ChangeTracker.Entries().Where(p => p.State == EntityState.Modified).ToList();
            foreach (var change in modifiedEntities)
            {
                //var baseEntity = change.Entity as AuditEntity;
                //if (baseEntity != null)
                //    baseEntity.Updated = serverDate;

                Dictionary<string, object> oldValues = new Dictionary<string, object>();
                Dictionary<string, object> newValues = new Dictionary<string, object>();
                bool isModified = false;
                var entityType = change.Entity.GetDiscriminatorFromType();
                var primaryKey = GetPrimaryKeyValue(change);

                foreach (var prop in change.OriginalValues.PropertyNames)
                {
                    var originalValue = change.OriginalValues[prop]?.ToString();
                    var currentValue = change.CurrentValues[prop]?.ToString();
                    if (originalValue != null && currentValue != null && !originalValue.Equals(currentValue)) //Only create a log if the value changes
                    {
                        isModified = true;
                        oldValues.Add(prop, originalValue);
                        newValues.Add(prop, currentValue);
                    }
                }

                if (isModified)
                {
                    long entityId = 0;
                    long.TryParse(primaryKey.ToString(), out entityId);
                    var log = new EntityEventLog(NeyTI.Core.Model.Entities.EventLogType.ModifiedId, entityType, entityId, System.Environment.MachineName);
                    log.OldValues = JsonConvert.SerializeObject(oldValues);
                    log.NewValues = JsonConvert.SerializeObject(newValues);
                    //log.CreatorUserId = LoggedUserApp.Id;

                    this.EntityEventLog.Add(log);
                };
            }

            return base.SaveChangesAsync();
        }

        public IList<T> Where<T>()
        {
            throw new NotImplementedException();
        }

        object GetPrimaryKeyValue(DbEntityEntry entry)
        {
            object key = 0;
            var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
            if(objectStateEntry.EntityKey.EntityKeyValues != null)
                key = objectStateEntry.EntityKey.EntityKeyValues[0].Value;
            return key;
        }


        // Security
        public DbSet<Core.Model.Security.AppUser> UserApp { get; set; }
        public DbSet<Core.Model.Security.AppUserRole> AppUserRole { get; set; }
        public DbSet<Core.Model.Security.AppRole> AppRole { get; set; }
        public DbSet<Core.Model.Security.SecurityGroup> SecurityGroup { get; set; }
        public DbSet<Core.Model.Security.SecurityItem> SecurityItem { get; set; }
        public DbSet<Core.Model.Security.Permission> Permission { get; set; }
        //Audit
        public DbSet<Core.Model.Entities.EventLogType> EventLogType { get; set; }
        public DbSet<Core.Model.Entities.EntityEventLog> EntityEventLog { get; set; }
        public DbSet<Core.Model.Entities.BusinessEventLog> BusinessEventLog { get; set; }

        // Batch Process
        public DbSet<Process.BaseTask> BaseTask { get; set; }
        public DbSet<Process.BaseTaskArgs> BaseTaskArgs { get; set; }
        public DbSet<Process.TaskState> TaskState { get; set; }
        //public DbSet<Process.Batch> Batch { get; set; }
        //public DbSet<Process.BatchItemState> BatchItemState { get; set; }

        //Config

        public DbSet<SystemParameterGroup> SystemParameterGroup { get; set; }
        public DbSet<SystemParameter> SystemParameter { get; set; }
    }
}
