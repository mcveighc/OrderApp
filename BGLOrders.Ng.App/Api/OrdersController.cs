using BGLOrderApp.Models;
using BGLOrderApp.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BGLOrderApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    // Wold be nice to authorize requests if time allows
    //[Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Order
        [HttpGet()]
        public IActionResult Get()
        {
            var orders = _orderService.GetAll();
            return Ok(orders);
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var order = _orderService.Get(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // POST: api/orders
        [HttpPost]
        public IActionResult Post([FromBody] NewOrderDto order)
        {
            if (ModelState.IsValid)
            {
               _orderService.Add(order);
                return Ok(true);
            }

            return BadRequest(ModelState);
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            if(ModelState.IsValid)
            {
                _orderService.Update(id, value);
                return Ok(true);
            }

            return BadRequest(ModelState);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderService.Remove(id);
            return Ok(true);
        }
    }
}
