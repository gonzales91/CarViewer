using System.Collections.Generic;
using System.Linq;

namespace CarsViewer.Models
{
    public static class CarsInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Cars.Any())
            {
                context.AddRange(
                new Car { Cars = "BMW", Color = "BLACK" },
                new Car { Cars = "OPEL", Color = "SILVER" },
                new Car { Cars = "AUDI", Color = "SILVER" },
                new Car { Cars = "FIAT", Color = "WHITE" },
                new Car { Cars = "SKODA", Color = "BLUE" },
                new Car { Cars = "MERCEDES", Color = "GRAY" },
                new Car { Cars = "MAZDA", Color = "BLACK" },
                new Car { Cars = "DODGE", Color = "RED" },
                new Car { Cars = "TOYOTA", Color = "GREEN" });

                context.SaveChanges();
            }
            
        }
    }
}
