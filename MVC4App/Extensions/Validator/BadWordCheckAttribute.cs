using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC4App.Extensions.Validator
{
    [AttributeUsage(AttributeTargets.Property)]
    public class BadWordCheckAttribute : ValidationAttribute
    {
        private List<String> _badWords = new List<string>
        {
            "ABC",
            "123",
            "GGG"
        };

        public override bool IsValid(object value)
        {
            string word = value as String;
            if (word != null)
            {
                return !_badWords.Contains(word, StringComparer.OrdinalIgnoreCase);
            }
            return true;
        }
    }
}