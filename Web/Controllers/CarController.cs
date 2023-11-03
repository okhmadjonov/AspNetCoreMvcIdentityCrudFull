using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Domain.Dtos;
using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CarController : Controller
    {

        private readonly IAuthorizationPolicyProvider _policyProvider;
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        public CarController( ICarRepository genericRepository, IMapper mapper, IAuthorizationPolicyProvider policyProvider)
        {
           
            _carRepository = genericRepository;
            _mapper = mapper;
            _policyProvider = policyProvider;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var cars = _carRepository.GetAll();
            return View(cars);
        }

        [HttpGet]
        public IActionResult AddCar() { 
        
            return View();
        }


        // Add Car
        [HttpPost] 
        public IActionResult AddCar(Car car)
        {
            _carRepository.Add(car);

            return RedirectToAction("Index");
        }


        // Delete Car
        [Authorize(Policy = "admin")]
        public IActionResult Delete(int id)
        {
            if (!HttpContext.User.IsInRole("admin"))
            {
                return Forbid();
            }

            _carRepository.Delete(id);
            return RedirectToAction("Index");
        }



        //Get Sinle car
        [HttpGet]
        public IActionResult Edit(int id) {
            var car = _carRepository.FindById(id);
            var carDto = new CarDto
            {
                Name = car.Name,
                Price = car.Price,

            };
           return View(carDto);
        }


        //Edit car
        [HttpPost]
        public IActionResult Edit(Car car)
        {
            if (car == null)
            {
                return BadRequest("The CarDto object is required.");
            }

            _carRepository.Edit(car);
            return RedirectToAction("Index");
        }



    }
}
