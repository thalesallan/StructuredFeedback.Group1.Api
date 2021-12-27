using StructuredFeedback.Group1.Borders.Dto;
using StructuredFeedback.Group1.Borders.Dto.Request;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace StructuredFeedback.Group1.Borders.Repositories
{
    public interface IFeedbackRepositorio 
    {
        Task<List<TribosDTO>> ObterListaTribos();
        Task<List<RelatorioDTO>> ObterRelatorio(RelatorioRequest request);
        Task<List<TotalTriboDTO>> ObterAdesao();
        Task<List<ConversaoTrajetoriaDTO>> ObterConversaoTrajetoria();
        Task<List<TrajetoriaDesejadaDTO>> ObterTrajetoriaDesejada(string tribo);
        Task<List<ObterTrajetoriasDTO>> ObterTrajetorias();
    }
}
