using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using backend.Data;
using backend.Dtos.User;
using backend.Interfaces;
using backend.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Helpers;

namespace backend.Controllers
{
    [Route("backend/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IUserRepository _userRepo;
        private readonly IPaymentMethodRepository _paymentMethodRepo;
        private readonly UserHelper _userHelper;
        public UserController(ApplicationDBContext context, IUserRepository userRepo, IPaymentMethodRepository paymentMethodRepo, UserHelper userHelper)
        {
            _userRepo = userRepo;
            _context = context;
            _paymentMethodRepo = paymentMethodRepo;
            _userHelper = userHelper;
        }

        // Get all users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var allUsers = await _userRepo.GetAllAsync();
                var allUsersDto = allUsers.Select(u => u.ToUserDto());
                return Ok(allUsersDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the user. \n", error = ex.Message });
            }
        }

        // Get selected user
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            try
            {
                var user = await _userRepo.GetByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(user.ToUserDto());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the user. \n", error = ex.Message });
            }
        }

        // Get details of selected user with payment methods
        [HttpGet("payment/{id:int}")]
        public async Task<IActionResult> GetUserByIdWithPaymentMethods([FromRoute] int id)
        {
            try
            {
                var user = await _userRepo.GetByIdAsync(id);
                var paymentMethods = await _paymentMethodRepo.GetAllByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    var userPaymentMethods = paymentMethods.Select(pm => pm.ToPaymentMethodDto()).ToList();
                    return Ok(user.ToUserWithPaymentDto(userPaymentMethods));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the user. \n", error = ex.Message });
            }
        }

        // User Creation is done when registration. This function may be not useful.
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var userModel = userDto.ToUserFromUserCreateDto();
                await _userRepo.CreateAsync(userModel);
                return CreatedAtAction(nameof(GetUserById), new { id = userModel.UserId }, userModel.ToUserDto());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the user. \n", error = ex.Message });
            }
        }

        // Update user - the user is allowed to update his own account only.
        [HttpPut]
        // [Route("{id:int}")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var currUserId = await _userHelper.GetCurrentUserIdAsync(HttpContext);
                if (currUserId == null)
                {
                    return Unauthorized("User not found.");
                }
                if (currUserId.Value != userDto.UserId)
                {
                    return Unauthorized($"User does not match");
                }
                var userModel = await _userRepo.UpdateAsync(currUserId.Value, userDto);
                if (userModel == null)
                {
                    return NotFound();
                }
                return Ok(userModel.ToUserDto());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the user. \n", error = ex.Message });
            }
        }

        // Delete account - state will be changes. record will be not deleted permenently.
        [HttpDelete]
        // [Route("{id:int}")]
        public async Task<IActionResult> DeleteUser()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var currUserId = await _userHelper.GetCurrentUserIdAsync(HttpContext);
                if (currUserId == null)
                {
                    return Unauthorized("User not found.");
                }
                var userModel = await _userRepo.DeleteAsync(currUserId.Value);
                if (userModel == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the user. \n", error = ex.Message });
            }
        }
    }
}