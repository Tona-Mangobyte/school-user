using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SchoolUser.Controllers
{
    [ApiController]
    [Route("api/subject")]
    [ValidateAntiForgeryToken]
    [Authorize]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectServices _subjectServices;

        public SubjectController(ISubjectServices subjectServices)
        {
            _subjectServices = subjectServices;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllSubjects()
        {
            return Ok(await _subjectServices.GetAllService());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectById(Guid id)
        {
            return Ok(await _subjectServices.GetByIdService(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateSubject(SubjectDto dto)
        {
            return Ok(await _subjectServices.CreateService(dto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(Guid id, SubjectDto dto)
        {
            return Ok(await _subjectServices.UpdateService(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(Guid id)
        {
            return Ok(await _subjectServices.DeleteService(id));
        }
    }
}