using ChinUpBoutique.Data;
using ChinUpBoutique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinUpBoutique.Services
{   
    public class StylistsService
    {
        private readonly Guid _userId;

        public StylistsService(Guid userId)
        {
            _userId = userId;
        }
        
        public void GetListOfStylists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var role = ctx.Roles.Single(e => e.Name == "StylistUser").Id;
                var stylists = ctx.Users
                    .Where(e => e.Roles.First().RoleId == role )
                    .Select(e => new Stylists {
                        StylistID = e.Id,
                        StylistUser = e,
                        StylistUserName = e.UserName
                    })
                 .ToList();


            }
        }
        
    }


}
