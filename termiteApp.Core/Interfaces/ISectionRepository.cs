using System;
using System.Collections.Generic;
using System.Text;
using termiteApp.Core.Domain;

namespace termiteApp.Core.Interfaces
{
   public interface ISectionRepository
    {
        //contract to be used for section repository
        Section insertSection(Section model);

        Section updateSection(Section model);

        Section GetSection(Section model);

        IEnumerable<Section> obtainSection();

      //  Section deleteSection(Section model);

        //IEnumerable<>
    }
}
