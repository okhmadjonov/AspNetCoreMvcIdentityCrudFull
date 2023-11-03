using DataContext.Context;
using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Services
{
   public class GenericService<T> : IGenericRepository<T> where T : class
    {
        public readonly AppDbContext _context;
        public GenericService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var car = FindById(id);
            _context.Remove<T>(car); 
            _context.SaveChanges();
        }

        public void Edit(Car car)
        {
            _context.Cars.Update(car);
            _context.SaveChanges();
        }

        public T FindById(int id)
        {
           return _context.Find<T>(id);
            
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

     
    }
}
