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
    public class CostumerController: ControllerBase
    {
        private readonly ICostumerUserCase _userCase;

        public CostumerController(ICostumerUserCase userCase)
        {
            _userCase = (userCase != null) ? userCase : throw new ArgumentNullException(nameof(userCase));
        }

        [HttpGet("GetCostumer")]

        public GenericListResponse<Costumer> GetCostumer()
        {
            GenericListResponse<Costumer> reponse;
            try
            {
                reponse = new GenericListResponse<Costumer>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Items = _userCase.ObtainCostumer()
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericListResponse<Costumer>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }

        [HttpGet("GetCostumerModel")]
        public GenericResponse<Costumer> GetCustomerModel(int id)
        {
            GenericResponse<Costumer> reponse;
            try
            {
                reponse = new GenericResponse<Costumer>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.GetCostumer(new Costumer() { ctmId = id })
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<Costumer>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }

        [HttpPost("UpdateCostumer")]
        public GenericResponse<Costumer> updateCostumer(Costumer model)
        {
            GenericResponse<Costumer> reponse;
            try
            {
                reponse = new GenericResponse<Costumer>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.UpdateCostumer(model)
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<Costumer>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }

        [HttpPost("InsertCostumer")]
        public GenericResponse<Costumer> insertCostumer(Costumer model)
        {
            GenericResponse<Costumer> reponse;
            try
            {
                reponse = new GenericResponse<Costumer>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.InsertCostumer(model)
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<Costumer>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }


    }
}
