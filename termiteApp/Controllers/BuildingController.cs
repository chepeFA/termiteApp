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
    public class BuildingController: ControllerBase
    {
        private readonly IBuildingUserCase _userCase;

        public BuildingController(IBuildingUserCase userCase)
        {
            _userCase = (userCase != null) ? userCase : throw new ArgumentNullException(nameof(userCase));
        }

        [HttpGet("GetBuilding")]

        public GenericListResponse<Building> GetBuilding()
        {
            GenericListResponse<Building> reponse;
            try
            {
                reponse = new GenericListResponse<Building>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Items = _userCase.ObtainBuilding()
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericListResponse<Building>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }



        [HttpGet("GetBuildingModel")]
        public GenericResponse<Building> GetBuildingModel(int id)
        {
            GenericResponse<Building> reponse;
            try
            {
                reponse = new GenericResponse<Building>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.GetBulding(new Building() { bldId = id })
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<Building>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }

        [HttpPost("UpdateBuilding")]
        public GenericResponse<Building> updateBuilding(Building model)
        {
            GenericResponse<Building> reponse;
            try
            {
                reponse = new GenericResponse<Building>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.UpdateBuilding(model)
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<Building>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }

        [HttpPost("InsertBuilding")]
        public GenericResponse<Building> InsertBuilding(Building model)
        {
            GenericResponse<Building> reponse;
            try
            {
                reponse = new GenericResponse<Building>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.InsertBuilding(model)
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<Building>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }
        [HttpPost("DeleteBuilding")]
        public GenericResponse<Building> deleteBuilding(Building model)
        {
            GenericResponse<Building> reponse;
            try
            {
                reponse = new GenericResponse<Building>()
                {
                    Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                    Item = _userCase.DeleteBuilding(model)
                };
            }
            catch (Exception ex)
            {
                reponse = new GenericResponse<Building>()
                {
                    Status = new ResponseStatus()
                    { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                };
            }
            return reponse;
        }

    }
}
