using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.DomainModels;

namespace DataLayer.Interfaces {
    public interface IBlogService {
        ICollection<Blog> GetAll();
        void Add(Blog blog);

        void AddPost(Post post);
        ICollection<Post> GetPosts(int blogId);
    }
}
