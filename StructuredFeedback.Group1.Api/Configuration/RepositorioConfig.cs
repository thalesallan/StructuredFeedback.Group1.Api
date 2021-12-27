using Microsoft.Extensions.DependencyInjection;
using StructuredFeedback.Group1.Borders.Repositories;
using StructuredFeedback.Group1.Repositories;

namespace StructuredFeedback.Group1.Api.Configuration
{
    public static class RepositorioConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IFeedbackRepositorio, FeedbackRepositorio>();
        }
    }
}
