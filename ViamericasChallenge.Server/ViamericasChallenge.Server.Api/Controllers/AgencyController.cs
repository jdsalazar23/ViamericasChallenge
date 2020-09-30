using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using ViamericasChallenge.Server.Logic;

namespace ViamericasChallenge.Server.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AgencyController : ControllerBase
    {
        /// <summary>
        /// Get data of agencies
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        /// <response code="200"> Success </response>
        /// <response code="404"> No Data </response> 
        /// <response code="401"> Invalid Token </response> 
        /// <response code="500"> Internal Error </response> 
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get(string city)
        {
            try
            {
                var result = await new AgencyLogic().GetAgenciesAsync(city);

                if (result == null || result.Count == 0)
                    return NotFound("No Data");
                else
                    return Ok(result);
            }
            catch (Common.Exceptions.TokenException)
            {
                return Unauthorized("Invalid token");
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Error");
            }
        }
    }
}
