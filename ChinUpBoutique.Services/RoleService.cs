using ChinUpBoutique.Data;
using ChinUpBoutique.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinUpBoutique.Services
{
    public class RoleService
    {
        private readonly Guid _userId;

        public RoleService()
        {

        }

        public RoleService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<UserRole> GetUserRoles()
        {

            using (var ctx = new ApplicationDbContext())
            {
                var appUsers = ctx.Users.ToList();
                var usersToReturn = new List<UserRole>();
                foreach (var u in appUsers)
                {
                    var m = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));
                    var rolesForUser = m.GetRoles(u.Id);

                    var user = new UserRole
                    {
                        UserId = u.Id,
                        UserName = u.UserName,
                        Email = u.Email,
                        RoleNames = rolesForUser
                    };

                    usersToReturn.Add(user);
                };
                return usersToReturn;
            }
        }

        public string GetUserRole(string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));

                //var user = UserManager..FindAsync(userId);
                string rolename = UserManager.GetRoles(userId).FirstOrDefault();
                return rolename;
            }
        }

        public IEnumerable<IdentityRole> GetIdentityRoles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Roles.ToList();
            }
        }

        public void EditIdentyRoles(string userId, string RoleId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));
                var olduser = UserManager.FindById(userId);
                var oldRoleName = UserManager.GetRoles(userId).FirstOrDefault();
                var newRoleName = ctx.Roles.SingleOrDefault(r => r.Id == RoleId).Name;


                if (oldRoleName != newRoleName)
                {
                    UserManager.RemoveFromRole(userId, oldRoleName);
                    UserManager.AddToRole(userId, newRoleName);
                    ctx.SaveChanges();
                }   
            }
        }
    }
}
