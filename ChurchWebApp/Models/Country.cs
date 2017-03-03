using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChurchWebApp.Models
{
    public class Country
    {
        public Guid ID { get; set; }

        [Display(Name ="Country")]
        public string Name { get; set; }
        public string Flag { get; set; }

    }
}