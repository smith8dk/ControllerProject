using System;
using System.Collections.Generic;
using System.Linq;
using ControllerProject.Models;
using System.Threading.Tasks;

namespace ControllerProject.Interfaces
{
    public interface ICountryContextDAO 
    {
        List<Countries> GetAllCountries();

        Countries GetCountry(int id);
        int? RemoveCountry(int id);
        int? UpdateCountry(Countries country);
        int? Add(Countries country);

    }
}
