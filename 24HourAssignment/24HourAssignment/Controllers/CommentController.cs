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
    public class CommentController : ApiController
    {
        // Helper Method
        private CommentService CreateCommentService()
        {

            var Id = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(Id);
            return commentService;

        }

        // C - PostPost
        public IHttpActionResult Post(CommentCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.CreateComment(note))
                return InternalServerError();

            return Ok();
        }

        // R - GetAllPosts
        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var posts = commentService.GetReplies();

            return Ok(posts);
        }

        // R - GetPostById

        public IHttpActionResult Get(int id)
        {
            CommentService commentService = CreateCommentService();
            var post = commentService.GetCommentById(id);
            return Ok(post);
        }

        // U - PutPost
        public IHttpActionResult Put(CommentEdit reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.UpdateComment(reply))
                return InternalServerError();

            return Ok();
        }

        // D - DeletePost
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCommentService();

            if (!service.DeleteComment(id))
                return InternalServerError();

            return Ok();
        }
    }
}
