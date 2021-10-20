using _24Hour.Data;
using _24Hour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        // C
        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    CommentAuthorId = _userId,
                    CommentText = model.CommentText
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // R
        public IEnumerable<CommentListItem> GetCommentByAuthorId()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.CommentAuthorId == _userId)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    CommentId = e.CommentId,
                                    CommentText = e.CommentText,
                                    CommentAuthorId = e.CommentAuthorId
                                }
                        );
                return query.ToArray();
            }
        }

        // R
        public CommentDetail GetCommentByPostId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == id && e.Id == _userId);
                return
                    new CommentDetail
                    {
                        CommentId = entity.CommentId,
                        CommentText = entity.CommentText,
                        CommentAuthorId = entity.CommentAuthorId
                    };
            }
        }

        // U
        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == model.CommentId && e.CommentAuthorId == _userId);

                entity.CommentText = model.CommentText;
                entity.CommentAuthorId = model.CommentAuthorId;

                return ctx.SaveChanges() == 1;
            }
        }

        // D
        public bool DeleteComment(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == Id && e.CommentAuthorId == _userId);

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
