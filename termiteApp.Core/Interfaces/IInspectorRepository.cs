using System;
using System.Collections.Generic;
using System.Text;
using termiteApp.Core.Domain;

namespace termiteApp.Core.Interfaces
{
  public interface IInspectorRepository
    {
        //contract to be used for inspector repository
        Inspector InsertInspector(Inspector model);

        Inspector UpdateInspector(Inspector model);

        Inspector GetInspector(Inspector model);

        IEnumerable<Inspector> ObtainInspector();

    }
}
