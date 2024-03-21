using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppWorkshop.Models;
using WebAppWorkshop.Repositories;

namespace WebAppWorkshop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReceptionistController : ControllerBase
    {
        private readonly IRepository<Receptionist> _repository;
        public ReceptionistController(IRepository<Receptionist> repository)
        {
            _repository = repository;   
        }

        [HttpGet]
        public async Task<IEnumerable<Receptionist>> GetAll() => await _repository.GetAllAsync();

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Receptionist), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByID(int id)
        {
            var receptionist = await _repository.GetByIDAsync(id);
            return receptionist == null ? NotFound() : Ok(receptionist);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Receptionist receptionist)
        {
            await _repository.AddAsync(receptionist);
            //return Ok(feat);
            return CreatedAtAction(nameof(GetByID), new { id = receptionist.id }, receptionist);

        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Receptionist receptionist)
        { 
            await _repository.UpdateAsync(receptionist);
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
