using System;
using System.Collections.Generic;
using System.Text;
using termiteApp.Core.Domain;

namespace termiteApp.Core.Interfaces
{
    public interface IInspectorUserCase
    {
        Inspector GetInspector(Inspector model);

        IEnumerable<Inspector> ObtainInspector();
        Inspector InsertInspector(Inspector model);

        Inspector UpdateInspector(Inspector model);

    }
}
