using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lotto.Models
{
    public class LuckyNumber
    {
        [HiddenInput(DisplayValue = false)]
        public int LuckyNumberID { get; set; }

        [Required(ErrorMessage = "Number is required.")]
        [Range(1, 50)]
        public int? Value { get; set; }
    }
}