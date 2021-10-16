using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrisonManagementSystem.Config;
using PrisonManagementSystem.Interfaces.Repositories;
using PrisonManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly Logger _logger;
        private readonly DbHelper _dbHelper;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(Logger logger, DbHelper dbHelper, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _dbHelper = dbHelper;
        }

        public async Task<IActionResult> Index()
        {
            await PrisonerStatistics();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task PrisonerStatistics()
        {
            ViewBag.Male = (await _dbHelper.GetAllPrisonersByGender("MALE")).Count;
            ViewBag.Female = (await _dbHelper.GetAllPrisonersByGender("FEMALE")).Count;

            ViewBag.Trial = (await _dbHelper.GetAllPrisonersByCrimeClass(1)).Count;
            ViewBag.Remand = (await _dbHelper.GetAllPrisonersByCrimeClass(2)).Count;
            ViewBag.Convicted = (await _dbHelper.GetAllPrisonersByCrimeClass(3)).Count;
            ViewBag.Condemned = (await _dbHelper.GetAllPrisonersByCrimeClass(4)).Count;

            ViewBag.All = (await _dbHelper.GetAllPrisoners()).Count;
        }
    }
}
