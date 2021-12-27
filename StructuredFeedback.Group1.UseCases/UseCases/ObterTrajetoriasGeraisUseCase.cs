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
    public class ObterTrajetoriasGeraisUseCase : IObterTrajetoriasGeraisUseCase
    {
        private readonly FeedbackRepositorio _feedbackRepository;

        public ObterTrajetoriasGeraisUseCase(IBQ bigQuery)
        {
            _feedbackRepository = new FeedbackRepositorio(bigQuery);
        }

        public async Task<List<ObterTrajetoriasGeraisResponse>> Execute()
        {
            var response = CalcularPorcetagemTragetoria(await _feedbackRepository.ObterTrajetorias());

            return response;
        }

        private List<ObterTrajetoriasGeraisResponse> CalcularPorcetagemTragetoria(List<ObterTrajetoriasDTO> param)
        {
            var Lista = new List<ObterTrajetoriasGeraisResponse>();

            double total = 0;

            param.ForEach(x =>
            {
                total += x.Quantidade;
            });

            List<ObterTrajetoriasGeraisResponse> teste = param
                .GroupBy(i => i.Trajetoria)
                .Select(j => new ObterTrajetoriasGeraisResponse()
                {
                    Trajetoria = j.First().Trajetoria,
                    Quantidade = j.Sum(x => x.Quantidade)
                }).ToList();

            teste.ForEach(x => Lista.Add(new ObterTrajetoriasGeraisResponse
            {
                Quantidade = x.Quantidade,
                Trajetoria = x.Trajetoria,
                Porcentagem = Math.Round((x.Quantidade * 100) / (total), 1)
            }));

            return Lista;
        }
    }
}
