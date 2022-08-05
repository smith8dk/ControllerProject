using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControllerProject.Data;
using ControllerProject.Interfaces;
using ControllerProject.Models;

namespace ControllerProject.Data
{
    public class NamesContextDAO : INameContextDAO
    {

        private NamesContext _context;
        public NamesContextDAO(NamesContext context)
        {
            _context = context;
        }

        public int? Add(Names name)
        {
            var names = _context.Names.Where(x => name.FullName.Equals(name.FullName)).FirstOrDefault();
            if(name == null)
            {
                return null;
            }
            try
            {
                _context.Names.Add(name);
                _context.SaveChanges();
                return 1;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public List<Names> GetAllTeams()
        {
            return _context.Names.ToList();
        }

        public Names GetTeam(int id)
        {
            return _context.Names.Where(x => id.Equals(id)).FirstOrDefault();
        }

        public int? RemoveTeam(int id)
        {
            var result = this.GetTeam(id);
            if (result == null) return null;
            
            try
            {
                _context.Names.Remove(result);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int? UpdateName(Names name)
        {
            var nameToUpdate = GetTeam(name.Id);
            if(nameToUpdate == null)
            {
                return null;
            }
            nameToUpdate.FullName = name.FullName;
            nameToUpdate.Birthdate = name.Birthdate;
            nameToUpdate.CollegeProgram = name.CollegeProgram;
            nameToUpdate.Year = name.Year;
            try
            {
                _context.Names.Update(nameToUpdate);
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
