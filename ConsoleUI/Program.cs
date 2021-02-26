using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entites.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car() { Id = 1, BrandId = 2, ColorId = 2, DailyPrice = 150, Description = "Audi", ModelYear = 2001 });
            carManager.Add(new Car() { Id = 2, BrandId = 3, ColorId = 1, DailyPrice = 200, Description = "Ford", ModelYear = 2011 });
            carManager.Add(new Car() { Id = 3, BrandId = 1, ColorId = 2, DailyPrice = 100, Description = "Renault", ModelYear = 2016 });


            foreach (var car in carManager.GetCars())
            {
                Console.WriteLine(car.BrandId +" "+ car.Description);
            }
        }
    }
}
