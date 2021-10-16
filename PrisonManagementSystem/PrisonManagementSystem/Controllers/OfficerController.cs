using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PrisonManagementSystem.Config;
using PrisonManagementSystem.Interfaces.Repositories;
using PrisonManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Controllers
{
    [Authorize]
    public class OfficerController : Controller
    {
        private readonly Logger _logger;
        private readonly DbHelper _dbHelper;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public OfficerController(Logger logger, IWebHostEnvironment webHostEnvironment,
            IMapper mapper, IUnitOfWork unitOfWork, DbHelper dbHelper)
        {
            _logger = logger;
            _dbHelper = dbHelper;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        //[HttpGet]
        //public async Task<IActionResult> Duty()
        //{
        //    try
        //    {
        //        var rank = new OfficersInfoViewModel
        //        {
        //            OfficerRanks = (await _unitOfWork.Ranks.GetAll()).ToList()
        //        };
        //        return View(rank);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.logError($"{ ex} error occurred while getting officer ranks");
        //    }
        //    return View();
        //}
    }
}
