using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PrisonManagementSystem.Config;
using PrisonManagementSystem.Db_Models;
using PrisonManagementSystem.Interfaces.Repositories;
using PrisonManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Controllers
{
    [Authorize]
    public class VisitorController : Controller
    {
        private readonly Logger _logger;
        private readonly DbHelper _dbHelper;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public VisitorController(Logger logger, DbHelper dbHelper, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _dbHelper = dbHelper;
        }

        [HttpGet]
        public async Task<IActionResult> RegisterVisitor()
        {
            try
            {
                var visitor = new CreateVisitorDto()
                {
                    Prisoners = (await _dbHelper.GetAllPrisoners()).ToList()
                };
                return View(visitor);
            }
            catch (Exception ex)
            {
                _logger.logError($"{ ex} error occurred while registering visitor");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterVisitor([FromForm] CreateVisitorDto model)
        {
            try
            {
                var form = model.VisitorDtos;
                model.Prisoners = (await _dbHelper.GetAllPrisoners()).ToList();
                var visitor = new Visitor()
                {
                    FirstName = form.FirstName,
                    LastName = form.LastName,
                    PrisonerId = form.PrisonerId,
                    ResidentAddress = form.ResidentAddress,
                    Gender = form.Gender,
                    Phone = form.Phone
                };

                var success = await _dbHelper.RegisterVisitor(visitor);

                return View();
            }
            catch (Exception e)
            {
                _logger.logError($"{e} an error occurred while registering prisoner");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> VisitingArrival()
        {
            try
            {
                var visitor = new CreateVisitorDto
                {
                    Visitors = (await _dbHelper.GetAllVisitorsInfo()).ToList()
                };
                return View(visitor);
            }
            catch (Exception ex)
            {
                _logger.logError($"{ex} cannot get visitors info on arrival");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> VisitingDeparture()
        {
            try
            {
                var visitor = new CreateVisitorDto
                {
                    Visitors = (await _dbHelper.GetActiveArrivedVisitingInfos()).ToList(),//all visitors who haven't signed off
                    Visitings = await _unitOfWork.Visitings.GetAll(p => p.Active == true)
                };
                return View(visitor);
            }
            catch (Exception ex)
            {
                _logger.logError($"{ex} cannot get visitor & visiting info on departure");
            }
            return View();
        }
    }
}

