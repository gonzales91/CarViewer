using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarsViewer.Models
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _appDbContext;

        public CarRepository(AppDbContext AppDbContext)
        {
            _appDbContext = AppDbContext;
        }

        public void AddCar(Car car)
        {
            _appDbContext.Cars.Add(car);
            _appDbContext.SaveChanges();
        }

        public void DeleteCar(Car car)
        {
            _appDbContext.Cars.Remove(car);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Car> GetAllCars()
        {
            //if (_appDbContext.Cars.Any())
                return _appDbContext.Cars;

        //    _appDbContext.AddRange(CarsInitializer.Initialize());
        //    _appDbContext.SaveChanges();
        //    return _appDbContext.Cars;
        }

        public Car GetCarById(int carId)
        {
            return _appDbContext.Cars.FirstOrDefault(i => i.Id == carId);
        }

        public void UpdateCar(Car car)
        {
            _appDbContext.Update(car);
            _appDbContext.SaveChanges();
        }

        public List<ColorUsagePercent> ColorUsagePercent()
        {
            var carUsageList = new List<ColorUsagePercent>();

            using (var command = _appDbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"select Color, count(*) * 100 / (select(count(*)) from Cars) AS ColorUsagePercent from Cars group by Color";
                _appDbContext.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while(result.Read())
                    {
                        string color = Convert.ToString(result["Color"]);
                        int percent = Convert.ToInt32(result["ColorUsagePercent"]);

                        carUsageList.Add(new ColorUsagePercent { Color = color, Percent = percent });
                    }
                }

                _appDbContext.Database.CloseConnection();
            }

            return carUsageList;
        }

        public List<CarUsagePercent> CarUsage()
        {
            var carUsageList = new List<CarUsagePercent>();

            using (var command = _appDbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"select Cars, count(*)  AS CarUsage from Cars group by Cars";
                _appDbContext.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        string car = Convert.ToString(result["Cars"]);
                        int usage = Convert.ToInt32(result["CarUsage"]);

                        carUsageList.Add(new CarUsagePercent { Car = car, Usage = usage });
                    }
                }

                _appDbContext.Database.CloseConnection();
            }

            return carUsageList;
        }        
    }
}
