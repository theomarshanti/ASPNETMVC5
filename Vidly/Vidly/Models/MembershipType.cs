using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
 
    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        //Rather than check if the Id is equal to random #s set somewhere else,
        // we can specify the #s here as well. So, in the Min18YearsIfAMember
        // we don't need to deal with magic #s (that other devs have no idea where
        // to find), instead we can more clearly communicate.
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
        public static readonly byte Monthly = 2;
        public static readonly byte Quarterly = 3;
        public static readonly byte Annualy = 4;
        //Could alternatively use an enum, but would then need to cast it to (byte)

    }
}