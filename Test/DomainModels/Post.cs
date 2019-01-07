using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.DomainModels {
    public class Post: ModelBase {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public override bool IsValid() {
            if (BlogId < 0 && (Blog == null || !Blog.IsValid())) Errors.Add("No blog associated to the post.");
            if (Title.IsNullOrEmpty()) Errors.Add("Post has no title.");
            if (Content.IsNullOrEmpty()) Errors.Add("Post has no content.");

            return Errors.Count == 0;
        }
    }
}
