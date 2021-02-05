using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=187000, Description="Doktordan Temiz", ModelYear=2015},
                new Car{Id=2, BrandId=2, ColorId=2, DailyPrice=200000, Description="Bayandan Temiz", ModelYear=2019},
                new Car{Id=3, BrandId=1, ColorId=2, DailyPrice=400000, Description="Öğretmenden Temiz", ModelYear=2020},
                new Car{Id=4, BrandId=2, ColorId=3, DailyPrice=355000, Description="TR'de İlk", ModelYear=1995},
                new Car{Id=5, BrandId=1, ColorId=3, DailyPrice=275000, Description="Keyfe Keder Satılık", ModelYear=2000},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            Car car= _cars.SingleOrDefault(c=>c.Id==id);
            return car;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=>c.Id==car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
