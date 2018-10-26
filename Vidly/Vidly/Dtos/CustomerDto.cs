using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        //By default, EntityFramework extrapolates some info about our columns
        // in our tables. We can override those defaults & provide additional 
        // info with the use of Data Annotations as follows: 
        // With Required, our column Name will no longer be nullable.
        // With StringLength, we specify the max # of characters (255)
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        
        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //////[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}