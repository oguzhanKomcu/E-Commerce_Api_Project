using ECommerceApi.Application.RepositoriesInterface;
using ECommerceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Persistence.RepositoriesConcretes
{
    public class OrderDetailRepository : BaseRepository<Order_Detail>, IOrderDetailRepository
    {
        public OrderDetailRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
