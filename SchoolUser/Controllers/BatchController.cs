using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SchoolUser.Controllers
{
    [ApiController]
    [Route("api/batch")]
    [ValidateAntiForgeryToken]
    [Authorize]
    public class BatchController : ControllerBase
    {
        private readonly IBatchServices _batchServices;

        public BatchController(IBatchServices batchServices)
        {
            _batchServices = batchServices;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllBatches()
        {
            return Ok(await _batchServices.GetAllService());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBatchById(Guid id)
        {
            return Ok(await _batchServices.GetByIdService(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBatch(BatchDto dto)
        {
            return Ok(await _batchServices.CreateService(dto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBatch(Guid id, BatchDto dto)
        {
            return Ok(await _batchServices.UpdateService(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBatch(Guid id)
        {
            return Ok(await _batchServices.DeleteService(id));
        }
    }
}