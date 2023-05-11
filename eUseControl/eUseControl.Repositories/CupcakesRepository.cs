using System;
using System.Collections.Generic;
using System.Linq;
using eUseControl.DomainModels;

namespace eUseControl.Repositories
{
    public interface ICupcakesRepository
    {
        void InsertCupcake(Cupcake c);
        void UpdateCupcake(Cupcake c);
        void DeleteCupcake(int id);
        List<Cupcake> GetCupcakes();
        Cupcake GetCupcakeById(int id);
        int InsertCartItem(CartItem item);
        CartItem GetCartItemById(int id);
        List<CartItem> GetCartItems();
        void DeleteCartItem(int cartItemId);




    }
    public class CupcakesRepository : ICupcakesRepository
    {
        eUseControlDataDbContext db;

        public CupcakesRepository()
        {
            db = new eUseControlDataDbContext();
        }

        public void InsertCupcake(Cupcake c)
        {
            db.Cupcakes.Add(c);
            db.SaveChanges();
        }

        public int InsertCartItem(CartItem item)
        {
            db.CartItems.Add(item);
            db.SaveChanges();
            return item.CartItemID;
        }


        public void DeleteCartItem(int cartItemId)
        {
            var cartItem = db.CartItems.Find(cartItemId);
            if (cartItem != null)
            {
               db.CartItems.Remove(cartItem);
                db.SaveChanges();
            }
        }

        public void UpdateCupcake(Cupcake c)
        {
            Cupcake cupcake = db.Cupcakes.Where(temp => temp.CupcakeID == c.CupcakeID).FirstOrDefault();
            if (cupcake != null)
            {
                cupcake.CupcakeName = c.CupcakeName;
                cupcake.Price = c.Price;
                cupcake.Quantity = c.Quantity;
                cupcake.ImagePath = c.ImagePath;
                db.SaveChanges();
            }
        }

        public void DeleteCupcake(int id)
        {
            Cupcake cupcake = db.Cupcakes.Where(temp => temp.CupcakeID == id).FirstOrDefault();
            if (cupcake != null)
            {
                db.Cupcakes.Remove(cupcake);
                db.SaveChanges();
            }
        }

        public List<Cupcake> GetCupcakes()
        {
            List<Cupcake> cupcakes = db.Cupcakes.OrderBy(temp => temp.CupcakeName).ToList();
            return cupcakes;
        }

        public Cupcake GetCupcakeById(int id)
        {
            Cupcake cupcake = db.Cupcakes.Where(temp => temp.CupcakeID == id).FirstOrDefault();
            return cupcake;
        }

        public CartItem GetCartItemById(int id)
        {
            CartItem cartItem = db.CartItems.Where(temp => temp.CartItemID == id).FirstOrDefault();
            return cartItem;
        }
        public List<CartItem> GetCartItems()
        {
            List<CartItem> CartItems = db.CartItems.OrderBy(temp => temp.CartItemID).ToList();
            return CartItems;
        }

    }

}
