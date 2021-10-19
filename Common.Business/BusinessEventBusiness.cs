using Common.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Business
{
    public static class BusinessEventBusiness
    {
        public static void Save(this BusinessEventLog entity, DbContext ctx) //BaseModelContext - Version NetStandar
        {
            //Version NetStandar
            //if (entity.IsNew)
            //    ctx.Set(entity.GetType()).Add(entity);
            if (entity.IsNew)
                ctx.Set<BusinessEventLog>().Add(entity);
        }

        public static void AddBusinessEventEntry(this AuditEntity entity, long eventTyeId, string subject, string machineName, string description, DbContext ctx) //BaseModelContext
        {
            var entry = new BusinessEventLog(eventTyeId, entity, subject, description, machineName);
            entry.Save(ctx);
        }

        /// <summary>
        /// Add Information Entry
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="subject"></param>
        /// <param name="machineName"></param>
        /// <param name="description"></param>
        /// <param name="ctx"></param>
        public static void AddBusinessEventEntry(this AuditEntity entity, string subject, string machineName, string description, DbContext ctx) //BaseModelContext
        {
            var entry = new BusinessEventLog(EventLogType.InformationId, entity, subject, description, machineName);
            entry.Save(ctx);
        }

    }

}
