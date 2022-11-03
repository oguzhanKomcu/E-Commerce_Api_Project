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

    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommandRequest, UserRegisterCommandResponse>
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ECommerceApi.Domain.Entities.AppUser> _userManager;
        private readonly SignInManager<Domain.Entities.AppUser> _signInManager;
        public UserRegisterCommandHandler(IAppUserRepository appUserRepository, IMapper mapper, UserManager<ECommerceApi.Domain.Entities.AppUser> userManager, SignInManager<Domain.Entities.AppUser> signInManager)
        {
            _appUserRepository = appUserRepository;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<UserRegisterCommandResponse> Handle(UserRegisterCommandRequest request, CancellationToken cancellationToken)
        {

            var user = _mapper.Map<ECommerceApi.Domain.Entities.AppUser>(request);

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return new UserRegisterCommandResponse
            {
                IsSuccess = true,
                UserId = user.Id,
            };
        }
    }



}
