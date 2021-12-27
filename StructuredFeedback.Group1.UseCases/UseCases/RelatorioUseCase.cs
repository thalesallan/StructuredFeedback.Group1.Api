using StructuredFeedback.Group1.Borders.Dto;
using StructuredFeedback.Group1.Borders.Dto.Request;
using StructuredFeedback.Group1.Borders.Dto.Response;
using StructuredFeedback.Group1.Borders.UseCases;
using StructuredFeedback.Group1.Repositories;
using StructuredFeedback.Group1.Repositories.GoogleCloud;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StructuredFeedback.Group1.UseCases.UseCases
{
    public class RelatorioUseCase : IRelatorioUseCase
    {
        private readonly FeedbackRepositorio _feedbackRepository;

        public RelatorioUseCase(IBQ bigQuery)
        {
            this._feedbackRepository = new FeedbackRepositorio(bigQuery);
        }

        public async Task<IList<BuscarRelatorioResponse>> Execute(RelatorioRequest request)
        {
            var response = CalcularUltimoFeedback(await _feedbackRepository.ObterRelatorio(request));

            return response;
        }

        private List<BuscarRelatorioResponse> CalcularUltimoFeedback(List<RelatorioDTO> param)
        {
            var result = new List<BuscarRelatorioResponse>();
           
            param.ForEach(x => result.Add(new BuscarRelatorioResponse
            {
                Nome = x.Nome,
                Email = x.Email,
                TrajetoriaDesejada = x.TrajetoriaDesejada,
                AtuacaoAtual = x.AtuacaoAtual,
                HoraConclusao = x.HoraConclusao,
                Regular = x.HoraConclusao.AddDays(90) > DateTime.Today
            }));

            return result;
        }
    }
}
