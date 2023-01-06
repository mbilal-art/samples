using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : Entity
    {
        public string FullName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LocationOfElection { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Nationality { get; set; }
        public bool OtherNationalities { get; set; }
        public bool TemOfService { get; set; }

        public byte[] IdImage { get; set; }
        public string IdImageContentType { get; set; }
        public string IdImageFileName { get; set; }

        public byte[] ProfilePicture { get; set; }
        public string ProfilePictureContentType { get; set; }
        public string ProfilePictureFileName { get; set; }

        public byte[] SelfiePicture { get; set; }
        public string SelfiePictureContentType { get; set; }
        public string SelfiePictureFileName { get; set; }

        public byte[] UtilityBillPicture { get; set; }
        public string UtilityBillPictureContentType { get; set; }
        public string UtilityBillPictureFileName { get; set; }

        public string? FacebookSocialLink { get; set; }
        public string? LinkedInSocialLink { get; set; }
        public string? TwitterSocialLink { get; set; }
        public string? InstagramSocialLink { get; set; }
        public string? YoutubeSocialLink { get; set; }
    }
}
