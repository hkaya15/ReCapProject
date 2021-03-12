using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarCompanyContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentedCarDetail(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarCompanyContext context = new CarCompanyContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.Id
                             join b in context.Brands
                             on car.BrandId equals b.Id

                             join cus in context.Customers
                             on rental.CustomerId equals cus.Id

                             join us in context.Users
                             on cus.UserId equals us.Id

                             select new RentalDetailDto
                             {
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,
                                 CompanyName = cus.CompanyName,
                                 BrandName = b.BrandName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate

                             };
                return result.ToList();




            }

        }
    }
}
