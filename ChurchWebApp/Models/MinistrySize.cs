using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChurchWebApp.Models
{
    public class MinistrySize
    {
        public Guid ID { get; set; }

        [Display(Name ="Church Size From")]
        public int from { get; set; }

        [Display(Name = "Church Size To")]
        public int to { get; set; }

    }
}