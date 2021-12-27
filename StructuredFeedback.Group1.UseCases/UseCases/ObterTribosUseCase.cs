using StructuredFeedback.Group1.Borders.Dto.Response;
using StructuredFeedback.Group1.Borders.UseCases;
using StructuredFeedback.Group1.Repositories;
using StructuredFeedback.Group1.Repositories.GoogleCloud;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StructuredFeedback.Group1.UseCases.UseCases
{
    public class ObterTribosUseCase : IObterTribosUseCase
    {
        private readonly FeedbackRepositorio _feedbackRepository;

        public ObterTribosUseCase(IBQ bigQuery)
        {
            _feedbackRepository = new FeedbackRepositorio(bigQuery);
        }

        public async Task<List<ListaTribosResponse>> Execute()
        {
            var response = await _feedbackRepository.ObterListaTribos();

            var result = new List<ListaTribosResponse>();

            response.ForEach(res => result.Add(new ListaTribosResponse
            {
                Tribo = res.Tribo,
            }));

            return result;
        }
    }
}
