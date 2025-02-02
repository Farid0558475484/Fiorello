﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FiorelloProject.ViewModels
{
	public class LoginVM
	{
        [Required, StringLength(100)]
        public string UsernameOrEmail { get; set; }



        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}

