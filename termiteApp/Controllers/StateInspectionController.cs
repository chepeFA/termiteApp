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
    public class StateInspectionController: ControllerBase
    {
        private readonly IStateInspectionUserCase _userCase;

        public StateInspectionController(IStateInspectionUserCase userCase)
        {
            _userCase = (userCase != null) ? userCase : throw new ArgumentNullException(nameof(userCase));
        }

        [HttpGet("GetStateInspection")]

        public GenericListResponse<StateInspection> GetStateInspection()
        {
            GenericListResponse<StateInspection> reponse;
            try
            {
                reponse = new GenericListResponse<StateInspection>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Items = _userCase.ObtainStateInspection()
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericListResponse<StateInspection>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }

        [HttpGet("GetStateInspectionModel")]
        public GenericResponse<StateInspection> GetStateInspectionModel(int id)
        {
            GenericResponse<StateInspection> reponse;
            try
            {
                reponse = new GenericResponse<StateInspection>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.GetStateInspection(new StateInspection() { sinsId = id })
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<StateInspection>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }


        [HttpPost("UpdateStateInspection")]
        public GenericResponse<StateInspection> UpdateStateInspection(StateInspection model)
        {
            GenericResponse<StateInspection> reponse;
            try
            {
                reponse = new GenericResponse<StateInspection>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.UpdateStateInspection(model)
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<StateInspection>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }

        [HttpPost("InsertStateInspection")]
        public GenericResponse<StateInspection> InsertStateInspection(StateInspection model)
        {
            GenericResponse<StateInspection> reponse;
            try
            {
                reponse = new GenericResponse<StateInspection>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.InsertStateInspection(model)
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<StateInspection>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }

        [HttpPost("DeleteStateInspection")]
        public GenericResponse<StateInspection> DeleteStateInspection(StateInspection model)
        {
            GenericResponse<StateInspection> reponse;
            try
            {
                reponse = new GenericResponse<StateInspection>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.DeleteStateInspection(model)
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<StateInspection>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }


    }
}
