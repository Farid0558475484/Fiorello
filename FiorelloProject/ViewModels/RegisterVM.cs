using System;
using System.ComponentModel.DataAnnotations;

namespace FiorelloProject.ViewModels
{
	public class RegisterVM
    {

        [Required ,StringLength(100)]
		public string Fulname { get; set; }

        [Required, StringLength(100)]
        public string Username { get; set; }

        [Required, EmailAddress,DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password),Compare(nameof(Password))]
        public string RePassword { get; set; }


    }
}

