using AutoMapper;
using ECommerceApi.Application.CQRS.AppUser.Queries.Request;
using ECommerceApi.Application.CQRS.AppUser.Queries.Response;
using ECommerceApi.Application.RepositoriesInterface;
using ECommerceApi.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.AppUser.Handlers.Queries
{

    public class UserGetByIdQueryHandler : IRequestHandler<UserGetByIdQueryRequest, UserGetByIdQueryResponse>
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ECommerceApi.Domain.Entities.AppUser> _userManager;
        private readonly SignInManager<Domain.Entities.AppUser> _signInManager;
        public UserGetByIdQueryHandler(IAppUserRepository appUserRepository, IMapper mapper, UserManager<ECommerceApi.Domain.Entities.AppUser> userManager, SignInManager<Domain.Entities.AppUser> signInManager)
        {
            _appUserRepository = appUserRepository;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<UserGetByIdQueryResponse> Handle(UserGetByIdQueryRequest request, CancellationToken cancellationToken)
        {

            UserGetByIdQueryResponse user = await _appUserRepository.GetFilteredFirstOrDefault(
                          selector: x => new UserGetByIdQueryResponse
                          {
                              Id = x.Id,
                              UserName = x.UserName,
                              Email = x.Email,
                              Imagepath = x.ImagePath,

                          },
                          expression: x => x.Id == request.UserId &&
                                          x.Status != Status.Passive);

           

            return user;

 

        }
    }
}
