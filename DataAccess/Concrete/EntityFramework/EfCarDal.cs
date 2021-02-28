using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentCarDbContext context = new RentCarDbContext())
            {
                var result = from cars in context.Cars
                             join colors in context.Colors
                             on cars.ColorId equals colors.Id
                             join brands in context.Brands
                             on cars.BrandId equals brands.Id
                             select new CarDetailDto
                             {
                                 CarId = cars.Id,
                                 BrandName = brands.Name,
                                 CarName = cars.Description,
                                 ColorName = colors.Name,
                                 DailyPrice = cars.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
