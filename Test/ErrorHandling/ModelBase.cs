using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test
{
    public abstract class ModelBase
    {
        [NotMapped]
        [JsonIgnore]
        public List<string> Errors = new List<string>();
        public abstract bool IsValid();
    }
}
