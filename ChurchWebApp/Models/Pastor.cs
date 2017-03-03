using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChurchWebApp.Models
{
    public class Pastor
    {
        public Guid iD { get; set; }
        public Guid MinistryId { get; set; }
        public Ministry Ministry { get; set; }

        [Display(Name ="Full Name")]
        public string Name { get; set; }

        [Display(Name = "Phone No. 1")]
        public string PhoneNumber1 { get; set; }

        [Display(Name = "Phone No. 2")]
        public string PhoneNumber2 { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Qualification { get; set; }
        public string Biography { get; set; }

        [Display(Name = "Pastor's Picture")]
        public string Picture { get; set; }

        [Display(Name = "Pastor's Picture Blob")]
        public string PictureBlob { get; set; }

        [Display(Name = "Pastor and Wife Picture")]
        public string PictureWithWife { get; set; }

        [Display(Name = "Pastor and Wife Picture Blob")]
        public string PictureWithWifeBlob { get; set; }

        [Display(Name = "FaceBook Handle")]
        public string Facebook { get; set; }

        [Display(Name = "Twitter Handle")]
        public string Twitter { get; set; }

        [Display(Name = "Youtube Handle")]
        public string Youtube { get; set; }

        [Display(Name = "Instagram Handle")]
        public string Instagram { get; set; }

        [Display(Name = "Video Introduction")]
        public string VideoIntroduction { get; set; }
        public bool IsMainPastor { get; set; }

    }
}