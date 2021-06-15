using System;
using System.Collections.Generic;
using System.Text;
using termiteApp.Core.Domain;
using termiteApp.Core.Interfaces;

namespace termiteApp.Core.UserCase
{
   public class BuildingUserCase: IBuildingUserCase
    {
        private readonly IBuildingRepository _repository;

        //constructor
        public BuildingUserCase(IBuildingRepository repository)
        {
            _repository = (repository != null) ? repository : throw new ArgumentException(nameof(repository));
        }

        public Building GetBulding(Building model)
        {
            return _repository.GetBuilding(model);
        }

        public Building InsertBuilding(Building model)
        {
            if (model != null && model.bldName != null)
            {
                return _repository.InsertBuilding(model);
            }
            //insert was not succesful
            throw new ArgumentNullException("Incompleted data");
        }

        public Building UpdateBuilding(Building model)
        {
            if (model != null && model.bldId > 0 && model.bldName != null) //name and description can be null?
            {
                return _repository.UpdateBuilding(model);
            }
            throw new ArgumentNullException("Incompleted data");
        }

        public Building DeleteBuilding(Building model)
        {
            if (model != null && model.bldId > 0) //name and description can be null?
            {
                return _repository.DeleteBuilding(model);
            }
            throw new ArgumentNullException("Incompleted data");
        }

        public IEnumerable<Building> ObtainBuilding()
        {
            return _repository.ObtainBuilding();
        }


    }
}
