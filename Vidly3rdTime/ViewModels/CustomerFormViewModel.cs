using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly3rdTime.Models;

namespace Vidly3rdTime.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Membership type is required.")]
        public byte? MembershipTypeId { get; set; }
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            MembershipTypeId = customer.MembershipTypeId;
            Birthdate = customer.Birthdate;
            IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
        }

        public Customer CustomerBasedOnViewModel
        {
            get
            {
                return new Customer ()
                {
                    Name = this.Name,
                    MembershipTypeId = this.MembershipTypeId.Value,
                    Birthdate = this.Birthdate,
                    IsSubscribedToNewsletter = this.IsSubscribedToNewsletter
                };
            }
        }

        public string Title
        {
            get
            {
                if ( Id != 0)
                    return "Edit Customer";

                return "New Customer";
            }
        }
    }
}