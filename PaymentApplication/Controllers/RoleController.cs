using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentApplication.Repository;

namespace PaymentApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        readonly IUserRoleRepository roleRepository;

        public RoleController(IUserRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        [HttpPost]
        [Route("GetAllRoles")]
        public IActionResult GetAllRoles()
        {
            return Ok(roleRepository.GetAll());
        }
    }
}
