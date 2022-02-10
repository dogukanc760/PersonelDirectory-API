using Api.DataAccess.Abstract;
using Api.Entities.Concrete;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Linq;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDal _userDal;
        private readonly IReportsDal _reportsDal;
        public UserController(IUserDal userDal, IReportsDal reportsDal)
        {
            _userDal = userDal;
            _reportsDal = reportsDal;   
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _userDal.Get();
            if (result == null)
            {
                return BadRequest("Not found");
            }

            return Ok(result.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var result = _userDal.GetByIdAsync(id).Result;
            if (result == null)
            {
                return BadRequest("Not found");
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User data)
        {
            var result = _userDal.AddAsync(data).Result;
            if (result.Id == null)
            {
                return BadRequest("Not Found!");
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] User data)
        {
            var result = _userDal.UpdateAsync(id, data).Result;
            if (result == null)
            {
                return BadRequest("Not found");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var result = _userDal.DeleteAsync(id).Result;
            if (result == null)
            {
                return BadRequest("Not found");
            }

            return NoContent();
        }

        [HttpPost("create-report/{id}")]
        public IActionResult CreateReport(string id)
        {
            var user = _userDal.GetByIdAsync(id);
            if (user.IsCompleted)
            {
                var userResult = user.Result;
                Reports reports = new Reports
                {
                    GsmCount = userResult.inDirectoryGsm.Count().ToString(),
                    PersonCount = userResult.inDirectoryPerson.Count().ToString(),
                    State = "Completed",
                    UserId = userResult.Id,
                };
                var result = _reportsDal.AddAsync(reports);
                if (result.IsCompleted)
                {
                    return Created("", result);
                }
                return BadRequest("Failed");
                
            }
            if (user.IsFaulted)
            {
                return NotFound();
            }
            else { return BadRequest("Failed"); }

        }
    }
}
