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
    }
    public class CupcakesRepository : ICupcakesRepository
    {
        eUseControlDatabaseDbContext db;

        public CupcakesRepository()
        {
            db = new eUseControlDatabaseDbContext();
        }

        public void InsertCupcake(Cupcake c)
        {
            db.Cupcakes.Add(c);
            db.SaveChanges();
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
    }

}
