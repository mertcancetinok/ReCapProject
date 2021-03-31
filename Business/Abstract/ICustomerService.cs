using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer entity);
        IResult Delete(Customer entity);
        IResult Update(Customer entity);
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int customerId);
    }
}
