using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.AddAsync(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult();
        }

      
        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CarImageDelete(carImage));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Delete(carImage);

            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByImagesCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageIsEmpty(id));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.UpdateAsync(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, file);
            carImage.Date = DateTime.Now;

            _carImageDal.Update(carImage);

            return new SuccessResult();
        }

        private List<CarImage> CheckIfCarImageIsEmpty(int id)
        {
            //Path Combine=> https://docs.microsoft.com/tr-tr/dotnet/api/system.io.path.combine?view=net-5.0#System_IO_Path_Combine_System_String_System_String_
            //Directory GetParent => https://docs.microsoft.com/tr-tr/dotnet/api/system.io.directory.getparent?view=net-5.0
            //Directory GetCurrentDirectory => https://docs.microsoft.com/tr-tr/dotnet/api/system.io.directory.getcurrentdirectory?view=net-5.0
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName 
                + @"WebAPI/wwwroot/ImagesRepos/default.png");
            var result = _carImageDal.GetAll(c => c.CarId == id).Any();

            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };
            }

            return _carImageDal.GetAll(p => p.CarId == id);

        }

        private IResult CarImageDelete(CarImage carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        private IResult CheckIfImageLimit(int carid)
        {
            var carImagecount = _carImageDal.GetAll(p => p.CarId == carid).Count;

            if (carImagecount >=5)
            {
                return new ErrorResult(Messages.FailAddedImageLimit);
            }

            return new SuccessResult();
        }
    }
}
