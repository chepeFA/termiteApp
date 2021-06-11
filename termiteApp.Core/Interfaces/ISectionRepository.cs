using System;
using System.Collections.Generic;
using System.Text;
using termiteApp.Core.Domain;
namespace termiteApp.Core.Interfaces
{
    public interface ISectionRepository
    {
        //contract to be used for section repository
        Section InsertSection(Section model);

        Section UpdateSection(Section model);

        Section GetSection(Section model);

        IEnumerable<Section> ObtainSection();


        Section deleteSection(Section model);
    }
}
