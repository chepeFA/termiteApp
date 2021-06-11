using System;
using System.Collections.Generic;
using System.Text;
using termiteApp.Core.Domain;

namespace termiteApp.Core.Interfaces
{
   public interface IStateRepository
    {
        State InsertState(State model);

        State UpdateState(State model);

        State GetState(State model);

        IEnumerable<State> ObtainState();


        State DeleteState(State model);
    }
}
