using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControllerProject.Interfaces;
using ControllerProject.Models;

namespace ControllerProject.Data
{
    public class CountryContextDAO : ICountryContextDAO
    {
        private CountryContext _context;

        public CountryContextDAO(CountryContext context)
        {
            _context = context;
        }

        public int? Add(Countries country)
        {
            var countries = _context.Countries.Where(x => country.CountryName.Equals(country.CountryName)).FirstOrDefault();
            if (country == null)
            {
                return null;
            }
            try
            {
                _context.Countries.Add(country);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<Countries> GetAllCountries()
        {
            return _context.Countries.ToList();
        }

        public Countries GetCountry(int id)
        {
            return _context.Countries.Where(x => id.Equals(id)).FirstOrDefault();
        }

        public int? RemoveCountry(int id)
        {
            var result = this.GetCountry(id);
            if (result == null) return null;

            try
            {
                _context.Countries.Remove(result);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int? UpdateCountry(Countries country)
        {
            var countryToUpdate = GetCountry(country.Id);
            if (countryToUpdate == null)
            {
                return null;
            }
            countryToUpdate.CountryName = country.CountryName;
            countryToUpdate.Capital = country.Capital;
            countryToUpdate.Population = country.Population;
            countryToUpdate.Continent = country.Continent;
            try
            {
                _context.Countries.Update(countryToUpdate);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
