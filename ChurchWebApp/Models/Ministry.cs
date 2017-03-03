using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChurchWebApp.Models
{
    public class Ministry
    {
        public Guid ID { get; set; }

        [Display(Name = "Ministry Category")]
        public Guid MinistryCategoryId { get; set; }

        [Display(Name = "Ministry Size")]
        public Guid MinistrySizeId { get; set; }

        [Display(Name = "Denomination")]
        public Guid DenominationId { get; set; }

        [Display(Name = "Country")]
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        public Denomination Denomination { get; set; }
        public MinistrySize AvgChurchSize { get; set; }
        public MinistryCategory MinistryCategory { get; set; }
        public MinistryCategory ChurchType { get; set; }
        public List<Vibe> MinistryVibes { get; set; }
        public ICollection<Pastor> Pastors { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Display(Name = "Phone No. 1")]
        public string PhoneNumber1 { get; set; }

        [Display(Name = "Phone No. 2")]
        public string PhoneNumber2 { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Town { get; set; }
        public string State { get; set; }

        [StringLength(160)]
        public string Vision { get; set; }

        [StringLength(160)]
        public string Mission { get; set; }

        [StringLength(160)]
        public string About { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }

        public string LogoBlob { get; set; }

        [Display(Name = "FaceBook Url")]
        public string FacebookUrl { get; set; }

        [Display(Name = "Twitter Url")]
        public string TwitterUrl { get; set; }

        [Display(Name = "Youtube Url")]
        public string YoutubeUrl { get; set; }

        [Display(Name = "Instagram Url")]
        public string InstagramUrl { get; set; }
        public string Source { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date Entered")]
        public DateTime DateEntered { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date Claimed")]
        public DateTime DateClaimed { get; set; }

        [Display(Name = "Church is Verified ?")]
        public bool IsVerified { get; set; }

        [Display(Name = "Church  is Claimed ?")]
        public bool IsClaimed { get; set; }

    }
}