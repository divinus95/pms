using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PrisonManagementSystem.Config;
using PrisonManagementSystem.Db_Models;
using PrisonManagementSystem.Interfaces.Repositories;
using PrisonManagementSystem.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrisonerController : ControllerBase
    {
        private readonly Logger _logger;
        private readonly DbHelper _dbHelper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;

        public PrisonerController(Logger logger, IWebHostEnvironment webHostEnvironment,
            IMapper mapper, IUnitOfWork unitOfWork, IConfiguration config, DbHelper dbHelper)
        {
            _logger = logger;
            _dbHelper = dbHelper;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _config = config;

        }

        [HttpPost("submit/visitorinfo")]
        public async Task<IActionResult> SubmitVisitor([FromForm] VisitorForm form)
        {
            try
            {
                var visitor = new Visitor()
                {
                    FirstName = form.FirstName,
                    LastName = form.LastName,
                    PrisonerId = form.PrisonerId,
                    ResidentAddress = form.ResidentAddress,
                    Gender = form.Gender,
                    Phone = form.Phone,
                    Active = true
                };

                var success = await _dbHelper.RegisterVisitor(visitor);
                if (success > 0)
                    return Ok(new { status = "success" });
            }
            catch (Exception e)
            {
                _logger.logError($"{e} an error occurred while registering prisoner");
            }
            return BadRequest(new { status = "error" });
        }

        [HttpPost("submit/prisonerinfo")]
        public async Task<IActionResult> SubmitPassport([FromForm] PrisonerForm form)
        {
            try
            {
                var othername = form.OtherName;
                var health = form.HealthConditions;

                var passportURL = UploadPassport(form.PassportPicture);
                var cellState = form.CellId;
                var prisonPassport = new Prisoner()
                {
                    PassportURL = passportURL,
                    FirstName = form.FirstName,
                    LastName = form.LastName,
                    OtherName = form.OtherName,
                    DateConvicted = form.DateConvicted,
                    DateOfBirth = form.DateOfBirth,
                    Description = form.Description,
                    EmergencyContact = form.EmergencyContact,
                    ExpectedJailTerm = form.ExpectedJailTerm,
                    Sentence = form.Sentence,
                    Offence = form.Offence,
                    HealthConditions = form.HealthConditions,
                    Gender = form.Gender,
                    PrisonerClassificationId = form.PrisonerClassificationId,
                    CellId = cellState,
                    Height = form.Height,
                    Weight = form.Weight,
                    ColorOfEye = form.ColorOfEye
                };
                if (String.IsNullOrEmpty(othername))
                    prisonPassport.OtherName = "none";
                if (String.IsNullOrEmpty(health))
                    prisonPassport.HealthConditions = "none";

                var success = await _dbHelper.RegisterPrisoner(prisonPassport);
                if (success > 0)
                {
                    var changedCell = await _dbHelper.UpdateCellStatus(cellState);
                    return Ok(new { status = "success" });
                }
            }
            catch (Exception e)
            {
                _logger.logError($"{e} an error occurred while registering prisoner");
            }
            return BadRequest(new { status = "error" });
        }

        [HttpPost("submit/visitorarrival")]
        public async Task<IActionResult> VisitorArrivalInfo([FromForm] Visiting req)
        {
            try
            {
                req.Active = true;
                //req sets departure value to default = 0001-01-01 00:00:00
                if (req.ArrivalTime <= DateTime.Now)
                {
                    var success = _mapper.Map<Visiting>(req);
                    await _unitOfWork.Visitings.Insert(success);
                    await _unitOfWork.Save();
                    return Ok(new { status = 200 });
                }
                return BadRequest("Request failed. Arrival time is incorrect");
            }
            catch (Exception ex)
            {
                _logger.logError($"{ex} can't add arrival info");
                return BadRequest("Request failed");
            }
        }

        [HttpPost("submit/visitordeparture")]
        public async Task<IActionResult> VisitorDepartureInfo([FromForm] Visiting req)
        {
            try
            {
                var verified = (await _dbHelper.GetArrivedVisitingInfo(req.VisitorId)).Find(r => r.VisitorId == req.VisitorId);               
                req.ArrivalTime = verified.ArrivalTime;
                req.VisitingId = verified.VisitingId;

                //req sets Active to false
                if (verified != null)
                {                 
                    var result =  _mapper.Map<Visiting>(req);
                    _unitOfWork.Visitings.Update(req);
                    await _unitOfWork.Save();

                    return Ok(new { status = 200 });
                }
                return BadRequest("Request failed");
            }
            catch (Exception ex)
            {
                _logger.logError($"{ex} can't add arrival info");
                return BadRequest("Request failed");
            }
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
            return $"{_config.GetValue<string>("BaseURL", "")}/images/{uniqueFileName}";
        }
    }
}
