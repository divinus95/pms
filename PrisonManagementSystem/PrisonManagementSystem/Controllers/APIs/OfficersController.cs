using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrisonManagementSystem.Config;
using PrisonManagementSystem.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficersController : ControllerBase
    {
        private readonly Logger _logger;
        private readonly DbHelper _dbHelper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public OfficersController(Logger logger, IWebHostEnvironment webHostEnvironment,
            IMapper mapper, IUnitOfWork unitOfWork, DbHelper dbHelper)
        {
            _logger = logger;
            _dbHelper = dbHelper;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
    }
}
