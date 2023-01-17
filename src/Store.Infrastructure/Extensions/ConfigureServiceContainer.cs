using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.Interfaces;
using Store.Application.Services;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Contexts;
using Store.Infrastructure.Data.Repositories;
using Store.Infrastructure.Identity;
using Store.Infrastructure.Middlewares;

namespace Store.Infrastructure.Extensions
{
    public static class ConfigureServiceContainer
    {
        public static void ConfigureDbContext(this IServiceCollection services,
             IConfiguration configuration)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationConnection")));

            services.AddScoped<ITokenClaimsService, TokenClaimsService>();
        }

        public static void ConfigureDependencyContainer(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();
            services.AddScoped<IBasketItemRepository, BasketItemRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IFavoriteRepository, FavoriteRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IFavoriteService, FavoriteService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IOrderService, OrderService>();
        }

        public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
