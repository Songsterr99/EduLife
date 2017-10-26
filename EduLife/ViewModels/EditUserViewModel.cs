using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EduLife.ViewModels
{
    public class EditUserViewModel
    {
        public string UserId { get; set; }

        //[Required]
        //[Display(Name = "E-mail")]
        public string UserEmail { get; set; }

        public List<IdentityRole> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }

        public EditUserViewModel()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }
    }
}
