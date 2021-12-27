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
    public class ConversaoTrajetoriaUseCase : IObterConversaoTrajetoriaUseCase
    {
        private readonly FeedbackRepositorio _feedbackRepository;

        public ConversaoTrajetoriaUseCase(IBQ bigQuery)
        {
            _feedbackRepository = new FeedbackRepositorio(bigQuery);
        }

        public async Task<ConversaoTrajetoriaResponse> Execute()
        {
            ConversaoTrajetoriaResponse response =  ConversaoTrajetoria(await _feedbackRepository.ObterConversaoTrajetoria());

            return response;
        }

        private ConversaoTrajetoriaResponse ConversaoTrajetoria(List<ConversaoTrajetoriaDTO> param)
        {
            double Sim = 0;
            double Nao = 0;

            param.ForEach(x =>
            {
                if (x.AtuacaoAtual == x.TrajetoriaDesejada)
                {
                    Sim++;
                }
                else
                {
                    Nao++;
                }
            });

            ConversaoTrajetoriaResponse ConversTrajetoria = new ConversaoTrajetoriaResponse();

            ConversTrajetoria.Sim = Math.Round(((Sim * 100) / (Sim + Nao)), 0);
            ConversTrajetoria.Nao = Math.Round(((Nao * 100) / (Sim + Nao)), 0);

            return ConversTrajetoria;
        }
    }

}
