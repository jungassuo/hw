using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Data;
using PizzaAPI.Models;

namespace PizzaAPI.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersApiController : ControllerBase
    {
        private readonly AddDbContext _db;
        private Response _response;

        public OrdersApiController(AddDbContext db)
        {
            _db = db;
            _response = new Response();
        }

        [HttpGet]
        public Response GetOrders()
        {
            try
            {
                IEnumerable<OrderHeader> objList = _db.OrderHeader.ToList();
                _response.Result = objList;

            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }

        [HttpPost]
        public async Task<Response> Post([FromBody] Order orderDto)
        {
            try
            {
                double totalPrice = orderDto.price + orderDto.toppingsCount;
                if (orderDto.toppingsCount >= 3)
                {
                    totalPrice = totalPrice * 0.9;
                }

                OrderHeader orderHeaderTemp = new OrderHeader()
                { Id = 0, TotalPrice = totalPrice, Size = orderDto.size, ToppingsCount = orderDto.toppingsCount};


                //Saving created object to finalOrder, to use its newly created value in upcoming queries
                OrderHeader finalOrder = _db.OrderHeader.Add(orderHeaderTemp).Entity;
                await _db.SaveChangesAsync();

                //Get newly generated OrderHeaderId
                int getId = finalOrder.Id;

                foreach (string value in orderDto.toppingsArr)
                {
                    OrderDetails temp = new OrderDetails()
                    {
                        Id = 0,
                        HeaderId = getId,
                        ToppingName = value
                    };
                    _db.OrderDetails.Add(temp);
                    await _db.SaveChangesAsync();
                }
                _response.Result = orderDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
