using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppWorkshop.Models;
using WebAppWorkshop.Repositories;

namespace WebAppWorkshop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly IRepository<Visitor> _repository;
        public VisitorController(IRepository<Visitor> repository)
        {
            _repository = repository;   
        }

        [HttpGet]
        public async Task<IEnumerable<Visitor>> GetAll() => await _repository.GetAllAsync();

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Visitor), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByID(int id)
        {
            var visitor = await _repository.GetByIDAsync(id);
            return visitor == null ? NotFound() : Ok(visitor);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Visitor visitor)
        {
            await _repository.AddAsync(visitor);
            //return Ok(feat);
            return CreatedAtAction(nameof(GetByID), new { id = visitor.id }, visitor);

        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Visitor visitor)
        { 
            await _repository.UpdateAsync(visitor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
