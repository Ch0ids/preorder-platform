using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PreorderPlatform.API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)] // Add this attribute to ignore the action in Swagger
    public class TestRouteController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            return Ok("Welcome to the home page!");
        }


        [Route("Emp/GetAll")]
        [Route("EmployeeAlls")]
        [Route("Employee/GetAlls")]
        public IActionResult GetAll()
        {
            return Ok("This endpoint is GetAll.");
        }

        [Route("Emp/GetById")]
        public IActionResult GetById()
        {
            return Ok("This endpoint is GetById.");
        }

        [Route("Emp/{id}")]
        public IActionResult GetById(string id)
        {
            return Ok($"This employee id is {id}");
        }

        [Route("Emp/Gender/{Gender}/City/{CityId}")]
        public IActionResult GetEmployeeByGenderAndCity(string Gender, int CityId)
        {
            return Ok($"Return Employee with Gender: {Gender}, CityId: {CityId} ");
        }


        [Route("Emp/Search")]
        public IActionResult Search(string Department, string Gender, string City)
        {
            return Ok($"Return Employee with Department: {Department}, Gender: {Gender}, City: {City} ");
        }
    }
}
