using StructuredFeedback.Group1.Borders.Dto.Response;
using System.Threading.Tasks;

namespace StructuredFeedback.Group1.Borders.UseCases
{
    public interface IObterConversaoTrajetoriaUseCase
    {
        Task<ConversaoTrajetoriaResponse> Execute();
    }
}
