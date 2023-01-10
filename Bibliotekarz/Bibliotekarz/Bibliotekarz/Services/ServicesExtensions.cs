namespace Bibliotekarz.Services
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddClientServices(this IServiceCollection services) 
        {
            services.AddScoped<IBookService, BookService>();
            //TODO: Rejestruj tutaj wszystkie serwisy

            return services;
        }
    }
}
