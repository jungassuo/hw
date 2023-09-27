using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Data;
using PizzaAPI.Models;

namespace PizzaAPI.Controllers
{
    [Route("api/toppings")]
    [ApiController]
    public class ToppingsApiController : ControllerBase
    {
        private readonly AddDbContext _db;
        private Response _response;

        public ToppingsApiController(AddDbContext db)
        {
            _db = db;
            _response = new Response();
        }

        [HttpGet]
        public Response GetToppings()
        {
            try
            {
                IEnumerable<Topping> objList = _db.Toppings.ToList();
                _response.Result = objList;

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
