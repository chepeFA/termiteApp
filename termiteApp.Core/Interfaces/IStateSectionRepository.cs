using System;
using System.Collections.Generic;
using System.Text;
using termiteApp.Core.Domain;

namespace termiteApp.Core.Interfaces
{
    public interface IStateSectionRepository
    {
        //contract to be used for section repository
        StateInspection InsertStateInspection(StateInspection model);

        StateInspection UpdateStateInspection(StateInspection model);

        StateInspection GetStateInspection(StateInspection model);

        IEnumerable<StateInspection> ObtainStateInspection();


        StateInspection DeleteStateInspection(StateInspection model);
    }
}
