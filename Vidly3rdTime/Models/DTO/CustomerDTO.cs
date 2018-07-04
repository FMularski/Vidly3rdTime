using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly3rdTime.Models.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Min18YearsOldIfAMember]
        public DateTime? Birthdate { get; set; }

        public MembershipTypeDTO MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}