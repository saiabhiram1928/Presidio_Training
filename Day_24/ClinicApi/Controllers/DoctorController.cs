using ClinicApi.Exceptions;
using ClinicApi.Interfaces;
using ClinicApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService) 
        {
            _doctorService = doctorService;
        }
        [HttpGet]
        public async Task<ActionResult<IList<Doctor>>> GetAllDoctorsApi()
        {
            try
            {
                var doctors = await _doctorService.GetAllDoctors();
                return Ok(doctors);
            }catch(NoDoctorsInDb nddex)
            {
                return NotFound(nddex.Message);
            }
        }
        [Route("GetDoctorsBySpec")]
        [HttpGet]
        public async Task<ActionResult<IList<Doctor>>> GetDoctorsBySpecializationApi(string spec)
        {
            try
            {
                var doctors = await _doctorService.GetDoctorsBySpecialization(spec);
                return Ok(doctors);
            }catch(NoDoctorsInDb nddex)
            {
                return NotFound(nddex.Message);
            }catch(NoDocWithSpec ndswex)
            {
                return NotFound(ndswex.Message);
            }
        }
        [Route("UpdateDocExp")]
        [HttpPut]
        public async Task<ActionResult<Doctor>> UpdateDoctorExperienceApi(int id , int exp)
        {
            try
            {
                var doctor = await _doctorService.UpdateDoctorExperience(id, exp);
                return Ok(doctor);
            }catch(NoDoctorException ndex)
            {
                return NotFound(ndex.Message); 
            }
        }
    }
}
