using System;
using System.Collections.Generic;
using System.Text;
using termiteApp.Core.Domain;

namespace termiteApp.Core.Interfaces
{
    public interface IBuildingRepository
    {
        Building InsertBuilding(Building model);

        Building UpdateBuilding(Building model);

        Building GetBuilding(Building model);

        IEnumerable<Building> ObtainBuilding();


        Building DeleteBuilding(Building model);
    }
}
