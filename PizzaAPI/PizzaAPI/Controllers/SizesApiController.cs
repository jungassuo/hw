using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Data;
using PizzaAPI.Models;

namespace PizzaAPI.Controllers
{
    [Route("api/sizes")]
    [ApiController]
    public class SizesApiController : ControllerBase
    {
        private readonly AddDbContext _db;
        private Response _response;

        public SizesApiController(AddDbContext db)
        {
            _db = db;
            _response = new Response();
        }

        [HttpGet]
        public Response GetToppings()
        {
            try
            {
                IEnumerable<Size> objList = _db.Sizes.ToList();
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
