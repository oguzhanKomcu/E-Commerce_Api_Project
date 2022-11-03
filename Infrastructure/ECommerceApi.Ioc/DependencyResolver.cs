using Autofac;
using AutoMapper;
using ECommerceApi.Application.Mapper;
using ECommerceApi.Application.RepositoriesInterface;
using ECommerceApi.Persistence.RepositoriesConcretes;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Ioc
{
    public class DependencyResolver : Module
    {

        protected override void Load(ContainerBuilder builder)
        {


            builder.RegisterType<AppUserRepository>().As<IAppUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OrderDetailRepository>().As<IOrderDetailRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductCommentRepository>().As<IProductCommentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductRatingRepository>().As<IProductRatingRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
           // builder.RegisterType<ConfigurationBuilder>().As<IConfiguration>().InstancePerLifetimeScope();




            builder.Register(context => new MapperConfiguration(cfg =>
            {

                cfg.AddProfile<Mapping>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();


            base.Load(builder);
        }




    }
}
