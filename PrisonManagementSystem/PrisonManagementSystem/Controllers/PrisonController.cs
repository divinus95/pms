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
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static PrisonManagementSystem.Models.PrisonerViewModel;

namespace PrisonManagementSystem.Controllers
{
    public class PrisonController : Controller
    {
        private readonly Logger _logger;
        private readonly DbHelper _dbHelper;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PrisonController(Logger logger, DbHelper dbHelper, IWebHostEnvironment webHostEnv,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _dbHelper = dbHelper;
            _webHostEnvironment = webHostEnv;
        }

        [HttpGet]
        public async Task<IActionResult> RegisterPrisoner()
        {
            try
            {
                var prisonerdto = new CreatePrisonerDto()
                {
                    Cells = (await _dbHelper.GetAllCells()).ToList(),
                    Classifications = (await _dbHelper.GetAllCrimeClass()).ToList()
                };
                return View(prisonerdto);
            }
            catch (Exception ex)
            {
                _logger.logError($"{ex} unable to load data");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPrisoner([FromForm] CreatePrisonerDto form)
        {
            try
            {
                form.Cells = (await _dbHelper.GetAllCells()).ToList();
                form.Classifications = (await _dbHelper.GetAllCrimeClass()).ToList();
                {
                    var req = form.PrisonerDtos;
                    var passportURL = UploadPassport(req.PassportPicture);
                    var cellState = req.CellId;
                    //var isoccupied = false;
                    var prisonPassport = new Prisoner()
                    {
                        PassportURL = passportURL,
                        FirstName = req.FirstName,
                        LastName = req.LastName,
                        OtherName = req.OtherName,
                        DateConvicted = req.DateConvicted,
                        DateOfBirth = req.DateOfBirth,
                        Description = req.Description,
                        EmergencyContact = req.EmergencyContact,
                        ExpectedJailTerm = req.ExpectedJailTerm,
                        Sentence = req.Sentence,
                        Offence = req.Offence,
                        HealthConditions = req.HealthConditions,
                        Gender = req.Gender,
                        CellId = cellState,
                        PrisonerClassificationId = req.PrisonerClassificationId,
                        Active = true,
                        DateRegistered = DateTime.Now,
                        Height = req.Height,
                        Weight = req.Weight,
                        ColorOfEye = req.ColorOfEye
                    };
                    var success = await _dbHelper.RegisterPrisoner(prisonPassport);
                    if (success > 0)
                        _ = await _dbHelper.UpdateCellStatus(cellState);
                    return View();
                }
            }
            catch (Exception ex)
            {
                _logger.logError($"{ex} error occurred while registering prisoner");
                return View();
            }
        }

        [HttpGet("Prison/Prisoners/{slug?}")]
        public async Task<IActionResult> Prisoners(string slug = "")
        {
            var prisoners = new List<PrisonerForm>();
            try
            {
                prisoners = (await _dbHelper.GetAllPrisonersInfo()).ToList();
                if (!string.IsNullOrWhiteSpace(slug))
                {
                    slug = slug.Trim();
                    var model = new CreatePrisonerDto
                    {
                        inMate = prisoners.FirstOrDefault(p => p.FirstName == slug)
                    };
                    return View(nameof(Prisonerdetails), model);
                };
            }
            catch (Exception ex)
            {
                _logger.logError($"{ex} unable to load data");
            }
            return View(new CreatePrisonerDto { inMates = prisoners });
        }

        [HttpGet]
        public async Task<IActionResult> Prisonerdetails(string slug = "")
        {
            var prisoners = new List<PrisonerForm>();
            prisoners = (await _dbHelper.GetAllPrisonersInfo()).ToList();
            var model = new CreatePrisonerDto
            {
                inMate = prisoners.FirstOrDefault(p => p.FirstName == slug)
            };
            return View(new CreatePrisonerDto { inMate = prisoners.FirstOrDefault(p => p.FirstName == slug) });
        }

        [HttpGet("Prison/RemandedInmates/{slug?}")]
        public async Task<IActionResult> RemandedInmates(string slug = "")
        {
            try
            {
                //var prisoners = new List<Prisoner>();
                //prisoners = (await _dbHelper.GetAllPrisonersByCrimeClass(2));
                //if (prisoners.Count > 0)
                //{
                //    slug = slug.Trim();
                //    var model = new CreatePrisonerDto
                //    {
                //        remand = prisoners.FirstOrDefault(p => p.FirstName == slug)
                //    };
                //    return View(prisoners);
                //};
            }
            catch (Exception ex)
            {
                _logger.logError($"{ex} unable to load remanded inmates data");
            }
            return View();
        }

        [HttpGet]
        public IActionResult RemandedInmatesInfo(string slug = "")
        {
            try
            {
                var prisoners = new List<PrisonerForm>();
                var remandedPrisoner = prisoners.FindAll(x => x.PrisonerClassificationId == 2);
                var model = new CreatePrisonerDto
                {
                    inMate = remandedPrisoner.FirstOrDefault(p => p.FirstName == slug)
                };
                return View(new CreatePrisonerDto { inMate = remandedPrisoner.FirstOrDefault(p => p.FirstName == slug) });
            }
            catch (Exception ex)
            {
                _logger.logError($"{ex} error occurred while getting remanded inmate's details");
            }
            return View();
        }
        private string UploadPassport(IFormFile formFile)
        {
            string uniqueFileName = null;
            string filePath = "";
            if (formFile.FileName != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + formFile.FileName;
                filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }
            }
            return $"/images/{uniqueFileName}";
        }
    }
}
