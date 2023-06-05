using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PreorderPlatform.Service.Utility.CustomAuthorizeAttribute;
using PreorderPlatform.Service.ViewModels.ApiResponse;
using PreorderPlatform.Service.ViewModels.User;

[Route("api/[controller]")]
public class TestValidationController : ControllerBase
{
    [HttpPost("test")]
    public async Task<IActionResult> Test([FromBody] UserCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            // Extract validation errors from ModelState
            // Handle validation errors using custom ApiResponse
            return UnprocessableEntity(new ApiResponse<object>(ModelState, "One or more validation errors occurred.", false, null));
        } else
        {
            return Ok(new ApiResponse<object>(null, "User is valid", true, null));
        }
    }

    [HttpPost("test1")]
    public async Task<IActionResult> Test1([FromBody] UserCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            // Extract validation errors from ModelState
            // Handle validation errors using custom ApiResponse
            return UnprocessableEntity(new ApiResponse<object>(GetValidationError.FromModelState(ModelState), "One or more validation errors occurred.", false, null));
        }
        else
        {
            return Ok(new ApiResponse<object>(null, "User is valid", true, null));
        }
    }



    
}