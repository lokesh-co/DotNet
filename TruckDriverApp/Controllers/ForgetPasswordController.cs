using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckDriverApp.Model;
using TruckDriverApp.Repoistory;
using TruckDriverApp.Repoistory.ResetPassword;

namespace TruckDriverApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgetPasswordController : ControllerBase
    {
        public readonly IResetpasswordRepository _reset;

        public ForgetPasswordController(IResetpasswordRepository reset)
        {
            _reset = reset;
        }
        [HttpPut]
        [Route("api/AddReset")]

       public IActionResult AddReset(registermodel obj_login)
        {
            try
            {
                var user = _reset.AddReset(obj_login);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        
        
        
        }
    }
}
