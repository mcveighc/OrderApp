using BGLOrderApp.Models;
using BGLOrderApp.Models.Data;
using BGLOrderApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BGLOrderApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemsService;

        public ItemsController(IItemService orderItemService)
        {
            _itemsService = orderItemService;
        }

        // GET: api/items
        [HttpGet]
        public IActionResult GetAll()
        {
            var orderItems = _itemsService.GetAll();
            return Ok(orderItems);
        }

        // GET: api/items/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _itemsService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // POST: api/items
        [HttpPost]
        [Authorize(Policy = "ModifyItemsPolicy")]
        public IActionResult Post([FromBody] ItemDto item)
        {
            if(ModelState.IsValid)
            {
                _itemsService.Add(item);
                return Ok(true);
            }

            return BadRequest(ModelState);
        }

        // PUT: api/items/5
        [HttpPut()]
        [Authorize(Policy = "ModifyItemsPolicy")]
        public IActionResult Put([FromBody] ItemDto item)
        {
            if (ModelState.IsValid)
            {
                _itemsService.Update(item);
                return Ok(true);
            }

            return BadRequest(ModelState);
        }

        // DELETE: api/items/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _itemsService.Delete(id);
            return Ok(true);
        }
    }
}
