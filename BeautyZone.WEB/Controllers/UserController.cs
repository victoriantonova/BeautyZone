using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyZone.BLL.Interfaces;
using BeautyZone.BLL.Models;
using BeautyZone.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyZone.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService userService;
        public UserController(IUserService serv)
        {
            userService = serv;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                List<UserBLL> user = userService.GetUsers();

                if (user == null)
                {
                    throw new Exception("Error. Users not found");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/User/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetUser([FromRoute] int id)
        {
            try
            {
                var user = userService.GetUser(id);

                if (user == null)
                {
                    throw new Exception("Error. User not found");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/User
        [Authorize]
        [HttpPut]
        public IActionResult PutUser([FromBody]UserBLL user)
        {
            try
            {
                if (user == null)
                {
                    throw new Exception("Error. User in request is null");
                }

                if (userService.GetUser(user.Id) == null)
                {
                    throw new Exception("Error. User not found");
                }

                userService.UpdateUser(user);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/User       
        [HttpPost]
        public IActionResult PostUser([FromBody]UserBLL user)
        {
            try
            {
                var users = userService.GetUsers();
                if (user.Login == null || user.Password == null)
                {
                    throw new Exception("Error. Password == null or Login == null");
                }

                foreach (UserBLL u in users)
                {
                    if (u.Login == user.Login)
                        throw new Exception("Error. Login already exists");
                }

                userService.CreateUser(user);


                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/User/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            try
            {
                if (userService.GetUser(id) == null)
                {
                    throw new Exception("Error. User not found");
                }
                else
                {
                    userService.DeleteUser(id);

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}