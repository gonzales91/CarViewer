using System.Collections.Generic;

namespace CarsViewer.Models
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int carId);

        void AddCar(Car car);
        void DeleteCar(Car car);
        void UpdateCar(Car car);

        List<ColorUsagePercent> ColorUsagePercent();
        List<CarUsagePercent> CarUsage();

    }
}
