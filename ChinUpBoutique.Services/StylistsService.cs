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
    public class StylistsService
    {
        private readonly Guid _userId;

        public StylistsService(Guid userId)
        {
            _userId = userId;
        }

        public List<StylistListItem> GetListOfStylists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var role = ctx.Roles.Single(e => e.Name == "StylistUser").Id;
                var stylists = ctx.Users.ToList();

                var service = new ProfilesService(_userId);

                List<StylistListItem> ListOfStylists = new List<StylistListItem>();
                foreach (var individual in stylists)
                {
                    var m = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));
                    var rolesForUser = m.GetRoles(individual.Id).FirstOrDefault();
                    if (rolesForUser == "StylistUser")
                    {
                        var profile = service.GetProfileByUserID(individual.Id);
                        var updated = new StylistListItem
                        {
                            StylistID = individual.Id,
                            StylistUserName = individual.UserName,
                            StylistFirstName = profile.FirstName,
                            StylistLastName = profile.LastName,
                            Photo = profile.Photo

                        };
                        ListOfStylists.Add(updated);
                    }
                }
                return ListOfStylists;
            }
        }

        public StylistDetail GetStylistById(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Users
                    .Single(e => e.Id == id.ToString());

                var service = new StylistDetail
                {
                    StylistID = entity.Id,
                    StylistUserName = entity.UserName
                };
                return service;
            }
        }



    }


}
