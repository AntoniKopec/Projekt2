using Microsoft.AspNetCore.Mvc;
using Restaurator.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.ApplicationUser.GetAll() });
        }
        [HttpPost]
        public IActionResult LockUnlock([FromBody]string id)
        {
            var objFromDB = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == id);
            if (objFromDB == null)
            {
                return Json(new { success = false, message = "Error while Locking/Unlocking." });
            }
            if(objFromDB.LockoutEnd!=null && objFromDB.LockoutEnd > DateTime.Now)
            {
                objFromDB.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDB.LockoutEnd = DateTime.Now.AddYears(100);
            }
            _unitOfWork.Save();

            return Json(new { success = true, message = "Operation Successful." });
        }
    }
}
