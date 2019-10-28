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
            //using (var ctx = new ApplicationDbContext())
            //{

            //    using (var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx)))
            //    {
            //        var query =
            //  ctx
            //      .Users
            //      .Select(
            //          e =>
            //      new UserRole
            //      {
            //          UserId = e.Id,
            //          UserName = e.UserName,
            //          Email = e.Email,
            //          RoleNames = UserManager.GetRoles(e.Id)


            //      }

            //  );
            //        return query.ToList();
            //    }
            //        //string rolename = UserManager.GetRoles(userId).FirstOrDefault();


            //}       


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

    }
}
