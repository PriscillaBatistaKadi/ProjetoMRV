using Microsoft.AspNetCore.Mvc;
using ProjetoMRV.Controllers.Base;
using ProjetoMRV.Domain.Command;
using ProjetoMRV.Domain.CommandResult;
using ProjetoMRV.Domain.Service;

namespace ProjetoMRV.Controllers
{
    [Route("api/Invited")]
    [ApiController]
    public class SpaController : BaseController
    {
        private readonly SpaService _service;

        public SpaController(SpaService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("GetInviteds")]
        public async Task<List<SpaResult>> Get()
        {
            try
            {
                var result = await _service.GetSpaService();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetAccepteds")]
        public async Task<List<SpaResult>> GetAccepteds()
        {
            try
            {
                var result = await _service.GetAcceptedsService();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Accept")]
        public async Task<IActionResult> Accept(SpaCommand command)
        {
            try
            {
                var result = await _service.AcceptSpaService(command);

                return Response(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Decline")]
        public async Task<IActionResult> Decline(SpaCommand acceptCommand)
        {
            try
            {
                var result = await _service.DeclineSpaService(acceptCommand);

                return Response(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
