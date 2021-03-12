using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfImagesMoreThanLimit(carImage.CarId));
            if(result != null)
            {
                return result;
            }
            
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.EntityAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.EntityDeleted);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            
            var result = _carImageDal.Get(c => c.Id == id);
            return new SuccessDataResult<CarImage>(result);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            var result = BusinessRules.Run(CheckIfCarImageNull(id));
            if (result != null)
            {
                return (IDataResult<List<CarImage>>)result;
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id).ToList(), "resim bulundu");
        }

        public IDataResult<List<CarImage>> GetCarImages()
        {
            var result = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfImagesMoreThanLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(c=>c.Id == carImage.CarId).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.EntityUpdated);
        }

        private IResult CheckIfImagesMoreThanLimit(int carId)
        {
            var imageCount = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if(imageCount >= 5)
            {
                return new ErrorResult(Messages.ImagesLimitExceeded);
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            var result = _carImageDal.GetAll(p => p.CarId == id).Any();
            if (!result)
            {
                string path = @"\wwwroot\uploads\logo.jpg";
                List<CarImage> carimages = new List<CarImage>();
                carimages.Add(new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now });
                return new ErrorDataResult<List<CarImage>>(carimages);
            }
            return new SuccessDataResult<List<CarImage>>();

        }
    }

}
