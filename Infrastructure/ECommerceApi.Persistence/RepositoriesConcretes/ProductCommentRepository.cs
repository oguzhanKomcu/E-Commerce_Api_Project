using ECommerceApi.Application.RepositoriesInterface;
using ECommerceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Persistence.RepositoriesConcretes
{
    public class ProductCommentRepository : BaseRepository<Product_Comment>, IProductCommentRepository
    {
        public ProductCommentRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
