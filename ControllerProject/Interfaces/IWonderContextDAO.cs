using System;
using System.Collections.Generic;
using System.Linq;
using ControllerProject.Models;
using System.Threading.Tasks;

namespace ControllerProject.Interfaces
{
    public interface IWonderContextDAO
    {
        List<Wonders> GetAllWonders();

        Wonders GetWonder(int id);
        int? RemoveWonder(int id);
        int? UpdateWonder(Wonders wonder);
        int? Add(Wonders wonder);
    }
}

