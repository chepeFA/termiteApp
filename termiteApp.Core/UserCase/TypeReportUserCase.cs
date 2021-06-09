using System;
using System.Collections.Generic;
using System.Text;
using termiteApp.Core.Domain;
using termiteApp.Core.Interfaces;


namespace termiteApp.Core.UserCase
{
    public class TypeReportUserCase: ITypeReportUserCase
    {
        private readonly ITypeReportRepository _repository;

        //constructor
        public TypeReportUserCase(ITypeReportRepository repository)
        {
            _repository = (repository != null) ? repository : throw new ArgumentException(nameof(repository));
        }

        public TypeReport GetTypeReport(TypeReport model)
        {
            return _repository.GetTypeReport(model);
        }

        //method to validate insertion of a type of report
        public TypeReport InsertTypeReport(TypeReport model)
        {
            if (model != null && model.trpName != null && model.trpDescription != null)
            {
                return _repository.InsertTypeReport(model);
            }
            //data is completed i.e. name or description is missing
            throw new ArgumentNullException("Incompleted data");
        }

        //method to update a type of report
        public TypeReport UpdateTypeReport(TypeReport model)
        {
            if (model != null && model.trpId> 0 && model.trpName != null && model.trpDescription != null) //name and description can be null?
            {
                return _repository.UpdateTypeReport(model);
            }
            throw new ArgumentNullException("Incompleted data");
        }

        //when user is about to delete a type of report
        public TypeReport DeleteTypeReport(TypeReport model)
        {
            if (model != null && model.trpId > 0) //name and description can be null?
            {
                return _repository.DeleteTypeReport(model);
            }
            throw new ArgumentNullException("Incompleted data");
        }

        public IEnumerable<TypeReport> ObtainTypeReport()
        {
            return _repository.ObtainTypeReport();
        }
    }
}
