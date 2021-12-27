using StructuredFeedback.Group1.Borders.Dto;
using StructuredFeedback.Group1.Borders.Dto.Response;
using StructuredFeedback.Group1.Borders.UseCases;
using StructuredFeedback.Group1.Repositories;
using StructuredFeedback.Group1.Repositories.GoogleCloud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StructuredFeedback.Group1.UseCases.UseCases
{
    public class ObterTrajetoriaDesejadaUseCase : IObterTrajetoriaDesejadaUseCase
    {
        private readonly FeedbackRepositorio _feedbackRepository;

        public ObterTrajetoriaDesejadaUseCase(IBQ bigQuery)
        {
            _feedbackRepository = new FeedbackRepositorio(bigQuery);
        }

        public async Task<IList<TrajetoriaDesejadaResponse>> Execute(string tribo)
        {
            var response = PorcentagemTrajetoriaDesejada(await _feedbackRepository.ObterTrajetoriaDesejada(tribo));

            return response;
        }

        private List<TrajetoriaDesejadaResponse> PorcentagemTrajetoriaDesejada(List<TrajetoriaDesejadaDTO> param)
        {
            var Lista = new List<TrajetoriaDesejadaResponse>();
            double total = 0;

            param.ForEach(x =>
            {
                total += x.Quantidade;
            });

            List<TrajetoriaDesejadaDTO> trajetorias = param
                .GroupBy(i => i.TrajetoriaDesejada)
                .Select(j => new TrajetoriaDesejadaDTO()
                {
                    TrajetoriaDesejada = j.First().TrajetoriaDesejada,
                    Tribo = j.First().Tribo,
                    TotalPessoas = j.Sum(x => x.Quantidade)
                }).ToList();

            trajetorias.ForEach(x => Lista.Add(new TrajetoriaDesejadaResponse
            {
                TrajetoriaDesejada = x.TrajetoriaDesejada,
                Tribo = x.Tribo,
                Porcentagem = Math.Round((x.TotalPessoas * 100) / (total), 1),
                Quantidade = x.TotalPessoas
            }));

            return Lista;
        }
    }
}
