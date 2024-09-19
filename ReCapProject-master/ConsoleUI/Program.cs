using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //CarDetailTest();
            //ColorTest();
            //BrandTest();
            //UserTest();
            //RentalTest();
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental { CarId = 2, CustomerId = 1, RentDate = System.DateTime.Today });
            rentalManager.ReturnCar(1);
            foreach (var rent in rentalManager.GetAll().Data)
            {
                Console.WriteLine("{0}|{1}|{2}|{3}|{4}", rent.RentalId, rent.CarId, rent.CustomerId, rent.RentDate, rent.ReturnDate);
            }
            Console.WriteLine("---------------------------------------");
            foreach (var rentalDetail in rentalManager.GetRentalDetail().Data)
            {
                Console.WriteLine("{0}--{1}--{2}--{3}", rentalDetail.RentalId,rentalDetail.CustomerName,rentalDetail.CarBrand,rentalDetail.CarDescription);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { FirstName = "ahmet", Email = "aaaadsds", LastName = "asdasd", Password = "asdasdasd" });
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine("{0}=>{1}", user.UserId, user.FirstName);
            }
            Console.WriteLine(userManager.GetById(1).Data.Password);
            userManager.Update(1005, new User { FirstName = "ahm2222ett", Email = "aaaadtttttdsds", LastName = "asd2222asd", Password = "asdasdasd" });
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void CarDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetail();
            foreach (var car in result.Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4} ", car.CarId, car.ColorName, car.BrandName, car.DailyPrice, car.Description);
            }
            Console.WriteLine(result.Message);
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car() { BrandId = 3, ColorId = 2, DailyPrice = 200, Description = "Porshe911", ModelYear = 2022 };
            carManager.Add(car1);
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Id : " + car.CarId + " Color Id : " +
                    car.ColorId + " Brand Id : " +
                    car.BrandId + " Model Year : " +
                    car.ModelYear + " Description : " +
                    car.Description + "\n------------------------------\n");
            }
            Console.WriteLine("GET BY ID");
            Console.WriteLine(carManager.GetById(4).Data.CarId);
            int deletedcar = Convert.ToInt32(Console.ReadLine());
            carManager.DeleteById(deletedcar);
            Car car2 = new Car() { CarId = 3, BrandId = 7, Description = "Güncellendi!", ColorId = 7, DailyPrice = 9700, ModelYear = 2024 };
            Console.WriteLine(carManager.Update(car2).Message);
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Id : " + car.CarId + " Color Id : " +
                    car.ColorId + " Brand Id : " +
                    car.BrandId + " Model Year : " +
                    car.ModelYear + " Description : " +
                    car.Description + "\n------------------------------\n");
            }
        }
    }
}
