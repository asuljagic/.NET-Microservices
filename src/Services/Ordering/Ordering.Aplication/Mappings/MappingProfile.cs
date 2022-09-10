using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ordering.Aplication.Features.Orders.Commands.CheckoutOrder;
using Ordering.Aplication.Features.Orders.Commands.UpdateOrder;
using Ordering.Aplication.Features.Orders.Queries.GetOrdersList;
using Ordering.Domain.Entities;

namespace Ordering.Aplication.Mappings
{
    //need mapper in order to map domain objects with application objects
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrdersVm>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}
