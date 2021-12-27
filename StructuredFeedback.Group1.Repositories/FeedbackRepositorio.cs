using StructuredFeedback.Group1.Borders.Dto;
using StructuredFeedback.Group1.Borders.Dto.Request;
using StructuredFeedback.Group1.Borders.Repositories;
using StructuredFeedback.Group1.Repositories.GoogleCloud;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StructuredFeedback.Group1.Repositories
{
    public class FeedbackRepositorio : IFeedbackRepositorio
    {
        private readonly IBQ _bigQuery;

        public FeedbackRepositorio(IBQ gcp)
        {
            _bigQuery = gcp;
        }

        public async Task<List<TribosDTO>> ObterListaTribos()
        {
            var query = @"select tribo from [mythical-harbor-330522.maratona_programacao.pessoa_fato] group by tribo order by tribo ASC";

            var rows = await _bigQuery.GetRows(query);

            var result = new List<TribosDTO>();

            rows.ForEach(row => result.Add(new TribosDTO
            {
                Tribo = row.F[0].V.ToString(),
            }));

            return result;
        }

        public async Task<List<RelatorioDTO>> ObterRelatorio(RelatorioRequest request)
        {
            var query = @"SELECT pf.nome, pf.horaConclusao, pf.email, pf.atuacaoAtual, pf.trajetoriaDesejada 
                                FROM [mythical-harbor-330522.maratona_programacao.pessoa_fato] pf  WHERE pf.tribo = '" + request.Tribo + "'order by nome ASC";

            var rows = await _bigQuery.GetRows(query);

            var result = new List<RelatorioDTO>();

            rows.ForEach(row => result.Add(new RelatorioDTO
            {
                Nome = row.F[0].V.ToString(),
                HoraConclusao = DateTime.Parse(row.F[1].V.ToString()),
                Email = row.F[2].V.ToString(),
                AtuacaoAtual = row.F[3].V.ToString(),
                TrajetoriaDesejada = row.F[4].V.ToString(),
            }));

            return result;
        }

        public async Task<List<TotalTriboDTO>> ObterAdesao()
        {
            var query = @"SELECT COUNT(pf.tribo), pf.tribo FROM [mythical-harbor-330522.maratona_programacao.pessoa_fato] pf GROUP BY pf.tribo";

            var rows = await _bigQuery.GetRows(query);

            var result = new List<TotalTriboDTO>();

            rows.ForEach(row => result.Add(new TotalTriboDTO
            {
                Tribo = row.F[1].V.ToString(),
                QuantidadeTotalTribo = int.Parse(row.F[0].V.ToString()),
            }));

            return result;
        }

        public async Task<List<ConversaoTrajetoriaDTO>> ObterConversaoTrajetoria()
        {
            var query = @"select pf.atuacaoAtual, pf.trajetoriaDesejada  from [mythical-harbor-330522.maratona_programacao.pessoa_fato] pf";

            var rows = await _bigQuery.GetRows(query);

            var result = new List<ConversaoTrajetoriaDTO>();

            rows.ForEach(row => result.Add(new ConversaoTrajetoriaDTO
            {
                AtuacaoAtual = row.F[0].V.ToString(),
                TrajetoriaDesejada = row.F[1].V.ToString(),
            }));

            return result;
        }

        public async Task<List<TrajetoriaDesejadaDTO>> ObterTrajetoriaDesejada(string tribo)
        {
            var query = @"SELECT pf.tribo, COUNT(pf.trajetoriaDesejada), pf.trajetoriaDesejada 
                            FROM [mythical-harbor-330522.maratona_programacao.pessoa_fato] pf where pf.tribo = '"+ tribo +"' GROUP BY pf.trajetoriaDesejada, pf.tribo ";

            var rows = await _bigQuery.GetRows(query);

            var result = new List<TrajetoriaDesejadaDTO>();

            rows.ForEach(row => result.Add(new TrajetoriaDesejadaDTO
            {
                Tribo = row.F[0].V.ToString(),
                Quantidade = int.Parse(row.F[1].V.ToString()),
                TrajetoriaDesejada = row.F[2].V.ToString()
            })); ;

            return result;
        }

        public async Task<List<ObterTrajetoriasDTO>> ObterTrajetorias()
        {
            var query = @"SELECT pf.tribo, COUNT(pf.trajetoria), pf.trajetoria FROM [mythical-harbor-330522.maratona_programacao.pessoa_fato] pf GROUP BY pf.trajetoria, pf.tribo";

            var rows = await _bigQuery.GetRows(query);

            var result = new List<ObterTrajetoriasDTO>();

            rows.ForEach(row => result.Add(new ObterTrajetoriasDTO
            {
                Tribo = row.F[0].V.ToString(),
                Quantidade = int.Parse(row.F[1].V.ToString()),
                Trajetoria = row.F[2].V.ToString()
            })); ;

            return result;
        }
    }
}
