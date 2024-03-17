using Application.Interfaces.CarInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _carBookContext;
        public CarRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }
        public List<Car> GetCarListWithBrands()
        {
            var values = _carBookContext.Cars.Include(x => x.Brand).ToList();
            return values;
        }
    }
}
