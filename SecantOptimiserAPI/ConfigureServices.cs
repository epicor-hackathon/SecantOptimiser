using SecantOptimiserAPI.Models;
using SecantOptimiserAPI.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddSecantGroup(this IServiceCollection services)
        {
            services.AddScoped<ISecantSection, SecantSectionService>();
            services.AddScoped<ISecFileService, SecFileService>();
            //services.AddScoped<IOptimiserRequestService, OptimiserRequestService>();
            services.AddScoped<ICuttingDataRequestService, CuttingDataRequestService>();
            services.AddScoped<IStockDataRequestService, StockDataRequestService>();
            services.AddScoped<ISecantOptimiserService, SecantOptimiserService>();
            services.AddScoped<IJobDataRequestService, JobDataRequestService>();
      
            return services;
        }
    }
}
