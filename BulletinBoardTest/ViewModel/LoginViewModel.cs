using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BulletinBoardTest.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please Input User ID")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Please Input User Password")]
        public string UserPassword { get; set; }
    }
}
