using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrisonManagementSystem.Config;
using PrisonManagementSystem.Db_Models;
using PrisonManagementSystem.Interfaces.Repositories;
using PrisonManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly Logger _logger;
        private readonly DbHelper _dbHelper;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminsController(Logger logger, IWebHostEnvironment webHostEnvironment,
            IMapper mapper, IUnitOfWork unitOfWork, DbHelper dbHelper)
        {
            _logger = logger;
            _dbHelper = dbHelper;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        [HttpPost("submit/addofficer")]
        public async Task<IActionResult> AddOfficer([FromForm] Officer model)
        {
            try
            {
                model.Active = true;
                if (!ModelState.IsValid)
                    return BadRequest("One or more fields are incorrect");
                var result = _mapper.Map<Officer>(model);
                await _unitOfWork.Officers.Insert(result);
                await _unitOfWork.Save();
                return Ok(new { status = "success" });
            }
            catch (Exception ex)
            {
                _logger.logError($"{ex} an error occurred while adding officer");
            }
            return BadRequest();
        }

        [HttpPost("submit/addnewduty")]
        public async Task<IActionResult> AddNewDuty([FromForm] Duty model)
        {
            try
            {
                model.Active = true;
                if (!ModelState.IsValid)
                    return BadRequest("one or more model validation errors occurred");
                var result = _mapper.Map<Duty>(model);
                await _unitOfWork.Duty.Insert(result);
                await _unitOfWork.Save();
                return Ok(new { status = 200 });
            }
            catch (Exception ex)
            {
                _logger.logError($"{ex} failed to add new duty");
                return BadRequest("an unknown error occurred");
            }
        }

    //    [HttpPost]
    //    public async Task<IActionResult> AssignOfficer([FromBody] OfficerDuty model)
    //    {
    //        try
    //        {
    //            var duty = new CreateDutyViewModel()
    //            {
    //                Duties = (await _unitOfWork.Duty.GetAll(p => p.Active == true)).ToList(),
    //                Officers = (await _unitOfWork.Officers.GetAll(p => p.Active == true)).ToList()
    //            };
    //            if (ModelState.IsValid)
    //            {
    //                var result = _mapper.Map<OfficerDuty>(model);
    //                await _unitOfWork.OfficerDuty.Insert(result);
    //                await _unitOfWork.Save();
    //                return Ok(new { StatusCode = 200 });
    //            }
    //            return BadRequest("validation error");
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.logError($"{ex} error occurred while assigning duty to officer");
    //            return BadRequest();
    //        }
    //    }
    }
}
