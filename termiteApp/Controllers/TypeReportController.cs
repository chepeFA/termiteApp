using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using termiteApp.Core.Interfaces;
using termiteApp.Api.Commond.Responses;
using termiteApp.Core.Domain;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace termiteApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    //constructor
    public class TypeReportController: ControllerBase
    {
        private readonly ITypeReportUserCase _userCase;

        public TypeReportController(ITypeReportUserCase userCase)
        {
            _userCase = (userCase != null) ? userCase : throw new ArgumentNullException(nameof(userCase));
        }

        [HttpGet("GetTypeReport")]
        public GenericListResponse<TypeReport> GetTypeReport()
        {
            GenericListResponse<TypeReport> reponse;
            try
            {
                reponse = new GenericListResponse<TypeReport>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Items = _userCase.ObtainTypeReport()
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericListResponse<TypeReport>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }

        [HttpGet("GetTypeReportModel")]
        public GenericResponse<TypeReport> GetTypeReportModel(int id)
        {
            GenericResponse<TypeReport> reponse;
            try
            {
                reponse = new GenericResponse<TypeReport>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.GetTypeReport(new TypeReport() { trpId = id })
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<TypeReport>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }

        [HttpPost("UpdateTypeReport")]
        public GenericResponse<TypeReport> updateTR(TypeReport model)
        {
            GenericResponse<TypeReport> reponse;
            try
            {
                reponse = new GenericResponse<TypeReport>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.UpdateTypeReport(model)
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<TypeReport>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }

        [HttpPost("InsertTypeReport")]
        public GenericResponse<TypeReport> insertTR(TypeReport model)
        {
            GenericResponse<TypeReport> reponse;
            try
            {
                reponse = new GenericResponse<TypeReport>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.InsertTypeReport(model)
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<TypeReport>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }

        [HttpPost("DeleteTypeReport")]
        public GenericResponse<TypeReport> deleteTR(TypeReport model)
        {
            GenericResponse<TypeReport> reponse;
            try
            {
                reponse = new GenericResponse<TypeReport>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.DeleteTypeReport(model)
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<TypeReport>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }

    }
}
