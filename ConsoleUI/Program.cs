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
            //carManager.Add(new Car{BrandId = 2, ColorId = 1, DailyPrice = 0, Description = "H", ModelYear = 2018 });

             CarDetailTest(carManager);
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            // brandManager.Add(new Brand {BrandName="Ferrari"});
            //foreach (var brand in brandManager.GetById(1002))
            //{
            //    Console.WriteLine(brand.BrandName);
            //}

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
