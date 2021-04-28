using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
  public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
  {
    public List<RentalDetailDto> GetRentalDetails()
    {
      using (ReCapContext context = new ReCapContext())
      {
        var result = from r in context.Rentals
                     join u in context.Users
                     on r.CustomerId equals u.Id
                     join c in context.Cars
                     on r.CarId equals c.Id
                     join b in context.Brands
                     on c.BrandId equals b.Id
                     select new RentalDetailDto
                     {
                       CarId = c.Id,
                       UserId = u.Id,
                       FirstName = u.FirstName,
                       LastName = u.LastName,
                       BrandName = b.Name
                     };
        return result.ToList();
      }
    }
  }
}
