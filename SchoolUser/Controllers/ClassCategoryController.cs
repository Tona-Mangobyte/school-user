using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SchoolUser.Controllers
{
    [ApiController]
    [Route("api/class-category")]
    [ValidateAntiForgeryToken]
    [Authorize]
    public class ClassCategoryController : ControllerBase
    {
        private readonly IClassCategoryServices _classCategoryServices;

        public ClassCategoryController(IClassCategoryServices classCategoryServices)
        {
            _classCategoryServices = classCategoryServices;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllClassCategories()
        {
            return Ok(await _classCategoryServices.GetAllService());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassCategoryById(Guid id)
        {
            return Ok(await _classCategoryServices.GetByIdService(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateClassCategory(ClassCategoryDto dto)
        {
            return Ok(await _classCategoryServices.CreateService(dto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClassCategory(Guid id, ClassCategoryDto dto)
        {
            return Ok(await _classCategoryServices.UpdateService(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassCategory(Guid id)
        {
            return Ok(await _classCategoryServices.DeleteService(id));
        }
    }
}