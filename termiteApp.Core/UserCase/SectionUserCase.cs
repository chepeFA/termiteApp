using System;
using System.Collections.Generic;
using System.Text;
using termiteApp.Core.Domain;
using termiteApp.Core.Interfaces;

namespace termiteApp.Core.UserCase
{

    public class SectionUserCase : ISectionUserCase
    {
        private readonly ISectionUserCase _repository;

        //constructor
        public SectionUserCase(ISectionUserCase repository)
        {
            _repository = (repository != null) ? repository : throw new ArgumentException(nameof(repository));
        }

        public Section GetSection(Section model)
        {
            return _repository.GetSection(model);
        }

        //method to validate insertion of a section
        public Section insertSection(Section model)
        {
            if(model!=null && model.sctName!= null && model.sctDescription!=null)
            {
                return _repository.insertSection(model);
            }
            //insert was not succesful
            throw new ArgumentNullException("Incompleted data");
        }

        //method to update a section 
        public Section updateSection(Section model)
        {

        }

    }
}

