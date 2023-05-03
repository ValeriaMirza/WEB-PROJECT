using System;
using System.Collections.Generic;
using System.Linq;
using eUseControl.DomainModels;


namespace eUseControl.Repositories
{
    public interface IOrderRepository
    {
        void InsertOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
        List<Order> GetOrders();
        Order GetOrderById(int id);
    }

    public class OrderRepository : IOrderRepository
    {
        eUseControlDatabaseDbContext db;

        public OrderRepository()
        {
            db = new eUseControlDatabaseDbContext();
        }

        public void InsertOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            Order oldOrder = db.Orders.FirstOrDefault(o => o.OrderID == order.OrderID);
            if (oldOrder != null)
            {
                oldOrder.FirstName = order.FirstName;
                oldOrder.LastName = order.LastName;
                oldOrder.Country = order.Country;
                oldOrder.Address = order.Address;
                oldOrder.Town = order.Town;
                oldOrder.PostalCode = order.PostalCode;
                oldOrder.Phone = order.Phone;
                oldOrder.Email = order.Email;
                oldOrder.AccountPassword = order.AccountPassword;
                oldOrder.DeliveryDate = order.DeliveryDate;
                oldOrder.OrderDate = order.OrderDate;
                db.SaveChanges();
            }
        }

        public void DeleteOrder(int id)
        {
            Order order = db.Orders.FirstOrDefault(o => o.OrderID == id);
            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }

        public List<Order> GetOrders()
        {
            List<Order> orders = db.Orders.ToList();
            return orders;
        }

        public Order GetOrderById(int id)
        {
            Order order = db.Orders.FirstOrDefault(o => o.OrderID == id);
            return order;
        }
    }
}