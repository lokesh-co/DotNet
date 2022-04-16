using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckDriverApp.Common;
using TruckDriverApp.Context;
using TruckDriverApp.Model;
using TruckDriverApp.Repoistory;

namespace TruckDriverApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverRegisterController : ControllerBase
    {
        private readonly ITruckDriverRepository _driver;
        private readonly TruckDriverAppDbContext _context;
        public DriverRegisterController(ITruckDriverRepository truck, TruckDriverAppDbContext context)
        {
            _driver = truck;
            _context = context;
        }
        [HttpPost("register")]
        public string RegisterAsync([FromBody] registermodel model)
        {

            var result = _driver.RegisterAsync(model);
                model.Password = PasswordType.ConvertToEncrypt(model.Password);
                model.Confirm_password = PasswordType.ConvertToEncrypt(model.Confirm_password);
                _context.SaveChanges();
                return "success";
        }
        [HttpGet("GetAllRegister")]
        public IActionResult GetAllRegister()
        {
            try
            {
                var user = _driver.GetAllRegister();
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
