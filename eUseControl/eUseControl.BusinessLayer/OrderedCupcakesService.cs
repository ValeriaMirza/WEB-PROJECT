using AutoMapper;
using eUseControl.DomainModels;
using eUseControl.Repositories;
using eUseControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic
{ public interface IOrderedCupcakesService
    {
        void InsertOrderedCupcake(OrderedCupcakeViewModel ovm);
        List<OrderedCupcakeViewModel> GetOrderedCupcakesByOrderId(int ID);
    }
    public class OrderedCupcakesService:IOrderedCupcakesService
    {
        IOrderedCupcakeRepository _orderedCupcakeRepo;

        public OrderedCupcakesService()
        {

            _orderedCupcakeRepo = new OrderedCupcakeRepository();
        }
        public void InsertOrderedCupcake(OrderedCupcakeViewModel ovm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<OrderedCupcakeViewModel, OrderedCupcake>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            OrderedCupcake order = mapper.Map<OrderedCupcakeViewModel, OrderedCupcake>(ovm);

            _orderedCupcakeRepo.InsertOrderedCupcake(order);
           
        }
        public List<OrderedCupcakeViewModel> GetOrderedCupcakesByOrderId(int ID)
        {
            List<OrderedCupcake> u = _orderedCupcakeRepo.GetOrderedCupcakesByOrderId(ID);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<OrderedCupcake, OrderedCupcakeViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<OrderedCupcakeViewModel> uvm = mapper.Map<List<OrderedCupcake>, List<OrderedCupcakeViewModel>>(u);
            return uvm;
        }
    }
}
