using DataAccess.Abstract;
using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=2, ColorId=3, ModelYear=2019, DailyPrice=150, Description="Aile arabası"},
                new Car{Id=2, BrandId=5, ColorId=1, ModelYear=2020, DailyPrice=200, Description="Spor araba"},
                new Car{Id=3, BrandId=1, ColorId=3, ModelYear=2017, DailyPrice=180, Description="Ticari araba"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _cars.FirstOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int Id)
        {
            return _cars.FirstOrDefault(c =>  c.Id == Id);
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _cars.FirstOrDefault(c => c.Id == car.Id);

            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
        }
    }
}
