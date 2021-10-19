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
    public class PostController : ApiController
    {

        // Helper Method
        private PostService CreatePostService()
        {
           
            var Id = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(Id);
            return postService;
           
        }

        // C - PostPost
        public IHttpActionResult Post(PostCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.CreatePost(note))
                return InternalServerError();

            return Ok();
        }

        // R - GetAllPosts
        public IHttpActionResult Get()
        {
            PostService postService = CreatePostService();
            var posts = postService.GetPosts();

            return Ok(posts);
        }

        // R - GetPostById

        public IHttpActionResult Get(int id)
        {
            PostService postService = CreatePostService();
            var post = postService.GetPostById(id);
            return Ok(post);
        }

        // U - PutPost
        public IHttpActionResult Put(PostEdit post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.UpdatePost(post))
                return InternalServerError();

            return Ok();
        }

        // D - DeletePost
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePostService();

            if (!service.DeleteNote(id))
                return InternalServerError();

            return Ok();
        }
    }
}
