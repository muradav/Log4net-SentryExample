using log4net;
using Log4netExample.Api.DataContext;
using Log4netExample.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Log4netExample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogTestController : ControllerBase
    {
        private readonly ILog _logger;
        private readonly AppDbContext _db;

        public LogTestController(ILog logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //throw new Exception("Sentry test");
            _logger.Debug("log Debug");
            
            _logger.Info("log Info");
            
            _logger.Warn("log Warn");
            
            _logger.Error("log Error");
            
            _logger.Fatal("log Fatal");

            return Ok("Test success");
        }

        [HttpPost]
        public IActionResult Add(string message)
        {
            Log log = new()
            {
                Date = DateTime.Now,
                Message = message
            };

            _db.Log.Add(log);
            _db.SaveChanges();


            return Ok("Done");
        }

        [HttpGet("connectionstring")]
        public IActionResult CheckConnection()
        {
            string connectionString = "data source=DESKTOP-RKRT344\\SQLEXPRESS;initial catalog=Log4netExample;integrated security=true;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return Ok("Connection successful!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Connection failed: " + ex.Message);
                }
            }
        }
    }
}
