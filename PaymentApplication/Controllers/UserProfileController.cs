using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaymentApplication.Models;
using PaymentApplication.Repository;

namespace PaymentApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IWebHostEnvironment _iwebHost;
        readonly IUserProfileRepository userDetailRepository;

        public UserProfileController(IUserProfileRepository userDetailRepository, IWebHostEnvironment iwebHost)
        {
            this.userDetailRepository = userDetailRepository;
            _iwebHost = iwebHost;
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser([FromForm(Name = "file")] IFormFile file, [FromForm(Name = "userData")] string userProfile)
        {
            var de_user = JsonConvert.DeserializeObject<UserProfile>(userProfile);
            var allowedExtensions = new[] {
                ".Jpg", ".png", ".jpg", "jpeg"
            };
            var uniqueFileName = "";
            string filePath = "";
            var fileName = Path.GetFileName(file.FileName);
            var ext = Path.GetExtension(file.FileName);
            if (allowedExtensions.Contains(ext)) //check what type of extension  
            {
                string uploadsFolder = Path.Combine(_iwebHost.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            var user = new UserProfile();
            user.ImageUrl = "/images/"+uniqueFileName;
            user.FirstName = de_user.FirstName;
            user.MiddleName = de_user.MiddleName;
            user.LastName =de_user.LastName;
            user.EmailId = de_user.EmailId;
            user.IsActive = de_user.IsActive;
            user.Country = de_user.Country;
            user.Location = de_user.Location;
            user.Gender = de_user.Gender;
            user.Password = de_user.Password;
            user.RegisteredDate = DateTime.Now;
            user.LastLoginDate = DateTime.Now;
            user.PhoneNumber = de_user.PhoneNumber;
            user.FKRoleId = de_user.FKRoleId;
            user.PKUserId = Guid.NewGuid().ToString();
            userDetailRepository.Add(user);
            
            return Ok();
        }

        [HttpPost]
        [Route("EditUser")]
        public IActionResult EditUser([FromForm(Name = "file")] IFormFile file, [FromForm(Name = "userData")] string userProfile)
        {
            var de_user = JsonConvert.DeserializeObject<UserProfile>(userProfile);
            var allowedExtensions = new[] {
                ".Jpg", ".png", ".jpg", "jpeg"
            };
            var uniqueFileName = "";
            string filePath = "";
            var fileName = Path.GetFileName(file.FileName);
            var ext = Path.GetExtension(file.FileName);
            if (allowedExtensions.Contains(ext)) //check what type of extension  
            {
                string uploadsFolder = Path.Combine(_iwebHost.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            var user = new UserProfile();
            user.ImageUrl =  "/images/" + uniqueFileName;
            user.FirstName = de_user.FirstName;
            user.MiddleName = de_user.MiddleName;
            user.LastName = de_user.LastName;
            user.EmailId = de_user.EmailId;
            user.IsActive = de_user.IsActive;
            user.Country = de_user.Country;
            user.Location = de_user.Location;
            user.Gender = de_user.Gender;
            user.Password = de_user.Password;
            user.RegisteredDate = DateTime.Now;
            user.LastLoginDate = DateTime.Now;
            user.PhoneNumber = de_user.PhoneNumber;
            user.FKRoleId = de_user.FKRoleId;
            user.PKUserId = de_user.PKUserId;
            userDetailRepository.Update(user);

            return Ok();
        }

        [HttpGet]
        [Route("GetUserById")]
        public IActionResult GetUserById(string userId)
        {
            var user=userDetailRepository.GetById(userId);
            return Ok(user);
        }

        [HttpPost]
        [Route("DeleteUserById")]
        public IActionResult DeleteUserById(string userId)
        {
             userDetailRepository.Delete(userId);
            return Ok();
        }
    }
}
