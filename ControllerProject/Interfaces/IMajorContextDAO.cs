using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControllerProject.Models;

namespace ControllerProject.Interfaces
{
    public interface IMajorContextDAO
    {
        List<UCMajors> GetAllMajors();

        UCMajors GetMajor(int id);
        int? RemoveMajor(int id);
        int? UpdateMajor(UCMajors major);
        int? Add(UCMajors major);
    }
}

