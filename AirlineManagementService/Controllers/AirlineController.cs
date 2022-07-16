using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Services.Abstraction;
using System.Net;

namespace AirlineManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        private readonly IAirlineService _airService;
        public AirlineController(IAirlineService airService)
        {
            _airService = airService;
        }

        [HttpPost]
        [Route("inventory/add")]

        public Response<string> AddAirline([FromBody] AirlineVM airlineVM)
        {
            var response = new Response<string>();
            try
            {
                if (_airService.AddAirline(airlineVM))
                {
                    response.StatusCode = (int)HttpStatusCode.OK;
                    response.Message = "Airline added";
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Message = "Airline Not added";
                }

            }
            catch(Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPut]
        [Route("inventory/update")]

        public Response<string> UpdateAirline([FromBody] AirlineVM airlineVM)
        {
            var response = new Response<string>();
            try
            {
                if (_airService.UpdateFlight(airlineVM))
                {
                    response.StatusCode = (int)HttpStatusCode.OK;
                    response.Message = "Airline Updated";
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Message = "Airline Not Updated";
                }

            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("search")]

        public Response<List<AirlineVM>> Search([FromBody] SearchVM searchVM)
        {
            var response = new Response<List<AirlineVM>>();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Data = _airService.Search(searchVM);

            }
            catch(Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
