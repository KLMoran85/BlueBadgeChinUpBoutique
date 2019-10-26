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

        public RoleService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<UserRole> GetUserRoles()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));
                //string rolename = UserManager.GetRoles(userId).FirstOrDefault();

                var query =
                    ctx
                        .Users
                        .Select(
                            e =>
                        new UserRole
                        {
                            UserId = e.Id,
                            UserName = e.UserName,
                            Email = e.Email,
                            RoleName = UserManager.GetRoles(e.Id).FirstOrDefault()


                        }

                    );
                return query.ToArray();
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
