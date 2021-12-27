using Microsoft.Extensions.DependencyInjection;
using StructuredFeedback.Group1.Repositories.GoogleCloud;

namespace StructuredFeedback.Group1.Api.Configuration
{
    public static class BigQueryConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IBQ, BQ>();
        }
    }
}
