using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckDriverApp.Model;
using TruckDriverApp.Repoistory.FrieghtRepoistory;

namespace TruckDriverApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverPlanController : ControllerBase
    {
        private readonly IFrieghtRepository _frieght;
        public DriverPlanController(IFrieghtRepository frieght)
        {
            _frieght = frieght;
        }
        [HttpPost]
        [Route("api/AddPlan")]
        public IActionResult AddPlan(planfrieght plan)
        {
            try { 
            var user = _frieght.AddPlan(plan);
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
        [HttpGet]
        [Route("api/GetAllPlan")]
        public IActionResult GetAllPlan()
        {
            try
            {
                var user = _frieght.GetALLPlan();
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
