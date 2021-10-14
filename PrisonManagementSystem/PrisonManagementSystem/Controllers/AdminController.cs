using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrisonManagementSystem.Config;
using PrisonManagementSystem.Interfaces.Repositories;
using PrisonManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly Logger _logger;
        private readonly DbHelper _dbHelper;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(Logger logger, IWebHostEnvironment webHostEnvironment,
            IMapper mapper, IUnitOfWork unitOfWork, DbHelper dbHelper)
        {
            _logger = logger;
            _dbHelper = dbHelper;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public async Task<IActionResult> AddOfficer()
        {
            try
            {
                var rank = new OfficersInfoViewModel
                {
                    OfficerRanks = (await _unitOfWork.Ranks.GetAll()).OrderByDescending(p => p.RankId).ToList()
                };
                return View(rank);
            }
            catch (Exception ex)
            {
                _logger.logError($"{ex} error occurred while getting officer ranks");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddNewDuty()
        {
            try
            {
                var dutytype = new CreateDutyViewModel()
                {
                    DutyTypes = (await _unitOfWork.DutyTypes.GetAll()).ToList()
                };
                return View(dutytype);
            }
            catch (Exception ex)
            {
                _logger.logError($"{ex} an error occurred while loading duty types");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AssignOfficer()
        {
            var duty = new DutiesViewModel()
            {
                Duties = new SelectList((await _unitOfWork.Duty.GetAll(p => p.Active == true)).ToList(), "DutyId", "DutyName"),
                Officers = new SelectList((await _unitOfWork.Officers.GetAll(p => p.Active == true)).ToList(), "OfficerId", "FirstName")
            };
            return View(duty);
        }

        [HttpPost()]
        public async Task<IActionResult> AssignOfficer(string[] Ids)
        {
            //var duty = new DutiesViewModel()
            //{
            SelectList Duties = new SelectList((await _unitOfWork.Duty.GetAll(p => p.Active == true)).ToList(), "DutyId", "DutyName");
            SelectList Officers = new SelectList((await _unitOfWork.Officers.GetAll(p => p.Active == true)).ToList(), "OfficerId", "FirstName");
            //};
            foreach (string Id in Ids)
            {
                SelectListItem selectedItem = Officers.ToList().Find(p => p.Value == Id);
            }
            return View();
        }
        public IActionResult GetOfficersOnDuty()
        {
            return View();
        }
        public IActionResult UpdateOfficer()
        {
            return View();
        }
    }
}
