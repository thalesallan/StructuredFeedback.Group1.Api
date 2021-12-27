using StructuredFeedback.Group1.Borders.Dto.Request;
using StructuredFeedback.Group1.Borders.Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StructuredFeedback.Group1.Borders.UseCases
{
    public interface IRelatorioUseCase
    {
        Task<IList<BuscarRelatorioResponse>> Execute(RelatorioRequest request);
    }
}
