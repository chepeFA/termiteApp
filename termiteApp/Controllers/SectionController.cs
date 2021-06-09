using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using termiteApp.Core.Interfaces;
using termiteApp.Api.Commond.Responses;
using termiteApp.Core.Domain;
using System.Net;

namespace termiteApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SectionController: ControllerBase
    {
        private readonly ISectionUserCase _userCase;

        public SectionController(ISectionUserCase userCase)
        {
            _userCase = (userCase != null) ? userCase : throw new ArgumentNullException(nameof(userCase));
        }

        [HttpGet("GetSection")]
        public GenericListResponse<Section> GetLista()
        {
            GenericListResponse<Section> reponse;
            try
            {
                reponse = new GenericListResponse<Section>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Items = _userCase.obtainSection()
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericListResponse<Section>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }

        [HttpGet("GetSectionModel")]
        public GenericResponse<Section> GetListaModel(int id)
        {
            GenericResponse<Section> reponse;
            try
            {
                reponse = new GenericResponse<Section>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.GetSection(new Section() { SctId = id })
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<Section>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }

        [HttpPost("UpdateSection")]
        public GenericResponse<Section> modificarLista(Section model)
        {
            GenericResponse<Section> reponse;
            try
            {
                reponse = new GenericResponse<Section>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.UpdateSection(model)
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<Section>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }

        [HttpPost("InsertSection")]
        public GenericResponse<Section> insertarLista(Section model)
        {
            GenericResponse<Section> reponse;
            try
            {
                reponse = new GenericResponse<Section>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.InsertSection(model)
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<Section>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }

        [HttpPost("DeleteSection")]
        public GenericResponse<Section> deleteSection(Section model)
        {
            GenericResponse<Section> reponse;
            try
            {
                reponse = new GenericResponse<Section>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.deleteSection(model)
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<Section>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }


    }
}
