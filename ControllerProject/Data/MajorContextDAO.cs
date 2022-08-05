using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControllerProject.Interfaces;
using ControllerProject.Models;

namespace ControllerProject.Data
{
    public class MajorContextDAO : IMajorContextDAO
    {
        private MajorContext _context;

        public MajorContextDAO(MajorContext context)
        {
            _context = context;
        }

        public int? Add(UCMajors major)
        {
            var majors = _context.Majors.Where(x => major.MajorName.Equals(major.MajorName)).FirstOrDefault();
            if (major == null)
            {
                return null;
            }
            try
            {
                _context.Majors.Add(major);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<UCMajors> GetAllMajors()
        {
            return _context.Majors.ToList();
        }

        public UCMajors GetMajor(int id)
        {
            return _context.Majors.Where(x => id.Equals(id)).FirstOrDefault();
        }

        public int? RemoveMajor(int id)
        {
            var result = this.GetMajor(id);
            if (result == null) return null;

            try
            {
                _context.Majors.Remove(result);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int? UpdateMajor(UCMajors major)
        {
            var majorToUpdate = GetMajor(major.Id);
            if (majorToUpdate == null)
            {
                return null;
            }
            majorToUpdate.MajorName = major.MajorName;
            majorToUpdate.PopularityRank = major.PopularityRank;
            majorToUpdate.AverageSalary = major.AverageSalary;
            majorToUpdate.AnnualGraduates = major.AnnualGraduates;
            try
            {
                _context.Majors.Update(majorToUpdate);
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
