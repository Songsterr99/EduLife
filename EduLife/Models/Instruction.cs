using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduLife.Models
{
    public class Instruction
    {
        public String InstructionID { get; set; }
        public String Content { get; set; }
        public DateTime CreateTime { get; set; }
        public int? Mark;


        public string ApplicationUserID { get; set; }
        [ForeignKey("ApplicationUserID")]
        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<PostTag> PostTags { get; set; }
    }
}
