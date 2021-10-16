using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrisonManagementSystem.Config;
using PrisonManagementSystem.Db_Models;
using PrisonManagementSystem.Interfaces.Repositories;
using PrisonManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PrisonManagementSystem.Models.UserDto;

namespace PrisonManagementSystem.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly Logger _logger;
        private readonly DbHelper _dbHelper;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        //private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;
        //private readonly IEmailSender _emailSender;

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
        public IActionResult Register()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationModel dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dto);
                }
                var userExists = (await _dbHelper.GetAllUsers()).FirstOrDefault(p => p.Username == dto.Username);
                if (userExists != null)
                {
                    ModelState.AddModelError(string.Empty, "username is taken");
                    return View(dto);
                }
                dto.Active = true;
               
                dto.Password = EncryptionHelper.CalculateSha1(dto.Password);
                var model = _mapper.Map<User>(dto);
                await _unitOfWork.Users.Insert(model);
                await _unitOfWork.Save();
                return RedirectToAction(nameof(SuccessRegistration));
            }
            catch (Exception ex)
            {
                _logger.logError($"{ex} error occurred while registering user");
                return View();
            }
        }

        [HttpGet]
        public IActionResult SuccessRegistration()
        {
            return View();
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
