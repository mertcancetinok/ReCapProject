﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult Add(Brand entity);
        IResult Delete(Brand entity);
        IResult Update(Brand entity);
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(int brandId);
    }
}
