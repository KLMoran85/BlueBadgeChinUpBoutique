using ChinUpBoutique.Data;
using ChinUpBoutique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinUpBoutique.Services
{
    public class UserReviewService
    {
        private readonly Guid _userId;

        public UserReviewService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUserReview(UserReviewCreate model)
        {
            var entity =
                new UserReview()
                {
                    OwnerID = _userId,
                    Title = model.Title,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.UserReviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserReviewListItem> GetUserReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                       .UserReviews
                       .Where(e => e.OwnerID == _userId)

                       .Select(
                          e =>
                                new UserReviewListItem
                                {
                                    ReviewID = e.ReviewID,
                                    StylistID = e.StylistID,
                                    Title = e.Title,
                                    Content = e.Content,
                                    CreatedUtc = e.CreatedUtc
                                }

                          );
                return query.ToArray();
            }
        }

        public UserReviewDetail GetUserReviewById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserReviews
                        .Single(e => e.ReviewID == id && e.OwnerID == _userId);

                return new UserReviewDetail
                {
                    ReviewID = entity.ReviewID,
                    StylistID = entity.StylistID,
                    Title = entity.Title,
                    Content = entity.Content,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }
        
        public bool UpdateUserReview(UserReviewEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserReviews
                        .Single(e => e.ReviewID == model.ReviewID && e.OwnerID == _userId);

                entity.ReviewID = model.ReviewID;
                entity.StylistID = model.StylistID;
                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUserReview(int ReviewID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserReviews
                        .Single(e => e.ReviewID == ReviewID && e.OwnerID == _userId);

                ctx.UserReviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
