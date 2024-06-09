
using PizzaShoppingAPI.Interfaces;
using PizzaShoppingAPI.Models;
using PizzaShoppingAPI.Models.DTOs;
using PizzaShoppingAPI.Exceptions;

namespace PizzaShoppingAPI.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<int, Pizza> _repository;


        public PizzaService(IRepository<int, Pizza> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PizzaDTO>> GetPizzasInStockAsync()
        {
            var pizzas = await _repository.Get();

            if (pizzas.Count() == 0)
                throw new NoPizzasFoundException();

            return MapToDto(pizzas);
        }

        public static PizzaDTO MapToDto(Pizza pizza)
        {
            if (pizza == null) 
                return null;

            return new PizzaDTO
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = pizza.Price
            };
        }

        public static IEnumerable<PizzaDTO> MapToDto(IEnumerable<Pizza> pizzas)
        {
            return pizzas?.Select(MapToDto).ToList();
        }
    }
}
