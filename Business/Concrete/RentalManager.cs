using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Core.Utilities.Business;
using Entities.DTOs;

namespace Business.Concrete
{

    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental entity)
        {
            IResult result = BusinessRules.Run(CheckIfCarIsNotReturn(entity));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(entity);
            return new SuccessResult(Messages.RentalAdded); 
        }
        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId));
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
        }

    public IDataResult<List<RentalDetailDto>> GetRentalDetails()
    {
      return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
    }

    public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.RentalUpdated);
        }
        private IResult CheckIfCarIsNotReturn(Rental entity)
        {
            var data = _rentalDal.GetAll(c=>c.CarId==entity.CarId);
            if (data.Any(d => d.ReturnDate > entity.RentDate) && data.Any(i => i.CarId == entity.CarId))
            {
                return new ErrorResult(Messages.CarIsNotReturn);
            }
            return new SuccessResult();
        }
    }
}
