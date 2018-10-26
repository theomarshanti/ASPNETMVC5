using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Vidly.Models;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if(customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            } else if (customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate is required");
            } else
            {
                var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
                return (age >= 18)
                    ? ValidationResult.Success
                    : new ValidationResult("Customer should be at least 18 years old");
            }
        }
    }
}