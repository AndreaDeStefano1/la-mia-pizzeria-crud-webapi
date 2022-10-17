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
        public IActionResult Get(string? name)
        {
            IQueryable<Pizza> pizzas;
            if (name != null)
            {
                name = name.ToLower();
                pizzas = _db.Pizzas.Where(p => p.Name.ToLower().Contains(name));
                return Ok(pizzas.ToList());
            }
            else
            {
                pizzas = _db.Pizzas;
                return Ok(pizzas.ToList());
            }


        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IQueryable<Pizza>  pizza = _db.Pizzas.Where(p=> p.PizzaId == id);
            return Ok(pizza.FirstOrDefault());
        }
    }
}
