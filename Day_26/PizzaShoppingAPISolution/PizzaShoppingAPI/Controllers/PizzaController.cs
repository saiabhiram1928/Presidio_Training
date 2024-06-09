
using Microsoft.AspNetCore.Mvc;
using PizzaShoppingAPI.Interfaces;
using PizzaShoppingAPI.Models;
using PizzaShoppingAPI.Exceptions;
using PizzaShoppingAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace PizzaShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("in-stock")]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IList<PizzaDTO>>> GetPizzasInStock()
        {
            try
            {
                var pizzas = await _pizzaService.GetPizzasInStockAsync();
                return Ok(pizzas.ToList());
            }
            catch (NoPizzasFoundException npfe)
            {
                return NotFound(new ErrorModel(404, npfe.Message));
            }
        }
    }
}
