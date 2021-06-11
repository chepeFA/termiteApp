using System;
using System.Collections.Generic;
using System.Text;
using termiteApp.Core.Domain;
using termiteApp.Core.Interfaces;

namespace termiteApp.Core.UserCase
{
    public class CostumerUserCase : ICostumerUserCase
    {
        private readonly ICostumerRepository _repository;

        //constructor
        public CostumerUserCase(ICostumerRepository repository)
        {
            _repository = (repository != null) ? repository : throw new ArgumentException(nameof(repository));
        }

        public Costumer GetCostumer(Costumer model)
        {
            return _repository.GetCostumer(model);
        }

        //method to validate insertion of a costumer
        public Costumer InsertCostumer(Costumer model)
        {
            //email and agency realtor can be null
            if (model != null && model.ctmName != null && model.ctmLastName != null && model.ctmPhoneNumber != null)
            {
                return _repository.InsertCostumer(model);
            }
            //insert was not succesful
            throw new ArgumentNullException("Incompleted data");
        }

        //method to validate the update of a costumer 
        public Costumer UpdateCostumer(Costumer model)
        {
            if (model != null && model.ctmId > 0 && model.ctmName != null && model.ctmLastName != null && model.ctmPhoneNumber != null) //name and description can be null?
            {
                return _repository.UpdateCostumer(model);
            }
            throw new ArgumentNullException("Incompleted data");
        }



        //when user is about to delete a costumer
        /*
        public Costumer DeleteCostumer(Costumer model)
        {
            if (model != null && model.ctmId > 0) //name and description can be null?
            {
                return _repository.DeleteCostumer(model);
            }
            throw new ArgumentNullException("Incompleted data");
        }
        */
        public IEnumerable<Costumer> ObtainCostumer()
        {
            return _repository.ObtainCostumer();
        }
    }
}
