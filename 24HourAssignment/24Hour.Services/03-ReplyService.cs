using _24Hour.Data;
using _24Hour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        // C
        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    ReplyAuthorId = _userId,
                    ReplyText = model.ReplyText
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // R
        public IEnumerable<ReplyListItem> GetReplyByAuthorId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Replies
                        .Where(e => e.ReplyAuthorId == _userId)
                        .Select(
                            e =>
                                new ReplyListItem
                                {
                                    ReplyId = e.ReplyId,
                                    ReplyText = e.ReplyText,
                                    ReplyAuthorId = e.ReplyAuthorId
                                }
                        );
                return query.ToArray();
            }
        }

        // R
        public ReplyDetail GetReplyByCommentId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.ReplyId == id && e.CommentId == _userId);
                return
                    new ReplyDetail
                    {
                        ReplyId = entity.ReplyId,
                        ReplyText = entity.ReplyText,
                        ReplyAuthorId = entity.ReplyAuthorId
                    };
            }
        }

        // U
        public bool UpdateReply(ReplyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.ReplyId == model.ReplyId && e.ReplyAuthorId == _userId);

                entity.ReplyText = model.ReplyText;
                entity.ReplyAuthorId = model.ReplyAuthorId;

                return ctx.SaveChanges() == 1;
            }
        }

        // D
        public bool DeleteReply(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.ReplyId == Id && e.ReplyAuthorId == _userId);

                ctx.Replies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

