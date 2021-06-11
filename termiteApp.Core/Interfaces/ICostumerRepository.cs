using System;
using System.Collections.Generic;
using System.Text;
using termiteApp.Core.Domain;
namespace termiteApp.Core.Interfaces
{
    public interface ICostumerRepository
    {
        //contract to be used for section repository
        Costumer InsertCostumer(Costumer model);

        Costumer UpdateCostumer(Costumer model);

        Costumer GetCostumer(Costumer model);

        IEnumerable<Costumer> ObtainCostumer();


       // Costumer DeleteCostumer(Costumer model);
    }
}
