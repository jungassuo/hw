using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Data;
using PizzaAPI.Models;
using PizzaAPI.Models.Dtos;

namespace PizzaAPI.Controllers
{
    // This controller is used to post and get data from database
    [Route("api/orders")]
    [ApiController]
    public class OrdersApiController : ControllerBase
    {
        private readonly AddDbContext _db;
        private Response _response;
        private readonly IMapper _mapper;


        public OrdersApiController(AddDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new Response();
            _mapper = mapper;
        }

        [HttpGet]
        public Response GetOrders()
        {
            try
            {
                IEnumerable<OrderHeader> objList = _db.OrderHeader.ToList();
                _response.Result = _mapper.Map<IEnumerable<OrderHeaderDto>>(objList);

            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }

        [HttpPost]
        public async Task<Response> Post([FromBody] OrderDto orderDto)
        {
            try
            {
                Order order = _mapper.Map<Order>(orderDto);
                // Calculate the total price of an order
                double totalPrice = order.price + order.toppingsCount;
                if (order.toppingsCount >= 3)
                {
                    totalPrice = totalPrice * 0.9;
                }

                OrderHeader orderHeaderTemp = new OrderHeader()
                { Id = 0, TotalPrice = totalPrice, Size = order.size, ToppingsCount = order.toppingsCount};


                //Saving created object to finalOrder, to use its newly created value in upcoming queries
                OrderHeader finalOrder = _db.OrderHeader.Add(orderHeaderTemp).Entity;
                await _db.SaveChangesAsync();

                //Get newly generated OrderHeaderId
                int getId = finalOrder.Id;

                foreach (string value in order.toppingsArr)
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
                _response.Result = order;
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
