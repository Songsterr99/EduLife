using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduLife.Models.InstructionViewModel
{
    public class InstructionViewModel
    {
        [Required]
        public string InstructionID { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
