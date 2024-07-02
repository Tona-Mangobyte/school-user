using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SchoolUser.Controllers
{
    [ApiController]
    [Route("api/class-subject")]
    [ValidateAntiForgeryToken]
    [Authorize]
    public class ClassSubjectController : ControllerBase
    {
        private readonly IClassSubjectServices _classSubjectServices;

        public ClassSubjectController(IClassSubjectServices classSubjectServices)
        {
            _classSubjectServices = classSubjectServices;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllClassSubjects()
        {
            return Ok(await _classSubjectServices.GetAllService());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassSubjectById(Guid id)
        {
            return Ok(await _classSubjectServices.GetByIdService(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateClassSubject(ClassSubjectDto dto)
        {
            return Ok(await _classSubjectServices.CreateService(dto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClassSubject(Guid id, ClassSubjectDto dto)
        {
            return Ok(await _classSubjectServices.UpdateService(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassSubject(Guid id)
        {
            return Ok(await _classSubjectServices.DeleteService(id));
        }
    }
}