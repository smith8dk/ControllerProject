using System;
using System.Collections.Generic;
using System.Linq;
using ControllerProject.Interfaces;
using ControllerProject.Models;
using System.Threading.Tasks;

namespace ControllerProject.Data
{
    public class WonderContextDAO : IWonderContextDAO
    {
        private WonderContext _context;
        public WonderContextDAO(WonderContext context)
        {
            _context = context;
        }

        public int? Add(Wonders wonder)
        {
            var wonders = _context.Wonders.Where(x => wonder.Name.Equals(wonder.Name)).FirstOrDefault();
            if (wonder == null)
            {
                return null;
            }
            try
            {
                _context.Wonders.Add(wonder);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<Wonders> GetAllWonders()
        {
            return _context.Wonders.ToList();
        }

        public Wonders GetWonder(int id)
        {
            return _context.Wonders.Where(x => id.Equals(id)).FirstOrDefault();
        }

        public int? RemoveWonder(int id)
        {
            var result = this.GetWonder(id);
            if (result == null) return null;

            try
            {
                _context.Wonders.Remove(result);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int? UpdateWonder(Wonders wonder)
        {
            var wonderToUpdate = GetWonder(wonder.Id);
            if (wonderToUpdate == null)
            {
                return null;
            }
            wonderToUpdate.Name = wonder.Name;
            wonderToUpdate.Location = wonder.Location;
            wonderToUpdate.TouristPerYear = wonder.TouristPerYear;
            wonderToUpdate.YearCreated = wonder.YearCreated;
            try
            {
                _context.Wonders.Update(wonderToUpdate);
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
