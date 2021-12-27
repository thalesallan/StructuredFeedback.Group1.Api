using StructuredFeedback.Group1.Borders.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuredFeedback.Group1.Borders.UseCases
{
    public interface IObterTribosUseCase
    {
        Task<List<ListaTribosResponse>> Execute();
    }
}
