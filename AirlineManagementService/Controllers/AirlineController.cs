using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles ="Admin")]

        public Response<List<FlightVM>> AddFlight([FromBody] FlightVM airlineVM)
        {
            var response = new Response<List<FlightVM>>();
            try
            {
               
                    response.StatusCode = (int)HttpStatusCode.OK;
                    response.Message = "Airline added";
                    response.Data = _airService.AddFlight(airlineVM);



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
        [Authorize(Roles = "Admin")]
        public Response<string> UpdateAirline([FromBody] FlightVM airlineVM)
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
        [Authorize]
        public Response<List<FlightVM>> Search([FromBody] SearchVM searchVM)
        {
            var response = new Response<List<FlightVM>>();
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

        [HttpPost("addairline")]

        public Response<List<AirlineVM>> AddAirline([FromBody]AirlineVM airline)
        {
            var response = new Response<List<AirlineVM>>();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Data = _airService.AddAirline(airline);

            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost("reshedule")]
        [Authorize]

        public async Task<Response<FlightVM>> ResheduleFlight([FromBody]ResheduleVM reshedule)
        {
            var response = new Response<FlightVM>();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Data = await _airService.ResheduleFlight(reshedule);

            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }
        [HttpPost("block")]
        [Authorize]

        public async Task<Response<AirlineVM>> Block([FromBody] AirlineVM airline)
        {
            var response = new Response<AirlineVM>();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Data = await _airService.BlockAirline(airline);

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
