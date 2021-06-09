using System;
using System.Collections.Generic;
using System.Text;
using termiteApp.Core.Domain;
namespace termiteApp.Core.Interfaces
{
   public interface ITypeReportRepository
    {
        TypeReport InsertTypeReport(TypeReport model);

        TypeReport UpdateTypeReport(TypeReport model);

        TypeReport DeleteTypeReport(TypeReport model);

        TypeReport GetTypeReport(TypeReport model);

        IEnumerable<TypeReport> ObtainTypeReport();


      //  TypeReport TypeReport(TypeReport model);
    }
}
