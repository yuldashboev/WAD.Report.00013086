using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppWorkshop.Models;
using WebAppWorkshop.Repositories;

namespace WebAppWorkshop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IRepository<Appointment> _repository;
        public AppointmentController(IRepository<Appointment> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Appointment>> GetAll() => await _repository.GetAllAsync();

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Appointment), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByID(int id)
        {
            var appointment = await _repository.GetByIDAsync(id);
            return appointment == null ? NotFound() : Ok(appointment);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            await _repository.AddAsync(appointment);
            return Ok(appointment);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Appointment appointment)
        {
            await _repository.UpdateAsync(appointment);
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
