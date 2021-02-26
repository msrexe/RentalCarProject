using Entites.Concrete;
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
        void Add(Car car);
    }
}
