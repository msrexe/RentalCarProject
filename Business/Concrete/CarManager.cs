using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Araç açıklaması 2 karakterden az olamaz\nAraç günlük fiyatı 0 ve aşağısı olamaz");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public Car GetById(Car car)
        {
            return _carDal.Get(c => c.Id == car.Id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCars()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(Car car)
        {
            return _carDal.GetAll(c => c.BrandId == c.BrandId);
        }

        public List<Car> GetCarsByColorId(Car car)
        {
            return _carDal.GetAll(c => c.ColorId == car.ColorId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
