using Moq;
using StructuredFeedback.Group1.Repositories.GoogleCloud;

namespace StructuredFeedback.Group1.Test.MockConfiguracao
{
    public class BigQueryConfig
    {
        private readonly Mock<IBQ> _repositorio;
        public BigQueryConfig()
        {
            if (_repositorio == null)
            {
                _repositorio = new Mock<IBQ>();
            }
        }

        public Mock<IBQ> FeedbackRepositorio()
        {
            return _repositorio;
        }

        public static BigQueryConfig Instace()
        {
            return new BigQueryConfig();
        }

        public IBQ Build()
        {
            return _repositorio.Object;
        }
    }
}
