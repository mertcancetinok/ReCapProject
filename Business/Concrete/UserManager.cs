using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Business.Constants;
using Entities.DTOs;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Update(UserForUpdateDto userForUpdate)
        {
            if (userForUpdate.NewPassword.Length>0)
            {
                if (!HashingHelper.VerifyPasswordHash(userForUpdate.Password, userForUpdate.PasswordHash, userForUpdate.PasswordSalt))
                {
                    return new ErrorDataResult<User>(Messages.PasswordError);
                }
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(userForUpdate.NewPassword, out passwordHash, out passwordSalt);
                userForUpdate.PasswordHash = passwordHash;
                userForUpdate.PasswordSalt = passwordSalt;
                var user = new User
                {
                    Id = userForUpdate.Id,
                    FirstName = userForUpdate.FirstName,
                    LastName = userForUpdate.LastName,
                    Email = userForUpdate.Email,
                    PasswordHash = userForUpdate.PasswordHash,
                    PasswordSalt = userForUpdate.PasswordSalt


                };
                _userDal.Update(user);
                return new SuccessResult(Messages.UserUpdated);

            }
            else
            {
                var user = new User
                {
                    Id = userForUpdate.Id,
                    FirstName = userForUpdate.FirstName,
                    LastName = userForUpdate.LastName,
                    Email = userForUpdate.Email,
                    PasswordHash = userForUpdate.PasswordHash,
                    PasswordSalt = userForUpdate.PasswordSalt


                };
                _userDal.Update(user);
                return new SuccessResult(Messages.UserUpdated);
            }
            
        }
    }
}
