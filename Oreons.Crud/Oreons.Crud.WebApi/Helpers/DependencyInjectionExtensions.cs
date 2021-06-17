using Domain.Commands.Handlers;
using Domain.Repositories;
using Infra.Repositories;
using Infra.Transiction;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Helpers
{
    public static class DependencyInjectionExtensions
    {
        public static void AddServiceInjections(this IServiceCollection services)
        {
            services.AddTransient<IUow, Uow>();
        }
        public static void AddRepositoryInjections(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ISubCategoryRepository, SubCategoryRepository>();
        }

        public static void AddCommandHandlerInjections(this IServiceCollection service)
        {
            service.AddTransient<AddUpdateCategoryCommandHandler, AddUpdateCategoryCommandHandler>();
            service.AddTransient<RemoveCategoryCommandHandler, RemoveCategoryCommandHandler>();
            service.AddTransient<AddUpdateSubCategoryCommandHandler, AddUpdateSubCategoryCommandHandler>();
            service.AddTransient<RemoveSubCategoryCommandHandler, RemoveSubCategoryCommandHandler>();
            service.AddTransient<AddUpdateProductCommandHandler, AddUpdateProductCommandHandler>();
            service.AddTransient<RemoveProductCommandHandler, RemoveProductCommandHandler>();

        }
    }
}
