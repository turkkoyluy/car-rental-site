using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarProjectDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (CarProjectDbContext context = new CarProjectDbContext())
            {
                
                var result = from c in context.Cars

                             join co in context.Colors
                             on c.ColorId equals co.ColorId

                             join b in context.Brands
                             on c.BrandId equals b.BrandId into carBrand
                             from cb in carBrand.DefaultIfEmpty()

                             join image in context.CarImages
                             on c.CarId equals image.CarId into carImages
                             from ci in carImages.DefaultIfEmpty()

                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandName = cb.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ImagePaths = ci != null && ci.ImagePath != null
                                                    ? new List<string> { ci.ImagePath}
                                                        : new List<string> { "default.jpg" }
                             };
                return result.ToList();
            }
        }
    }
}
