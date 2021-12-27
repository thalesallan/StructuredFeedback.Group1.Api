using System;

namespace StructuredFeedback.Group1.Borders.Dto.Response
{
    public class BuscarRelatorioResponse
    {
        public string Nome { get; set; }
        public DateTime HoraConclusao { get; set; }
        public bool Regular { get; set; }
        public string Email { get; set; }
        public string AtuacaoAtual { get; set; }
        public string TrajetoriaDesejada { get; set; }
    }
}
