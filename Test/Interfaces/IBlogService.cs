using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.DomainModels;

namespace Test.Interfaces
{
    public interface IBlogService
    {
        ICollection<Blog> GetAll();
        void Add(Blog blog);

        void AddPost(Post post);
        ICollection<Post> GetPosts(int blogId);
    }
}
