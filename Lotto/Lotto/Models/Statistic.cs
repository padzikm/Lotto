using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lotto.Models
{
    public class Statistic
    {
        [HiddenInput(DisplayValue = false)]
        public int StatisticID { get; set; }
        
        public List<LuckyNumber> LuckyNumbers { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        public Statistic()
        {
            LuckyNumbers = new List<LuckyNumber>(6);

            for (int i = 0; i < 6; ++i)
                LuckyNumbers.Add(new LuckyNumber());            
        }
    }
}