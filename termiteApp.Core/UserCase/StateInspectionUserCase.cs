using System;
using System.Collections.Generic;
using System.Text;
using termiteApp.Core.Domain;
using termiteApp.Core.Interfaces;

namespace termiteApp.Core.UserCase
{
    public class StateInspectionUserCase : IStateInspectionUserCase
    {
        private readonly IStateSectionRepository _repository;

        //constructor
        public StateInspectionUserCase(IStateSectionRepository repository)
        {
            _repository = (repository != null) ? repository : throw new ArgumentException(nameof(repository));
        }

        public StateInspection GetStateInspection(StateInspection model)
        {
            return _repository.GetStateInspection(model);
        }

        //method to validate insertion of a StateInspection
        public StateInspection InsertStateInspection(StateInspection model)
        {
            if (model != null && model.sinsName != null && model.sinsDescription != null)
            {
                return _repository.InsertStateInspection(model);
            }
            //insert was not succesful
            throw new ArgumentNullException("Incompleted data");
        }


        //method to validate the update of a StateInspection
      
        public StateInspection UpdateStateInspection(StateInspection model)
        {
            if(model!=null && model.sinsId> 0 && model.sinsName !=null && model.sinsDescription != null) //name and description can be null?
            {
                return _repository.UpdateStateInspection(model);
            }
            throw new ArgumentNullException("Incompleted data");
        }
        //when user is about to delete a state inspection
        public StateInspection DeleteStateInspection(StateInspection model)
        {
            if (model != null && model.sinsId > 0) //name and description can be null?
            {
                return _repository.DeleteStateInspection(model);
            }
            throw new ArgumentNullException("Incompleted data");
        }

        public IEnumerable<StateInspection> ObtainStateInspection()
        {
            return _repository.ObtainStateInspection();
        }

    }
}
