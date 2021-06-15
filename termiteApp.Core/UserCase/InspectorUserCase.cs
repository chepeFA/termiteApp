using System;
using System.Collections.Generic;
using System.Text;
using termiteApp.Core.Domain;
using termiteApp.Core.Interfaces;

namespace termiteApp.Core.UserCase
{
    public class InspectorUserCase :IInspectorUserCase
    {
        private readonly IInspectorRepository _repository;

        //constructor

        public InspectorUserCase(IInspectorRepository repository)
        {
            _repository = (repository != null) ? repository : throw new ArgumentException(nameof(repository));
        }

        public Inspector GetInspector(Inspector model)
        {
            return _repository.GetInspector(model);
        }

        //method to validate insertion of a inspector
        public Inspector InsertInspector(Inspector model)
        {
            if (model != null && model.inpName != null && model.inpLastName != null && model.inpLicenseNumber != null) //&& model.inpSignature != null)
            {
                return _repository.InsertInspector(model);
            }
            //insert was not succesful
            throw new ArgumentNullException("Incompleted data");
        }

        //method to validate the update of a inspector
        public Inspector UpdateInspector(Inspector model)
        {
            if (model != null && model.inpName != null && model.inpLastName != null && model.inpLicenseNumber != null) //&& model.inpSignature != null) //name and description can be null?
            {
                return _repository.UpdateInspector(model);
            }
            throw new ArgumentNullException("Incompleted data");
        }

        public IEnumerable<Inspector> ObtainInspector()
        {
            return _repository.ObtainInspector();
        }
    }
}
