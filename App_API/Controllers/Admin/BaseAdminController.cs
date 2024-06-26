using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App_API.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class BaseAdminController : ControllerBase
    {
    }
}
