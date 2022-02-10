using Api.DataAccess.Abstract;
using Api.Entities.Concrete;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Linq;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryController : ControllerBase
    {
        private readonly IDirectoryDal _directoryDal;
        public DirectoryController(IDirectoryDal directoryDal)
        {
            _directoryDal = directoryDal;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _directoryDal.Get();
            if (result == null)
            {
                return BadRequest("Not found");
            }

            return Ok(result.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var result = _directoryDal.GetByIdAsync(id).Result;
            if (result == null)
            {
                return BadRequest("Not found");
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Directory data)
        {
            var result = _directoryDal.AddAsync(data).Result;
            if (result.Id == null)
            {
                return BadRequest("failed");
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Directory data)
        {
            var result = _directoryDal.UpdateAsync(id, data).Result;
            if (result == null)
            {
                return BadRequest("Not found");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var result = _directoryDal.DeleteAsync(id).Result;
            if (result == null)
            {
                return BadRequest("Not found");
            }

            return NoContent();
        }
    }
}
