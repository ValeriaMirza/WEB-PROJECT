using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using eUseControl.DomainModels;
using eUseControl.Repositories;
using eUseControl.ViewModels;
using AutoMapper;
using AutoMapper.Configuration;

namespace eUseControl.BusinessLogic
{
    public interface IOrdersService
    {
        List<OrderViewModel> GetOrders();
        OrderViewModel GetOrderById(int id);
       List< OrderViewModel> GetOrdersByUserID(int uid);
        void AddOrder(OrderViewModel ovm);
        void UpdateOrder(OrderViewModel ovm);
        void DeleteOrder(int id);
        int CreateOrder(OrderViewModel ovm);
    }

    public class OrdersService : IOrdersService
    {
        IOrdersRepository _ordersRepo;

        public OrdersService()
        {

            _ordersRepo = new OrdersRepository();
        }
       public List<OrderViewModel> GetOrdersByUserID(int uid)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Order, OrderViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();

            var orders = _ordersRepo.GetOrdersByUserID(uid);
            var orderViewModels = mapper.Map<List<Order>, List<OrderViewModel>>(orders);

            return orderViewModels;
        }
        public List<OrderViewModel> GetOrders()
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Order, OrderViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();

            var orders = _ordersRepo.GetOrders();
            var orderViewModels = mapper.Map<List<Order>, List<OrderViewModel>>(orders);

            return orderViewModels;
        }
        public int CreateOrder(OrderViewModel ovm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<OrderViewModel, Order>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Order order = mapper.Map<OrderViewModel, Order>(ovm);
            order.OrderDate= DateTime.Now;
            order.DeliveryDate = DateTime.Now.AddDays(7);

            _ordersRepo.CreateOrder(order);
            int orderId = _ordersRepo.GetLatestOrderId();
            return orderId;
        }
     
        public OrderViewModel GetOrderById(int id)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Order, OrderViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();

            var order = _ordersRepo.GetOrderById(id);
            var orderViewModel = mapper.Map<Order, OrderViewModel>(order);

            return orderViewModel;
        }

        public void AddOrder(OrderViewModel ovm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<OrderViewModel, Order>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();

            var order = mapper.Map<OrderViewModel, Order>(ovm);
            _ordersRepo.InsertOrder(order);
        }

        public void UpdateOrder(OrderViewModel ovm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<OrderViewModel, Order>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();

            var order = mapper.Map<OrderViewModel, Order>(ovm);
            _ordersRepo.UpdateOrder(order);
        }

        public void DeleteOrder(int id)
        {
            _ordersRepo.DeleteOrder(id);
        }
    }
}
