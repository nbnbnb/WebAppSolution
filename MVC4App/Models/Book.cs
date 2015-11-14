using MVC4App.Extensions.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC4App.Models
{
    public class Book
    {
        [Required]
        [StringLength(10)]
        [BadWordCheck]
        [Display(Name = "书名")]
        public string Title { get; set; }

        [Required]
        [Range(0.01, 100, ErrorMessage = "Price must be between 0.01 and 100.00")]
        [Display(Name = "价格")]
        public decimal Price { get; set; }

        [Display(Name = "出生日期")]
        [AgeRange(10, 30)]
        [Required]
        public DateTime BrithDate { get; set; }
    }
}