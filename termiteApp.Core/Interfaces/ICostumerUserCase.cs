using System;
using System.Collections.Generic;
using System.Text;
using termiteApp.Core.Domain;

namespace termiteApp.Core.Interfaces
{
   public interface ICostumerUserCase
    {
        Costumer GetCostumer(Costumer model);

        IEnumerable<Costumer> ObtainCostumer();
        Costumer InsertCostumer(Costumer model);

        Costumer UpdateCostumer(Costumer model);

     //   Costumer DeleteCostumer(Costumer model);

    }
}
