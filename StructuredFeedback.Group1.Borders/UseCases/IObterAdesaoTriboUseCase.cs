using StructuredFeedback.Group1.Borders.Dto;
using StructuredFeedback.Group1.Borders.Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StructuredFeedback.Group1.Borders.UseCases
{
    public interface IObterAdesaoTriboUseCase
    {
        Task<List<AdesaoTriboResponse>> Execute();
    }
}
