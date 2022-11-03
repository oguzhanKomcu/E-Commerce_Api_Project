using AutoMapper;
using ECommerceApi.Application.CQRS.AppUser.Commands.Request;
using ECommerceApi.Application.CQRS.AppUser.Commands.Response;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.AppUser.Handlers.Commands
{

    public class UserLogOutCommandHandler : IRequestHandler<UserLogOutCommandRequest, UserLogOutCommandResponse>
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly UserManager<ECommerceApi.Domain.Entities.AppUser> _userManager;
        private readonly SignInManager<Domain.Entities.AppUser> _signInManager;
        public UserLogOutCommandHandler(IAppUserRepository appUserRepository,  UserManager<ECommerceApi.Domain.Entities.AppUser> userManager, SignInManager<Domain.Entities.AppUser> signInManager)
        {
            _appUserRepository = appUserRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<UserLogOutCommandResponse> Handle(UserLogOutCommandRequest request, CancellationToken cancellationToken)
        {

            await _signInManager.SignOutAsync();

            return new UserLogOutCommandResponse
            {
                IsSuccess = true,
            };
        }
    }
}
