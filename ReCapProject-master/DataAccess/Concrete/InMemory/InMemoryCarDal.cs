using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>() {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=150,ModelYear=2021,Description="Bmw 2021 model " },
                new Car{CarId=2,BrandId=1,ColorId=1,DailyPrice=100,ModelYear=2022,Description="Bmw 2022 model " },
                new Car{CarId=3,BrandId=1,ColorId=2,DailyPrice=250,ModelYear=2021,Description="Audi 2021 model " },
                new Car{CarId=4,BrandId=2,ColorId=3,DailyPrice=250,ModelYear=2023,Description="Audi 2023 model " },
                new Car{CarId=5,BrandId=2,ColorId=3,DailyPrice=100,ModelYear=2024,Description="Porshe 2024 model " },
                new Car{CarId=6,BrandId=3,ColorId=4,DailyPrice=129,ModelYear=2023,Description="Porshe 2023 model " }
            };

        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(_car => _car.CarId == car.CarId);
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

        public List<CarDetailDto> GetCarDetail()
        {
            throw new NotImplementedException();
        }

        public Car GetCarsByBrandId(int brandId)
        {
            var result = _cars.Find(c => c.BrandId == brandId);
            return result;
        }

        public void Update(Car car)
        {
            Car updatedCar = _cars.FirstOrDefault(c => c.CarId == car.CarId);
            updatedCar.Description = car.Description;
            updatedCar.DailyPrice = car.DailyPrice;
            updatedCar.ModelYear = car.ModelYear;
            updatedCar.BrandId = car.BrandId;
            updatedCar.ColorId = car.ColorId;

        }
    }
}
