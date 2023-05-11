using System;
using System.Collections.Generic;
using System.Linq;
using eUseControl.DomainModels;



namespace eUseControl.Repositories
{
    public interface IOrderedCupcakeRepository
    {
        void InsertOrderedCupcake(OrderedCupcake oc);
        void UpdateOrderedCupcake(OrderedCupcake oc);
        void DeleteOrderedCupcake(int orderId, int cupcakeId);
        List<OrderedCupcake> GetOrderedCupcakesByOrderId(int orderId);
    }

    public class OrderedCupcakeRepository : IOrderedCupcakeRepository
    {
        eUseControlDataDbContext db;

        public OrderedCupcakeRepository()
        {
            db = new eUseControlDataDbContext();
        }

        public void InsertOrderedCupcake(OrderedCupcake oc)
        {
            
            db.OrderedCupcakes.Add(oc);
            db.SaveChanges();
        }

        public void UpdateOrderedCupcake(OrderedCupcake oc)
        {
            OrderedCupcake orderedCupcake = db.OrderedCupcakes.Where(temp => temp.OrderID == oc.OrderID && temp.CupcakeID == oc.CupcakeID).FirstOrDefault();
            if (orderedCupcake != null)
            {
                orderedCupcake.Quantity = oc.Quantity;
                db.SaveChanges();
            }
        }

        public void DeleteOrderedCupcake(int orderId, int cupcakeId)
        {
            OrderedCupcake orderedCupcake = db.OrderedCupcakes.Where(temp => temp.OrderID == orderId && temp.CupcakeID == cupcakeId).FirstOrDefault();
            if (orderedCupcake != null)
            {
                db.OrderedCupcakes.Remove(orderedCupcake);
                db.SaveChanges();
            }
        }

        public List<OrderedCupcake> GetOrderedCupcakesByOrderId(int orderId)
        {
            List<OrderedCupcake> orderedCupcakes = db.OrderedCupcakes.Where(temp => temp.OrderID == orderId).ToList();
            return orderedCupcakes;
        }
    }
}
