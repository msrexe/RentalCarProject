using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentCarDbContext context = new RentCarDbContext())
            {
                var result = from rentals in context.Rentals
                             join cars in context.Cars
                             on rentals.CarId equals cars.Id
                             join brands in context.Brands
                             on cars.BrandId equals brands.Id
                             join customers in context.Customers
                             on rentals.CustomerId equals customers.Id  
                             join users in context.Users
                             on customers.UserId equals users.Id
                             select new RentalDetailDto
                             {
                              Id = rentals.Id,
                              BrandName = brands.Name,
                              CustomerName = users.FirstName + " " + users.LastName,
                              RentDate = rentals.RentDate,
                              ReturnDate = rentals.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
