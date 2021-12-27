using StructuredFeedback.Group1.Borders.Dto;
using StructuredFeedback.Group1.Borders.Dto.Response;
using StructuredFeedback.Group1.Borders.UseCases;
using StructuredFeedback.Group1.Repositories;
using StructuredFeedback.Group1.Repositories.GoogleCloud;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StructuredFeedback.Group1.UseCases.UseCases
{
    public class ObterAdesaoTriboUseCase : IObterAdesaoTriboUseCase
    {
        private readonly FeedbackRepositorio _feedbackRepository;

        public ObterAdesaoTriboUseCase(IBQ bigQuery)
        {
            _feedbackRepository = new FeedbackRepositorio(bigQuery);
        }

        public async Task<List<AdesaoTriboResponse>> Execute()
        {
            var response = CalcPorcentage(await _feedbackRepository.ObterAdesao());

            return response;
        }

        private List<AdesaoTriboResponse> CalcPorcentage(List<TotalTriboDTO> param)
        {
            double quantidadeTotal = 0;
            
            param.ForEach(soma =>
            {
                quantidadeTotal += soma.QuantidadeTotalTribo;
            });

            var ListaTribos = new List<AdesaoTriboResponse>();

            param.ForEach(item => ListaTribos.Add(new AdesaoTriboResponse
            {
                Tribo = item.Tribo,
                QuantidadeTotalTribo = item.QuantidadeTotalTribo,
                QuantidadeTotal = quantidadeTotal,
                Porcentage = Math.Round((item.QuantidadeTotalTribo * 100) / (quantidadeTotal), 0)
            }));

            return ListaTribos;
        }
    }
}
