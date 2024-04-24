using Microsoft.AspNetCore.Mvc;
using recipes_api.Services;
using recipes_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using System.Net.Http.Headers;

namespace recipes_api.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    public readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("{email}", Name = "GetUser")]
    public IActionResult Get(string email)
    {
        try
        {
            return Ok(_userRepository.GetUser(email));
        }
        catch (Exception ex)
        {
            return Unauthorized(new { ex.Message });
        }
    }

    [HttpPost("signup")]
    public IActionResult Create([FromBody] User user)
    {
        try
        {
            _userRepository.AddUser(user);
            return Created("", user);
        } catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPatch("{email}")]
    public IActionResult Update(string email, [FromBody] User user)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{email}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "User")]
    public IActionResult Delete(string email)
    {
        try
        {
            var token = HttpContext.User.Identity as ClaimsIdentity;
            var emailToken = token?.FindFirst(ClaimTypes.Email)?.Value;
            _userRepository.DeleteUser(email);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(new { ex.Message });
        }
    }
    [HttpPost("login")]
    public IActionResult Login([FromBody] User user)
    {
        try
        {   
            var userFound = _userRepository.GetUser(user.Email);
            var VerifyPassword = new HashPasswords().VerifyPassword(user.Password, userFound.Password);
            if (userFound == null || VerifyPassword == false)
            {
                return Unauthorized(new { message = "Email ou senha incorretos" });
            }

            var token = new TokenGenerator().Generate(userFound);
            return Ok(new { token });
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = "Erro ao autenticar: " + ex.Message });
        }
    }
}