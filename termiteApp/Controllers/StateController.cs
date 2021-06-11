using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using termiteApp.Core.Interfaces;
using termiteApp.Api.Commond.Responses;
using termiteApp.Core.Domain;
using System.Net;

namespace termiteApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StateController:ControllerBase
    {
        private readonly IStateUserCase _userCase;

        public StateController(IStateUserCase userCase)
        {
            _userCase = (userCase != null) ? userCase : throw new ArgumentNullException(nameof(userCase));
        }

        [HttpGet("GetState")]

        public GenericListResponse<State> GetState()
        {
            GenericListResponse<State> reponse;
            try
            {
                reponse = new GenericListResponse<State>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Items = _userCase.ObtainState()
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericListResponse<State>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }

        [HttpGet("GetStateModel")]
        public GenericResponse<State> GetStateModel(int id)
        {
            GenericResponse<State> reponse;
            try
            {
                reponse = new GenericResponse<State>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.GetState(new State() { staId = id })
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<State>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }

        [HttpPost("UpdateState")]
        public GenericResponse<State> updateState(State model)
        {
            GenericResponse<State> reponse;
            try
            {
                reponse = new GenericResponse<State>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.UpdateState(model)
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<State>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }

        [HttpPost("InsertState")]
        public GenericResponse<State> insertState(State model)
        {
            GenericResponse<State> reponse;
            try
            {
                reponse = new GenericResponse<State>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.InsertState(model)
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<State>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }


        [HttpPost("DeleteState")]
        public GenericResponse<State> deleteState(State model)
        {
            GenericResponse<State> reponse;
            try
            {
                reponse = new GenericResponse<State>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.DeleteState(model)
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<State>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }

    }
}
