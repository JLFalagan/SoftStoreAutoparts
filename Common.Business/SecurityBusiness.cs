using Common.Extension;
using Common.Model;
using Common.Model.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Business
{
    public static class SecurityBusiness
    {
        public static AppUser GetByUsername(string username)
        {

            try
            {
                AppUser retVal = null;

                using (var ctx = BaseBusiness.CreateDbContext())
                {
                    retVal = ctx.Set<AppUser>().Where(x => x.UserName.ToUpper() == username.ToUpper()).Include("Roles").SingleOrDefault();
                }

                return retVal;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Save(this AppUser entity, DbContext ctx) //BaseModelContext - Version NetStandar
        {
            var other = ctx.SingleOrDefault<AppUser>(x => x.UserName == entity.UserName);
            if (other != null && !entity.Equals(other))
                throw new BusinessException("Ya existe un Usuario con el mismo nombre de usuario");

            //if (entity.UserRoles.Count() > 0)
            //{
            //    var result = entity.UserRoles.All(x => x.RoleId == 0);
            //    throw new BusinessException("Debe seleccionar un Rol de Seguridad.");
            //}

            //if (entity.IsNew)
            //    ctx.Set(entity.GetType()).Add(entity);
            if (entity.IsNew)
                ctx.Set<AppUser>().Add(entity);
            else
            {
                var childDb1 = ctx.Set<AppUserAppUserRole>();
                var childDb2 = ctx.Set<AppUserAppRole>();
                var items1 = childDb1.Local.Where(x => x.User == null).ToList();
                childDb1.RemoveRange(items1);
                var items2 = childDb2.Local.Where(x => x.User == null).ToList();
                childDb2.RemoveRange(items2);
            }

            ctx.SaveChanges();
        }

        public static void Delete(this AppUser entity, DbContext ctx)
        {
            var delete = ctx.Set<AppUser>().Find(entity.Id);
            var childDb = ctx.Set<AppUserAppUserRole>();
            childDb.RemoveRange(delete.UserRoles);
            ctx.Set<AppUser>().Remove(delete);
            ctx.SaveChanges();
        }

        public static AppUser Validate(string username, string password)
        {

            AppUser retVal = null;
            try
            {
                using (var ctx = BaseBusiness.CreateDbContext())
                {
                    if (!ctx.CheckConnection())
                        throw new WithoutConnectionException();
                    retVal = ctx.Set<AppUser>().Where(x => x.UserName.ToUpper() == username.ToUpper() && x.Password == password).Include(x => x.UserRoles.Select(y => y.Role)).SingleOrDefault();
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return retVal;
        }

        public static bool ChangePassword(string username, string currentPassword, string newPassword)
        {

            AppUser entity = null;

            using (var ctx = BaseBusiness.CreateDbContext())
            {
                entity = ctx.Set<AppUser>().Where(x => x.UserName.ToUpper() == username.ToUpper() && x.Password == currentPassword).SingleOrDefault();
                if (entity == null)
                    throw new BusinessException("El Usuario y/o Contraseña actual son erroneas");

                entity.Password = newPassword;
                entity.Save(ctx);
            }

            return true;
        }

        public static void Save(this AppUserRole entity, DbContext ctx) //BaseModelContext - Version NetStandar
        {
            var other = ctx.SingleOrDefault<AppUserRole>(x => x.Name == entity.Name);
            if (other != null && !entity.Equals(other))
                throw new BusinessException("Ya existe un Rol con el mismo nombre.");

            //if (entity.IsNew)
            //    ctx.Set(entity.GetType()).Add(entity);
            if (entity.IsNew)
                ctx.Set<AppUserRole>().Add(entity);
            else
            {
                var childDb = ctx.Set<AppUserAppUserRole>();
                var items = childDb.Local.Where(x => x.Role == null).ToList();
                childDb.RemoveRange(items);
            }

            ctx.SaveChanges();
        }
        public static void Delete(this AppUserRole entity, DbContext ctx) //BaseModelContext
        {
            var reference = ctx.Set<AppUser>().Where(x => x.UserRoles.Any(y => y.RoleId == entity.Id)).Count();
            if (reference > 0)
                throw new BusinessException("El Rol no se puede eliminar porque está asigando a uno o más usuarios.");

            var delete = ctx.Set<AppUserRole>().Find(entity.Id);
            var child1Db = ctx.Set<Permission>();
            child1Db.RemoveRange(delete.Permissions);
            ctx.Set<AppUserRole>().Remove(delete);
        }
        public static AppUserRole CloneRoleApp(long RoleAppId, DbContext ctx) //BaseModelContext
        {
            var entity = ctx.Set<AppUserRole>().Find(RoleAppId);

            var roleAppClone = new AppUserRole();
            roleAppClone.Name = entity.Name;
            foreach (var permission in entity.Permissions)
            {
                var permissionClone = new Permission();
                permissionClone.ItemId = permission.ItemId;
                permissionClone.Item = permission.Item;
                permissionClone.IsEnabled = permission.IsEnabled;
                permissionClone.IsVisible = permission.IsVisible;
                permissionClone.IsReadOnly = permission.IsReadOnly;

                roleAppClone.Permissions.Add(permissionClone);
            }

            return roleAppClone;
        }

        public static void Save(this SecurityGroup entity, DbContext ctx) //BaseModelContext - Version NetStandar
        {
            var other = ctx.SingleOrDefault<SecurityGroup>(x => x.Name == entity.Name);
            if (other != null && !entity.Equals(other))
                throw new BusinessException("Ya existe un Grupo de Seguridad con el mismo Nombre.");

            //Se remueven los items que no estan seleccioandos
            var removes = entity.Items.Where(x => !x.IsSelected);
            entity.Items.RemoveAll(removes);
            //for (int i = entity.Items.Count - 1; i >= 0; i--)
            //{
            //    if(!entity.Items[i].IsSelected)
            //        entity.Items.Remove(entity.Items[i]);
            //}

            var child1Db = ctx.Set<SecurityItem>();
            var child2Db = ctx.Set<Permission>();
            var items1 = child1Db.Local.Where(x => x.Group == null).ToList();
            //Elimino todos los permisos relacionados con el item de seguridad que elimino
            foreach (var item in items1)
            {
                var permisionsBySecurityItem = child2Db.Where(x => x.ItemId == item.Id);
                child2Db.RemoveRange(permisionsBySecurityItem);
            }

            child1Db.RemoveRange(items1);

            //if (entity.IsNew)
            //    ctx.Set(entity.GetType()).Add(entity);
            if (entity.IsNew)
                ctx.Set<SecurityGroup>().Add(entity);

            ctx.SaveChanges();
        }

        public static void Save(this SystemParameter entity, DbContext ctx) //BaseModelContext - Version NetStandar
        {
            var other = ctx.SingleOrDefault<SystemParameter>(x => x.Key == entity.Key);
            if (other != null && !entity.Equals(other))
                throw new BusinessException("Ya existe un Parámetro con la misma Clave.");

            //if (entity.IsNew)
            //    ctx.Set(entity.GetType()).Add(entity);
            if (entity.IsNew)
                ctx.Set<SystemParameter>().Add(entity);
        }
    }
}
