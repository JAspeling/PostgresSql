using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.DomainModels;
using Test.Interfaces;

namespace Test.Controllers {
    [Route("api/[controller]")]
    public class BlogController : Controller {
        private readonly IBlogService blogService;

        public BlogController(IBlogService blogService) {
            this.blogService = blogService;
        }

        [HttpGet]
        public IActionResult GetAll() {
            try {
                var result = blogService.GetAll();
                return Ok(result);
            } catch (Exception ex) {
                return StatusCode(500, ex.Simplify("Failed to get all the Blogs"));
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody]Blog blog) {
            try {
                blogService.Add(blog);
                return Ok();
            } catch (Exception ex) {
                return StatusCode(500, ex.Simplify("Failed to add a blog"));
            }
        }

        [HttpPost("AddPost")]
        public IActionResult AddPost([FromBody]Post post) {
            try {
                blogService.AddPost(post);
                return Ok();
            } catch (Exception ex) {
                return StatusCode(500, ex.Simplify("Failed to add a blog"));
            }
        }
    }
}
