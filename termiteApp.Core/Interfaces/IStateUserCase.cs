using System;
using System.Collections.Generic;
using System.Text;
using termiteApp.Core.Domain;

namespace termiteApp.Core.Interfaces
{
    public interface IStateUserCase
    {
        State GetState(State model);

        IEnumerable<State> ObtainState();
        State InsertState(State model);

        State UpdateState(State model);

        State DeleteState(State model);

    }
}
