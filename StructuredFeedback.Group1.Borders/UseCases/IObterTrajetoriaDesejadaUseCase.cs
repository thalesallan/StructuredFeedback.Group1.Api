using StructuredFeedback.Group1.Borders.Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StructuredFeedback.Group1.Borders.UseCases
{
    public interface IObterTrajetoriaDesejadaUseCase
    {
        Task<IList<TrajetoriaDesejadaResponse>> Execute(string tribo);
    }
}
