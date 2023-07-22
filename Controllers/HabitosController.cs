using Microsoft.AspNetCore.Mvc;
using prueba.DTO;
using prueba.Models;
using prueba.Services;
using System.Threading.Tasks;

namespace prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitosController : ControllerBase
    {
        private readonly IHabitosServices _service;
        public HabitosController(IHabitosServices service)
        {
            _service = service;
        }

        [HttpPost("SetHabitos")]
        public async Task<Response<Spresult>> Set(Habitos param)
        {
            var result = await _service.Set(param);
            return result;
        }

        [HttpGet("GetHabito/{id}")]
        public async Task<Response<VwHabito>> Get(int id)
        {
            var result = await _service.Get(id);
            return result;
        }
    }
}