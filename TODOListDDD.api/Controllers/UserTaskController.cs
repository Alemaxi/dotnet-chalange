using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TODOListDDD.api.Data.Converter.Implementations;
using TODOListDDD.api.Data.VO;
using TODOListDDD.application.Interfaces;

namespace TODOListDDD.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserTaskController : ControllerBase
    {
        private readonly ILogger<UserTaskController> _logger;
        private readonly IUserTaskAppService _AppService;
        private UserTaskConverter converter;

        public UserTaskController(ILogger<UserTaskController> logger, IUserTaskAppService appService)
        {
            _logger = logger;
            _AppService = appService;
            converter = new UserTaskConverter();
        }


        //Gets
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetAll()
        {
            return Ok(converter.Parse(_AppService.FindAll()));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            if (id == 0) return BadRequest("Invalid id");
            return Ok(converter.Parse(_AppService.FindById(id)));
        }

        [HttpGet("completed")]
        public IActionResult Completed(long id)
        {
            _AppService.Completed(id);
            return Ok();
        }


        //Posts
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody] UserTaskVO item)
        {
            if (item is null) return BadRequest("Invalid request");
            var create = converter.Parse(item);
            return Ok(converter.Parse(_AppService.Create(create)));
        }


        //Puts
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Edit([FromBody] UserTaskVO item)
        {
            var edit = converter.Parse(item);

            var edited = _AppService.Edit(edit);

            if (edited is null) return BadRequest("Invalid Request");

            return Ok(converter.Parse(edited));
        }


        //Deletes
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public IActionResult Delete(long id)
        {
            _AppService.Delete(id);
            return Ok();
        }
    }
}
