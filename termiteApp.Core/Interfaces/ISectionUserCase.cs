using System;
using System.Collections.Generic;
using System.Text;
using termiteApp.Core.Domain;

namespace termiteApp.Core.Interfaces
{
   public interface ISectionUserCase
    {
        Section GetSection(Section model);

        IEnumerable<Section> obtainSection();
        Section InsertSection(Section model);

        Section UpdateSection(Section model);

        Section deleteSection(Section model);

        

       


    }
}
