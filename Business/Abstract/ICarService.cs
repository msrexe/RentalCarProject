using Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetCars();
        Car GetById(Car car);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
