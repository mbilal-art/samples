using Application.Commands.Account;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MapperProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<UserAccountCreateCommand, User>()
                .ForMember(x => x.IdImage, m => m.Ignore())
                .ForMember(x => x.IdImageContentType, m => m.Ignore())
                .ForMember(x => x.IdImageFileName, m => m.Ignore())
                .ForMember(x => x.ProfilePicture, m => m.Ignore())
                .ForMember(x => x.ProfilePictureContentType, m => m.Ignore())
                .ForMember(x => x.ProfilePictureFileName, m => m.Ignore())
                .ForMember(x => x.SelfiePicture, m => m.Ignore())
                .ForMember(x => x.SelfiePictureContentType, m => m.Ignore())
                .ForMember(x => x.SelfiePictureFileName, m => m.Ignore());

            CreateMap<User, UserAccountCreateCommand>()
                .ForMember(x => x.IdImage, m => m.Ignore())
                .ForMember(x => x.ProfilePicture, m => m.Ignore())
                .ForMember(x => x.SelfiePicture, m => m.Ignore());
        }
    }
}
