using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Data;
using PizzaAPI.Models;
using PizzaAPI.Models.Dtos;

namespace PizzaAPI.Controllers
{
    // This controller is used for getting all pizza sizes from database
    [Route("api/sizes")]
    [ApiController]
    public class SizesApiController : ControllerBase
    {
        private readonly AddDbContext _db;
        private readonly IMapper _mapper;
        private readonly Response _response;

        public SizesApiController(AddDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new Response();
            _mapper = mapper;
        }

        [HttpGet]
        public Response GetSizes()
        {
            try
            {
                IEnumerable<Size> objList = _db.Sizes.ToList();
                _response.Result = _mapper.Map<IEnumerable<SizeDto>>(objList);

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
