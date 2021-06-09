using System;
using System.Collections.Generic;
using System.Text;
using termiteApp.Core.Domain;
using termiteApp.Core.Interfaces;

namespace termiteApp.Core.UserCase
{

    public class SectionUserCase : ISectionUserCase
    {
        private readonly ISectionRepository _repository;

        //constructor
        public SectionUserCase(ISectionRepository repository)
        {
            _repository = (repository != null) ? repository : throw new ArgumentException(nameof(repository));
        }

        public Section GetSection(Section model)
        {
            return _repository.GetSection(model);
        }

        //method to validate insertion of a section
        public Section InsertSection(Section model)
        {
            if(model!=null && model.SctName!= null && model.SctDescription!=null)
            {
                return _repository.InsertSection(model);
            }
            //insert was not succesful
            throw new ArgumentNullException("Incompleted data");
        }

        //method to update a section 
        public Section UpdateSection(Section model)
        {
            if(model!=null && model.SctId> 0 && model.SctName !=null && model.SctDescription != null) //name and description can be null?
            {
                return _repository.UpdateSection(model);
            }
            throw new ArgumentNullException("Incompleted data");
        }

        //when user is about to delete a section
        public Section deleteSection(Section model)
        {
            if (model != null && model.SctId > 0) //name and description can be null?
            {
                return _repository.deleteSection(model);
            }
            throw new ArgumentNullException("Incompleted data");
        }

        public IEnumerable<Section> obtainSection()
        {
            return _repository.ObtainSection();
        }



    }
}

