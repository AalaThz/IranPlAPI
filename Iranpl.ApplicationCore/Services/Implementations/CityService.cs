using Iranpl.ApplicationCore.Services.Intefaces;
using Iranpl.Domain.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.ApplicationCore.Services.Implementations
{
    public class CityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository) 
        {
            _cityRepository = cityRepository;
        }

        public List<City> GetAllCities()
        {
            return _cityRepository.GetAll();
        }

        public City GetCityById(int id) 
        {
            return _cityRepository.GetById(id);
        }

        public List<City> GetCitiesByPartId(int partId)
        {
            return _cityRepository.GetCitiesByPartId(partId);
        }
    }
}
