using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            carManager.Add(new Entities.Concrete.Car { Id = 6, BrandId = 2, ColorId = 1, DailyPrice = 150.00, Description = "Hatasızzz", ModelYear = 2018 });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("*************************");

            carManager.Delete(new Entities.Concrete.Car { Id = 6, BrandId = 2, ColorId = 1, DailyPrice = 150.00, Description = "Hatasızzz", ModelYear = 2018 });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear);
            }
            Console.WriteLine("*************************");

            carManager.Update(new Entities.Concrete.Car { Id = 5, BrandId = 2, ColorId = 1, DailyPrice = 150.00, Description = "Hatasızzz", ModelYear = 2018 });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear);
            }

            Console.WriteLine("*************************");

            Car car1 =carManager.GetById(3);
            Console.WriteLine(car1.Id+" "+car1.BrandId+" "+car1.ColorId+" "+car1.DailyPrice+" "+car1.Description+" "+car1.ModelYear);
           
        }
    }
}
