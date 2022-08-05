using ControllerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.Interfaces
{
    public interface INameContextDAO
    {
        List<Names> GetAllTeams();

        Names GetTeam(int id);
        int? RemoveTeam(int id);
        int? UpdateName(Names name);
        int? Add(Names name);
    }
}
