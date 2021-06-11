using System;
using System.Collections.Generic;
using System.Text;

using termiteApp.Core.Domain;

namespace termiteApp.Core.Interfaces
{
   public interface IStateInspectionUserCase

    {
        StateInspection GetStateInspection(StateInspection model);

        IEnumerable<StateInspection> ObtainStateInspection();
        StateInspection InsertStateInspection(StateInspection model);

        StateInspection UpdateStateInspection(StateInspection model);

        StateInspection DeleteStateInspection(StateInspection model);
    }
}
