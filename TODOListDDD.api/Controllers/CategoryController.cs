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
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryAppService _AppService;
        private CategoryConverter converter;

        public CategoryController(ILogger<CategoryController> logger, ICategoryAppService appService)
        {
            _logger = logger;
            _AppService = appService;
            converter = new CategoryConverter();
        }

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

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody] CategoryVO item)
        {
            if (item is null) return BadRequest("Invalid request");
            var create = converter.Parse(item);
            return Ok(converter.Parse(_AppService.Create(create)));
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Edit([FromBody] CategoryVO item)
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
