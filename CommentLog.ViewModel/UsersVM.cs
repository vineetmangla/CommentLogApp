﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentLog.ViewModel
{
    public class UsersVM
    {        
        public int Id { get; set; }

        [Required(ErrorMessage = "Email address is required ")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Name { get; set; }
        
    }
}
