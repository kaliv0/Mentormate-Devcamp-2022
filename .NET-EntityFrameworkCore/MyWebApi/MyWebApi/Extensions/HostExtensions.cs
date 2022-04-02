namespace MyWebApi.Web.Extensions
{
    using MyWebApi.Data;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System.Threading.Tasks;

    public static class HostExtensions
    {
        public static async Task InitializeDbContext(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var databaseInitializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();

                await databaseInitializer.InitializeAsync();
            }
        }
    }
}
