﻿using System.ComponentModel.DataAnnotations;

namespace DiscGolfWeb.Model
{
    public class Login
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
