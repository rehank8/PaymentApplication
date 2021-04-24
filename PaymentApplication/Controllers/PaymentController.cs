using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentApplication.Models;
using PaymentApplication.Repository;

namespace PaymentApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        readonly IUserProfileRepository userDetailRepository;

        public PaymentController(IUserProfileRepository userDetailRepository)
        {
            this.userDetailRepository = userDetailRepository;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public ActionResult<IEnumerable<UserProfile>> GetAllUsers()
        {
            try
            {
                return Ok(userDetailRepository.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
