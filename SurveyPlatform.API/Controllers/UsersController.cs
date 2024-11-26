﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyPlatform.API.DTOs.Requests;
using SurveyPlatform.BLL.Models;
using SurveyPlatform.BLL;
using SurveyPlatform.DTOs.Responses;

namespace SurveyPlatform.Controllers
{
    [Route("api/users")]
    [Authorize]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UsersController(UserService userService,IMapper Mapper)
        {
            _userService = userService;
            _mapper = Mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UserResponse>> Register([FromBody] RegisterUserRequest request)
        {
            var newUserData = _mapper.Map<RegisterUserRequest, UserRegisterModel>(request);
            var userResponse = await _userService.RegisterUserAsync(newUserData);
            if (userResponse != null) return Ok(userResponse);
            else return Conflict("Email already has in DB");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginUserRequest request)
        {
            var userModel = _mapper.Map<LoginUserRequest, UserLoginModel>(request);
            var loginResponse = await _userService.LoginUserAsync(userModel);
            if (loginResponse == string.Empty) return Unauthorized("Email Or Password Is Incorrect");
            return Ok(loginResponse);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponse>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();
            var allUsers = _mapper.Map<List<UserResponse>>(users);
            return Ok(allUsers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUserByID([FromRoute] Guid id)
        {
            var users = await _userService.GetUserByIdAsync(id);
            var userMapped = _mapper.Map<UserResponse>(users);
            return Ok(userMapped);
        }

        [HttpGet("{id}/responses")]
        public async Task<ActionResult<UserResponsesResponse>> GetUserResponses([FromRoute] Guid id)
        {
            var users = await _userService.GetUserResponsesByIdAsync(id);
            var userMapped = _mapper.Map<UserResponsesResponse>(users);
            return Ok(userMapped);
        }

        [HttpGet("{id}/polls")]
        public async Task<ActionResult<UserPollsResponse>> GetUserPolls([FromRoute] Guid id)
        {
            var users = await _userService.GetUserPollsByIdAsync(id);
            var userMapped = _mapper.Map<UserPollsResponse>(users);
            return Ok(userMapped);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserResponse>> UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserRequest request)
        {
            var userMapped = _mapper.Map<UpdateUserModel>(request);
            var updatedUser = await _userService.UpdateUserAsync(id,userMapped);
            var updatedUserMapped = _mapper.Map<UserResponse>(updatedUser);
            return Ok(updatedUserMapped);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> DeleteUser([FromRoute] Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }

        [HttpPatch("{id}/reactivate")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> ReActivateUser([FromRoute] Guid id)
        {
            await _userService.ChangeUserActivated(id);
            return Ok();
        }
    }
}
