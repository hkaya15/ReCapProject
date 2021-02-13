using Business.Concrete;

using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            // CarDetailTest(carManager);

            Rental r = new Rental();
            r.CarId = 3;
            r.RentDate = DateTime.Now;
            r.CustomerId = 1;
            var result=rentalManager.Add(r);

            if (result.IsSuccess == true)
            {
                foreach (var item in rentalManager.GetAll().Data)
                {
                    Console.WriteLine(item.RentDate);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }





        }



        private static void CarDetailTest(CarManager carManager)
        {
            Console.WriteLine("*************************");
            var result = carManager.GetCarDetails();

            if (result.IsSuccess == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Id: {0} Marka: {1} Renk: {2} Açıklama: {3} Fiyat: {4} ", car.CarId, car.BrandName, car.ColorName, car.Description, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }




        }
    }
  
}
