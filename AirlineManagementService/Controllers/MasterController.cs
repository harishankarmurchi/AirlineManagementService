using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Services.Abstraction;
using Services.Services;
using System.Net;

namespace AirlineManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMasterService _masterService;

        public MasterController(IMasterService masterService)
        {
            _masterService = masterService;

        }

        [HttpGet("masterdata")]
        [Authorize]
        public async Task<Response<MasterVM>> GetMasterData()
        {
            var response = new Response<MasterVM>();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Data = await _masterService.GetMasterData();

            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("airline")]
        [Authorize]
        public async Task<Response<object>> GetAllAirlines()
        {
            var response = new Response<object>();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Data = await _masterService.GetAirline();

            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }


    }
}
