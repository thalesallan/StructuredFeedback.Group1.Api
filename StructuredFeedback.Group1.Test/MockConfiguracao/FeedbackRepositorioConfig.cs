using Moq;
using StructuredFeedback.Group1.Borders.Dto;
using StructuredFeedback.Group1.Borders.Dto.Request;
using StructuredFeedback.Group1.Borders.Repositories;
using StructuredFeedback.Group1.Borders.UseCases;
using StructuredFeedback.Group1.Repositories;
using StructuredFeedback.Group1.Repositories.GoogleCloud;
using System;
using System.Collections.Generic;

namespace StructuredFeedback.Group1.Test.MockConfiguracao
{
    public class FeedbackRepositorioConfig
    {
        private readonly Mock<IBQ> _gcp;
        private readonly Mock<IFeedbackRepositorio> _repositorio;
        public FeedbackRepositorioConfig()
        {
            if(_gcp == null)
            {
                _gcp = new Mock<IBQ>();
            }
        }

        public static FeedbackRepositorioConfig Instace()
        {
            return new FeedbackRepositorioConfig();
        }

        public IBQ Build()
        {
            return  _gcp.Object;
        }

        public FeedbackRepositorioConfig ObterListaTribos()
        {
            var resposta = new List<TribosDTO>() 
            { 
                new TribosDTO
                {
                    Tribo = "Origem"
                },
                new TribosDTO
                {
                    Tribo = "Asgard"
                },
                new TribosDTO
                {
                    Tribo = "Dataflix"
                },
                new TribosDTO
                {
                    Tribo = "Raptors"
                },
                new TribosDTO
                {
                    Tribo = "Guarás"
                },
                new TribosDTO
                {
                    Tribo = "Ragnarok"
                }
            };

            _repositorio.Setup(repositorio => repositorio.ObterListaTribos()).ReturnsAsync(resposta);

            return this;
        }

        public FeedbackRepositorioConfig ObterRelatorio(RelatorioRequest request)
        {
            var resposta = new List<RelatorioDTO>()
            {
                new RelatorioDTO
                {
                    Nome = "NomeMOCK",
                    Email ="Email.MOCK@teste.com.br",
                    AtuacaoAtual = "DL",
                    TrajetoriaDesejada = "DL",
                    HoraConclusao= DateTime.Now
                },
                new RelatorioDTO
                {
                    Nome = "NomeMOCK",
                    Email ="Email.MOCK@teste.com.br",
                    AtuacaoAtual = "Desenvolvedor",
                    TrajetoriaDesejada = "Arquiteto",
                    HoraConclusao= DateTime.Now
                }
            };

            _repositorio.Setup(repositorio => repositorio.ObterRelatorio(request)).ReturnsAsync(resposta);

            return this;
        }

        public FeedbackRepositorioConfig ObterAdesao() 
        {
            var resposta = new List<TotalTriboDTO>()
            {
                new TotalTriboDTO
                {
                    Tribo = "Ragnarok",
                    QuantidadeTotalTribo = 250
                },
                new TotalTriboDTO
                {
                    Tribo = "Raptors",
                    QuantidadeTotalTribo = 300
                }
            };

            _repositorio.Setup(repositorio => repositorio.ObterAdesao()).ReturnsAsync(resposta);

            return this;
        }

        public FeedbackRepositorioConfig ObterConversaoTrajetoria()
        {
            var resposta = new List<ConversaoTrajetoriaDTO>() 
            { 
                new ConversaoTrajetoriaDTO
                {
                    AtuacaoAtual = "DL",
                   TrajetoriaDesejada = "Arquiteto"
                },
                new ConversaoTrajetoriaDTO
                {
                    AtuacaoAtual = "Desenvolvedor",
                   TrajetoriaDesejada = "DL"
                },
                new ConversaoTrajetoriaDTO
                {
                    AtuacaoAtual = "DL",
                   TrajetoriaDesejada = "TMAM"
                }
            };

            _repositorio.Setup(repositorio => repositorio.ObterConversaoTrajetoria()).ReturnsAsync(resposta);

            return this;
        }

        public FeedbackRepositorioConfig ObterTrajetoriais(string tribo)
        {
            var resposta = new List<TrajetoriaDesejadaDTO>()
            {
                new TrajetoriaDesejadaDTO
                {
                    Tribo = "Ragnarok",
                    Quantidade = 200,
                    TrajetoriaDesejada = "DL"
                },
                new TrajetoriaDesejadaDTO
                {
                    Tribo = "Ragnarok",
                    Quantidade = 200,
                    TrajetoriaDesejada = "TMAM"
                },
                new TrajetoriaDesejadaDTO
                {
                    Tribo = "Ragnarok",
                    Quantidade = 200,
                    TrajetoriaDesejada = "PO"
                },
            };

            _repositorio.Setup(repositorio => repositorio.ObterTrajetoriaDesejada(tribo)).ReturnsAsync(resposta);

            return this;
        }

        public FeedbackRepositorioConfig ObterTrajetorias()
        {
            var resposta = new List<ObterTrajetoriasDTO>()
            {
                new ObterTrajetoriasDTO
                {
                    Tribo = "Ragnarok",
                    Quantidade = 200,
                    Trajetoria = "DL"
                },
                 new ObterTrajetoriasDTO
                {
                    Tribo = "Ragnarok",
                    Quantidade = 200,
                    Trajetoria = "Desenvolvedor"
                },
            };

            _repositorio.Setup(repositorio => repositorio.ObterTrajetorias()).ReturnsAsync(resposta);

            return this;
        }
    }
}
