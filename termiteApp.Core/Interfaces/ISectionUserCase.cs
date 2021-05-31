using System;
using System.Collections.Generic;
using System.Text;
using termiteApp.Core.Domain;

namespace termiteApp.Core.Interfaces
{
   public interface ISectionUserCase
    {
        Section insertSection(Section model);

        Section updateSection(Section model);

      //  Section deleteSection(Section model);

        Section GetSection(Section model);

        IEnumerable<Section> obtainSection();


    }
}
