using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PersonCatalog.Web.CustomValidations
{
    public class ValidationBase : ValidationAttribute
    {
        protected bool RegexMatcher(string name, string regex)
        {
            var count = Regex.Matches(name, regex).Count;
            char[] symbols = name.ToCharArray();
            if (symbols.Length != count)
            {
                return true;
            }
            return false;
        }
    }
}
