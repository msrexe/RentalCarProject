using Business.Abstract;
using DataAccess.Abstract;
using Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public Car GetById(Car car)
        {
            return _carDal.GetById(car.Id);
        }

        public List<Car> GetCars()
        {
            return _carDal.GetAll();
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
