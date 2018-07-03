using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly3rdTime.ViewModels;

namespace Vidly3rdTime.Models
{
    public class Min18YearsOldIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (CustomerFormViewModel)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == null || 
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return age >= 18
                ? ValidationResult.Success 
                : new ValidationResult("Customer has to be at least 18 years old to go on a membership.");
        }
    }
}