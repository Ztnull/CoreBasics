using System;
using System.ComponentModel.DataAnnotations;

namespace JWTAuthSample.Models
{
    public class LoginViewModel
    {
       [Required]
        public string User { get; set; }

        [Required]
        public string Password { get; set; }


    }
}