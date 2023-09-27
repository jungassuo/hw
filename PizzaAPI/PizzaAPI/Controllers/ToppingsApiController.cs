using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Data;
using PizzaAPI.Models;
using PizzaAPI.Models.Dtos;

namespace PizzaAPI.Controllers
{
    // This controller is used for getting all toppings from database
    [Route("api/toppings")]
    [ApiController]
    public class ToppingsApiController : ControllerBase
    {
        private readonly AddDbContext _db;
        private Response _response;
        private IMapper _mapper;

        public ToppingsApiController(AddDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new Response();
        }

        [HttpGet]
        public Response GetToppings()
        {
            try
            {
                IEnumerable<Topping> objList = _db.Toppings.ToList();
                _response.Result = _mapper.Map<IEnumerable<ToppingDto>>(objList);

            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }
    }
}
