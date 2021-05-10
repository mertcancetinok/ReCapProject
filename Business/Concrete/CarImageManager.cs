using System;
using System.Collections.Generic;
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

namespace Business.Concrete
{
    [ValidationAspect(typeof(CarImageValidator))]
    public class CarImageManager:ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IResult Add(CarImage entity,IFormFile file)
        {
            var result = BusinessRules.Run(CheckIfCarImagesMoreThanFive(entity.CarId));
            if (result!=null)
            {
                return result;
            }

            entity.ImagePath = FileHelper.Add(file);
            entity.Date = DateTime.Now;
            _carImageDal.Add(entity);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(List<CarImage> entities)
        {
            foreach (var entity in entities)
            {
                FileHelper.Delete(entity.ImagePath);
                _carImageDal.Delete(entity);
            }
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IResult Update(CarImage entity,IFormFile file)
        {
            FileHelper.Update(file,entity.ImagePath);
            _carImageDal.Update(entity);
            return new SuccessResult(Messages.CarImageUpdate);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }


        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        private IResult CheckIfCarImagesMoreThanFive(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImagesMoreThanFive);
            }

            return new SuccessResult();
        }
    }
}