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
    public class TaskListController : ControllerBase
    {
        private readonly ILogger<TaskListController> _logger;
        private readonly ITaskListAppService _AppService;
        private TaskListConverter converter;

        public TaskListController(ILogger<TaskListController> logger, ITaskListAppService appService)
        {
            _logger = logger;
            _AppService = appService;
            converter = new TaskListConverter();
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetAll()
        {
            return Ok(converter.Parse(_AppService.FindAll()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetById(long id)
        {
            if (id == 0) return BadRequest("Invalid id");
            return Ok(converter.Parse(_AppService.FindById(id)));
        }

        [HttpGet("bycategory/{category}")]
        [ProducesResponseType(200)]
        public IActionResult GetByCategory(string category)
        {
            return Ok(converter.Parse(_AppService.FindByCategory(category)));
        }

        [HttpGet("byname/{name}")]
        [ProducesResponseType(200)]
        public IActionResult GetByName(string name)
        {
            return Ok(converter.Parse(_AppService.FindByName(name)));
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody] TaskListVO item)
        {
            if (item is null) return BadRequest("Invalid request");
            var create = converter.Parse(item);
            return Ok(converter.Parse(_AppService.Create(create)));
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Edit([FromBody] TaskListVO item)
        {
            var edit = converter.Parse(item);

            var edited = _AppService.Edit(edit);

            if (edited is null) return BadRequest("Invalid Request");

            return Ok(converter.Parse(edited));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public IActionResult Delete(long id)
        {
            _AppService.Delete(id);
            return Ok();
        }
    }
}
