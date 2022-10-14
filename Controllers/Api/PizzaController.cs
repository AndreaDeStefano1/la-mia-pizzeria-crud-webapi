using la_mia_pizzeria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        PizzaContext _db;
        public PizzaController()
        {
            _db = new PizzaContext();
        }
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<Pizza> pizzas = _db.Pizzas;

            return Ok(pizzas.ToList());
        }
    }
}
