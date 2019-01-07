using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.DomainModels {
    public class Blog : ModelBase {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }

        public override bool IsValid() {
            if (this.Url.IsNullOrEmpty()) this.Errors.Add("No URL specified.");

            return this.Errors.Count == 0;
        }
    }
}
