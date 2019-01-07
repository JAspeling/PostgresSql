using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.DomainModels;
using Test.Interfaces;

namespace Test.Services {
    public class BlogService : IBlogService {
        private readonly BloggingContext context;

        public BlogService(BloggingContext context) {
            this.context = context;
        }

        public void Add(Blog blog) {
            if (blog.IsValid()) {
                this.context.Add(blog);

                context.SaveChanges();
            } else {
                throw new Exception(string.Join(Environment.NewLine, blog.Errors));
            }
        }

        public void AddPost(Post post) {
            if (post.IsValid()) {
                var blog = this.context.Blogs
                    .Include(b => b.Posts)
                    .FirstOrDefault(b => b.BlogId == post.BlogId);

                if (blog == null) throw new Exception($"Blog with id '{post.BlogId}' does not exist");
                if (blog.Posts == null) blog.Posts = new List<Post>() { post };

                context.SaveChanges();
            } else {
                throw new Exception(string.Join(Environment.NewLine, post.Errors));
            }
        }

        public ICollection<Blog> GetAll() {
            var blogs = this.context.Blogs.Include(b => b.Posts).ToList();
            return blogs;
        }

        public ICollection<Post> GetPosts(int blogId) {
            var blog = this.context.Blogs
                .Include(b => b.Posts)
                .FirstOrDefault(b => b.BlogId == blogId);

            return blog?.Posts;
        }
    }
}
