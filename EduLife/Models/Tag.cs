using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduLife.Models
{
    public class Tag
    {
        public string TagID { get; set; }

        public ICollection<PostTag> PostTags;
    }
}
