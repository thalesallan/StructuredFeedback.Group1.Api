using System.Threading.Tasks;

namespace StructuredFeedback.Group1.Borders.UseCases
{
    public interface IUseCase<TRequest, TResponse>
    {
        Task<TResponse> Execute(TRequest request);
    }
}
