using Application.Commands.Account;
using AutoMapper;
using Domain.Aggregates;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CommandHandlers.Account
{
    public class UserAccountUpdateCommandHandler : IRequestHandler<UserAccountUpdateCommand, UserAccountUpdateCommandResult>
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IMapper _mapper;
        public UserAccountUpdateCommandHandler(IUserAccountRepository userAccountRepository, IMapper mapper)
        {
            _userAccountRepository = userAccountRepository;
            _mapper = mapper;
        }
        public async Task<UserAccountUpdateCommandResult> Handle(UserAccountUpdateCommand command, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<UserAccountUpdateCommand, User>(command);

            user.IdImage = CommandHelper.ConvertFormFileIntoBytes(command.IdImage);
            user.IdImageContentType = command.IdImage.ContentType;
            user.IdImageFileName = command.IdImage.FileName;

            user.ProfilePicture = CommandHelper.ConvertFormFileIntoBytes(command.ProfilePicture);
            user.ProfilePictureContentType = command.ProfilePicture.ContentType;
            user.ProfilePictureFileName = command.ProfilePicture.FileName;

            user.SelfiePicture = CommandHelper.ConvertFormFileIntoBytes(command.SelfiePicture);
            user.SelfiePictureContentType = command.SelfiePicture.ContentType;
            user.SelfiePictureFileName = command.SelfiePicture.FileName;

            await _userAccountRepository.Update(user);
            return new UserAccountUpdateCommandResult()
            {
                IsSucceed = true
            };
        }
    }
}
