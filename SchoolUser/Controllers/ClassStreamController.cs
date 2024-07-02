using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SchoolUser.Controllers
{
    [ApiController]
    [Route("api/class-stream")]
    [ValidateAntiForgeryToken]
    [Authorize]
    public class ClassStreamController : ControllerBase
    {
        private readonly IClassStreamServices _ClassStreamServices;

        public ClassStreamController(IClassStreamServices ClassStreamServices)
        {
            _ClassStreamServices = ClassStreamServices;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllClassStreams()
        {
            return Ok(await _ClassStreamServices.GetAllService());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassStreamById(Guid id)
        {
            return Ok(await _ClassStreamServices.GetByIdService(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateClassStream(ClassStreamDto dto)
        {
            return Ok(await _ClassStreamServices.CreateService(dto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClassStream(Guid id, ClassStreamDto dto)
        {
            return Ok(await _ClassStreamServices.UpdateService(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassStream(Guid id)
        {
            return Ok(await _ClassStreamServices.DeleteService(id));
        }

    }
}