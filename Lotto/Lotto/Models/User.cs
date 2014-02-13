using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lotto.Models
{
    public class User
    {
        
        [HiddenInput(DisplayValue = false)]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool IsActive { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool IsAdmin { get; set; }

        public User()
        {
            IsActive = false;
            IsAdmin = false;
        }
    }
}