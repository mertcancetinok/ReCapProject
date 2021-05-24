using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User entity);
        IResult Delete(User entity);
        IResult Update(UserForUpdateDto userForUpdate);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        IDataResult<User> GetByEmail(string email);
        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}
