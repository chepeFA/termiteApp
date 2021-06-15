using System;
using System.Collections.Generic;
using System.Text;
using termiteApp.Core.Domain;

namespace termiteApp.Core.Interfaces
{
    public interface IBuildingUserCase
    {
        Building GetBulding(Building model);

        IEnumerable<Building> ObtainBuilding();
        Building InsertBuilding(Building model);

        Building UpdateBuilding(Building model);

        Building DeleteBuilding(Building model);
    }
}
