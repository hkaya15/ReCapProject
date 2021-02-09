﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarCompanyContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarCompanyContext context=new CarCompanyContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 CarId=c.Id,
                                 BrandName=b.BrandName,
                                 ColorName=co.ColorName,
                                 Description=c.Description,
                                 DailyPrice=c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
