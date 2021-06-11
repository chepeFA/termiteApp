using System;
using System.Collections.Generic;
using System.Text;
using termiteApp.Core.Domain;
using termiteApp.Core.Interfaces;

namespace termiteApp.Core.UserCase
{
    public class StateUserCase : IStateUserCase
    {
        private readonly IStateRepository _repository;

        //constructor
        public StateUserCase(IStateRepository repository)
        {
            _repository = (repository != null) ? repository : throw new ArgumentException(nameof(repository));
        }


        public State GetState(State model)
        {
            return _repository.GetState(model);
        }

        //method to validate insertion of a state
        public State InsertState(State model)
        {
            if (model != null && model.staName != null)
            {
                return _repository.InsertState(model);
            }
            //insert was not succesful
            throw new ArgumentNullException("Incompleted data");
        }

        //method validate the update of a state
        public State UpdateState(State model)
        {
            if (model != null && model.staId > 0 && model.staName != null) //name and description can be null?
            {
                return _repository.UpdateState(model);
            }
            throw new ArgumentNullException("Incompleted data");
        }

        //when user is about to delete a section
        public State DeleteState(State model)
        {
            if (model != null && model.staId > 0) //name and description can be null?
            {
                return _repository.DeleteState(model);
            }
            throw new ArgumentNullException("Incompleted data");
        }

        public IEnumerable<State> ObtainState()
        {
            return _repository.ObtainState();
        }


    }
}
