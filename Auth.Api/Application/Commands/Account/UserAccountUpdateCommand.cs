using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Account
{
    public class UserAccountUpdateCommand : IRequest<UserAccountUpdateCommandResult>
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
        public IFormFile IdImage { get; set; }
        public IFormFile ProfilePicture { get; set; }
        public IFormFile SelfiePicture { get; set; }
        public IFormFile UtilityBillPicture { get; set; }
        public string? FacebookSocialLink { get; set; }
        public string? LinkedInSocialLink { get; set; }
        public string? TwitterSocialLink { get; set; }
        public string? InstagramSocialLink { get; set; }
        public string? YoutubeSocialLink { get; set; }
    }
}
