using Microsoft.AspNetCore.Mvc;

namespace Pebolim.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected int UserId { get => GetUserId(); }

        private int GetUserId()
        {
            var userIdClaim = User.FindFirst("id");
            if (userIdClaim == null)
                return 0;
            return int.Parse(userIdClaim.Value);
        }
    }
}
