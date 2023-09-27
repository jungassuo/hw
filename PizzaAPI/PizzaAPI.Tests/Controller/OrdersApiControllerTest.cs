using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Controllers;
using PizzaAPI.Data;
using PizzaAPI.Models;
using PizzaAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq.EntityFrameworkCore;

namespace PizzaAPI.Tests.Controller
{
    public class OrdersApiControllerTest
    {
        private readonly AddDbContext _db;
        private Response _response;
        private readonly IMapper _mapper;


        public OrdersApiControllerTest(AddDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new Response();
            _mapper = mapper;
        }

        [Fact]
        public void OrderApiController_GetOrders_ReturnSuccess()
        {
            var objList = A.Fake<ICollection<OrderHeaderDto>>();
            var list = A.Fake<List<OrderHeaderDto>>();
            A.CallTo(() => _mapper.Map<IEnumerable<OrderHeaderDto>>(list)).Returns(list);
            var controller = new OrdersApiController(_db,_mapper);

            var result = controller.GetOrders();

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}
