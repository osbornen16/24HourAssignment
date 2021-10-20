using _24Hour.Models;
using _24Hour.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24HourAssignment.Controllers
{
    [Authorize]
    public class ReplyController : ApiController
    {

        // Helper Method
        private ReplyService CreateReplyService()
        {

            var Id = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(Id);
            return replyService;

        }

        // C - PostReply

        public IHttpActionResult Post(ReplyCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReplyService();

            if (!service.CreateReply(note))
                return InternalServerError();

            return Ok();
        }

        // R - GetReplyByCommentId

      /*  public IHttpActionResult Get()
        {
            ReplyService replyService = CreateReplyService();
            var posts = replyService.GetReplyByCommentId(id);

            return Ok(posts);
        }*/

        // R - GetReplyByAuthorId

        public IHttpActionResult Get(int id)
        {
            ReplyService replyService = CreateReplyService();
            var post = replyService.GetReplyByAuthorId(id);
            return Ok(post);
        }

        // R - 

        // U - PutPost
        public IHttpActionResult Put(ReplyEdit reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReplyService();

            if (!service.UpdateReply(reply))
                return InternalServerError();

            return Ok();
        }

        // D - DeletePost
        public IHttpActionResult Delete(int id)
        {
            var service = CreateReplyService();

            if (!service.DeleteReply(id))
                return InternalServerError();

            return Ok();
        }
    }
}
