using ChinUpBoutique.Data;
using ChinUpBoutique.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChinUpBoutique.Services
{
    public class ProfilesService
    {
        private readonly Guid _userId;

        public ProfilesService(Guid userId)
        {
            _userId = userId;
        }
        public bool Create()
        {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Profiles.Add(new Profile { UserID = _userId.ToString()});

                return ctx.SaveChanges() == 1;
            }
        }
        public bool Edit(ProfileEdit edit)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldProfile = ctx.Profiles
                    .Single(e => e.UserID == _userId.ToString());

                oldProfile.FirstName = edit.FirstName;
                oldProfile.LastName = edit.LastName;
                oldProfile.Email = edit.Email;
                oldProfile.PhoneNumber = edit.PhoneNumber;

                MemoryStream target = new MemoryStream();
                edit.Photo.InputStream.CopyTo(target);
                byte[] data = target.ToArray();

                oldProfile.Photo = data;

                return ctx.SaveChanges() == 1;
                    
            }
        }

        public Profile GetProfileByUserID(string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var Profile = ctx.Profiles
                    .SingleOrDefault(e => e.UserID == userId);

                return Profile;
            }
        }

        public bool UpdateProfile(ProfileEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Profiles
                    .Single(e => e.UserID == model.UserID);

                entity.UserID = model.UserID;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Email = model.Email;

                return ctx.SaveChanges() == 1;
            }
        }

    
        
    }
}
