using Microsoft.AspNetCore.Mvc;
using ProjetoMRV.Domain.Service.Interface;
using System.Reflection.Metadata;

namespace ProjetoMRV.Controllers.Base
{
    public class BaseController : Controller
    {
        private readonly IService _service;

        protected BaseController(IService service)
        {
            _service = service;
        }

        protected new IActionResult Response(object result)
        {
            var notifications = _service?.Notifications();

            if (notifications?.Count == 0)
            {
                return Ok(result);
            }

            return BadRequest(notifications);
        }
    }
}
