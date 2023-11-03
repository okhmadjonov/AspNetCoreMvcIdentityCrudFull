using DataContext.Context;
using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Services
{
    public class CarService : GenericService<Car>, ICarRepository 
    {
        public CarService(AppDbContext context) :base(context) { }
        
            
        
    }
}
