using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Interfaces;

namespace DataLayer.Controllers {
    [Route("api/[controller]")]
    public class PostsController : Controller {
        private readonly IBlogService blogService;

        public PostsController(IBlogService blogService) {
            this.blogService = blogService;
        }

        [HttpGet("{blogId}")]
        public IActionResult GetPosts(int blogId) {
            try {
                var results = blogService.GetPosts(blogId);
                return Ok(results);
            } catch (Exception ex) {
                return StatusCode(500, ex.Simplify($"Failed to retrieve all the posts for the blog '{blogId}'"));
            }
        }
    }
}
