using System;
using System.ComponentModel.DataAnnotations;

namespace MvcAsyncDemo.CustomValidation
{
    public class NumericOnlyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            long number;

            return long.TryParse(value.ToString(), out number);
        }

        public override string FormatErrorMessage(string name)
        {
            return "ID must contain only numeric values";
        }
    }
}