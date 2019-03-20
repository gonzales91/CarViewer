using System;
using System.ComponentModel.DataAnnotations;

namespace CarsViewer.Models
{
    public class UpperCase : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {                
                validationContext.ObjectType.GetProperty(validationContext.MemberName).SetValue(validationContext.ObjectInstance, value.ToString().ToUpper(), null);
            }
            catch
            {
            }

            return null;
        }
    }
}
