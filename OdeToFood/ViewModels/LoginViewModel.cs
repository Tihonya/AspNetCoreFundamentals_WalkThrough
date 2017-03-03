using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(256)]
        [Display(Name = "Name")]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
