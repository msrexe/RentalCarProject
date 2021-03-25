using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Color() { Id = 1, Name = "Mavi" });
            //colorManager.Add(new Color() { Id = 2, Name = "Beyaz" });
            //colorManager.Add(new Color() { Id = 3, Name = "Siyah" });

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand() { Id = 1, Name = "Renault" });
            //brandManager.Add(new Brand() { Id = 2, Name = "Audi" });
            //brandManager.Add(new Brand() { Id = 3, Name = "Ford" });

            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car() { Id = 4, BrandId = 2, ColorId = 2, DailyPrice = 150, Description = "a3", ModelYear = 2001 });
            //carManager.Add(new Car() { Id = 5, BrandId = 3, ColorId = 1, DailyPrice = 200, Description = "mondeo", ModelYear = 2011 });
            //carManager.Add(new Car() { Id = 6, BrandId = 1, ColorId = 2, DailyPrice = 100, Description = "clio", ModelYear = 2016 });

            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                   // Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer() { Id=1, UserId = 1, CompanyName = "ABCompany" });
            customerManager.Add(new Customer() { Id=2, UserId = 2, CompanyName = "CDCompany" });
            customerManager.Add(new Customer() { Id=3, UserId = 3, CompanyName = "EFCompany" });

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental() { Id = 1, CarId = 4, CustomerId = 1, RentDate = DateTime.Now });
            rentalManager.Add(new Rental() { Id = 2, CarId = 4, CustomerId = 2, RentDate = DateTime.Now });

        }
    }
}
