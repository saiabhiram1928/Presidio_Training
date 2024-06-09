using EmployeeRequestTrackerAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Models.DTOs.RequestDTOs;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly ILogger<RequestController> _logger;

        public RequestController(IRequestService requestService, ILogger<RequestController> logger)
        {
            _requestService = requestService;
            _logger = logger;
        }

        [Authorize]
        [HttpPost("raise")]
        public async Task<IActionResult> RaiseRequest([FromBody] RequestDTO requestDto)
        {
            try
            {
                var employeeId = User.FindFirstValue("eid");
                if (employeeId == null)
                {
                    _logger.LogError("User is not logged in.");
                    throw new NotLoggedInException("User is not logged in.");
                }

                var request = new Request
                {
                    RequestMessage = requestDto.RequestMessage,
                    RequestRaisedBy = Convert.ToInt32(employeeId),
                    RequestDate = DateTime.Now,
                    RequestStatus = "Open"
                };

                var result = await _requestService.RaiseRequest(request);
                return Ok(result);
            }
            catch (NotLoggedInException ex)
            {
                _logger.LogError("User is not logged in.");
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [Authorize]
        [HttpGet("GetRequests")]
        [ProducesResponseType(typeof(IList<Request>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<Request>>> GetRequest()
        {
            try
            {
                var employeeId = User.FindFirstValue("eid");
                if (employeeId == null)
                {
                    _logger.LogError("User is not logged in.");
                    throw new NotLoggedInException("User is not logged in.");
                }

                var result = await _requestService.ViewOpenRequests(Convert.ToInt32(employeeId));
                return Ok(result);
            }
            catch (NotLoggedInException ex)
            {
                _logger.LogError("User is not logged in.");
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
            catch (NoRequestsFoundException ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }
    }
}
