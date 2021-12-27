using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using StructuredFeedback.Group1.Borders.Dto.Request;
using StructuredFeedback.Group1.Borders.UseCases;
using System;
using System.Threading.Tasks;

namespace StructuredFeedback.Group1.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IRelatorioUseCase _relatorioUseCase;
        private readonly IObterAdesaoTriboUseCase _ObterAdesaoTriboUseCase;
        private readonly IObterConversaoTrajetoriaUseCase _conversaoTrajetoriaUseCase;
        private readonly IObterTrajetoriaDesejadaUseCase _obterTrajetoriaDesejadaUseCase;
        private readonly IObterTrajetoriasGeraisUseCase _obterTrajetoriasGeraisUseCase;
        private readonly IObterTribosUseCase _obterTribosUseCase;

        public FeedbackController(IRelatorioUseCase relatorioUseCase, 
            IObterAdesaoTriboUseCase ObterAdesaoTriboUseCase, IObterConversaoTrajetoriaUseCase conversaoTrajetoriaUseCase, 
            IObterTrajetoriaDesejadaUseCase obterTrajetoriaDesejadaUseCase, IObterTrajetoriasGeraisUseCase obterTrajetoriasGeraisUseCase,
            IObterTribosUseCase obterTribosUseCase)
        {
            _relatorioUseCase = relatorioUseCase;
            _ObterAdesaoTriboUseCase = ObterAdesaoTriboUseCase;
            _conversaoTrajetoriaUseCase = conversaoTrajetoriaUseCase;
            _obterTrajetoriaDesejadaUseCase = obterTrajetoriaDesejadaUseCase;
            _obterTrajetoriasGeraisUseCase = obterTrajetoriasGeraisUseCase;
            _obterTribosUseCase = obterTribosUseCase;
        }

        [HttpGet]
        [Route("ObterTribos")]
        public async Task<IActionResult> ObterTribos()
        {
            try
            {
                var response = await _obterTribosUseCase.Execute();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObterRelatorio")]
        public async Task<IActionResult> ObterRelatorio([FromQuery] RelatorioRequest request)
        {
            try
            {
                var response = await _relatorioUseCase.Execute(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObterAdesaoTribo")]
        public async Task<IActionResult> ObterAdesaoTribo()
        {
            try
            {
                var response = await _ObterAdesaoTriboUseCase.Execute();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObterConversaoTrajetoria")]
        public async Task<IActionResult> ObterConversaoTrajetoria()
        {
            try
            {
                var response = await _conversaoTrajetoriaUseCase.Execute();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObterTrajetoriaDesejada")]
        public async Task<IActionResult> ObterTrajetoriaDesejada([FromQuery] string tribo)
        {
            try
            {
                var response = await _obterTrajetoriaDesejadaUseCase.Execute(tribo);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObterTrajetorias")]
        public async Task<IActionResult> ObterTrajetorias()
        {
            try
            {
                var response = await _obterTrajetoriasGeraisUseCase.Execute();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
