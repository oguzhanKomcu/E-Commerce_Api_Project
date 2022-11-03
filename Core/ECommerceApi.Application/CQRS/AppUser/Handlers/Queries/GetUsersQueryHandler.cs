using AutoMapper;
using ECommerceApi.Application.CQRS.AppUser.Queries.Request;
using ECommerceApi.Application.CQRS.AppUser.Queries.Response;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.AppUser.Handlers.Queries
{

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQueryRequest, List<GetUsersQueryResponse>>
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ECommerceApi.Domain.Entities.AppUser> _userManager;
        private readonly SignInManager<Domain.Entities.AppUser> _signInManager;
        public GetUsersQueryHandler(IAppUserRepository appUserRepository, IMapper mapper, UserManager<ECommerceApi.Domain.Entities.AppUser> userManager, SignInManager<Domain.Entities.AppUser> signInManager)
        {
            _appUserRepository = appUserRepository;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<List<GetUsersQueryResponse>> Handle(GetUsersQueryRequest request, CancellationToken cancellationToken)
        {

            var users = await _appUserRepository.GetFilteredList(
               selector: x => new GetUsersQueryResponse
               {
                   UserId = x.Id,
                   UserName = x.UserName,
                   First_Name = x.First_Name,
                   ImagePath = x.ImagePath,
                   Last_Name = x.Last_Name
               },
               expression: x => x.Status != Domain.Enums.Status.Passive,
               orderBy: x => x.OrderBy(x => x.UserName));

            return users;



        }
    }


}
