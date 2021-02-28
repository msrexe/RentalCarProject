using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetCars();
        Car GetById(Car car);
        List<Car> GetCarsByBrandId(Car car);
        List<Car> GetCarsByColorId(Car car);
        List<CarDetailDto> GetCarDetails(); 
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
    }
}
