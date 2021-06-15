using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using termiteApp.Core.Interfaces;
using termiteApp.Api.Commond.Responses;
using termiteApp.Core.Domain;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using termiteApp.Core.AuxClasses;
namespace termiteApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InspectorController: ControllerBase
    {
        private readonly IInspectorUserCase _userCase;
      
     


        public InspectorController(IInspectorUserCase userCase)
                {
                    _userCase = (userCase != null) ? userCase : throw new ArgumentNullException(nameof(userCase));

                    //json to byte (deserialize)

                }

                [HttpGet("GetInspector")]
                public GenericListResponse<Inspector> GetInspector()
                {
                    GenericListResponse<Inspector> reponse;
                    try
                    {
                        reponse = new GenericListResponse<Inspector>()
                        {
                            Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                            Items = _userCase.ObtainInspector()
                        };
                    }
                    catch (Exception ex)
                    {
                        reponse = new GenericListResponse<Inspector>()
                        {
                            Status = new ResponseStatus()
                            { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                        };
                    }
                    return reponse;
                }

                [HttpGet("GetInspectorModel")]
                public GenericResponse<Inspector> GetInspectorModel(int id)
                {
                    GenericResponse<Inspector> reponse;
                    try
                    {
                        reponse = new GenericResponse<Inspector>()
                        {
                            Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                            Item = _userCase.GetInspector(new Inspector() { inpId = id })
                        };
                    }
                    catch (Exception ex)
                    {
                        reponse = new GenericResponse<Inspector>()
                        {
                            Status = new ResponseStatus()
                            { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                        };
                    }
                    return reponse;
                }

                [HttpPost("UpdateInspector")]
                public GenericResponse<Inspector> UpdateInspector(Inspector model)
                {
                    GenericResponse<Inspector> reponse;
                    try
                    {
                        reponse = new GenericResponse<Inspector>()
                        {
                            Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                            Item = _userCase.UpdateInspector(model)
                        };
                    }
                    catch (Exception ex)
                    {
                        reponse = new GenericResponse<Inspector>()
                        {
                            Status = new ResponseStatus()
                            { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                        };
                    }
                    return reponse;
                }

    //    [HttpPost]
        //public IActionResult CreateDocument([FromBody] CreateDocumentModel model)
      //  {
          //  return new ObjectResult(model);
        //}

        [HttpPost("InsertInspector")]

                public GenericResponse<Inspector> InsertInspector(Inspector model)
                {
                    GenericResponse<Inspector> reponse;
                    try
                    {
                        reponse = new GenericResponse<Inspector>()
                        {
                            Status = new ResponseStatus() { HttpCode = HttpStatusCode.OK },
                            Item = _userCase.InsertInspector(model)

                        };
                    }
                    catch (Exception ex)
                    {
                        reponse = new GenericResponse<Inspector>()
                        {
                            Status = new ResponseStatus()
                            { HttpCode = HttpStatusCode.InternalServerError, Message = ex.ToString() }
                        };
                    }
                    return reponse;
                }

                [HttpPost("InsertInspectorSignature")]

                public void Post(byte[] bytes)
                {
                   
                }

                

    }
}
