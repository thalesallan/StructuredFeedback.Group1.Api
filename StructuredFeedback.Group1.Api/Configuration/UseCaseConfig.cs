using Microsoft.Extensions.DependencyInjection;
using StructuredFeedback.Group1.Borders.UseCases;
using StructuredFeedback.Group1.UseCases.UseCases;

namespace StructuredFeedback.Group1.Api.Configuration
{
    public static class UseCaseConfig
    {
        public static void ConfigureServices(IServiceCollection service)
        {
            service.AddScoped<IRelatorioUseCase, RelatorioUseCase>();
            service.AddScoped<IObterAdesaoTriboUseCase, ObterAdesaoTriboUseCase>();
            service.AddScoped<IObterConversaoTrajetoriaUseCase, ConversaoTrajetoriaUseCase>();
            service.AddScoped<IObterTrajetoriaDesejadaUseCase, ObterTrajetoriaDesejadaUseCase>();
            service.AddScoped<IObterTrajetoriasGeraisUseCase, ObterTrajetoriasGeraisUseCase>();
            service.AddScoped<IObterTribosUseCase, ObterTribosUseCase>();
        }
    }
}
