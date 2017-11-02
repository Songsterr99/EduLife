using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduLife.Models
{
    public class PostTag
    {
        public string PostTagID { get; set; }

        public string InstructionID { get; set; }
        [ForeignKey("InstructionID")]
        public Instruction Instruction { get; set; }

        public string TagID { get; set; }
        [ForeignKey("InstructionID")]
        public Tag Tag { get; set; }
    }
}
