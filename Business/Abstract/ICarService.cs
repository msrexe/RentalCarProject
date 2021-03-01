using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetCars();
        IDataResult<Car> GetById(Car car);
        IDataResult<List<Car>> GetCarsByBrandId(Car car);
        IDataResult<List<Car>> GetCarsByColorId(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetails(); 
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
    }
}
