using Library.Business;
using Library.Domain;
using Library.Infra.Repository;
using Library.Infra.Repository.DbConfiguration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infra.CrossCutting.Extension
{
    public static class BootStrapper
    {
        public static void BootStrapperStart(this IServiceCollection services)
        {
            DIBusiness(services);
            DIRepository(services);
            services.BuildServiceProvider();
        }

        public static void DIBusiness(IServiceCollection services)
        {
            services.AddTransient<IBusiness<Author>, AuthorBusiness>();
            services.AddTransient<IBusiness<Book>, BookBusiness>();
            services.AddTransient<IBusiness<Publisher>, PublisherBusiness>();
            services.AddTransient<IBusiness<Rent>, RentBusiness>();
            services.AddTransient<IBusiness<Reserve>, ReserveBusiness>();
            services.AddTransient<IBusiness<User>, UserBusiness>();
        }

        public static void DIRepository(IServiceCollection services)
        {
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IPublisherRepository, PublisherRepository>();
            services.AddTransient<IRentRepository, RentRepository>();
            services.AddTransient<IReserveRepository, ReserveRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IDatabaseFactory, DatabaseFactory>();
        }
    }
}