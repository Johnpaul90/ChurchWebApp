using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChurchWebApp.Models
{
    public class ChurchClaims
    {
        public Guid ID { get; set; }
        public Guid UserId { get; set; }
        public Guid MinistryId { get; set; }
        public Ministry Ministry { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}